//#region init user datatable
var userCOINDepositHistoriesDatatable = $("#userCOINDepositHistoriesDatatable").DataTable({
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
        "url": "/accounts/users/get-user-coin-deposit-histories",
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
        targets: [3]
    }],
    "order": [[5, 'desc']],
    "columns": [
        {
            "data": "depositAmount", "name": "DepositAmount",
            "render": function (row, type, data) {
                return data.depositAmount.toString().replace(/(?:(^\d{1,3})(?=(?:\d{3})*$)|(\d{3}))(?!$)/mg, '$1$2.');
            },
        },
        {
            "data": "coins", "name": "Coins",
            "render": function (row, type, data) {
                return data.coins.toString().replace(/(?:(^\d{1,3})(?=(?:\d{3})*$)|(\d{3}))(?!$)/mg, '$1$2.');
            },
        },
        { "data": "depositMethodName", "name": "DepositMethodName", "Width": 110 },
        { "data": "transactionId", "name": "TransactionId", "Width": 110 },
        {
            "data": "depositStatusName", "name": "DepositStatusName",
            "render": function (row, type, data) {
                if (data.depositStatusName === "Pending") {
                    return "<span class='badge bg-warning status'>Pending</span>";
                }
                else if (data.depositStatusName === "Completed") {
                    return "<span class='badge bg-success status'>Completed</span>";
                }
                else {
                    return "<span class='badge bg-danger status'>Failed</span>";
                }
            },
        },
        {
            "data": "dateCreated", "name": "DateCreated",
            "render": function (row, type, data) {
                return new Date(data.dateCreated).toLocaleTimeString() + " " + new Date(data.dateCreated).toLocaleDateString()
            }
        },
        {
            "render": function (row, type, data) {
                if (data.depositStatusName === "Pending") {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalChangeCoinDepositStatus(${data.userCoinDepositHistoryId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #ff6339; padding: 0px;" ><i class="bi bi-repeat"></i></a><a href="javascript:void(0)" onclick="modalInformation(${data.userCoinDepositHistoryId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></a></div>`;
                }
                else {

                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.userCoinDepositHistoryId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></a></div>`;
                }
            },
        },
    ]
});

userCOINDepositHistoriesDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isActive === false) {
        e.preventDefault();
    }
});

$(document).ready(function () {
    $("#search").keyup(function () {
        $("#userCOINDepositHistoriesDatatable").dataTable().fnFilter(this.value);
    });
});

//#endregion

//#region modal change coin deposit status
var userCoinDepositHistoryIdForChangeCoinDepositStatus = null;
function modalChangeCoinDepositStatus(userCoinDepositHistoryId) {
    userCoinDepositHistoryIdForChangeCoinDepositStatus = userCoinDepositHistoryId;

    let modalChangeCoinDepositStatus = new bootstrap.Modal(document.getElementById('modal-change-coin-deposit-status'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/accounts/users/information/get-user-coin-deposit-history-with-user-coin-usage-history-id/${userCoinDepositHistoryIdForChangeCoinDepositStatus}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalChangeCoinDepositStatus = $("#modal-change-coin-deposit-status");

                getModalChangeCoinDepositStatus.find("label[name='account-name']").text(response.resultObj.accountName);
                getModalChangeCoinDepositStatus.find("label[name='deposit-amount']").text(response.resultObj.depositAmount);
                getModalChangeCoinDepositStatus.find("label[name='coins']").text(response.resultObj.coins);
                getModalChangeCoinDepositStatus.find("label[name='deposit-method-name']").text(response.resultObj.depositMethodName);
                getModalChangeCoinDepositStatus.find("label[name='transaction-id']").text(response.resultObj.transactionId);
                getModalChangeCoinDepositStatus.find("label[name='deposit-status-name']").text(response.resultObj.depositStatusName);
                getModalChangeCoinDepositStatus.find("label[name='remarks']").text(response.resultObj.remarks);
                getModalChangeCoinDepositStatus.find("label[name='deposit-date']").text(new Date(response.resultObj.dateCreated).toLocaleTimeString() + " " + new Date(response.resultObj.dateCreated).toLocaleDateString());

                modalChangeCoinDepositStatus.show();
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
    const selectCoinDepositStatus = document.querySelector('#select-coin-deposit-status');

    selectCoinDepositStatus.addEventListener('change', function () {
        const selectedValue = this.value;

        if (selectedValue === "2" || selectedValue === "3") {
            $("#submit-change-coin-deposit-status").removeAttr("disabled");
        }
        else {
            $("#submit-change-coin-deposit-status").attr("disabled", "disabled");
        }
    });

    var formValidateChangeCoinDepositStatus = $("#form-change-coin-deposit-status").validate({
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

        },
        messages: {

        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let depositStatusId = parseInt($('#select-coin-deposit-status').find(":selected").val());

            let changeDepositStatusRequest = {
                userCoinDepositHistoryId: userCoinDepositHistoryIdForChangeCoinDepositStatus,
                depositStatusId: depositStatusId
            };

            if (depositStatusId === 2 || depositStatusId == 3) {
                $.ajax({
                    method: "POST",
                    url: `coin-deposit-histories/check-and-change-deposit-status`,
                    data: JSON.stringify(changeDepositStatusRequest),
                    headers: {
                        "Content-Type": "application/json;",
                    },
                    processData: false,
                    contentType: false,
                    datatype: 'json',
                })
                    .done(function (response) {
                        artistIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-change-coin-deposit-status');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            userCOINDepositHistoriesDatatable.ajax.reload();

                            $("#form-change-coin-deposit-status").validate().resetForm();
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
                ShowToastError("No artist selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-change-coin-deposit-status', function () {
        const truck_modal = document.querySelector('#modal-change-coin-deposit-status');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        console.log("AA");

        //$('#form-edit-artist :input[type="text"]').val('');
        //$('#form-edit-artist :input[type="date"]').val('');
        formValidateChangeCoinDepositStatus.resetForm();
    });
});
//#endregion

//#region information user-coin-deposit-histories
var userCoinDepositHistoryIdInformation = null;
function modalInformation(userCoinDepositHistoryId) {
    userCoinDepositHistoryIdInformation = userCoinDepositHistoryId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/accounts/users/information/get-user-coin-deposit-history-with-user-coin-usage-history-id/${userCoinDepositHistoryIdInformation}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='account-name']").text(response.resultObj.accountName);
                getModalInformation.find("label[name='deposit-amount']").text(response.resultObj.depositAmount);
                getModalInformation.find("label[name='coins']").text(response.resultObj.coins);
                getModalInformation.find("label[name='deposit-method-name']").text(response.resultObj.depositMethodName);
                getModalInformation.find("label[name='transaction-id']").text(response.resultObj.transactionId);
                getModalInformation.find("label[name='deposit-status-name']").text(response.resultObj.depositStatusName);
                getModalInformation.find("label[name='remarks']").text(response.resultObj.remarks);
                getModalInformation.find("label[name='deposit-date']").text(new Date(response.resultObj.dateCreated).toLocaleTimeString() + " " + new Date(response.resultObj.dateCreated).toLocaleDateString());

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