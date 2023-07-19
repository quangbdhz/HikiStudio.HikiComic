//#region init tinyMCE
(function () {
    // make instance
    const mceElf = new tinymceElfinder({
        baseUrl: "/lib/elfinder/",
        url: "/file-manager-connector",
        nodeId: 'elfinder'
    });

    // TinyMCE init image cover comic
    tinymce.init({
        selector: "#comic-cover-image",
        setup: function (ed) {
            ed.on('change redo undo click keyup', function (e) {
                let content = tinyMCE.get(ed.id).getContent();
                if (content.indexOf(`img src="`) == -1) {
                    $("#comic-cover-image-error").css("display", "flex");
                }
                else {
                    $("#comic-cover-image-error").css("display", "none");
                }
                CheckEnableSaveChange();
            });
        },
        skin: "oxide-dark",
        content_css: "dark",
        height: 400,
        plugins: "image, link, media, imagetools",
        relative_urls: false,
        remove_script_host: false,
        toolbar: "undo redo | styleselect | link image media",
        file_picker_callback: mceElf.browser,
        images_upload_handler: mceElf.uploadHandler,
        imagetools_cors_hosts: ['hypweb.net'] // set CORS for this demo
    });

    // TinyMCE init summary comic
    tinymce.init({
        selector: "#summary",
        setup: function (ed) {
            ed.on('change redo undo click keyup', function (e) {
                let content = tinyMCE.get(ed.id).getContent();
                let lengthContent = content.length;
                if (lengthContent === 0 || content === null || content === undefined) {
                    $("#summary-error-required").css("display", "flex");
                    $("#summary-error-max-min-length").css("display", "none");
                }
                else if (lengthContent > 0 && lengthContent < 15) {
                    $("#summary-error-required").css("display", "none");
                    $("#summary-error-max-min-length").css("display", "flex");
                }
                else {
                    $("#summary-error-required").css("display", "none");
                    $("#summary-error-max-min-length").css("display", "none");
                }
                CheckEnableSaveChange();
            });
        },
        skin: "oxide-dark",
        content_css: "dark",
        height: 250,
        plugins: "link",
        relative_urls: false,
        remove_script_host: false,
        toolbar: "undo redo | styleselect | link",
        file_picker_callback: mceElf.browser
    });
})();
//endregion

