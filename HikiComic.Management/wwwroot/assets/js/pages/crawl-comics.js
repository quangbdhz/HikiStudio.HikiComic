const urlDefault = ["https://kunmanga.com/manga/page/2/?m_orderby=new-manga", "https://mangabtt.com/find-story?status=-1&sort=15&page=1", "https://manhwaclan.com/manga/page/2/?m_orderby=new-manga"];

function truncateString(inputString) {
    if (inputString.length > 25) {
        return inputString.substring(0, 25);
    }
    return inputString;
}

function changeButtonText(option) {
    var button = document.getElementById("dropdownMenuButton2");
    button.innerHTML = option.innerHTML;

    let urlDefaultId = 0;
    if (option.innerHTML === "kunmanga.com") {
        urlDefaultId = 0;
    }
    else if (option.innerHTML === "mangabtt.com") {
        urlDefaultId = 1;
    }
    else if (option.innerHTML === "manhwaclan.com") {
        urlDefaultId = 2;
    }

    $("#url-page-crawl-comics").val(urlDefault[urlDefaultId]);
}

const generateUUID = () => {
    var d = new Date().getTime();
    var d2 = (typeof performance !== "undefined" && performance.now && performance.now() * 1000) || 0;

    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
        var r = Math.random() * 16;
        if (d > 0) {
            r = (d + r) % 16 | 0;
            d = Math.floor(d / 16);
        } else {
            r = (d2 + r) % 16 | 0;
            d2 = Math.floor(d2 / 16);
        }
        return (c === "x" ? r : (r & 0x3) | 0x8).toString(16);
    });
};

function FormatDate(date) {
    var d = new Date(date),
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;

    return [day, month, year].join("/");
}


