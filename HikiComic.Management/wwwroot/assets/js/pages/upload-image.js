// upload image and validation
$(document).ready(function () {
    var initImage = "";

    const toast = new bootstrap.Toast(document.getElementById('myToast'))
    const ERROR = "ERROR",
        SUCCESS = "SUCCESS",
        WARNING = "WARNING";

    //Show toast
    function showToast(message, type) {

        const className = $("#myToast .alert")
        const icon = $("#myToast .alert i")
        className.removeClass();
        icon.removeClass();
        const content = $("#myToast #toast-content")
        content.text(message)
        switch (type) {
            case ERROR: {
                className.addClass("alert mb-0 alert-danger");
                icon.addClass("bi bi-file-excel")
                break;
            }
            case SUCCESS: {
                className.addClass("alert mb-0 alert-success");
                icon.addClass("bi bi-check-circle")
                break;
            }
            case WARNING: {
                className.addClass("alert mb-0 alert-warning");
                icon.addClass("bi bi-exclamation-triangle")
                break;
            }
            default: {
                className.addClass("alert mb-0 alert-success");
                icon.addClass("bi bi-check-circle")
                break;
            }
        }
        toast.show();
    }

    var _URL = window.URL || window.webkitURL;

    function ShowToastSuccess(message) {
        showToast(message, SUCCESS);
    }

    function ShowToastError(message) {
        showToast(message, ERROR);
    }

    $("#file-upload-form").submit(function (e) {
        e.preventDefault();

    })

    function ekUpload() {
        function Init() {
            var fileSelect = document.getElementById('file-upload'),
                fileDrag = document.getElementById('file-drag'),
                submitButton = document.getElementById('submit-button');

            fileSelect.addEventListener('change', fileSelectHandler, false);

            // Is XHR2 available?
            var xhr = new XMLHttpRequest();
            if (xhr.upload) {
                // File Drop
                fileDrag.addEventListener('dragover', fileDragHover, false);
                fileDrag.addEventListener('dragleave', fileDragHover, false);
                fileDrag.addEventListener('drop', fileSelectHandler, false);
            }
        }

        function fileDragHover(e) {
            var fileDrag = document.getElementById('file-drag');

            e.stopPropagation();
            e.preventDefault();

            fileDrag.className = (e.type === 'dragover' ? 'hover' : 'modal-body file-upload');
        }

        function fileSelectHandler(e) {
            // Fetch FileList object
            var files = e.target.files || e.dataTransfer.files;

            // Cancel event and hover styling
            fileDragHover(e);

            // Process all File objects
            for (var i = 0, f; f = files[i]; i++) {
                parseFile(f);
                uploadFile(f);
            }
        }

        // Output
        function output(msg) {
            // Response
            var m = document.getElementById('messages');
            m.innerHTML = msg;
        }

        function checkMaximumImageSize(file) {
            let size = file.size / 1048576;
            if (size > 10)
                return false;
            return true;
        }

        function parseFile(file) {
            output(
                '<strong>' + encodeURI(file.name) + '</strong>'
            );

            var imageName = file.name;
            var isMaxSize = checkMaximumImageSize(file);
            var isGood = (/\.(?=bmp|jpg|png|jpeg)/gi).test(imageName);

            if (isGood && isMaxSize) {
                document.getElementById('start').classList.add("hidden");
                document.getElementById('response').classList.remove("hidden");
                document.getElementById('notimage').classList.add("hidden");

                // Thumbnail Preview
                document.getElementById('file-image').classList.remove("hidden");
                document.getElementById('file-image').src = URL.createObjectURL(file);

                if (initImage !== $("#messages strong").text()) {
                    $("#submit-change-avatar").removeAttr("disabled");
                }
            }
            else {
                $("#submit-change-avatar").attr("disabled", "disabled");
                document.getElementById('file-image').classList.add("hidden");
                document.getElementById('notimage').classList.remove("hidden");

                //ShowToastError("Please select an image.");
                document.getElementById('start').classList.remove("hidden");
                document.getElementById('response').classList.add("hidden");
                document.getElementById("file-upload-form").reset();
            }
        }

        function checkSquareImage(file) {
            return new Promise((resolve, reject) => {
                var img = new Image();
                var objectUrl = _URL.createObjectURL(file);
                img.onload = function () {
                    if (this.width === this.height) resolve(true)
                    else resolve(false)
                    _URL.revokeObjectURL(objectUrl);
                };
                img.src = objectUrl;
            });
        }

        function setProgressMaxValue(e) {
            var pBar = document.getElementById('file-progress');

            if (e.lengthComputable) {
                pBar.max = e.total;
            }
        }

        function updateFileProgress(e) {
            var pBar = document.getElementById('file-progress');

            if (e.lengthComputable) {
                pBar.value = e.loaded;
            }
        }

        function SubmitAjaxChangeAvatar(formData) {
            $.ajax({
                url: '/account-settings/change-avatar',
                type: "POST",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                data: formData,
                beforeSend: function () {
                    showLoadingOverlay();
                },
                complete: function () {
                    hideLoadingOverlay();
                }
            })
                .done(function (response) {
                    if (response.isSuccessed === true) {
                        ShowToastSuccess(response.message);

                        $("#submit-change-avatar").attr("disabled", "disabled");
                        $("#avatar-account").attr("src", response.resultObj);
                        $("#avatar-account-header").attr("src", response.resultObj);
                        $("#messages strong").text("");
                        $("#file-drag").removeClass("modal-body file-upload");
                        $("#file-image").attr("src", "#");
                        $("#file-image").addClass("hidden");
                        $("#start").removeClass("hidden");
                        $("#response").addClass("hidden");
                    }
                    else {
                        ShowToastError(response.message);
                    }
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    ShowToastError(jqXHR.responseJSON.message);
                });
        }

        function uploadFile(file) {
            const approvedFileExtension = [".jpg", ".png", ".bmp", ".jpeg"];
            var checkUpload = 0;
            var checkFileExtension = file.type.replace("image/", ".");

            $("#file-upload-form").submit(async function (e) {
                e.preventDefault();
                if (checkUpload === 0) {
                    if (!approvedFileExtension.includes(checkFileExtension)) {
                        //console.log("ERROR FIle");
                    }
                    else {
                        var formData = new FormData();
                        formData.append("formFile", file);

                        let fileNameCurrent = $("#messages strong").text();
                        let fileName = file.name;

                        if (fileNameCurrent === fileName) {
                            let messsageValidation = "";

                            let isMaximumSize = checkMaximumImageSize(file);
                            if (!isMaximumSize) {
                                if (messsageValidation === "") {
                                    messsageValidation = "The image file size should be from 1KB to 10 MB and should be the following type file: .png, .jpg, .bmp, .jpeg, maybe transparent background."
                                }
                                else {
                                    messsageValidation = messsageValidation + " The image file size should be from 1KB to 10 MB and should be the following type file: .png, .jpg, .bmp, .jpeg, maybe transparent background."
                                }
                            }
                            
                            if (isMaximumSize) {
                                SubmitAjaxChangeAvatar(formData);
                            }
                            else {
                                ShowToastError(messsageValidation);

                                $("#submit-change-avatar").attr("disabled", "disabled");
                                $("#avatar-account").attr("src", response.resultObj);
                                $("#avatar-account-header").attr("src", response.resultObj);
                                $("#messages strong").text("");
                                $("#file-drag").removeClass("modal-body file-upload");
                                $("#file-image").attr("src", "#");
                                $("#file-image").addClass("hidden");
                                $("#start").removeClass("hidden");
                                $("#response").addClass("hidden");
                            }
                        }
                        checkUpload = 1;
                    }
                }
            });

            checkUpload = 0;
        }

        // Check for the various File API support.
        if (window.File && window.FileList && window.FileReader) {
            Init();
        } else {
            document.getElementById('file-drag').style.display = 'none';
        }
    }
    ekUpload();

    $("#submit-change-avatar").click(function (e) {
        let fileNameCurrent = $("#messages strong").text();
        if (fileNameCurrent === null || fileNameCurrent === "")
            ShowToastError("The image file size should be from 1KB to 10 MB and should be the following type file: .png, .jpg, .bmp, .jpeg, maybe transparent background.");

    })

    $("#cancel-change-avatar").click(function (e) {
        $("#submit-change-avatar").attr("disabled", "disabled");
        $("#file-drag").removeClass("modal-body file-upload");
        $("#file-image").attr("src", "#");
        $("#file-image").addClass("hidden");
        $("#start").removeClass("hidden");
        $("#response").addClass("hidden");
        $("#messages strong").text("");
        $("#file-upload-form")[0].reset();

        document.getElementById('notimage').classList.add("hidden");
    })

    $("#close-change-avatar").click(function (e) {
        $("#submit-change-avatar").attr("disabled", "disabled");
        $("#file-drag").removeClass("modal-body file-upload");
        $("#file-image").attr("src", "#");
        $("#file-image").addClass("hidden");
        $("#start").removeClass("hidden");
        $("#response").addClass("hidden");
        $("#messages strong").text("");
        $("#file-upload-form")[0].reset();

        document.getElementById('notimage').classList.add("hidden");
    })
})