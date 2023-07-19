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
        "url": "/accounts/users/get-users",
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
                if (!data.isDeleted && !data.isDisable) {
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
                if (data.phoneNumber === null || data.phoneNumber === '') {
                    return "";
                }
                else {
                    let icon = `<span style="color: #00ae98;"><i class="fa-sharp fa-solid fa-shield-check"></i></span>`;
                    return `<div class="d-flex gap-2 justify-content-center">${data.phoneNumber}${data.phoneNumberConfirmed === true ? icon : ""}</div>`
                }
            },
        },
        { "data": "firstName", "name": "FirstName", "Width": 110 },
        { "data": "lastName", "name": "LastName", "Width": 110 },
        {
            "render": function (row, type, data) {
                if (data.isDisable)
                    return "";

                if (!data.isDeleted) {
                    return `<span class='badge bg-success status'>Active</span>`;
                }
                else {
                    return `<span class='badge bg-secondary status'>Inactive</span>`;
                }
            },
        },
        {
            "render": function (row, type, data) {
                let userBehaviorCoinDepositHistories = `<a href="/accounts/users/${data.id}/information/coin-deposit-histories" title="Coin Deposit Histories" style="background: transparent; border: none; color: #ffbc69; padding: 0px;"><i class="bi bi-coin"></i></a>`;
                let userBehaviorCoinUsageHistories = `<a href="/accounts/users/${data.id}/information/coin-usage-histories" title="Coin Usage Histories" style="background: transparent; border: none; color: #7af3ff; padding: 0px; margin-left: 2px; margin-right: 2px;"><i class="bi bi-basket2"></i></a>`;
                let userBehaviorComments = `<a href="/accounts/users/${data.id}/comments" title="Comments" style="background: transparent; border: none; color: #cfff18; padding: 0px;"><i class="bi bi-chat-dots"></i></a>`;

                return `<div class="d-flex gap-2 justify-content-center">${userBehaviorCoinDepositHistories}${userBehaviorCoinUsageHistories}${userBehaviorComments}</div>`;
            },
        },
        {
            "render": function (row, type, data) {
                let optionLockUser = "";
                let optionDeleteUser = "";
                let optionInformation = "";

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

                optionInformation = `<a href='/accounts/users/${data.id}/information' class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a>`;

                if (data.isDisable)
                    return "";

                return `<div class="d-flex gap-2 justify-content-center">${optionInformation}${optionLockUser}${optionDeleteUser}</div>`;
            },
        },
    ]
});

usersDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted || row.data().isDisable) {
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
        return !element.isDisable;
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
            url: `/accounts/users/user-lock`,
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
            url: `/accounts/users/unlock-user`,
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
            usersDatatable.rows(`:has(td:eq(5):contains("Active"))`).select();
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
        url: `/accounts/users/delete-users`,
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
            url: `/accounts/users/delete-users`,
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
            url: `/accounts/users/restore-user`,
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

////#region information user
//var userIdInformation = null;
//function modalInformation(userId) {
//    userIdInformation = userId;

//    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
//        keyboard: false
//    })

//    $.ajax({
//        method: "GET",
//        url: `/accounts/users/get-user-by-user-id/${userId}`,
//    })
//        .done(function (response) {
//            if (response.isSuccessed === true) {
//                let getModalInformation = $("#modal-information");

//                getModalInformation.find("label[name='first-name']").text(response.resultObj.firstName);
//                getModalInformation.find("label[name='last-name']").text(response.resultObj.lastName);
//                getModalInformation.find("label[name='email']").text(response.resultObj.email);
//                getModalInformation.find("label[name='username']").text(response.resultObj.userName);
//                getModalInformation.find("label[name='phone-number']").text(response.resultObj.phoneNumber);
//                getModalInformation.find("label[name='date-of-birth']").text(new Date(response.resultObj.dob).toLocaleDateString());
//                getModalInformation.find("label[name='gender']").text(response.resultObj.genderName);
//                getModalInformation.find("label[name='is-active']").text(response.resultObj.isActive);

//                let roles = "";
//                for (let i = 0; i < response.resultObj.roles.length; i++) {
//                    roles += `<span class="badge rounded-pill text-white text-bg-secondary">${response.resultObj.roles[i]}</span>`
//                }
//                $("#roles").html(roles)

//                modalInformation.show();
//            }
//            else {
//                ShowToastError(response.message);
//            }
//        })
//        .fail(function (jqXHR, textStatus, errorThrown) {
//            ShowToastError(jqXHR.responseJSON.message);
//        });
//    return;

//}
////#endregion