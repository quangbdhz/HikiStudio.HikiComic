//#region init artist datatable
var rolesDatatable = $("#rolesDatatable").DataTable({
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
        "url": "/roles/get-roles",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false, "targets": [3, 5]
    },
    {
        className: "text-start",
        targets: [1, 2]
    }
    ],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "order": [[1, 'asc']],
    "columns": [
        {
            "render": function (row, type, data) {
                if (!data.isDeleted) {
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.roleId}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        { "data": "roleName", "name": "RoleName", "Width": 110 },
        { "data": "description", "name": "Description", "Width": 110 },
        {
            "data": "priorityName", "name": "PriorityName",
            "render": function (row, type, data) {
                return `<div class="badge top-${5 - parseInt(data.priority)} bg-light-success me-1">${data.priorityName}</div>`
            } },
        {
            "data": "dateCreated", "name": "DateCreated",
            "render": function (row, type, data) {
                return new Date(data.dateCreated).toLocaleDateString()
            }
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
                if (data.isDeleted) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation('${data.roleId}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit('${data.roleId}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.roleId}', '${data.roleName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation('${data.roleId}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit('${data.roleId}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.roleId}', '${data.roleName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

rolesDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#rolesDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#rolesDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#rolesDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = rolesDatatable.data().count();
    var count = $('#rolesDatatable tbody').find("input[type='checkbox']:checked").length;
    if ($(this).hasClass("select-checkbox")) {
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

    if (count > 0) {
        $("#btn-deletecheckall").removeAttr('disabled');
    } else {
        $("#btn-deletecheckall").attr('disabled', 'true');
    }

    if (count == countRow) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
});
//#endregion

//#region validation form create role
function CheckEnableSaveChange(event) {
    if ($('#form-create-role').validate().checkForm()) {
        $("#submit-create-role").removeAttr("disabled");
    }
    else {
        $("#submit-create-role").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-role").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-role').find("input[name='CreateDate']").val(today);
});

$(document).ready(function () {
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

    var formValidateCreate = $("#form-create-role").validate({
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
            "role-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
                validateName: true,
            },
            "description": {
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
        },
        messages: {
            "role-name": {
                required: "Please enter Role Name.",
                notFullSpaceName: "Please enter Role Name.",
                minlength: "Role Name must be from 2 to 32 characters.",
                maxlength: "Role Name must be from 2 to 32 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 2 to 32 characters.",
                maxlength: "Description must be from 2 to 32 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let roleName = $(form).find('input[name="role-name"]').val();
            let description = $(form).find('input[name="description"]').val();
            let priority = $(form).find('select[name="priority"]').val();

            let createRoleDataRequest = {
                roleName: roleName,
                description: description,
                priority: parseInt(priority)
            };

            $.ajax({
                method: "POST",
                url: `roles/create-role`,
                data: JSON.stringify(createRoleDataRequest),
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

                        $('#form-create-role :input[type="text"]').val('');
                        $('#form-create-role :input[type="date"]').val('');
                        rolesDatatable.ajax.reload();
                        $("#form-create-role").validate().resetForm();
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

    $(document).on('click', '#cancel-create-role', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-role :input[type="text"]').val('');
        $('#form-create-role :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit role
var roleIdEdit = null;
function modalEdit(roleId) {
    roleIdEdit = roleId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-role').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/roles/get-role-by-role-id/${roleId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='role-name']").val(response.resultObj.roleName);
                getModalEdit.find("input[name='description']").val(response.resultObj.description);
                getModalEdit.find('select[name="priority"]').val(response.resultObj.priority);
                getModalEdit.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-role'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-role').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-role').prop('disabled', true);
                    }
                    if ($("#form-edit-role").valid() == false) {
                        $('#submit-edit-role').prop('disabled', true);
                    }
                });

                myModal.show();
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
    return;
}

$(document).ready(function () {
    $.validator.addMethod("validateName", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z\s]+\s*$/.test(value);
    }, 'Numeric and Special characters are not allowed.');

    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    var formValidateEdit = $("#form-edit-role").validate({
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
            "role-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
                validateName: true,
            },
            "description": {
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
        },
        messages: {
            "role-name": {
                required: "Please enter Role Name.",
                notFullSpaceName: "Please enter Role Name.",
                minlength: "Role Name must be from 2 to 32 characters.",
                maxlength: "Role Name must be from 2 to 32 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 2 to 32 characters.",
                maxlength: "Description must be from 2 to 32 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let roleName = $(form).find('input[name="role-name"]').val();
            let description = $(form).find('input[name="description"]').val();
            let priority = $(form).find('select[name="priority"]').val();

            let updateRoleDataRequest = {
                roleName: roleName,
                description: description,
                priority: parseInt(priority)
            };

            if (roleIdEdit !== null && roleIdEdit !== undefined && roleIdEdit !== "00000000-0000-0000-0000-000000000000") {
                $.ajax({
                    method: "PUT",
                    url: `roles/update-role/${roleIdEdit}`,
                    data: JSON.stringify(updateRoleDataRequest),
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
                        roleIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-role :input[type="text"]').val('');
                            $('#form-edit-role :input[type="date"]').val('');
                            rolesDatatable.ajax.reload();
                            $("#form-edit-role").validate().resetForm();
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
            else {
                ShowToastError("No role selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-role', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-role :input[type="text"]').val('');
        $('#form-edit-role :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete multiple roles
$("#checkbox-all").click(function () {
    var data_list = $('#rolesDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            rolesDatatable.rows(`:has(td:eq(5):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            rolesDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    var data_list = $('#rolesDatatable input[type="checkbox"].ms')
    let sum_checked = 0;

    data_list.each(function () {
        if ($(this).is(':checked')) {
            sum_checked += 1;
        }
    });

    if (sum_checked > 0) {
        $("#btn-deletecheckall").removeAttr('disabled');
    } else {
        $("#btn-deletecheckall").attr('disabled', 'true');
    }

    if ((data_list.length) == sum_checked) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
})

$("#delete-with-checkbox").click(function () {
    var roleIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            roleIds.push($(this).data("id"))
        }
    });

    if (roleIds[0] === null || roleIds[0] === undefined) {
        roleIds[0] = -1;
    }

    const deleteRolesRequest = {
        roleIds: roleIds
    };

    $.ajax({
        method: "DELETE",
        url: `/roles/delete-roles`,
        data: JSON.stringify(deleteRolesRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    rolesDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-deletecheckall").attr('disabled', 'true');
                rolesDatatable.rows().deselect();
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

//#region delete one role
var roleIdDelete;
function modalDelete(roleId, roleName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#roleIdDelete").html(`<b>${roleName}</b>`);
    roleIdDelete = roleId;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    let roleIds = [];
    roleIds.push(roleIdDelete);

    const deleteRolesRequest = {
        roleIds: roleIds
    };

    $.ajax({
        method: "DELETE",
        url: `/roles/delete-roles`,
        data: JSON.stringify(deleteRolesRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                rolesDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            rolesDatatable.rows().deselect();
            $("#btn-deletecheckall").attr('disabled', 'true');
            $('input[type="checkbox"]').prop('checked', false);
            modal.hide();
            return;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
});
//#endregion

//#region restore role
var roleIdRestore = null;
function modalRestore(roleId, roleName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#role-name-restore").html(`<b>${roleName}</b>`);
    roleIdRestore = roleId;
}

$("button#submit-restore-role").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (roleIdRestore !== null && roleIdRestore !== undefined && roleIdRestore !== "00000000-0000-0000-0000-000000000000") {
        let roleId = roleIdRestore;

        $.ajax({
            method: "POST",
            url: `/roles/restore-role`,
            data: JSON.stringify(roleId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    rolesDatatable.ajax.reload();
                    roleIdRestore = null;
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
        ShowToastError("No role selected for restoring.");
    }
});
//#endregion

//#region information role
var roleIdInformation = null;
function modalInformation(roleId) {
    roleIdInformation = roleId;


    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/roles/get-role-by-role-id/${roleId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='role-name']").text(response.resultObj.roleName);
                getModalInformation.find("label[name='description']").text(response.resultObj.description);
                getModalInformation.find("label[name='role-priority']").text(response.resultObj.priorityName);

                setStatusTextInField(getModalInformation, "role-is-deleted", response.resultObj.isDeleted);
                setInfoUserCreateAndUpdateObject(getModalInformation, "role", response);

                modalInformation.show();
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
    return;

}
//#endregion

