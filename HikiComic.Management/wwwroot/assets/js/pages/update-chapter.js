//#region get information chapter comic
var currentChapterId = -1;
var currentComicSEOAlias = "";
var currentChapterSEOAlias = "";
$.ajax({
    async: false,
    method: "GET",
    url: `/comic/information-chapter`,
})
    .done(function (response) {
        if (response.isSuccessed === true) {
            currentChapterId = response.resultObj.comicId;
            currentComicSEOAlias = response.resultObj.comicSEOAlias;
            currentChapterSEOAlias = response.resultObj.chapterSEOAlias;
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


if (currentComicSEOAlias !== "" && currentChapterSEOAlias !== "") {
    //#region validation create comic strip
    function CheckEnableSaveChange() {
        let imageChapter = $('#chapter-image').summernote('code');

        if ($('#form-edit').validate().checkForm() && imageChapter.indexOf(`img src="`) !== -1) {
            $("#chapter-image-error").css("display", "none");
            $("#submit-edit-chapter").removeAttr("disabled");
        }
        else {
            if (imageChapter.indexOf(`img src="`) === -1) {
                $("#chapter-image-error").css("display", "flex");
            }
            else {
                $("#chapter-image-error").css("display", "none");
            }

            $("#submit-edit-chapter").attr("disabled", "disabled");
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

        var formValidateCreate = $("#form-edit").validate({
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

                let updateChapterComicAndChapterImageURLRequest = {
                    chapterName: chapterName,
                    stringChapterImageURLs: stringChapterImageURLs,
                    chapterImageURLs: []
                };


                $.ajax({
                    method: "POST",
                    url: `/comic/${currentComicSEOAlias}/${currentChapterSEOAlias}/update-chapter`,
                    data: JSON.stringify(updateChapterComicAndChapterImageURLRequest),
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
                            localStorage.setItem('message-chapter-update', response.message);

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