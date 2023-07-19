//validate sign-in-form
$(document).ready(function () {
    var initFirstName = $("#first-name").val();
    var initLastName = $("#last-name").val();
    var initPhone = $("#phone").val();
    let initDOB = $("#date-of-birth").val();
    let initGender = $('#gender').find(":selected").text();

    function CheckEnableSaveChangePersonalInfo(event) {
        let currentFirstName = $("#first-name").val();
        let currentLastName = $("#last-name").val();
        let currentPhone = $("#phone").val();
        let currentDOB = $("#date-of-birth").val();
        let currentGender = $('#gender').find(":selected").text();

        if ($('#form-change-name').validate().checkForm() && (currentFirstName !== initFirstName || currentLastName !== initLastName || currentPhone !== initPhone || currentDOB !== initDOB || currentGender !== initGender)) {
            $("#save-form-change-name").removeAttr("disabled");
        }
        else {
            $("#save-form-change-name").attr("disabled", "disabled");
        }

        if ($('#form-change-password').validate().checkForm()) {
            $("#save-form-change-password").removeAttr("disabled");
        }
        else {
            $("#save-form-change-password").attr("disabled", "disabled");
        }
        
        return true;
    }

    document.addEventListener("keyup", function (event) {
        CheckEnableSaveChangePersonalInfo(event);
    });

    document.addEventListener("click", function (event) {
        CheckEnableSaveChangePersonalInfo(event);
    });

    $.validator.addMethod("validateLastName", function (value, element) {
        return this.optional(element) || (/^\s*[a-zA-Z\s]+\s*$/.test(value));
    }, "Numeric and Special characters are not allowed.");

    $.validator.addMethod("validateFirstName", function (value, element) {
        return this.optional(element) || (/^\s*[a-zA-Z\s]+\s*$/.test(value));
    }, "Numeric and Special characters are not allowed.");

    $.validator.addMethod("validateNumberr", function (value, element) {
        return this.optional(element) || /^(?=(?:\D*\d){10,}\D*$)[0-9]{1,2}[\s-]?[- ]?([0-9]{3,4})[- ]?([0-9]{3,4})[- ]?([0-9]{3,10})$/.test(value);
    }, 'Phone Number must be from 10 to 20 characters.');

    $.validator.addMethod("validatePhoneNumber", function (value, element) {
        return this.optional(element) || /^[0-9]{0,2}[\s-]?[- ]?([0-9]{0,4})[- ]?([0-9]{0,4})[- ]?([0-9]{0,})$/.test(value);
    }, 'Invalid Phone Number.(e.x:1-888-364-3577).');

    $.validator.addMethod("notEqualTo", function (value, element, param) {
        return this.optional(element) || value != $(param).val();
    }, "New Password cannot be the same as Current Password.");

    $.validator.addMethod("notWhiteSpace", function (value, element, param) {
        return this.optional(element) || !(/\s/.test(value));
    }, "Numeric and Special characters are not allowed.");

    $.validator.addMethod("notFullSpaceCurrentPassword", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Current Password.");

    $.validator.addMethod("notFullSpaceNewPassword", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter New Password.")

    $.validator.addMethod("notFullSpaceConfirmPassword", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Confirm Password.");

    $.validator.addMethod("notFullSpaceLastName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Last Name.");

    $.validator.addMethod("notFullSpaceFirstName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter First Name.");

    $.validator.addMethod("notFullSpacePhone", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Phone Number.");

    //#region change password
    function SubmitAjaxChangePassword(form) {
        let currentPassword = $(form).find('input[name="current-password"]').val();
        let newPassword = $(form).find('input[name="new-password"]').val();
        let confirmPassword = $(form).find('input[name="confirm-password"]').val();

        let userProfile = {
            currentPassword: currentPassword,
            newPassword: newPassword,
            confirmPassword: confirmPassword
        };

        $.ajax({
            type: "POST",
            url: "/account-settings/change-password",
            data: JSON.stringify(userProfile),
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

                    $('#formChangePasswordCollapse').addClass('collapsed');
                    $('#changePasswordCollapse').removeClass('show');
                    $('#form-change-password').trigger("reset");
                    $("#save-form-change-password").attr("disabled", "disabled");
                }
                else {
                    ShowToastError(response.message);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }

    var validatorFormChangePassword = $("#form-change-password").validate({
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
            "current-password": {
                required: true,
                notFullSpaceCurrentPassword: true,
                minlength: 6,
                maxlength: 32,
            },
            "new-password": {
                required: true,
                notFullSpaceNewPassword: true,
                minlength: 6,
                maxlength: 32,
                notEqualTo: "#current-password",
            },
            "confirm-password": {
                required: true,
                notFullSpaceConfirmPassword: true,
                minlength: 6,
                maxlength: 32,
                equalTo: "#new-password",
            }
        },
        messages: {
            "new-password": {
                required: "Please enter New Password.",
                maxlength: "New Password must be from 6 to 32 characters.",
                minlength: "New Password must be from 6 to 32 characters.",
            },
            "current-password": {
                required: "Please enter Current Password.",
                maxlength: "Current Password must be from 6 to 32 characters.",
                minlength: "Current Password must be from 6 to 32 characters.",
            },
            "confirm-password": {
                required: "Please enter Confirm Password.",
                maxlength: "Confirm Password must be from 6 to 32 characters.",
                minlength: "Confirm Password must be from 6 to 32 characters.",
                equalTo: "Confirm Password must be the same as the New Password.",
            }
        },
        submitHandler: function (form) {
            SubmitAjaxChangePassword(form);
        }
    });

    $("#cancel-form-change-password").click(function (e) {
        validatorFormChangePassword.resetForm();
        $("#save-form-change-password").attr('disabled', 'disabled');
    })
    //#endregion

    //#region change personal info
    function SubmitAjaxChangePersonalInfo(form) {
        let firstName = $(form).find('input[name="first-name"]').val();
        let lastName = $(form).find('input[name="last-name"]').val();
        let phone = $(form).find('input[name="phone"]').val();
        let dob = $(form).find('input[name="date-of-birth"]').val();
        let genderId = $('#gender').find(":selected").val();

        let userPersonalInfo = {
            firstName: firstName,
            lastName: lastName,
            phoneNumber: phone,
            dOB: dob,
            genderId: genderId
        };

        $.ajax({
            type: "POST",
            url: "/account-settings/change-personal-info",
            data: JSON.stringify(userPersonalInfo),
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

                    $("#save-form-change-name").attr('disabled', 'disabled');

                    $("#formChangeNameCollapse").addClass('collapsed');
                    $("#changeNameCollapse").removeClass('show');
                    $("#form-change-name").trigger("reset");

                    initFirstName = response.resultObj.firstName;
                    initLastName = response.resultObj.lastName;
                    initPhone = response.resultObj.phoneNumber;
                    let originalDOB = new Date(response.resultObj.dob);
                    initGender = response.resultObj.genderName;

                    let day = ("0" + originalDOB.getDate()).slice(-2);
                    let month = ("0" + (originalDOB.getMonth() + 1)).slice(-2);
                    let convertDOBText = (day) + "-" + (month) + "-" + originalDOB.getFullYear();
                    let convertDOBToPicker = originalDOB.getFullYear() + "-" + (month) + "-" + (day)

                    initDOB = convertDOBToPicker;

                    $("#full-name-account").text(response.resultObj.firstName + " " + response.resultObj.lastName);
                    $("#phone-account").text(initPhone);
                    $("#date-of-birth-account").text(convertDOBText);
                    $("#gender-account").text(initGender);

                    $("#first-name").attr("value", initFirstName);
                    $("#last-name").attr("value", initLastName);
                    $("#phone").attr("value", initPhone);

                    $("#date-of-birth").attr("value", convertDOBToPicker);

                    let genderId = $(`option:contains("${initGender}")`).val();
                    $("#gender").val(`${genderId}`).change();
                }
                else {
                    ShowToastError(response.message);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }

    var validatorFormChangeName = $("#form-change-name").validate({
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
            "first-name": {
                required: true,
                notFullSpaceFirstName: true,
                minlength: 2,
                maxlength: 32,
                validateFirstName: true,
            },
            "last-name": {
                required: true,
                notFullSpaceLastName: true,
                minlength: 2,
                maxlength: 32,
                validateLastName: true,
            },
            "phone": {
                notFullSpacePhone: true,
                minlength: 10,
                maxlength: 20,
                validatePhoneNumber: true,
                validateNumberr: true,
            },
            "date-of-birth": {
                required: true,
            },
            "gender": {
                required: true,
            }
        },
        messages: {
            "first-name": {
                required: "Please enter First Name.",
                maxlength: "First Name must be from 2 to 32 characters.",
                minlength: "First Name must be from 2 to 32 characters.",
            },
            "last-name": {
                required: "Please enter Last Name.",
                maxlength: "Last Name must be from 2 to 32 characters.",
                minlength: "Last Name must be from 2 to 32 characters.",
            },
            "phone": {
                maxlength: "Phone Number must be from 10 to 20 characters.",
                minlength: "Phone Number must be from 10 to 20 characters.",
            },
            "date-of-birth": {
                required: "Please enter Date of Birth.",
            }
        },
        submitHandler: function (form) {
            SubmitAjaxChangePersonalInfo(form);
        }
    });

    $("#cancel-form-change-name").click(function (e) {
        validatorFormChangeName.resetForm();

        $("#save-form-change-name").attr('disabled', 'disabled');

        $("#first-name").attr("value", initFirstName);
        $("#last-name").attr("value", initLastName);
        $("#phone").attr("value", initPhone);
        $("#date-of-birth").attr("value", initDOB);
        $("#gender").attr("value", initGender);
    })
    //#endregion
});


