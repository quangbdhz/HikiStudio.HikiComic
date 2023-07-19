//#region init artist datatable
var creatorRequestsDatatable = $("#creatorRequestsDatatable").DataTable({
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
        "url": "/creator-requests/get-creators",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false, "targets": 5
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
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.userRoleUpgradeRequestId}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        { "data": "email", "name": "Email", "Width": 110 },
        { "data": "phoneNumber", "name": "PhoneNumber", "Width": 110 },
        {
            "data": "status", "name": "Status",
            "render": function (row, type, data) {
                if (data.approvalStatus == 1) {
                    return `<span class="badge badge-pill bg-light-warning me-1">${data.status}</span>`;
                }
                else if (data.approvalStatus == 2) {
                    return `<span class="badge badge-pill bg-light-primary me-1">In Discussion</span>`;
                }
                else if (data.approvalStatus == 3) {
                    return `<span class="badge badge-pill bg-light-success me-1">${data.status}</span>`;
                }
                else {
                    return `<span class="badge badge-pill bg-light-danger me-1">${data.status}</span>`;
                }
            }
        },
        {
            "data": "dateCreated", "name": "DateCreated",
            "render": function (row, type, data) {
                return new Date(data.dateCreated).toLocaleDateString();
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
                if (data.approvalStatus == 1 || data.approvalStatus == 2) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" title="Approve" onclick="modalApprove('${data.userRoleUpgradeRequestId}', '${data.email}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-solid fa-square-check" style="color: #41b431;font-size: 18px;"></i></a><a href="javascript:void(0)" title="Exchange With User" onclick="modalExchange('${data.userRoleUpgradeRequestId}', '${data.email}')" class="btn btn-info link-edit" style="background: transparent;border: none;color: #435ebe;padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-solid fa-inbox" style="color: #42d0ff;font-size: 18px;"></i></a><a href="javascript:void(0)" title="Reject" onclick="modalReject('${data.userRoleUpgradeRequestId}', '${data.email}')" class="btn btn-info link-edit" style="background: transparent;border: none;color: #435ebe;padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-regular fa-rectangle-xmark" style="color: #f03838; font-size: 18px;"></i></a></div>`;
                }
                return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" title="Exchange With User" onclick="modalExchange('${data.userRoleUpgradeRequestId}', '${data.email}')" class="btn btn-info link-edit" style="background: transparent;border: none;color: #435ebe;padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-solid fa-inbox" style="color: #42d0ff;font-size: 18px;"></i></a></div>`;
            },
        },
        {
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center"><a title="Information" href="javascript:void(0)" onclick="modalInformation(${data.userRoleUpgradeRequestId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a></div>`;
            },
        },
    ]
});

creatorRequestsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#creatorRequestsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#creatorRequestsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#creatorRequestsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = creatorRequestsDatatable.data().count();
    var count = $('#creatorRequestsDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region approve
var userRoleUpgradeRequestIdApprove = -1;
function modalApprove(userRoleUpgradeRequestId, email) {
    let modalApprove = new bootstrap.Modal(document.getElementById('modal-approve'), {
        keyboard: false
    })
    userRoleUpgradeRequestIdApprove = userRoleUpgradeRequestId;
    modalApprove.show();
    $("#approve-email").html(`<b>${email}</b>`);
}

$("button#submit-approve").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-approve');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userRoleUpgradeRequestIdApprove !== null && userRoleUpgradeRequestIdApprove !== undefined && userRoleUpgradeRequestIdApprove > 0) {
        let createUserRoleUpgradeRequestRequest = {
            UserRoleUpgradeRequestId: userRoleUpgradeRequestIdApprove,
            approvalStatus: 3
        }

        $.ajax({
            method: "POST",
            url: `/creator-requests/change-status`,
            data: JSON.stringify(createUserRoleUpgradeRequestRequest),
            headers: {
                "Content-Type": "application/json;",
            },
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
                    ShowToastSuccess(response.message);
                    creatorRequestsDatatable.ajax.reload();
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
        ShowToastError("No creator selected for approve.");
    }
});
//#endregion

//#region exchange
var userRoleUpgradeRequestIdExchange = -1;
function modalExchange(userRoleUpgradeRequestId, email) {
    let modalExchange = new bootstrap.Modal(document.getElementById('modal-exchange'), {
        keyboard: false
    })

    $("#email-creator").html(email);

    $.ajax({
        method: "GET",
        url: `/creator-requests/get-exchanges/${userRoleUpgradeRequestId}`,
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
        beforeSend: function () {
            showLoadingOverlay();
        },
        complete: function () {
            hideLoadingOverlay();
        }
    })
        .done(function (response) {
            userRoleUpgradeRequestIdExchange = userRoleUpgradeRequestId;
            $('#box-exchanges').empty();

            $.each(response, function (index, item) {
                var html = '';
                if (item.isReader) {
                    html += '<div class="d-flex flex-row justify-content-start mb-4">';
                    html += '  <img class="avatar-circle" src="' + item.urlAvatar + '" alt="avatar 1">';
                    html += '  <div class="p-3 ms-3" style="border-radius: 15px; background-color: rgba(57, 192, 237,.2);">';
                    html += '    <p class="small mb-0" title="' + formatMMDDYYYYHHMM(item.dateCreated) + '">' + item.message + '</p>';
                    html += '  </div>';
                    html += '</div>';
                } else {
                    html += '<div class="d-flex flex-row justify-content-end mb-4">';
                    html += '  <div class="p-3 me-3 border" style="border-radius: 15px; background-color: #fbfbfb;">';
                    html += '    <p class="small mb-0 box-exchange-text-high-role" title="' + formatMMDDYYYYHHMM(item.dateCreated) + '">' + item.message + '</p>';
                    html += '  </div>';
                    html += '  <img class="avatar-circle" src="' + item.urlAvatar + '" alt="avatar 1">';
                    html += '</div>';
                }

                $('#box-exchanges').append(html);
            });

            let frameExchange = $("#frame-exchange");
            frameExchange.scrollTop(frameExchange[0].scrollHeight);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });

    modalExchange.show();
}

$("#send-message").click(function () {
    let message = $("#my-message").val();

    if (userRoleUpgradeRequestIdExchange !== -1) {
        let createUserRoleUpgradeExchangeRequest = {
            userRoleUpgradeRequestId: userRoleUpgradeRequestIdExchange,
            message: message
        }

        $.ajax({
            method: "POST",
            url: `/creator-requests/create-exchange`,
            data: JSON.stringify(createUserRoleUpgradeExchangeRequest),
            headers: {
                "Content-Type": "application/json;",
            },
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
                    if (response.message === "The account has been successfully upgraded.") {
                        ShowToastSuccess(response.message);
                    }

                    let html = '';

                    html += '<div class="d-flex flex-row justify-content-end mb-4">';
                    html += '  <div class="p-3 me-3 border" style="border-radius: 15px; background-color: #fbfbfb;">';
                    html += '    <p class="small mb-0 box-exchange-text-high-role" title="' + formatMMDDYYYYHHMM(response.resultObj.dateCreated) + '">' + response.resultObj.message + '</p>';
                    html += '  </div>';
                    html += '  <img class="avatar-circle" src="' + response.resultObj.urlAvatar + '" alt="avatar 1">';
                    html += '</div>';

                    $('#box-exchanges').append(html);
                    $("#my-message").val("");

                    let frameExchange = $("#frame-exchange");
                    frameExchange.scrollTop(frameExchange[0].scrollHeight);
                }
                else {
                    ShowToastError(response.message);
                }

                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
});

$("#modal-exchange-close").click(function () {
    creatorRequestsDatatable.ajax.reload();
});
//#endregion

//#region reject
var userRoleUpgradeRequestIdReject = 0;
function modalReject(userRoleUpgradeRequestId, email) {
    let modalReject = new bootstrap.Modal(document.getElementById('modal-reject'), {
        keyboard: false
    })
    userRoleUpgradeRequestIdReject = userRoleUpgradeRequestId;
    modalReject.show();
    $("#rejected-email").html(`<b>${email}</b>`);
}

$("button#submit-reject").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-reject');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (userRoleUpgradeRequestIdReject !== null && userRoleUpgradeRequestIdReject !== undefined && userRoleUpgradeRequestIdReject > 0) {
        let createUserRoleUpgradeRequestRequest = {
            UserRoleUpgradeRequestId: userRoleUpgradeRequestIdReject,
            approvalStatus: 4
        }

        $.ajax({
            method: "POST",
            url: `/creator-requests/change-status`,
            data: JSON.stringify(createUserRoleUpgradeRequestRequest),
            headers: {
                "Content-Type": "application/json;",
            },
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
                    ShowToastSuccess(response.message);
                    creatorRequestsDatatable.ajax.reload();
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
        ShowToastError("No creator selected for approve.");
    }
});
//#endregion

//#region information creator
var userRoleUpgradeRequestIdInformation = null;
function modalInformation(userRoleUpgradeRequestId) {
    userRoleUpgradeRequestIdInformation = userRoleUpgradeRequestId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/creator-requests/get-user-role-upgrade-request-by-user-role-upgrade-request-id/${userRoleUpgradeRequestId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='creator-email']").text(response.resultObj.email);
                getModalInformation.find("label[name='creator-username']").text(response.resultObj.userName);
                getModalInformation.find("label[name='creator-first-name']").text(response.resultObj.firstName);
                getModalInformation.find("label[name='creator-last-name']").text(response.resultObj.lastName);
                getModalInformation.find("label[name='creator-phone-number']").text(response.resultObj.phoneNumber);

                if (response.resultObj.approvalStatus == 1) {
                    getModalInformation.find("label[name='creator-status']").html(`<span class="badge badge-pill bg-light-warning me-1">${response.resultObj.status}</span>`);
                }
                else if (response.resultObj.approvalStatus == 2) {
                    getModalInformation.find("label[name='creator-status']").html(`<span class="badge badge-pill bg-light-primary me-1">In Discussion</span>`);
                }
                else if (response.resultObj.approvalStatus == 3) {
                    getModalInformation.find("label[name='creator-status']").html(`<span class="badge badge-pill bg-light-success me-1">${response.resultObj.status}</span>`);
                }
                else {
                    getModalInformation.find("label[name='creator-status']").html(`<span class="badge badge-pill bg-light-danger me-1">${response.resultObj.status}</span>`);
                }

                setStatusTextInField(getModalInformation, "creator-is-deleted", response.resultObj.isDeleted);
                getModalInformation.find(`label[name='creator-date-created']`).text(formatMMDDYYYYHHMM(response.resultObj.dateCreated));

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