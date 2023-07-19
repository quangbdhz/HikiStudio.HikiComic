//#region get information comic strip
var currentComicId = -1;
var currentComicSEOAlias = "";
$.ajax({
    async: false,
    method: "GET",
    url: `/comic/comic-information`,
})
    .done(function (response) {
        if (response.isSuccessed === true) {
            currentComicId = response.resultObj.id;
            currentComicSEOAlias = response.resultObj.comicSEOAlias;
            return;
        }
        else {
            ShowToastError(response.message);
        }
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        ShowToastError(jqXHR.responseJSON.message);
    });

//#endregion

//#region check creator
var isCreator = true;

$.ajax({
    method: "GET",
    url: `/comic/is-creator`,
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

if (currentComicSEOAlias !== "") {
    //#region get message toast
    const messageChapterCreate = localStorage.getItem('message-chapter-create');

    if (messageChapterCreate !== null && messageChapterCreate !== undefined && messageChapterCreate !== "") {
        ShowToastSuccess(messageChapterCreate);
        localStorage.removeItem('message-chapter-create');
    }

    const messageChapterUpdate = localStorage.getItem('message-chapter-update');

    if (messageChapterUpdate !== null && messageChapterUpdate !== undefined && messageChapterUpdate !== "") {
        ShowToastSuccess(messageChapterUpdate);
        localStorage.removeItem('message-chapter-update');
    }
    //#endregion

    //#region init chapter datatable
    var chaptersDatatable = $("#chaptersDatatable").DataTable({
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
            "url": `/comic/${currentComicSEOAlias}/get-chapters`,
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "orderable": false,
            "className": 'select-checkbox',
            "targets": 0,
        },
        {
            "orderable": false, "targets": 1
        },
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
            targets: [1]
        }],
        "select": {
            style: 'multi',
            selector: 'td:first-child'
        },
        "order": [],
        "columns": [
            {
                "render": function (row, type, data) {
                    if (!data.isDeleted) {
                        return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.chapterId}' /> `;
                    }
                    else {
                        return "";
                        //return `<input type='checkbox' disabled class='form-check-input bg-secondary ms' data-id='${data.chapterId}' />`;
                    }
                },
            },
            {
                "data": "chapterName", "name": "ChapterName",
                "render": function (row, type, data) {
                    return `<div class='text-wrap width-110'><a href="/comic/${currentComicSEOAlias}/${data.chapterSEOAlias}/chapter-detail" alt="${data.chapterName}" style="color: #c9cbd3;">${data.chapterName}</a></div>`
                }
            },
            { "data": "viewCount", "name": "ViewCount", "Width": 110 },
            {
                "data": "dateCreated", "name": "DateCreated",
                "render": function (row, type, data) {
                    return new Date(data.dateCreated).toLocaleDateString()
                }
            },
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
                        approved = `<a href="javascript:void(0)" title="Approve" onclick="modalApprove('${data.chapterId}', '${data.chapterName}')" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-solid fa-square-check" style="color: #41b431;font-size: 18px;"></i></a>`;
                        reject = `<a href="javascript:void(0)" title="Reject" onclick="modalReject('${data.chapterId}', '${data.chapterName}')" class="btn btn-info link-edit" style="background: transparent;border: none;color: #435ebe;padding: 0px;display: flex;justify-content: center;align-items: center;" ><i class="fa-regular fa-rectangle-xmark" style="color: #f03838; font-size: 18px;"></i></a>`;
                    }
                    return `<div class="d-flex gap-2 justify-content-center">${approved}${reject}</div >`;
                },
            },
            {
                "render": function (row, type, data) {
                    if (data.isDeleted) {
                        return `<div class="d-flex gap-2 justify-content-center"><a href='/comic/${currentComicSEOAlias}/${data.chapterSEOAlias}/chapter-detail' class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href='/comic/${currentComicSEOAlias}/${data.chapterSEOAlias}/update-chapter' class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.chapterId}', '${data.chapterName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                    }
                    else {
                        return `<div class="d-flex gap-2 justify-content-center"><a href='/comic/${currentComicSEOAlias}/${data.chapterSEOAlias}/chapter-detail' class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href='/comic/${currentComicSEOAlias}/${data.chapterSEOAlias}/update-chapter' class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.chapterId}', '${data.chapterName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                    }
                },
            },
        ]
    });

    chaptersDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
        let row = dt.row(cell.index().row);
        if (row.data().isDeleted) {
            e.preventDefault();
        }
    });

    $('#chaptersDatatable').on('page.dt', function () {
        $("#btn-deletecheckall").attr('disabled', 'true');
        $("#checkbox-all").prop('checked', false);
    });
    //#endregion

    //#region search, sort, check datatable
    $(document).ready(function () {
        $("#search").keyup(function () {
            $("#chaptersDatatable").dataTable().fnFilter(this.value);
            $("#checkbox-all").prop('checked', false);
            $("#btn-deletecheckall").attr('disabled', 'true');
        });
    });

    $(document).ready(function () {
        $('#chaptersDatatable_wrapper').find('div').first().remove();
    });

    $("th.sorting").on("click", function () {
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    })

    $('tbody').on('click', 'td', function () {
        var countRow = chaptersDatatable.data().count();
        var count = $('#chaptersDatatable tbody').find("input[type='checkbox']:checked").length;
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

    //#region delete multiple chapters
    $("#checkbox-all").click(function () {
        var data_list = $('#chaptersDatatable input[type="checkbox"].ms');

        $("#checkbox-all").change(function () {
            if (this.checked) {
                data_list.each(function () {
                    if (!this.disabled) {
                        $(this).prop('checked', true);
                    }
                });
                chaptersDatatable.rows(`:has(td:eq(4):contains("Active"))`).select();
                $("input#checkbox-all").addClass("selected");
            }
            else {
                data_list.each(function () {
                    if (!this.disabled) {
                        $(this).prop('checked', false);
                    }
                });
                chaptersDatatable.rows().deselect();
                $("input#checkbox-all").removeClass("selected");
            }
        });
    })

    $(window).change(function () {
        var data_list = $('#chaptersDatatable input[type="checkbox"].ms')
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
        var chapterIds = [];
        $('input[type="checkbox"]').each(function () {
            if ($(this).is(':checked')) {
                chapterIds.push($(this).data("id"))
            }
        });

        if (chapterIds[0] === null || chapterIds[0] === undefined) {
            chapterIds[0] = -1;
        }

        const deleteChapterComicsRequest = {
            chapterIds: chapterIds
        };

        $.ajax({
            method: "DELETE",
            url: `/comic/delete-chapters`,
            data: JSON.stringify(deleteChapterComicsRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    if (response.isSuccessed === true) {
                        ShowToastSuccess(response.message);
                        chaptersDatatable.ajax.reload();
                    }
                    else {
                        ShowToastError(response.message);
                    }

                    $("#btn-deletecheckall").attr('disabled', 'true');
                    chaptersDatatable.rows().deselect();
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

    //#region delete one chapter
    var chapterIdDeleteInLine;
    function modalDelete(chapterId, nameChapter) {
        let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
            keyboard: false
        })
        modalDelete.show();
        $("#name-chapter-delete-in-line").html(`<b>${nameChapter}</b>`);
        chapterIdDeleteInLine = chapterId;
    }

    $("button#btn-delete").on("click", function (event) {
        event.preventDefault();
        const truck_modal = document.querySelector('#modal-delete');
        const modal = bootstrap.Modal.getInstance(truck_modal);

        let chapterIds = [];
        chapterIds.push(chapterIdDeleteInLine);

        const deleteChapterComicRequest = {
            chapterIds: chapterIds
        };

        $.ajax({
            method: "DELETE",
            url: `/comic/delete-chapters`,
            data: JSON.stringify(deleteChapterComicRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    chaptersDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                chaptersDatatable.rows().deselect();
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

    //#region restore chapter
    var chapterIdRestore = null;
    function modalRestore(chapterId, nameChapter) {
        let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
            keyboard: false
        })
        modalRestore.show();
        $("#name-chapter-restore").html(`<b>${nameChapter}</b>`);
        chapterIdRestore = chapterId;
    }

    $("button#submit-restore-chapter").on("click", function (event) {
        event.preventDefault();
        const truck_modal = document.querySelector('#modal-restore');
        const modal = bootstrap.Modal.getInstance(truck_modal);

        if (chapterIdRestore !== null && chapterIdRestore !== undefined && chapterIdRestore > 0) {
            let chapterId = chapterIdRestore;

            $.ajax({
                method: "POST",
                url: `/comic/restore-chapter`,
                data: JSON.stringify(chapterId),
                headers: {
                    "Content-Type": "application/json;",
                },
                datatype: 'json',
            })
                .done(function (response) {
                    if (response.isSuccessed === true) {
                        ShowToastSuccess(response.message);
                        chaptersDatatable.ajax.reload();
                        chapterIdRestore = null;
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
            ShowToastError("No chapter selected for restoring.");
        }
    });
    //#endregion

}
else {

}

//#region approve
var chapterIdApprove = -1;
function modalApprove(chapterId, chapterName) {
    let modalApprove = new bootstrap.Modal(document.getElementById('modal-approve'), {
        keyboard: false
    })
    chapterIdApprove = chapterId;
    modalApprove.show();
    $("#approve-chapter-name").html(`<b>${chapterName}</b>`);
}

$("button#submit-approve").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-approve');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (chapterIdApprove !== null && chapterIdApprove !== undefined && chapterIdApprove > 0) {
        let chapterId = chapterIdApprove;

        $.ajax({
            method: "POST",
            url: `/comic/approve-chapter`,
            data: JSON.stringify(chapterId),
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
                    chaptersDatatable.ajax.reload();
                    chapterIdApprove = -1;
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
        ShowToastError("No chapter selected for approve.");
    }
});
//#endregion

//#region reject
var chapterIdReject = 0;
function modalReject(chapterId, chapterName) {
    let modalReject = new bootstrap.Modal(document.getElementById('modal-reject'), {
        keyboard: false
    })
    chapterIdReject = chapterId;
    modalReject.show();
    $("#rejected-chapter-name").html(`<b>${chapterName}</b>`);
}

$("button#submit-reject").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-reject');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (chapterIdReject !== null && chapterIdReject !== undefined && chapterIdReject > 0) {
        let feedback = $("#reject-feedback").val();

        $.ajax({
            method: "POST",
            url: `/comic/reject-chapter/${chapterIdReject}`,
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
                    chaptersDatatable.ajax.reload();
                    chapterIdReject = -1;
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
        ShowToastError("No chapter selected for approve.");
    }
});
//#endregion