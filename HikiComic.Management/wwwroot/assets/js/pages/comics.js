//#region get message toast
const messageComicCreate = localStorage.getItem('message-comic-create');

if (messageComicCreate !== null && messageComicCreate !== undefined && messageComicCreate !== "") {
    ShowToastSuccess(messageComicCreate);
    localStorage.removeItem('message-comic-create');
}

const messageComicUpdate = localStorage.getItem('message-comic-update');

if (messageComicUpdate !== null && messageComicUpdate !== undefined && messageComicUpdate !== "") {
    ShowToastSuccess(messageComicUpdate);
    localStorage.removeItem('message-comic-update');
}
//#endregion

//#region check creator
var isCreator = true;

$.ajax({
    method: "GET",
    url: `/comics/is-creator`,
    async: false, 
    datatype: 'json',
})
    .done(function (response) {
        if (response.isSuccessed === true) {
            isCreator = response.resultObj;
        }
        else {
            ShowToastError(response.message);
        }
        return;
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        ShowToastError(jqXHR.responseJSON.message);
    });
//#endregion

//#region init comic datatable
var comicsDatatable = $("#comicsDatatable").DataTable({
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
        "url": "/comics/get-comics",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    { 
        "orderable": false, "targets": [5]
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
                if (!data.isDeleted) {
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.comicId}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        {
            "data": "comicName", "name": "ComicName",
            "render": function (row, type, data) {
                return `<div class='text-wrap width-110'><a href="/comic/${data.comicSEOAlias}" alt="${data.comicName}" style="color: #c9cbd3;">${data.comicName}</a></div>`
            }
        },
        {
            "data": "name", "name": "DateCreated",
            "render": function (row, type, data) {
                return new Date(data.dateCreated).toLocaleDateString()
            }
        },
        { "data": "viewCount", "name": "ViewCount", "Width": 110 },
        {
            "data": "stringApprovalStatus", "name": "StringApprovalStatus",
            "render": function (row, type, data) {
                if (data.approvalStatus == 1) {
                    return `<span class="badge badge-pill bg-light-warning me-1">${data.stringApprovalStatus}</span>`;
                }
                else if (data.approvalStatus == 2) {
                    return `<span class="badge badge-pill bg-light-primary me-1">In Discussion</span>`;
                }
                else if (data.approvalStatus == 3) {
                    return `<span class="badge badge-pill bg-light-success me-1">${data.stringApprovalStatus}</span>`;
                }
                else {
                    return `<span class="badge badge-pill bg-light-danger me-1">${data.stringApprovalStatus}</span>`;
                }
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
                let reject = "";
                let approved = ""

                if (data.approvalStatus === 1 && !isCreator) {
                    approved = `<a href="javascript:void(0)" title="Approve" onclick="modalApprove('${data.comicId}', '${data.comicName}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-solid fa-square-check" style="color: #41b431;font-size: 18px;"></i></a>`;
                    reject = `<a href="javascript:void(0)" title="Reject" onclick="modalReject('${data.comicId}', '${data.comicName}')" class="btn btn-info link-edit" style="background: transparent;border: none;color: #435ebe;padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-regular fa-rectangle-xmark" style="color: #f03838; font-size: 18px;"></i></a>`;
                }

                let userBehaviorComments = `<a href="/comics/get-comic-by-comic-seo-alias/${data.comicSEOAlias}/comments" title="Comments" style="background: transparent; border: none; color: #cfff18; padding: 0px;"><i class="bi bi-chat-dots"></i></a>`;

                return `<div class="d-flex gap-2 justify-content-center">${approved}${userBehaviorComments}${reject}</div >`;
            },
        },
        {
            "render": function (row, type, data) {
                if (data.isDeleted) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="/comics/${data.comicSEOAlias}/comic-information" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="/comics/${data.comicSEOAlias}/update-comic" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.comicId}', '${data.comicName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a  href="/comics/${data.comicSEOAlias}/comic-information" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="/comics/${data.comicSEOAlias}/update-comic" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.comicId}', '${data.comicName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

comicsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted) {
        e.preventDefault();
    }
});

$('#comicsDatatable').on('page.dt', function () {
    $("#btn-multiple-delete-comics").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#comicsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-multiple-delete-comics").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#comicsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-multiple-delete-comics").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = comicsDatatable.data().count();
    var count = $('#comicsDatatable tbody').find("input[type='checkbox']:checked").length;
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
        $("#btn-multiple-delete-comics").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-comics").attr('disabled', 'true');
    }

    if (count == countRow) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
});
//#endregion

//#region delete multiple comics
$("#checkbox-all").click(function () {
    let data_list = $('#comicsDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            comicsDatatable.rows(`:has(td:eq(5):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            comicsDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    let data_list = $('#comicsDatatable input[type="checkbox"].ms')
    let sum_checked = 0;

    data_list.each(function () {
        if ($(this).is(':checked')) {
            sum_checked += 1;
        }
    });

    if (sum_checked > 0) {
        $("#btn-multiple-delete-comics").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-comics").attr('disabled', 'true');
    }

    if ((data_list.length) == sum_checked) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
})

$("#submit-delete-comics-multiple").click(function () {
    var comicIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            comicIds.push($(this).data("id"))
        }
    });

    if (comicIds[0] === null || comicIds[0] === undefined) {
        comicIds[0] = -1;
    }

    const deleteComicsRequest = {
        comicIds: comicIds
    };

    $.ajax({
        method: "DELETE",
        url: `/comics/delete-comics`,
        data: JSON.stringify(deleteComicsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    comicsDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-multiple-delete-comics").attr('disabled', 'true');
                comicsDatatable.rows().deselect();
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

//#region detete one comic 
var comicIdDeleteInLine;
function modalDelete(comicId, nameComic) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#comic-name-delete").html(`<b>${nameComic}</b>`);
    comicIdDeleteInLine = comicId;
}

$("button#submit-delete-comic").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (comicIdDeleteInLine !== null && comicIdDeleteInLine !== undefined && comicIdDeleteInLine > 0) {
        let comicIds = [];
        comicIds.push(comicIdDeleteInLine);

        const deleteComicsRequest = {
            comicIds: comicIds
        };

        $.ajax({
            method: "DELETE",
            url: `/comics/delete-comics`,
            data: JSON.stringify(deleteComicsRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    comicsDatatable.ajax.reload();
                    comicIdDeleteInLine = null;
                }
                else {
                    ShowToastError(response.message);
                }

                comicsDatatable.rows().deselect();
                $("#btn-multiple-delete-comics").attr('disabled', 'true');
                $('input[type="checkbox"]').prop('checked', false);
                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No comic selected for delete.");
    }
});
//#endregion

//#region restore comic
var comicIdRestore = null;
function modalRestore(comicId, nameComic) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#comic-name-restore").html(`<b>${nameComic}</b>`);
    comicIdRestore = comicId;
}

$("button#submit-restore-comic").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (comicIdRestore !== null && comicIdRestore !== undefined && comicIdRestore > 0) {
        let comicId = comicIdRestore;

        $.ajax({
            method: "POST",
            url: `/comics/restore-comic`,
            data: JSON.stringify(comicId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    comicsDatatable.ajax.reload();
                    comicIdRestore = null;
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
        ShowToastError("No comic selected for restoring.");
    }
});
//#endregion


//#region approve
var comicIdApprove = -1;
function modalApprove(comicId, comicName) {
    let modalApprove = new bootstrap.Modal(document.getElementById('modal-approve'), {
        keyboard: false
    })
    comicIdApprove = comicId;
    modalApprove.show();
    $("#approve-comic-name").html(`<b>${comicName}</b>`);
}

$("button#submit-approve").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-approve');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (comicIdApprove !== null && comicIdApprove !== undefined && comicIdApprove > 0) {
        let comicId = comicIdApprove;

        $.ajax({
            method: "POST",
            url: `/comics/approve-comic`,
            data: JSON.stringify(comicId),
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
                    comicsDatatable.ajax.reload();
                    comicIdApprove = -1;
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
        ShowToastError("No comic selected for approve.");
    }
});
//#endregion

//#region reject
var comicIdReject = 0;
function modalReject(comicId, comicName) {
    let modalReject = new bootstrap.Modal(document.getElementById('modal-reject'), {
        keyboard: false
    })
    comicIdReject = comicId;
    modalReject.show();
    $("#rejected-comic-name").html(`<b>${comicName}</b>`);
}

$("button#submit-reject").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-reject');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (comicIdReject !== null && comicIdReject !== undefined && comicIdReject > 0) {
        let feedback = $("#reject-feedback").val();

        $.ajax({
            method: "POST",
            url: `/comics/reject-comic/${comicIdReject}`,
            data: JSON.stringify(feedback),
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
                    comicsDatatable.ajax.reload();
                    comicIdReject = -1;
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
        ShowToastError("No comic selected for approve.");
    }
});
//#endregion