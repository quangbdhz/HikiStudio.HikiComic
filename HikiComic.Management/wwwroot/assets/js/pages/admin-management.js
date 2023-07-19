//#region init user datatable
var usersDatatable = $("#usersDatatable").DataTable({
    "lengthChange": false,
    "processing": true,
    "serverSide": true,
    "filter": true,
    "responsive": true,
    'language': {
        'loadingRecords': '&nbsp;',
        'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
    },
    "pagingType": 'full_numbers',
    "ajax": {
        "url": "/accounts/admins/get-users",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false, "targets": 2
    },
    {
        "orderable": false, "targets": 3
    },
    {
        "orderable": false, "targets": 5
    },
    {
        className: "text-start",
        targets: [1]
    }],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "order": [[1, 'asc']],
    "columns": [
        {
            "render": function (row, type, data) {
                let isDisableDeleteRestored = data.roles.filter(x => x.priority == 4).length;

                if (!data.isDeleted && isDisableDeleteRestored == 0) {
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.id}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        { "data": "email", "name": "Email", "Width": 110 },
        {
            "render": function (row, type, data) {
                if (!data.emailConfirmed) {
                    return "<span class='badge bg-light-danger status'>Unconfirmed</span>";
                }
                else {
                    return "<span class='badge bg-light-primary status'>Confirmed</span>";
                }
            },
        },
        {
            "render": function (row, type, data) {
                if (data.phoneNumber === null || data.phoneNumber === '') {
                    return "";
                }
                else {
                    let icon = `<span style="color: #00ae98;"><i class="fa-sharp fa-solid fa-shield-check"></i></span>`;
                    return `<div class="d-flex gap-2 justify-content-center">${data.phoneNumber}${data.phoneNumberConfirmed === true ? icon : ""}</div>`
                }
            },
        },
        {
            "render": function (row, type, data) {
                if (!data.isDeleted) {
                    return "<span class='badge bg-success status'>Active</span>";
                }
                else {
                    return "<span class='badge bg-secondary status'>Inactive</span>";
                }
            },
        },
        {
            "render": function (row, type, data) {
                var list = [];
                var a = 0;
                for (var i = 0; i < data.roles.length; i++) {
                    a++;
                    list += `<span class='badge rounded-pill text-bg-info m-lg-1'>${data.roles[i].roleName}</span>`;

                    if (a === 2) {
                        a = 0;
                        list += ` <br/>`;
                    }
                }
                return list;
            }
        },
        {
            "render": function (row, type, data) {
                let optionLockUser = "";
                let optionDeleteUser = "";
                let optionInformation = "";
                let optionResendMail = "";


                let isDisableDeleteRestored = data.roles.filter(x => x.priority == 4).length;

                if (isDisableDeleteRestored == 0) {
                    if (data.lockoutEnabled === true) {
                        optionLockUser = `<a href="javascript:void(0)" onclick="modalUnlock('${data.id}', '${data.userName}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #d35400; padding: 0px;" ><i class="bi bi-unlock"></i></a>`;
                    }
                    else {
                        optionLockUser = `<a href="javascript:void(0)" onclick="modalLock('${data.id}', '${data.userName}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #8e44ad; padding: 0px;" ><i class="bi bi-lock"></i></a>`;
                    }

                    if (data.isDeleted) {
                        optionDeleteUser = `<a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.id}', '${data.userName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a>`
                    }
                    else {
                        optionDeleteUser = `<a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.id}', '${data.userName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a>`
                    }
                }

                if (!data.emailConfirmed) {
                    optionResendMail = `<a href="javascript:void(0)" onclick="modalResendMail('${data.email}', '${data.userName}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #ffd145; padding: 0px;" ><i class="fa-solid fa-paper-plane-top"></i></a>`;
                }

                optionInformation = `<a href='/accounts/admins/${data.id}/information' class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a>`;

                return `<div class="d-flex gap-2 justify-content-center">${optionInformation}${optionResendMail}${optionLockUser}${optionDeleteUser}</div>`;
            },
        },
    ]
});

usersDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);

    let isDisableDeleteRestored = row.data().roles.filter(x => x.priority == 4).length;

    if (row.data().isDeleted || isDisableDeleteRestored != 0) {
        e.preventDefault();
    }
});

