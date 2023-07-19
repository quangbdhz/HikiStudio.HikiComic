function showLoadingOverlay() {
    $(".loading-overlay").show();
}

function hideLoadingOverlay() {
    $(".loading-overlay").hide();
}


$(document).ready(function () {
    $("#login").submit(function (e) {
        e.preventDefault();
    })

    $.validator.addMethod("notFullSpacePassword", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Password.");

    $.validator.addMethod("notFullSpaceConfirmPassword", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Confirm Password.");

    $.validator.addMethod("notFullSpace", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Email.");

    $.validator.addMethod("validateEmail", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9](\.?[a-zA-Z0-9]){5,29}@([a-zA-Z_]+?\.[a-zA-Z]{3,5})$/.test(value);
    }, 'Invalid Email Address (e.x:abc@domain.com).');

    function SubmitVerifyEmail(form) {
        const urlParams = new URLSearchParams(window.location.search);

        const token = urlParams.get('token').replace(/[\s\t]/g, '+');

        let password = $(form).find('input[name="password"]').val();
        let confirmPassword = $(form).find('input[name="confirm-password"]').val();

        let verifyTokenEmailAndChangePasswordRequest = {
            token: token,
            password: password,
            confirmPassword: confirmPassword
        };

        $.ajax({
            type: "POST",
            url: "/user-mail-confirmations",
            data: JSON.stringify(verifyTokenEmailAndChangePasswordRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            dataType: "json",
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
                    setTimeout(function () {
                        window.location.href = "/";
                    }, 2000);
                }
                else {
                    ShowToastError(response.message);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }


    $("#login").validate({
        onkeyup: function (element) { $(element).valid(); },
        onfocusout: function (element) { $(element).valid(); },
        onclick: function (element) { $(element).valid(); },
        rules: {
            "password":
            {
                notFullSpacePassword: true,
                required: true,
                minlength: 6,
                maxlength: 32,
            },
            "confirm-password":
            {
                notFullSpacePassword: true,
                required: true,
                notFullSpaceConfirmPassword: true,
                minlength: 6,
                maxlength: 32,
                equalTo: "#password",
            }
        },
        messages: {
            "password": {
                required: "Please enter New Password.",
                maxlength: "New Password must be from 6 to 32 characters.",
                minlength: "New Password must be from 6 to 32 characters.",
            },
            "confirm-password": {
                required: "Please enter Confirm Password.",
                maxlength: "Confirm Password must be from 6 to 32 characters.",
                minlength: "Confirm Password must be from 6 to 32 characters.",
                equalTo: "Confirm Password must be the same as the New Password.",
            }
        },
        submitHandler: function (form) {
            SubmitVerifyEmail(form);
        }
    });
});

const passwordField = document.querySelector("#password");
const eyeIcon = document.querySelector("#eye");
if (eyeIcon !== null) {
    eye.addEventListener('click', function (e) {
        const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
        if (type == "text") {
            eyeIcon.classList.add("fa-eye");
            eyeIcon.classList.remove("fa-eye-slash");
        }
        else {
            eyeIcon.classList.add("fa-eye-slash");
            eyeIcon.classList.remove("fa-eye");
        }
        passwordField.setAttribute("type", type);
    })
}

const passwordFieldConfirmPassword = document.querySelector("#confirm-password");
const eyeIconConfirmPassword = document.querySelector("#eyeConfirmPassword");
if (eyeIcon !== null)
{
    eyeConfirmPassword.addEventListener('click', function (e) {

        const type = passwordFieldConfirmPassword.getAttribute("type") === "password" ? "text" : "password";
        if (type == "text") {
            eyeIconConfirmPassword.classList.add("fa-eye");
            eyeIconConfirmPassword.classList.remove("fa-eye-slash");
        }
        else {
            eyeIconConfirmPassword.classList.add("fa-eye-slash");
            eyeIconConfirmPassword.classList.remove("fa-eye");
        }
        passwordFieldConfirmPassword.setAttribute("type", type);
    })
}