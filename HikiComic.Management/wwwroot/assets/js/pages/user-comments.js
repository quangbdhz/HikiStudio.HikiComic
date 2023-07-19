//#region get userId
const url = window.location.href;
const regex = /\/([a-fA-F0-9-]+)\/comments/;
const matches = url.match(regex);
const userIdLocal = matches ? matches[1] : null;
//#endregion

//#region init comment datatable
var commentsDatatable = $("#commentsDatatable").DataTable({
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
        "url": `/accounts/users/${userIdLocal}/get-comments`,
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    { 
        "orderable": false, "targets": 4 
    },
    {
        className: "text-start",
        targets: [1]
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
                if (data.isDeleted === false) {
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.commentId}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        { "data": "commentContent", "name": "CommentContent", "Width": 110 },
        { "data": "comicName", "name": "comicName", "Width": 110, "className": "comic-name-column" },
        {
            "data": "dateCreated", "name": "DateCreated",
            "render": function (row, type, data) {
                return new Date(data.dateCreated).toLocaleDateString()
            }
        },
        {
            "render": function (row, type, data) {
                if (data.isDeleted === false) {
                    return "<span class='badge bg-success status'>Active</span>";
                }
                else {
                    return "<span class='badge bg-secondary status'>Inactive</span>";
                }
            },
        },
        {
            "render": function (row, type, data) {
                if (data.isDeleted === true) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.commentId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.commentId}', '${data.commentContent}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.commentId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.commentId}', '${data.commentContent}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

commentsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted) {
        e.preventDefault();
    }
});

$('#commentsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#commentsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#commentsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = commentsDatatable.data().count();
    var count = $('#commentsDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region delete multiple comments
$("#checkbox-all").click(function () {
    var data_list = $('#commentsDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            commentsDatatable.rows(`:has(td:eq(4):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            commentsDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    var data_list = $('#commentsDatatable input[type="checkbox"].ms')
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
    var commentIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            commentIds.push($(this).data("id"))
        }
    });

    if (commentIds[0] === null || commentIds[0] === undefined) {
        commentIds[0] = -1;
    }

    const deleteCommentsRequest = {
        commentIds: commentIds
    };

    $.ajax({
        method: "DELETE",
        url: `/accounts/users/delete-comments`,
        data: JSON.stringify(deleteCommentsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    commentsDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-deletecheckall").attr('disabled', 'true');
                commentsDatatable.rows().deselect();
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

//#region delete one comments
var commentIdDelete;
function modalDelete(commentId, commentContent) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#commentIdDelete").html(`<b>${commentContent}</b>`);
    commentIdDelete = commentId;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    let commentIds = [];
    commentIds.push(commentIdDelete);

    const deleteArtistsRequest = {
        commentIds: commentIds
    };

    $.ajax({
        method: "DELETE",
        url: `/accounts/users/delete-comments`,
        data: JSON.stringify(deleteArtistsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                commentsDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            commentsDatatable.rows().deselect();
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

//#region restore comment
var commentIdRestore = null;
function modalRestore(commentId, commentContent) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#artist-name-restore").html(`<b>${commentContent}</b>`);
    commentIdRestore = commentId;
}

$("button#submit-restore-artist").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (commentIdRestore !== null && commentIdRestore !== undefined && commentIdRestore > 0) {
        let commentId = commentIdRestore;

        $.ajax({
            method: "POST",
            url: `/accounts/users/restore-comment`,
            data: JSON.stringify(commentId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    commentsDatatable.ajax.reload();
                    commentIdRestore = null;
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
        ShowToastError("No artist selected for restoring.");
    }
});
//#endregion

//#region information artist
var commentIdInformation = null;
function modalInformation(commentId) {
    commentIdInformation = commentId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/accounts/users/get-comment-by-comment-id/${commentId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='comment-content']").text(response.resultObj.commentContent);
                getModalInformation.find("label[name='comic-name']").text(response.resultObj.comicName);
                getModalInformation.find("label[name='comment-dislike']").text(response.resultObj.dislike);
                getModalInformation.find("label[name='comment-like']").text(response.resultObj.like);
                setStatusTextInField(getModalInformation, "comment-is-active", response.resultObj.isDeleted);
                getModalInformation.find("label[name='comment-date-created']").text(formatMMDDYYYYHHMM(response.resultObj.dateCreated));

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