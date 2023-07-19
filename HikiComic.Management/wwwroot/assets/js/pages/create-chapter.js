//#region init tinyMCE
//(function () {
//    // make instance
//    const mceElf = new tinymceElfinder({
//        baseUrl: "/lib/elfinder/",
//        url: "/file-manager-connector",
//        nodeId: 'elfinder'
//    });

//     //TinyMCE init image cover comic
//    tinymce.init({
//        selector: "#chapter-image",
//        setup: function (ed) {
//            ed.on('change redo undo click keyup', function (e) {
//                let content = tinyMCE.get(ed.id).getContent();
//                if (content.indexOf(`img src="`) == -1) {
//                    $("#chapter-image-error").css("display", "flex");
//                }
//                else {
//                    $("#chapter-image-error").css("display", "none");
//                }
//                CheckEnableSaveChange();
//            });
//        },
//        skin: "oxide-dark",
//        content_css: "dark",
//        height: 400,
//        plugins: "image, link, media, imagetools",
//        relative_urls: false,
//        remove_script_host: false,
//        toolbar: "undo redo | styleselect | link image media",
//        file_picker_callback: mceElf.browser,
//        images_upload_handler: mceElf.uploadHandler,
//        imagetools_cors_hosts: ['hypweb.net'] // set CORS for this demo
//    });
//})();
//endregion


//#region get information comic strip
var currentComicId = -1;
var currentComicSEOAlias = "";
$.ajax({
    async: false,
    method: "GET",
    url: `/comic/comic-information`,
})
    .done(function (response) {
        if (response.isSuccessed === true) {
            currentComicId = response.resultObj.comicId;
            currentComicSEOAlias = response.resultObj.comicSEOAlias;
            return;
        }
        else {
            ShowToastError(response.message);
        }
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        ShowToastError(jqXHR.responseJSON.message);
    });

//#endregion

if (currentComicSEOAlias !== "") {  
    //#region validation create comic strip
    function CheckEnableSaveChange() {
        let imageChapter = $('#chapter-image').summernote('code');

        if ($('#form-create').validate().checkForm() && imageChapter.indexOf(`img src="`) !== -1) {
            $("#chapter-image-error").css("display", "none");
            $("#submit-create-chapter").removeAttr("disabled");
        }
        else {
            if (imageChapter.indexOf(`img src="`) === -1) {
                $("#chapter-image-error").css("display", "flex");
            }
            else {
                $("#chapter-image-error").css("display", "none");
            }

            $("#submit-create-chapter").attr("disabled", "disabled");
        }
        return true;
    }

    $(document).ready(function () {
        $.validator.addMethod("notFullSpaceName", function (value, element, param) {
            let matchValue = value.trim();
            return this.optional(element) || matchValue.length !== 0;
        }, "Please enter Name.");

        $.validator.addMethod("formatChapterName", function (value, element, param) {
            let matchValue = value.indexOf("Chapter ");
            return this.optional(element) || matchValue === 0;
        }, "Invalid Chapter Name. (e.x: Chapter 01).");

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
                "chapter-name": {
                    required: true,
                    notFullSpaceName: true,
                    minlength: 8,
                    maxlength: 100,
                    formatChapterName: true,
                },
            },
            messages: {
                "chapter-name": {
                    required: "Please enter Chapter Name.",
                    notFullSpaceName: "Please enter Chapter Name.",
                    minlength: "Chapter Name must be from 8 to 100 characters.",
                    maxlength: "Chapter Name must be from 8 to 100 characters.",
                    formatChapterName: "Invalid Chapter Name. (e.x: Chapter 01).",
                },
            },
            submitHandler: function (form, event) {
                event.preventDefault();

                var stringChapterImageURLs = $('#chapter-image').summernote('code');
                let chapterName = $(form).find('input[name="chapter-name"]').val();

                let createChapterAndChapterImageURLRequest = {
                    chapterName: chapterName,
                    stringChapterImageURLs: stringChapterImageURLs,
                    chapterImageURLs: []
                };

                $.ajax({
                    method: "POST",
                    url: `/comic/${currentComicSEOAlias}/create-chapter`,
                    data: JSON.stringify(createChapterAndChapterImageURLRequest),
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
                            localStorage.setItem('message-chapter-create', response.message);

                            window.location = `/comic/${currentComicSEOAlias}`;
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
}

