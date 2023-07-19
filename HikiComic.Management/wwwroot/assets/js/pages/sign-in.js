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
    }, "Password is required.");

    $.validator.addMethod("notFullSpace", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Email is required.");

    $.validator.addMethod("validateEmail", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(value);
    }, 'Invalid Email Address (e.x:abc@domain.com).');

    function SubmitLogin(form) {
        let email = $(form).find('input[name="email"]').val();
        let password = $(form).find('input[name="password"]').val();
        let getRememberMe = $(form).find('input[name="remember-me"]').val();
        let rememberMe = false;

        if (getRememberMe === "true") {
            rememberMe = true;
        }

        let loginDataRequest = {
            email: email,
            password: password,
            rememberMe: rememberMe
        };

        $.ajax({
            type: "POST",
            url: "/login",
            data: JSON.stringify(loginDataRequest),
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
                    window.location = "/";
                }
                else {
                    Swal.fire({
                        icon: "error",
                        text: response.message,
                        title: "Login Failed"
                    });
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                 Swal.fire({
                        icon: "error",
                        text: jqXHR.responseJSON.message,
                        title: "Login Failed"
                    });
            });

    }


    $("#login").validate({
        onkeyup: function (element) { $(element).valid(); },
        onfocusout: function (element) { $(element).valid(); },
        onclick: function (element) { $(element).valid(); },
        rules: {
            "email": {
                notFullSpace: true,
                validateEmail: true,
                required: true,
            },
            "password":
            {
                notFullSpacePassword: true,
                required: true,
                minlength: 6,
                maxlength: 32,
            }
        },
        messages: {
            "email": { required: "Please enter Email." },
            "password": {
                required: "Please enter Password.",
                maxlength: "Password must be from 6 to 32 characters.",
                minlength: "Password must be from 6 to 32 characters.",
            }
        },
        submitHandler: function (form) {
            SubmitLogin(form);
        }
    });
});

const passwordField = document.querySelector("#password");
const eyeIcon = document.querySelector("#eye");
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