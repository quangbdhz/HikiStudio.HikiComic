
//#region init user datatable
var serviceConfigsDatatable = $("#serviceConfigsDatatable").DataTable({
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
        "url": "/service-configs/get-service-configs",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [
        {
            "orderable": false, "targets": 2
        },
        {
            "orderable": false, "targets": 3
        },
        {
            "orderable": false, "targets": 4
        },
        {
            className: "text-start",
            targets: [0]
        }],
    "order": [[0, 'asc']],
    "columns": [
        { "data": "serviceConfigName", "name": "ServiceConfigName", "Width": 110 },
        {
            "render": function (row, type, data) {
                if (data.stringValue !== "" || data.stringValue !== null) {
                    return data.stringValue;
                }
                return data.value;
            },
        },
        { "data": "description", "name": "Description", "Width": 110 },
        { "data": "note", "name": "Note", "Width": 110 },
        {
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalEdit(${data.serviceConfigId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;"><i class="bi bi-pencil-square"></i></a><a href="javascript:void(0)" onclick="modalInformation(${data.serviceConfigId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></a></div>`
            },
        },
    ]
});

serviceConfigsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isActive === false) {
        e.preventDefault();
    }
});

$(document).ready(function () {
    $("#search").keyup(function () {
        $("#serviceConfigsDatatable").dataTable().fnFilter(this.value);
    });
});
//#endregion

//#region config textarea
$('#note').on('input', function () {
    let note = $("#note").val();

    if (this.scrollHeight <= 44 || note === null || note === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }

    this.style.height = (this.scrollHeight) + 'px';
});

$('#description').on('input', function () {
    let description = $("#description").val();

    if (this.scrollHeight <= 44 || description === null || description === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }

    this.style.height = (this.scrollHeight) + 'px';
});

$('#note').click('input', function () {
    let note = $("#note").val();

    if (this.scrollHeight <= 44 || note === null || note === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }

    this.style.height = (this.scrollHeight) + 'px';
});

$('#description').click('input', function () {
    let description = $("#description").val();

    if (this.scrollHeight <= 44 || description === null || description === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }

    this.style.height = (this.scrollHeight) + 'px';
});
//#endregion

//#region edit service config
var serviceConfigIdEdit = null;
function modalEdit(serviceConfigId) {
    serviceConfigIdEdit = serviceConfigId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-service-config').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/service-configs/get-service-config-by-service-config-id/${serviceConfigIdEdit}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='service-config-name']").val(response.resultObj.serviceConfigName);
                getModalEdit.find("input[name='value']").val(response.resultObj.value);
                getModalEdit.find("textarea[name='description']").val(response.resultObj.description);
                getModalEdit.find("textarea[name='note']").val(response.resultObj.note);

                let $form = $('#form-edit-service-config');
                let origForm = $form.serialize();

                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-service-config').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-service-config').prop('disabled', true);
                    }
                    
                    if ($("#form-edit-service-config").valid() == false) {
                        $('#submit-edit-service-config').prop('disabled', true);
                    }
                });

                //$('form :textarea').on('change textarea', function () {
                //    if ($form.serialize() !== origForm) {
                //        $('#submit-edit-service-config').prop('disabled', false);
                //    }
                //    else {
                //        $('#submit-edit-service-config').prop('disabled', true);
                //    }

                //    if ($("#form-edit-service-config").valid() == false) {
                //        $('#submit-edit-service-config').prop('disabled', true);
                //    }
                //});

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
    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    var formValidateEdit = $("#form-edit-service-config").validate({
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
            "service-config-name": {
                required: true,
            },
            "value": {
                required: true,
                number: true,
            },
            "description": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 1000,
            },
            "note": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
        },
        messages: {
            "service-config-name": {
                required: "Please enter Service Config Name.",
            },
            "value": {
                required: "Please enter Service Config Value.",
                number: 'Please enter a valid number.'
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 10 to 1000 characters.",
                maxlength: "Description must be from 10 to 1000 characters.",
            },
            "note": {
                notFullSpaceName: "Please enter Note.",
                minlength: "Note must be from 10 to 500 characters.",
                maxlength: "Note must be from 10 to 500 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let value = $(form).find('input[name="value"]').val();
            let description = $(form).find('textarea[name="description"]').val();
            let note = $(form).find('textarea[name="note"]').val();

            let updateServiceConfigRequest = {
                value: value,
                description: description,
                note: note
            };

            if (serviceConfigIdEdit !== null && serviceConfigIdEdit !== undefined && serviceConfigIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `service-configs/update-service-config/${serviceConfigIdEdit}`,
                    data: JSON.stringify(updateServiceConfigRequest),
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
                        serviceConfigIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-service-config :input[type="text"]').val('');
                            serviceConfigsDatatable.ajax.reload();
                            $("#form-edit-service-config").validate().resetForm();
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
                ShowToastError("No service selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-service-config', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-service-config :input[type="text"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region information service config
var serviceConfigIdInformation = null;
function modalInformation(serviceConfigId) {
    serviceConfigIdInformation = serviceConfigId;

    console.log(serviceConfigId);

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/service-configs/get-service-config-by-service-config-id/${serviceConfigIdInformation}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='service-config-name']").text(response.resultObj.serviceConfigName);
                getModalInformation.find("label[name='value']").text(response.resultObj.value);
                getModalInformation.find("label[name='description']").text(response.resultObj.description);
                getModalInformation.find("label[name='note']").text(response.resultObj.note);

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