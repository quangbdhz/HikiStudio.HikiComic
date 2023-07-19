//#region init user datatable
var userCOINUsageHistoriesDatatable = $("#userCOINUsageHistoriesDatatable").DataTable({
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
        "url": "/accounts/users/get-user-coin-usage-histories",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [
        {
            "orderable": false, "targets": 1
        },
        {
            "orderable": false, "targets": 2
        },
        {
            "orderable": false, "targets": 4
        }],
    "order": [[3, 'desc']],
    "columns": [
        {
            "data": "usageAmount", "name": "UsageAmount",
            "render": function (row, type, data) {
                return data.usageAmount.toString().replace(/(?:(^\d{1,3})(?=(?:\d{3})*$)|(\d{3}))(?!$)/mg, '$1$2.');
            },
        },
        {
            "data": "usageMethodName", "name": "UsageMethodName",
            "render": function (row, type, data) {
                if (data.usageMethodName === "ReadComics") {
                    return "Read Comics";
                }
                else if (data.usageStatusName === "ChangeNickname") {
                    return "Change Nickname";
                }
                else {
                    return "Change Avatar";
                }
            },
        },
        {
            "data": "usageStatusName", "name": "UsageStatusName",
            "render": function (row, type, data) {
                if (data.usageStatusName === "Pending") {
                    return "<span class='badge bg-warning status'>Pending</span>";
                }
                else if (data.usageStatusName === "Completed") {
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
                return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.userCoinUsageHistoryId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a></div>`;
            },
        },
    ]
});

userCOINUsageHistoriesDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isActive === false) {
        e.preventDefault();
    }
});

$(document).ready(function () {
    $("#search").keyup(function () {
        $("#userCOINUsageHistoriesDatatable").dataTable().fnFilter(this.value);
    });
});

//#endregion

//#region information artist
var userCoinUsageHistoryIdInformation = null;
function modalInformation(artistId) {
    userCoinUsageHistoryIdInformation = artistId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/accounts/users/information/user-coin-usage-histories/get-user-coin-usage-history-with-user-coin-usage-history-id/${userCoinUsageHistoryIdInformation}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='account-name']").text(response.resultObj.accountName);
                getModalInformation.find("label[name='usage-amount']").text(response.resultObj.usageAmount);
                getModalInformation.find("label[name='usage-method-name']").text(response.resultObj.usageMethodName);
                getModalInformation.find("label[name='usage-status-name']").text(response.resultObj.usageStatusName);
                getModalInformation.find("label[name='usage-date']").text(new Date(response.resultObj.dateCreated).toLocaleTimeString() + " " + new Date(response.resultObj.dateCreated).toLocaleDateString());

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