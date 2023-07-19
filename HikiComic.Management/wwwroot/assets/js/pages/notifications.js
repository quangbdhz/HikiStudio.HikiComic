//#region init notification datatable
var notificationsDatatable = $("#notificationsDatatable").DataTable({
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
        "url": "/notifications/get-notifications",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false,
        "targets": [3, 5]
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
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.notificationId}' /> `;
                }
                else {
                    return "";
                    //return `<input type='checkbox' disabled class='form-check-input bg-secondary ms' data-id='${data.id}' />`;
                }
            },
        },
        { "data": "title", "name": "Title", "Width": 110 },
        { "data": "message", "name": "Message", "Width": 110 },
        {
            "render": function (row, type, data) {
                return `<div class="badge top-${6 - parseInt(data.notificationPriorityId)} bg-light-success me-1">${data.notificationPriority}</div>`
            }
        },
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
                if (!data.isDeleted) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.notificationId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.notificationId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.notificationId}', '${data.title}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.notificationId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.notificationId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.notificationId}', '${data.title}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
            },
        },
    ],
    createdRow: function (row, data, dataIndex) {
        $('td', row).eq(2).css('white-space', 'normal');
    }
});

notificationsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isActive === false) {
        e.preventDefault();
    }
});

$('#notificationsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#notificationsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#notificationsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = notificationsDatatable.data().count();
    var count = $('#notificationsDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region validation form create Notification
function CheckEnableSaveChange(event) {
    if ($('#form-create-notification').validate().checkForm()) {
        $("#submit-create-notification").removeAttr("disabled");
    }
    else {
        $("#submit-create-notification").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-notification").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-notification').find("input[name='CreateDate']").val(today);
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

    var formValidateCreate = $("#form-create-notification").validate({
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
            "notification-title": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 100,
            },
            "notification-message": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 200,
            },
        },
        messages: {
            "notification-title": {
                required: "Please enter Title.",
                notFullSpaceName: "Please enter Title.",
                minlength: "Title must be from 2 to 100 characters.",
                maxlength: "Title must be from 2 to 100 characters.",
            },
            "notification-message": {
                required: "Please enter Message.",
                notFullSpaceName: "Please enter Message.",
                minlength: "Message must be from 2 to 200 characters.",
                maxlength: "Message must be from 2 to 200 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let title = $(form).find('input[name="notification-title"]').val();
            let message = $(form).find('input[name="notification-message"]').val();
            let priorityId = $(form).find('select[name="notification-priority"]').val();

            let createNotificationDataRequest = {
                appUserId: "00000000-0000-0000-0000-000000000000",
                comicId: 0,
                title: title,
                message: message,
                isRead: false,
                actions: "",
                imageURL: "",
                notificationPriority: parseInt(priorityId),
                createdBy: "00000000-0000-0000-0000-000000000000",
            };

            $.ajax({
                method: "POST",
                url: `notifications/create-notification`,
                data: JSON.stringify(createNotificationDataRequest),
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

                        $('#form-create-notification :input[type="text"]').val('');
                        $('#form-create-notification :input[type="date"]').val('');
                        notificationsDatatable.ajax.reload();
                        $("#form-create-notification").validate().resetForm();
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

    $(document).on('click', '#cancel-create-notification', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-notification :input[type="text"]').val('');
        $('#form-create-notification :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit Notification
var notificationIdEdit = null;
function modalEdit(notificationId) {
    notificationIdEdit = notificationId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-notification').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/notifications/get-notification-by-notification-id/${notificationId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='notification-title']").val(response.resultObj.title);
                getModalEdit.find("input[name='notification-message']").val(response.resultObj.message);
                $("#notification-priority").val(response.notificationPriorityId);
                getModalEdit.find("input[name='notification-date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-notification'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-notification').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-notification').prop('disabled', true);
                    }
                    if ($("#form-edit-notification").valid() == false) {
                        $('#submit-edit-notification').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-notification").validate({
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
            "notification-title": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 100,
            },
            "notification-message": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 200,
            },
        },
        messages: {
            "notification-title": {
                required: "Please enter Title.",
                notFullSpaceName: "Please enter Title.",
                minlength: "Title must be from 2 to 100 characters.",
                maxlength: "Title must be from 2 to 100 characters.",
            },
            "notification-message": {
                required: "Please enter Message.",
                notFullSpaceName: "Please enter Message.",
                minlength: "Message must be from 2 to 200 characters.",
                maxlength: "Message must be from 2 to 200 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let title = $(form).find('input[name="notification-title"]').val();
            let message = $(form).find('input[name="notification-message"]').val();
            let priorityId = $(form).find('select[name="notification-priority"]').val();

            let updateNotificationDataRequest = {
                appUserId: "00000000-0000-0000-0000-000000000000",
                comicId: 0,
                title: title,
                message: message,
                isRead: false,
                actions: "",
                imageURL: "",
                notificationPriority: parseInt(priorityId),
                createdBy: "00000000-0000-0000-0000-000000000000",
            };

            if (notificationIdEdit !== null && notificationIdEdit !== undefined && notificationIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `notifications/update-notification/${notificationIdEdit}`,
                    data: JSON.stringify(updateNotificationDataRequest),
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
                        notificationIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-notification :input[type="text"]').val('');
                            $('#form-edit-notification :input[type="date"]').val('');
                            notificationsDatatable.ajax.reload();
                            $("#form-edit-notification").validate().resetForm();
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
                ShowToastError("No Notification selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-notification', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-notification :input[type="text"]').val('');
        $('#form-edit-notification :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete multiple Notification
$("#checkbox-all").click(function () {
    var data_list = $('#notificationsDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            notificationsDatatable.rows(`:has(td:eq(5):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            notificationsDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    var data_list = $('#notificationsDatatable input[type="checkbox"].ms')
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
    var notificationIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            notificationIds.push($(this).data("id"))
        }
    });

    if (notificationIds[0] === null || notificationIds[0] === undefined) {
        notificationIds[0] = -1;
    }

    const deleteNotificationsRequest = {
        notificationIds: notificationIds
    };

    $.ajax({
        method: "DELETE",
        url: `/notifications/delete-notifications`,
        data: JSON.stringify(deleteNotificationsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    notificationsDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-deletecheckall").attr('disabled', 'true');
                notificationsDatatable.rows().deselect();
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

//#region delete one notification
var notificationIdDelete;
function modalDelete(notificationId, title) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#notificationIdDelete").html(`<b>${title}</b>`);
    notificationIdDelete = notificationId;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    let notificationIds = [];
    notificationIds.push(notificationIdDelete);

    const deleteArtistsRequest = {
        notificationIds: notificationIds
    };

    $.ajax({
        method: "DELETE",
        url: `/notifications/delete-notifications`,
        data: JSON.stringify(deleteArtistsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                notificationsDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            notificationsDatatable.rows().deselect();
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

//#region restore Notification
var notificationIdRestore = null;
function modalRestore(notificationId, title) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#notification-title-restore").html(`<b>${title}</b>`);
    notificationIdRestore = notificationId;
}

$("button#submit-restore-notification").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (notificationIdRestore !== null && notificationIdRestore !== undefined && notificationIdRestore > 0) {
        let notificationId = notificationIdRestore;

        $.ajax({
            method: "POST",
            url: `/notifications/restore-notification`,
            data: JSON.stringify(notificationId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    notificationsDatatable.ajax.reload();
                    notificationIdRestore = null;
                }
                else {
                    ShowToastError(response.message);
                }

                //notificationsDatatable.rows().deselect();
                //$('input[type="checkbox"]').prop('checked', false);
                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No Notification selected for restoring.");
    }
    //let artistIds = [];
    //artistIds.push(localartistId);


});
//#endregion

//#region information Notification
var notificationIdInformation = null;
function modalInformation(notificationId) {
    notificationIdInformation = notificationId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/notifications/get-notification-by-notification-id/${notificationId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='notification-title']").text(response.resultObj.title);
                getModalInformation.find("label[name='notification-message']").text(response.resultObj.message);
                setStatusTextInField(getModalInformation, "notification-is-deleted", response.resultObj.isDeleted);
                setInfoUserCreateAndUpdateObject(getModalInformation, "notification", response);
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