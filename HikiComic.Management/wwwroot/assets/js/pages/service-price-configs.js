
//#region init user datatable
var servicePriceConfigsDatatable = $("#servicePriceConfigsDatatable").DataTable({
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
        "url": "/service-price-configs/get-service-price-configs",
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
            className: "text-start",
            targets: [0]
        }],
    "order": [[0, 'asc']],
    "columns": [
        { "data": "servicePriceName", "name": "ServicePriceName", "Width": 110 },
        { "data": "price", "name": "Price", "Width": 110 },
        { "data": "description", "name": "Description", "Width": 110 },
        {
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalEdit(${data.servicePriceId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;"><i class="bi bi-pencil-square"></i></a><a href="javascript:void(0)" onclick="modalInformation(${data.servicePriceId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></a></div>`
            },
        },
    ]
});

servicePriceConfigsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isActive === false) {
        e.preventDefault();
    }
});

$(document).ready(function () {
    $("#search").keyup(function () {
        $("#servicePriceConfigsDatatable").dataTable().fnFilter(this.value);
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
var servicePriceConfigIdEdit = null;
function modalEdit(servicePriceConfigId) {
    servicePriceConfigIdEdit = servicePriceConfigId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-service-price-config').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/service-price-configs/get-service-price-config-by-service-price-config-id/${servicePriceConfigIdEdit}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='service-price-config-name']").val(response.resultObj.servicePriceName);
                getModalEdit.find("input[name='price']").val(response.resultObj.price);
                getModalEdit.find("textarea[name='description']").val(response.resultObj.description);

                let $form = $('#form-edit-service-price-config');
                let origForm = $form.serialize();

                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-service-price-config').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-service-price-config').prop('disabled', true);
                    }

                    if ($("#form-edit-service-price-config").valid() == false) {
                        $('#submit-edit-service-price-config').prop('disabled', true);
                    }
                });

                //$('form :textarea').on('change textarea', function () {
                //    if ($form.serialize() !== origForm) {
                //        $('#submit-edit-service-price-config').prop('disabled', false);
                //    }
                //    else {
                //        $('#submit-edit-service-price-config').prop('disabled', true);
                //    }

                //    if ($("#form-edit-service-price-config").valid() == false) {
                //        $('#submit-edit-service-price-config').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-service-price-config").validate({
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
            "service-price-config-name": {
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
        },
        messages: {
            "service-price-config-name": {
                required: "Please enter Service Price Config Name.",
            },
            "price": {
                required: "Please enter Service Price.",
                number: 'Please enter a valid number.'
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 10 to 1000 characters.",
                maxlength: "Description must be from 10 to 1000 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let price = $(form).find('input[name="price"]').val();
            let description = $(form).find('textarea[name="description"]').val();

            let updateServicePriceConfigRequest = {
                price: price,
                description: description
            };

            if (servicePriceConfigIdEdit !== null && servicePriceConfigIdEdit !== undefined && servicePriceConfigIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `service-price-configs/update-service-price-config/${servicePriceConfigIdEdit}`,
                    data: JSON.stringify(updateServicePriceConfigRequest),
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
                        servicePriceConfigIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-service-price-config :input[type="text"]').val('');
                            servicePriceConfigsDatatable.ajax.reload();
                            $("#form-edit-service-price-config").validate().resetForm();
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

    $(document).on('click', '#cancel-edit-service-price-config', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-service-price-config :input[type="text"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region information service price config
var servicePriceConfigIdInformation = null;
function modalInformation(servicePriceConfigId) {
    servicePriceConfigIdInformation = servicePriceConfigId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/service-price-configs/get-service-price-config-by-service-price-config-id/${servicePriceConfigIdInformation}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='service-price-config-name']").text(response.resultObj.servicePriceName);
                getModalInformation.find("label[name='price']").text(response.resultObj.price);
                getModalInformation.find("label[name='description']").text(response.resultObj.description);

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