$(document).ready(function () {

    //#region  get authors, artist, genre
    function GetDataFieldComicDetails(dom, className) {
        let domFields = dom.querySelectorAll(`.${className} a`);
        let valueFields = [];

        domFields.forEach((item) => {
            valueFields.push(item.textContent.trim())
        });

        if (valueFields.length !== 0) {
            return valueFields;
        }
        return ["Updating"]
    }
    //#endregion

    var getComics = []; 
    var crawlComics = [];

    function SaveChapters(chapter, comicDetailIdInDB) {
        $.ajax({
            method: "POST",
            url: `/crawl-comics/create-chapter-by-crawling/${comicDetailIdInDB}`,
            data: JSON.stringify(chapter),
            headers: {
                "Content-Type": "application/json;",
            },
            processData: false,
            contentType: false,
            datatype: 'json',
        })
            .done(function (response) {})
            .fail(function (jqXHR, textStatus, errorThrown) { })
            .always(function () {});
    }

    function GetChapterImageURL(chapter, comic, comicDetailIdInDB, option) {
        let generateChapterUUID = generateUUID();

        $("#crawlChaptersDatatable").append(
            `<tr>
                <td style="white-space: normal;"><p style="width: 100%; word-wrap: break-word;">${comic.comicName}</p></td>
                <td>${chapter.chapterName}</td>
                <td style="width: 12%;text-align: center;">
                    <span id="chapter-${generateChapterUUID}" style="justify-content: center;display: inline-block;" class="loader"></span>
                    <span id="chapter-${generateChapterUUID}-success" style="display:none; justify-content: center;" class="badge bg-light-success">Success</span>
                </td>
            </tr>`
        );

        $.ajax({
            method: "GET",
            url: `${chapter.urlChapter}`,
        })
            .done(function (response) {
                let parser = new DOMParser();
                let doc = parser.parseFromString(response, "text/html");

                let chapterDetails = [];
                let chapterImageURLs = [];


                //kunmanga.com
                if (option === 1) {
                    chapterDetails = Array.from(doc.querySelectorAll(".page-break > img"));

                    chapterDetails.forEach((item, index) => {
                        chapterImageURLs.push(item.getAttribute("src").trim());
                    });
                }

                //mangabtt.com
                if (option === 2) {
                    chapterDetails = Array.from(doc.querySelectorAll('.reading-detail img[data-index]'));


                    chapterDetails.forEach((item, index) => {
                        chapterImageURLs.push(item.getAttribute("src").trim());
                    });
                }


                let chapterImageURLEncodes = [];
                let countURL = 0;
                let temp = "|";

                chapterImageURLs.forEach(function (url, index) {
                    countURL++;
                    temp += url + "|"

                    if (countURL > 30) {
                        chapterImageURLEncodes.push(temp);
                        temp = "|";
                        countURL = 0;
                    }
                });

                if (temp !== "|") {
                    chapterImageURLEncodes.push(temp);
                }

                let createChapterRequest = {
                    chapterName: chapter.chapterName,
                    stringChapterImageURLs: "",
                    serialChapterOfComic: chapter.serialChapter,
                    dateCreated: chapter.dateCreated.replaceAll("/", "-").split("-").reverse().join("-"),
                    chapterImageURLs: chapterImageURLEncodes
                };

                SaveChapters(createChapterRequest, comicDetailIdInDB);
            })
            .fail(function (jqXHR, textStatus, errorThrown) { })
            .always(function () {
                //$(`#${comic.generateComicUUID}`).hide();
                //$(`#success-${comic.generateComicUUID}`).css({ "display": "flex" });

                $(`#chapter-${generateChapterUUID}`).hide();
                $(`#chapter-${generateChapterUUID}-success`).css({ "display": "flex" });
            });
    }

    async function GetComicDetails(comic, option) {
        $.ajax({
            method: "GET",
            url: `${comic.urlComicDetail}`,
        })
            .done(function (response) {
                let parser = new DOMParser();

                let doc = parser.parseFromString(response, "text/html");

                //kunmanga.com
                if (option === 1) {
                    let comicDetails = Array.from(doc.querySelectorAll(".post-content_item"));

                    let alternative = "";
                    let authorNames = ["Updating"];
                    let artistNames = ["Updating"];
                    let genreNames = ["Updating"];

                    comicDetails.forEach((item) => {
                        let option = item?.querySelector("h5")?.textContent?.trim();

                        if (option === "Alternative") {
                            alternative = item.querySelector(".summary-content").textContent.trim();
                        }
                        else if (option === "Author(s)") {
                            authorNames = GetDataFieldComicDetails(item, "author-content");
                        }
                        else if (option === "Genre(s)") {
                            genreNames = GetDataFieldComicDetails(item, "genres-content");
                        }
                        else if (option === "Artist(s)") {
                            artistNames = GetDataFieldComicDetails(item, "artist-content");
                        }
                        else {

                        }
                    });

                    let domSummary = doc.querySelector(".summary__content");

                    let summary = "";
                    if (domSummary !== null && domSummary !== undefined) {
                        summary = domSummary.querySelector(":nth-child(2)");

                        if (summary === null || summary === undefined) {
                            summary = domSummary.querySelector(":nth-child(1)");
                        }
                    }

                    summary = summary !== null ? summary.textContent.trim() : "";

                    let currentComic = { ...comic, alternative, authorNames, artistNames, genreNames, summary };

                    let createComicByCrawlingRequest =
                    {
                        comicName: currentComic.comicName,
                        alternative: alternative,
                        comicCoverImageURL: currentComic.comicCoverImageURL,
                        comicDetailCoverImageURL: currentComic.comicCoverImageURL,
                        summary: summary,
                        artists: artistNames,
                        authors: authorNames,
                        genres: genreNames,
                    }

                    $.ajax({
                        method: "POST",
                        url: "/crawl-comics/create-comic-by-crawling",
                        data: JSON.stringify(createComicByCrawlingRequest),
                        headers: {
                            "Content-Type": "application/json;",
                        },
                        processData: false,
                        contentType: false,
                        datatype: 'json',
                    })
                        .done(function (response) {
                            //get chapter for comic strip details
                            let chapters = [];
                            let domChapters = Array.from(doc.querySelectorAll(".wp-manga-chapter"));
                            let domInfoChapter = "";

                            let chapterName = "";
                            let urlChapter = "";
                            let dateCreatedOriginal = "";
                            let dateCreated = "";
                            let chapter = {};

                            domChapters = domChapters.reverse();

                            domChapters.forEach((element, index) => {
                                domInfoChapter = element.querySelector("a");

                                chapterName = domInfoChapter.textContent.trim();
                                urlChapter = domInfoChapter.getAttribute("href").trim();

                                dateCreatedOriginal = element.querySelector("span i");

                                if (dateCreatedOriginal === null || dateCreatedOriginal === undefined) {
                                    dateCreated = FormatDate(new Date().toDateString());
                                } else {
                                    dateCreated = FormatDate(dateCreatedOriginal.textContent.trim());
                                }

                                chapter = { chapterName, serialChapter: index, urlChapter, dateCreated };

                                GetChapterImageURL(chapter, currentComic, response.resultObj, 1);

                                chapters.push(chapter);
                            });

                        })
                        .fail(function (jqXHR, textStatus, errorThrown) { })
                        .always(function () {
                            let data = $(`#${comic.generateComicUUID}`).parent().parent();

                            const tr = crawlComicsDatatable.row(data.closest('tr'));
                            tr.remove().draw();
                        });
                }

                //mangabtt.com
                if (option === 2) {
                    let comicDetailsDoc = doc.querySelector("article#item-detail");
                    const storyID = comicDetailsDoc.querySelector('#storyID').value;

                    //#region get comic details -> server web root
                    let alternative = "";
                    let authorNames = ["Updating"];
                    let artistNames = ["Updating"];
                    let genreNames = ["Updating"];

                    let genresDoc = Array.from(comicDetailsDoc.querySelectorAll(".tr-theloai"));

                    if (genresDoc.length > 0) {
                        genreNames = [];

                        genresDoc.forEach((item) => {
                            genreNames.push(item.textContent.trim());
                        })
                    }

                    let domSummary = doc.querySelector("p#summary");

                    let summary = domSummary !== null ? domSummary.textContent.trim() : "";

                    let currentComic = { ...comic, alternative, authorNames, artistNames, genreNames, summary };

                    let createComicByCrawlingRequest =
                    {
                        comicName: currentComic.comicName,
                        alternative: alternative,
                        comicCoverImageURL: currentComic.comicCoverImageURL,
                        comicDetailCoverImageURL: currentComic.comicCoverImageURL,
                        summary: summary,
                        artists: artistNames,
                        authors: authorNames,
                        genres: genreNames,
                    }
                    //#endregion

                    //#region add comics in Database
                    $.ajax({
                        method: "POST",
                        url: "/crawl-comics/create-comic-by-crawling",
                        data: JSON.stringify(createComicByCrawlingRequest),
                        headers: {
                            "Content-Type": "application/json;",
                        },
                        processData: false,
                        contentType: false,
                        datatype: 'json',
                    })
                        .done(function (response) {
                            let comicDetailId = response.resultObj;

                            //#region get chapters -> server web root
                            var fd = new FormData();
                            fd.append('StoryID', storyID);

                            $.ajax({
                                method: "POST",
                                url: `https://mangabtt.com/Story/ListChapterByStoryID/`,
                                data: fd,
                                processData: false,
                                contentType: false,
                            })
                                .done(function (response) {
                                    let chapters = [];
                                    let docChapters = parser.parseFromString(response, "text/html");

                                    let domChapters = Array.from(docChapters.querySelectorAll("div.col-xs-5.chapter"));

                                    let common = "";
                                    let chapterName = "";
                                    let urlChapter = "";
                                    let dateCreated = "";
                                    let chapter = {};

                                    domChapters = domChapters.reverse();

                                    domChapters.forEach((element, index) => {
                                        common = element.querySelector("a");
                                        chapterName = common.textContent.trim();
                                        urlChapter = common.getAttribute('href');
                                        dateCreated = FormatDate(new Date().toDateString());

                                        chapter = { chapterName, serialChapter: index, urlChapter, dateCreated };

                                        GetChapterImageURL(chapter, currentComic, comicDetailId, 2);

                                        chapters.push(chapter);
                                    });

                                })
                                .fail(function (jqXHR, textStatus, errorThrown) { });

                            //#endregion
                        })
                        .fail(function (jqXHR, textStatus, errorThrown) { })
                        .always(function () {
                            let data = $(`#${comic.generateComicUUID}`).parent().parent();

                            const tr = crawlComicsDatatable.row(data.closest('tr'));
                            tr.remove().draw();
                        });
                    //#endregion
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) { });
    }

    function GetComics(urlPagingComic, option) {
        $.ajax({
            method: "GET",
            url: `${urlPagingComic}`,
        })
            .done(function (response) {
                let parser = new DOMParser();

                let doc = parser.parseFromString(response, "text/html");

                let urlComicDetail = "";
                let comicName = "";
                let comicCoverImageURL = "";

                //kunmanga.com
                if (option === 1) {
                    let domComics = Array.from(doc.querySelectorAll(".c-image-hover"));

                    domComics.forEach((item, index) => {
                        urlComicDetail = item.querySelector("a").getAttribute("href");
                        comicName = item.querySelector("a").getAttribute("title");
                        comicCoverImageURL = item.querySelector("img").getAttribute("src").replace("-175x238", "-350x476");

                        let generateComicUUID = generateUUID();
                        getComics.push({ generateComicUUID: generateComicUUID, comicName, urlComicDetail, comicCoverImageURL });

                        crawlComicsDatatable.row.add({ generateComicUUID: generateComicUUID, comicName, urlComicDetail, comicCoverImageURL }).draw();
                    });
                }

                //mangabtt.com
                if (option === 2) {
                    let domComics = Array.from(doc.querySelectorAll('figure.clearfix'));

                    domComics.forEach((item, index) => {
                        urlComicDetail = item.querySelector("a").getAttribute("href");
                        comicName = item.querySelector("a").getAttribute("title");
                        comicCoverImageURL = item.querySelector("img").getAttribute("src");


                        let generateComicUUID = generateUUID();
                        getComics.push({ generateComicUUID: generateComicUUID, comicName, urlComicDetail, comicCoverImageURL });
                        crawlComicsDatatable.row.add({ generateComicUUID: generateComicUUID, comicName, urlComicDetail, comicCoverImageURL }).draw();
                    });
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) { });
    }

    //#region init crawlComicDatatable and checkbox
    var crawlComicsDatatable = $("#crawlComicsDatatable").DataTable({
        "lengthChange": false,
        "filter": true,
        "responsive": true,
        "pagingType": 'full_numbers',
        "columnDefs": [{
            "orderable": false,
            "className": 'select-checkbox',
            "targets": 0,
        },
        {
            "orderable": false, "targets": 1
        },
        {
            "orderable": false, "targets": 3
        },
        {
            "orderable": false, "targets": 4
        },
        {
            className: "text-start",
            targets: [2]
        }],
        "select": {
            style: 'multi',
            selector: 'td:first-child'
        },
        "order": [],
        "columns": [
            {
                "render": function (row, type, data) {
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.generateComicUUID}' /> `;
                },
            },
            {
                "data": "coverImage", "name": "CoverImage", "sWidth": 110,
                "render": function (row, type, data) {
                    return `<img referrerPolicy="no-referrer" src="${data.comicCoverImageURL}" onerror="this.onerror=null; this.src='${data.comicCoverImageURL.replace('-350x476', "")}'" style="width: 100px;" alt="${truncateString(data.comicName)}">`
                }
            },
            {
                "render": function (row, type, data) {
                    return `<p style="width: 100%; word-wrap: break-word;">${data.comicName}</p>`;
                },
            },
            {
                "data": "urlComicDetail", "name": "UrlComicDetail", "sWidth": 110,
                "render": function (row, type, data) {
                    return ` <div><a href="${data.urlComicDetail}">Details</a></div>`
                }
            },
            {
                "sWidth": 110,
                "render": function (row, type, data) {
                    return `<span id="waiting-${data.generateComicUUID}" class="badge bg-light-warning">Waiting</span>
                            <span id="${data.generateComicUUID}" style="justify-content: center; display:none;" class="loader"></span>
                            <span id="success-${data.generateComicUUID}" style="display:none; justify-content: center;" class="badge bg-light-success">Success</span>`;
                },
            },
        ],
        createdRow: function (row, data, dataIndex) {
            $('td', row).eq(2).css('white-space', 'normal');
        }
    });

    crawlComicsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
        let row = dt.row(cell.index().row);
        if (row.data().isActive === false) {
            e.preventDefault();
        }
    });

    $('#crawlComicsDatatable').on('page.dt', function () {
        $("#checkbox-all").prop('checked', false);
    });

    $('tbody').on('click', 'td', function () {
        var countRow = crawlComicsDatatable.data().count();
        var count = $('#crawlComicsDatatable tbody').find("input[type='checkbox']:checked").length;

        if ($(this).hasClass("select-checkbox")) {
            if ($(this).parent().hasClass("selected")) {
                //uncheck
                $(this).find("input[type='checkbox']").prop('checked', false);
                count--;
                if (count === 0) {
                    $("#save-comics").prop('disabled', true);
                }
            } else {
                //check
                let fieldCheckBox = $(this).find("input[type='checkbox']");
                if (fieldCheckBox.prop('disabled') !== true) {
                    fieldCheckBox.prop('checked', true);
                    count++;

                    if (count !== 0)
                        $("#save-comics").prop('disabled', false);
                }
            }
        }

        if (count > 0) {
            $("#btn-deletecheckall").removeAttr('disabled');
        } else {
            $("#btn-deletecheckall").attr('disabled', 'true');
        }

        if (count - 1 == countRow) {
            $("#checkbox-all").prop('checked', true);
        }
        else {
            $("#checkbox-all").prop('checked', false);
        }
    });

    $("#checkbox-all").click(function () {
        var data_list = $('#crawlComicsDatatable input[type="checkbox"].ms');

        $("#checkbox-all").change(function () {
            if (this.checked) {
                data_list.each(function () {
                    if (!this.disabled) {
                        $(this).prop('checked', true);
                    }
                });
                crawlComicsDatatable.rows(`:has(td:eq(3):contains("Details"))`).select();
                $("input#checkbox-all").addClass("selected");

                $("#save-comics").prop('disabled', false);
            }
            else {
                data_list.each(function () {
                    if (!this.disabled) {
                        $(this).prop('checked', false);
                    }
                });
                crawlComicsDatatable.rows().deselect();
                $("input#checkbox-all").removeClass("selected");

                $("#save-comics").prop('disabled', true);
            }
        });
    })
    //#endregion

    $("#submit-crawl-comic-strips").click(function (e) {
        e.preventDefault();

        $("#checkbox-all").prop("checked", false);
        $("#save-comics").prop('disabled', true);

        getComics = [];

        let url = $("#url-page-crawl-comics").val();

        if (url.indexOf("https://kunmanga.com/manga/page") === -1 && url.indexOf("https://mangabtt.com/") === -1 && url.indexOf("https://manhwaclan.com/manga/page")) {
            ShowToastError("URL Fail");
        }
        else {
            crawlComicsDatatable.clear().draw();
            $("#crawlChaptersDatatable tbody").empty();

            let webRoot = $("#dropdownMenuButton2").text().trim();

            if (webRoot === "kunmanga.com" || webRoot === "manhwaclan.com") {
                if (url.indexOf("https://kunmanga.com/manga/page") === -1 && url.indexOf("https://manhwaclan.com/manga/page") === -1) {
                    ShowToastError("URL Fail");
                }
                else {
                    GetComics(url, 1);
                }
            }

            if (webRoot === "mangabtt.com") {
                if (url.indexOf("https://mangabtt.com/") === -1) {
                    ShowToastError("URL Fail");
                }
                else {
                    GetComics(url, 2);
                }
            }
        }
    });

    $("#save-comics").click(function (e) {
        e.preventDefault();

        let crawlGenerateComicUUIDs = [];
        crawlComics = [];

        $('input[type="checkbox"]').each(function () {
            if ($(this).is(':checked')) {
                crawlGenerateComicUUIDs.push($(this).data("id"))
            }
        });

        crawlGenerateComicUUIDs.forEach((item) => {
            getComics.forEach((comic) => {
                if (comic.generateComicUUID === item) {
                    crawlComics.push(comic);
                }
            })
        })

        $("#checkbox-all").prop('checked', false);
        var data_list = $('#crawlComicsDatatable input[type="checkbox"].ms');
        data_list.each(function () {
            if (!this.disabled) {
                $(this).prop('checked', false);
            }
        });
        crawlComicsDatatable.rows().deselect();
        $("input#checkbox-all").removeClass("selected");

        $("#save-comics").prop('disabled', true);

        crawlComics.forEach(function (item) {
            $(`#${item.generateComicUUID}`).show();
            $(`#waiting-${item.generateComicUUID}`).css({ "display": "none" });

            let webRoot = $("#dropdownMenuButton2").text().trim();
            let url = $("#url-page-crawl-comics").val();

            if (webRoot === "kunmanga.com") {
                if (url.indexOf("https://kunmanga.com/manga/page") === -1) {
                    ShowToastError("URL Fail");
                }
                else {
                    GetComicDetails(item, 1);
                }
            }

            if (webRoot === "mangabtt.com") {
                if (url.indexOf("https://mangabtt.com/") === -1) {
                    ShowToastError("URL Fail");
                }
                else {
                    GetComicDetails(item, 2);
                }
            }
        })
    });
});