//#region choices genre
const selectGenres = new Choices('#select-genre', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-genre .choices__input")
    .focusout(function () {
        const elementCreate = $(".set-genre-for-comic .choices__inner");
        if ((selectGenres.getValue().length === 0)) {
            $("#select-genre").parent().parent().next("#lable-error-select-genre").remove()
            $("#select-genre").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Genre(s).</div>");
            if (!elementCreate.hasClass("error-genre")) {
                elementCreate.addClass("error-genre")
                $("#submit-create-comic").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-genre");
            $("#lable-error-select-genre").remove();
        }
    })

$('#div-select-genre').change(function () {
    const elementCreate = $(".set-genre-for-comic .choices__inner");
    if ((selectGenres.getValue().length === 0)) {
        $("#select-genre").parent().parent().next("#lable-error-select-genre").remove()
        $("#select-genre").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Genre(s).</div>");
        if (!elementCreate.hasClass("error-genre")) {
            elementCreate.addClass("error-genre")
            $("#submit-create-comic").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-genre");
        $("#lable-error-select-genre").remove();
    }
})
//#endregion

//#region handle choices genre
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-genre').on('change', function () {
    let listChoices = selectGenres.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectGenres.config.choices[p].value;
        let label = selectGenres.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-genre option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion


//#region choices artist
const selectArtisrs = new Choices('#select-artist', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-artist .choices__input")
    .focusout(function () {
        const elementCreate = $(".create-artist .choices__inner");
        if ((selectArtisrs.getValue().length === 0)) {
            $("#select-artist").parent().parent().next("#lable-error-select-artist").remove()
            $("#select-artist").parent().parent().after("<div id='lable-error-select-artist' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Artist(s).</div>");
            if (!elementCreate.hasClass("error-artist")) {
                elementCreate.addClass("error-artist")
                $("#submit-create-comic").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-artist");
            $("#lable-error-select-artist").remove();
        }
    })

$('#div-select-artist').change(function () {
    const elementCreate = $(".create-artist .choices__inner");
    if ((selectArtisrs.getValue().length === 0)) {
        $("#select-artist").parent().parent().next("#lable-error-select-artist").remove()
        $("#select-artist").parent().parent().after("<div id='lable-error-select-artist' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Artist(s).</div>");
        if (!elementCreate.hasClass("error-artist")) {
            elementCreate.addClass("error-artist")
            $("#submit-create-comic").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-artist");
        $("#lable-error-select-artist").remove();
    }
})
//#endregion

//#region handle choices artist
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-artist').on('change', function () {
    let listChoices = selectArtisrs.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectArtisrs.config.choices[p].value;
        let label = selectArtisrs.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-artist option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion

//#region choices author
const selectAuthors = new Choices('#select-author', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-author .choices__input")
    .focusout(function () {
        const elementCreate = $(".create-author .choices__inner");
        if ((selectAuthors.getValue().length === 0)) {
            $("#select-author").parent().parent().next("#lable-error-select-author").remove()
            $("#select-author").parent().parent().after("<div id='lable-error-select-author' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Author(s).</div>");
            if (!elementCreate.hasClass("error-author")) {
                elementCreate.addClass("error-author")
                $("#submit-create-comic").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-author");
            $("#lable-error-select-author").remove();
        }
    })

$('#div-select-author').change(function () {
    const elementCreate = $(".create-author .choices__inner");
    if ((selectAuthors.getValue().length === 0)) {
        $("#select-author").parent().parent().next("#lable-error-select-author").remove()
        $("#select-author").parent().parent().after("<div id='lable-error-select-author' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Author(s).</div>");
        if (!elementCreate.hasClass("error-author")) {
            elementCreate.addClass("error-author")
            $("#submit-create-comic").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-author");
        $("#lable-error-select-author").remove();
    }
})
//#endregion

//#region handle choices author
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-author').on('change', function () {
    let listChoices = selectAuthors.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectAuthors.config.choices[p].value;
        let label = selectAuthors.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-author option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion

//#region validation create comic
function CheckEnableSaveChange() {
    let comicCoverImage = tinymce.get("comic-cover-image").getContent();
    let summary = tinymce.get("summary").getContent();

    if ($('#form-create').validate().checkForm() && selectGenres.getValue().length != 0 && selectArtisrs.getValue().length != 0 && selectAuthors.getValue().length != 0 && comicCoverImage.indexOf(`img src="`) !== -1 && summary.length >= 15) {
        $("#submit-create-comic").removeAttr("disabled");
    }
    else {
        $("#submit-create-comic").attr("disabled", "disabled");
    }
    return true;
}

$(document).ready(function () {
    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    $('input').on('blur keyup', function () {
        CheckEnableSaveChange();
    })

    var formValidateCreate = $("#form-create").validate({
        errorClass: "is-invalid",
        validClass: "",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
        },
        onfocusout: function (element) { $(element).valid(); },
        onclick: function (element) { $(element).valid(); },
        rules: {
            "comic-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 100,
            },
            "alternative": {
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 100,
            },
            "comic-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "comic-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "comic-name": {
                required: "Please enter Name Comic.",
                notFullSpaceName: "Please enter Name Comic.",
                minlength: "Name Comic must be from 2 to 100 characters.",
                maxlength: "Name Comic must be from 2 to 100 characters.",
            },
            "alternative": {
                notFullSpaceName: "Please enter Different Name Comic.",
                minlength: "Different Name Comic must be from 2 to 100 characters.",
                maxlength: "Different Name Comic must be from 2 to 100 characters.",
            },
            "comic-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "comic-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let artistIds = [];
            let artistNames = [];
            $('#select-artist option:selected').each(function (i, selectedelement) {
                artistIds[i] = $(selectedelement).val() * 1;
                artistNames[i] = $(selectedelement).text();
            })

            let authorIds = [];
            let authorNames = [];
            $('#select-author option:selected').each(function (i, selectedelement) {
                authorIds[i] = $(selectedelement).val() * 1;
                authorNames[i] = $(selectedelement).text();
            })

            let genreIds = [];
            let genreNames = [];
            $('#select-genre option:selected').each(function (i, selectedelement) {
                genreIds[i] = $(selectedelement).val() * 1;
                genreNames[i] = $(selectedelement).text();
            })

            let comicCoverImage = tinymce.get("comic-cover-image").getContent();
            let comicCoverImageURL = comicCoverImage.slice(comicCoverImage.indexOf("src")).split('"')[1];

            let summary = tinymce.get("summary").getContent();
            

            let comicName = $(form).find('input[name="comic-name"]').val();
            let alternative = $(form).find('input[name="alternative"]').val();
            let comicSEOSummary = $(form).find('input[name="comic-seo-summary"]').val();
            let comicSEOTitle = $(form).find('input[name="comic-seo-title"]').val();

            let createComicRequest = {
                comicName: comicName,
                alternative: alternative,
                comicSEOSummary: comicSEOSummary,
                comicSEOTitle: comicSEOTitle,
                summary: summary,
                comicCoverImageURL: comicCoverImageURL,
                artists: artistIds,
                authors: authorIds,
                genres: genreIds,
            };

            $.ajax({
                method: "POST",
                url: `/comics/create-comic`,
                data: JSON.stringify(createComicRequest),
                headers: {
                    "Content-Type": "application/json;",
                },
                processData: false,
                contentType: false,
                datatype: 'json',
                beforeSend: function () {
                    showLoadingOverlay();
                },
                complete: function () {
                    hideLoadingOverlay();
                }
            })
                .done(function (response) {
                    if (response.isSuccessed === true) {
                        localStorage.setItem('message-comic-create', response.message);

                        window.location = "/comics";
                        return;
                    }
                    else {
                        ShowToastError(response.message);
                    }

                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    ShowToastError(jqXHR.responseJSON.message);
                });
        }
    });
});
//#endregion