$('#usersDatatable').on('page.dt', function () {
    $("#btn-multiple-delete-user").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#usersDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-multiple-delete-user").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#usersDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-multiple-delete-user").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = usersDatatable.data().filter(function (element) {
        let isDisableDeleteRestored = element.roles.filter(x => x.priority == 4).length;
        if (isDisableDeleteRestored == 0) return true;
        return false;
    }).length;

    var count = $('#usersDatatable tbody').find("input[type='checkbox']:checked").length;
    if ($(this).hasClass("select-checkbox")) {
        if ($(this).children().length > 0) {
            if ($(this).parent().hasClass("selected")) {
                //uncheck
                $(this).find("input[type='checkbox']").prop('checked', false);
                count--;
            } else {
                //check
                let fieldCheckBox = $(this).find("input[type='checkbox']");
                if (fieldCheckBox.prop('disabled') !== true) {
                    fieldCheckBox.prop('checked', true);
                    count++;
                }
            }
        }
    }

    if (count > 0) {
        $("#btn-multiple-delete-user").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-user").attr('disabled', 'true');
    }

    if (count == countRow) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
});
//#endregion

//#region choices genre
const selectRoles = new Choices('#select-role', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-role .choices__input")
    .focusout(function () {
        const elementCreate = $(".set-role-for-user .choices__inner");
        if ((selectRoles.getValue().length === 0)) {
            $("#select-role").parent().parent().next("#lable-error-select-role").remove()
            $("#select-role").parent().parent().after("<div id='lable-error-select-role' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Role(s).</div>");
            if (!elementCreate.hasClass("error-role")) {
                elementCreate.addClass("error-role")
                $("#submit-create-user").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-role");
            $("#lable-error-select-role").remove();
        }
    })

$('#div-select-role').change(function () {
    const elementCreate = $(".set-role-for-user .choices__inner");
    if ((selectRoles.getValue().length === 0)) {
        $("#select-role").parent().parent().next("#lable-error-select-role").remove()
        $("#select-role").parent().parent().after("<div id='lable-error-select-role' class='is-invalid' style='color:#dc3545;font-weight: 600;margin-top: 2px; position: absolute;'>Please select Genre(s).</div>");
        if (!elementCreate.hasClass("error-role")) {
            elementCreate.addClass("error-role")
            $("#submit-create-user").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-role");
        $("#lable-error-select-role").remove();
    }
})
//#endregion

//#region handle choices genre
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-role').on('change', function () {
    let listChoices = selectRoles.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectRoles.config.choices[p].value;
        let label = selectRoles.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-role option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion

//#region validation form create user
function generateUsername() {
    const characters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let username = '';

    for (let i = 0; i < 32; i++) {
        const randomIndex = Math.floor(Math.random() * characters.length);
        username += characters.charAt(randomIndex);
    }

    return username;
}

$('#user-name').val(generateUsername());

$('#generator-username').click(function () {
    $('#user-name').val(generateUsername());
    $('#user-name').validate();
    CheckEnableSaveChange();
});

function CheckEnableSaveChange(event) {
    if ($('#form-create-user').validate().checkForm() && selectRoles.getValue().length != 0) {
        $("#submit-create-user").removeAttr("disabled");
    }
    else {
        $("#submit-create-user").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-user").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-user').find("input[name='CreateDate']").val(today);
});

$(document).ready(function () {
    $.validator.addMethod("validateEmail", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(value);
    }, 'Invalid Email Address (e.x:abc@domain.com).');


    $.validator.addMethod("validateName", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z\s]+\s*$/.test(value);
    }, 'Numeric and Special characters are not allowed.');

    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    $('input').on('blur keyup', function (event) {
        CheckEnableSaveChange(event);
    })

    var formValidateCreate = $("#form-create-user").validate({
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
            "email": {
                required: true,
                notFullSpaceName: true,
                validateEmail: true,
            },
            "user-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
        },
        messages: {
            "email": {
                required: "Please enter Email.",
                notFullSpaceName: "Please enter Email.",
                validateEmail: "Invalid Email Address (e.x:abc@domain.com).",
            },
            "user-name": {
                required: "Please enter Username.",
                notFullSpaceName: "Please enter Username.",
                minlength: "Username must be from 2 to 32 characters.",
                maxlength: "Username must be from 2 to 32 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let roleIds = [];
            let roleNames = [];
            $('#select-role option:selected').each(function (i, selectedelement) {
                roleIds[i] = $(selectedelement).val();
                roleNames[i] = $(selectedelement).text();
            })
            let email = $(form).find('input[name="email"]').val();
            let userName = $(form).find('input[name="user-name"]').val();

            let createUserAndAssignRoleRequest = {
                email: email,
                userName: userName,
                roleIds: roleIds
            };

            $.ajax({
                method: "POST",
                url: `/accounts/admins/create-user-and-assign-role`,
                data: JSON.stringify(createUserAndAssignRoleRequest),
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
                        const truck_modal = document.querySelector('#modal-create');
                        const modal = bootstrap.Modal.getInstance(truck_modal);
                        modal.hide();
                        ShowToastSuccess(response.message);

                        $('#form-create-user :input[type="text"]').val('');
                        $('#form-create-user :input[type="date"]').val('');
                        usersDatatable.ajax.reload();

                        $('#lable-error-select-role').css('display', 'none');
                        $('.choices__inner').removeClass('error-role');
                        selectRoles.removeActiveItems();

                        $("#form-create-user").validate().resetForm();
                        $('#user-name').val(generateUsername());
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

    $(document).on('click', '#cancel-create-user', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-user :input[type="text"]').val('');
        $('#form-create-user :input[type="date"]').val('');

        $('#lable-error-select-role').css('display', 'none');
        $('.choices__inner').removeClass('error-role');
        selectRoles.removeActiveItems();
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region lock user
var userIdLock = null;
function modalLock(userId, userName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-lock'), {
        keyboard: false
    })
    modalRestore.show();
    $("#user-name-of-user-lock").html(`<b>${userName}</b>`);
    userIdLock = userId;
}

$("button#submit-user-lock").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-lock');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userIdLock !== null && userIdLock !== undefined && userIdLock !== "00000000-0000-0000-0000-000000000000") {
        let userId = userIdLock;

        $.ajax({
            method: "POST",
            url: `/accounts/admins/user-lock`,
            data: JSON.stringify(userId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                    userIdLock = null;
                }
                else {
                    ShowToastError(response.message);
                }

                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No user selected for lock.");
    }
});
//#endregion

//#region unlock user
var userIdUnlock = null;
function modalUnlock(userId, userName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-unlock'), {
        keyboard: false
    })
    modalRestore.show();
    $("#user-name-of-unlock-user").html(`<b>${userName}</b>`);
    userIdUnlock = userId;
}

$("button#submit-unlock-user").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-unlock');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userIdUnlock !== null && userIdUnlock !== undefined && userIdUnlock !== "00000000-0000-0000-0000-000000000000") {
        let userId = userIdUnlock;

        $.ajax({
            method: "POST",
            url: `/accounts/admins/unlock-user`,
            data: JSON.stringify(userId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                    userIdUnlock = null;
                }
                else {
                    ShowToastError(response.message);
                }

                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No user selected for unlock.");
    }
});
//#endregion

//#region delete multiple users
$("#checkbox-all").click(function () {
    let data_list = $('#usersDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            usersDatatable.rows(':has(td:eq(6):contains("teamMembers"):not(:contains("admin")))').select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            usersDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    let data_list = $('#usersDatatable input[type="checkbox"].ms')
    let sum_checked = 0;

    data_list.each(function () {
        if ($(this).is(':checked')) {
            sum_checked += 1;
        }
    });

    if (sum_checked > 0) {
        $("#btn-multiple-delete-user").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-user").attr('disabled', 'true');
    }

    if ((data_list.length) == sum_checked) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
})

$("#submit-delete-user-multiple").click(function () {
    var userIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            userIds.push($(this).data("id"))
        }
    });

    if (userIds[0] === null || userIds[0] === undefined) {
        userIds[0] = "00000000-0000-0000-0000-000000000000";
    }

    const deleteUsersRequest = {
        userIds: userIds
    };

    $.ajax({
        method: "DELETE",
        url: `/accounts/admins/delete-users`,
        data: JSON.stringify(deleteUsersRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-multiple-delete-user").attr('disabled', 'true');
                usersDatatable.rows().deselect();
                $('input[type="checkbox"]').prop('checked', false);
                $("#checkbox-all").prop('checked', false);
                return;
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
});
//#endregion 

//#region detete one user 
var userIdDeleteInLine;
function modalDelete(userId, userName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#user-name-user-delete").html(`<b>${userName}</b>`);
    userIdDeleteInLine = userId;
}

$("button#submit-delete-user").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userIdDeleteInLine !== null && userIdDeleteInLine !== undefined && userIdDeleteInLine !== "00000000-0000-0000-0000-000000000000") {
        let userIds = [];
        userIds.push(userIdDeleteInLine);

        const deleteUsersRequest = {
            userIds: userIds
        };

        $.ajax({
            method: "DELETE",
            url: `/accounts/admins/delete-users`,
            data: JSON.stringify(deleteUsersRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                    userIdDeleteInLine = null;
                }
                else {
                    ShowToastError(response.message);
                }

                usersDatatable.rows().deselect();
                $("#btn-multiple-delete-user").attr('disabled', 'true');
                $('input[type="checkbox"]').prop('checked', false);
                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No user selected for delete.");
    }
});
//#endregion

//#region restore user
var userIdRestore = null;
function modalRestore(userId, userName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#user-name-user-restore").html(`<b>${userName}</b>`);
    userIdRestore = userId;
}

$("button#submit-restore-user").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userIdRestore !== null && userIdRestore !== undefined && userIdRestore !== "00000000-0000-0000-0000-000000000000") {
        let userId = userIdRestore;

        $.ajax({
            method: "POST",
            url: `/accounts/admins/restore-user`,
            data: JSON.stringify(userId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                    userIdRestore = null;
                }
                else {
                    ShowToastError(response.message);
                }

                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No user selected for restoring.");
    }
});
//#endregion

//#region resend mail confirmation for user
var userEmailResendMail = null;
function modalResendMail(email, userName) {
    let modalResendMail = new bootstrap.Modal(document.getElementById('modal-resend-mail'), {
        keyboard: false
    })
    modalResendMail.show();
    $("#email-of-user-resend-mail").html(`<b>${email}</b>`);
    userEmailResendMail = email;
}

$("button#submit-resend-mail").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-resend-mail');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userEmailResendMail !== null && userEmailResendMail !== undefined) {
        let email = userEmailResendMail;

        $.ajax({
            method: "POST",
            url: `/accounts/admins/resend-mail-email-confirmation`,
            data: JSON.stringify(email),
            headers: {
                "Content-Type": "application/json;",
            },
            beforeSend: function () {
                showLoadingOverlay();
            },
            complete: function () {
                hideLoadingOverlay();
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    usersDatatable.ajax.reload();
                    email = null;
                }
                else {
                    ShowToastError(response.message);
                }

                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No user selected for resend mail.");
    }
});
//#endregion