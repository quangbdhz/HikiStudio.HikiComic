//#region init author datatable
var authorsDataTable = $("#authorsDatatable").DataTable({
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
        "url": "/authors/get-authors",
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
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.authorId}' /> `;
                }
                else {
                    return "";
                    //return `<input type='checkbox' disabled class='form-check-input bg-secondary ms' data-id='${data.id}' />`;
                }
            },
        },
        { "data": "authorName", "name": "AuthorName", "Width": 110 },
        { "data": "alternative", "name": "Alternative", "Width": 110 },
        { "data": "authorSEOAlias", "name": "AuthorSEOAlias", "Width": 110 },
        {
            "data": "name", "name": "DateCreated",
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
                if (data.isDeleted) {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.authorId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.authorId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.authorId}', '${data.authorName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.authorId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.authorId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.authorId}', '${data.authorName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

authorsDataTable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted) {
        e.preventDefault();
    }
});

$('#authorsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#authorsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#authorsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = authorsDataTable.data().count();
    var count = $('#authorsDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region validation form create author
function CheckEnableSaveChange(event) {
    if ($('#form-create-author').validate().checkForm()) {
        $("#submit-create-author").removeAttr("disabled");
    }
    else {
        $("#submit-create-author").attr("disabled", "disabled");
    }
    return true;
}

$('#summary').on('input', function () {
    let summary = $("#summary").val();

    if (this.scrollHeight <= 44 || summary === null || summary === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }

    this.style.height = (this.scrollHeight) + 'px';
});

$(document).on('click', '#btn-create', function () {
    $("#submit-create-author").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-author').find("input[name='CreateDate']").val(today);
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

    var formValidateCreate = $("#form-create-author").validate({
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
            "author-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
                //validateName: true,
            },
            "alternative": {
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
            "summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 1000,
            },
            "author-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "author-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "author-name": {
                required: "Please enter Author Name.",
                notFullSpaceName: "Please enter Author Name.",
                minlength: "Author Name must be from 2 to 32 characters.",
                maxlength: "Author Name must be from 2 to 32 characters.",
                //validateName: "Numeric and Special characters are not allowed.",
            },
            "alternative": {
                notFullSpaceName: "Please enter Alternative.",
                minlength: "Alternative must be from 2 to 32 characters.",
                maxlength: "Alternative must be from 2 to 32 characters.",
            },
            "summary": {
                required: "Please enter Summary.",
                notFullSpaceName: "Please enter Summary.",
                minlength: "Summary must be from 10 to 1000 characters.",
                maxlength: "Summary must be from 10 to 1000 characters.",
            },
            "author-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "author-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let authorName = $(form).find('input[name="author-name"]').val();
            let alternative = $(form).find('input[name="alternative"]').val();
            let summary = $(form).find('textarea[name="summary"]').val();
            let authorSEOSummary = $(form).find('input[name="author-seo-summary"]').val();
            let authorSEOTitle = $(form).find('input[name="author-seo-title"]').val();

            let createAuthorDataRequest = {
                authorName: authorName,
                alternative: alternative,
                summary: summary,
                authorSEOSummary: authorSEOSummary,
                authorSEOTitle: authorSEOTitle
            };

            $.ajax({
                method: "POST",
                url: `authors/create-author`,
                data: JSON.stringify(createAuthorDataRequest),
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

                        $('#form-create-author :input[type="text"]').val('');
                        $('#form-create-author :input[type="date"]').val('');
                        authorsDataTable.ajax.reload();
                        $("#form-create-author").validate().resetForm();
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

    $(document).on('click', '#cancel-create-author', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-author :input[type="text"]').val('');
        $('#form-create-author :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit author
var authorIdEdit = null;
function modalEdit(authorId) {
    authorIdEdit = authorId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-author').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/authors/get-author-by-author-id/${authorId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='author-name']").val(response.resultObj.authorName);
                getModalEdit.find("input[name='alternative']").val(response.resultObj.alternative);
                getModalEdit.find("textarea[name='summary']").val(response.resultObj.summary);
                getModalEdit.find("input[name='author-seo-summary']").val(response.resultObj.authorSEOSummary);
                getModalEdit.find("input[name='author-seo-title']").val(response.resultObj.authorSEOTitle);
                getModalEdit.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-author'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-author').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-author').prop('disabled', true);
                    }
                    if ($("#form-edit-author").valid() == false) {
                        $('#submit-edit-author').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-author").validate({
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
            "author-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
            "alternative": {
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
            },
            "summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 1000,
            },
            "author-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "author-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "author-name": {
                required: "Please enter Author Name.",
                notFullSpaceName: "Please enter Author Name.",
                minlength: "Author Name must be from 2 to 32 characters.",
                maxlength: "Author Name must be from 2 to 32 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "alternative": {
                notFullSpaceName: "Please enter Alternative.",
                minlength: "Alternative must be from 2 to 32 characters.",
                maxlength: "Alternative must be from 2 to 32 characters.",
            },
            "summary": {
                required: "Please enter Summary.",
                notFullSpaceName: "Please enter Summary.",
                minlength: "Summary must be from 10 to 1000 characters.",
                maxlength: "Summary must be from 10 to 1000 characters.",
            },
            "author-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "author-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let authorName = $(form).find('input[name="author-name"]').val();
            let alternative = $(form).find('input[name="alternative"]').val();
            let summary = $(form).find('textarea[name="summary"]').val();
            let authorSEOSummary = $(form).find('input[name="author-seo-summary"]').val();
            let authorSEOTitle = $(form).find('input[name="author-seo-title"]').val();

            let updateAuthorDataRequest = {
                authorName: authorName,
                alternative: alternative,
                summary: summary,
                authorSEOSummary: authorSEOSummary,
                authorSEOTitle: authorSEOTitle
            };

            if (authorIdEdit !== null && authorIdEdit !== undefined && authorIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `authors/update-author/${authorIdEdit}`,
                    data: JSON.stringify(updateAuthorDataRequest),
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
                        authorIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-author :input[type="text"]').val('');
                            $('#form-edit-author :input[type="date"]').val('');
                            authorsDataTable.ajax.reload();
                            $("#form-edit-author").validate().resetForm();
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
                ShowToastError("No author selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-author', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-author :input[type="text"]').val('');
        $('#form-edit-author :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete multiple authors
$("#checkbox-all").click(function () {
    var data_list = $('#authorsDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            authorsDataTable.rows(`:has(td:eq(5):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            authorsDataTable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    var data_list = $('#authorsDatatable input[type="checkbox"].ms')
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
    var authorIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            authorIds.push($(this).data("id"))
        }
    });

    if (authorIds[0] === null || authorIds[0] === undefined) {
        authorIds[0] = -1;
    }

    const deleteAuthorsRequest = {
        authorIds: authorIds
    };

    $.ajax({
        method: "DELETE",
        url: `/authors/delete-authors`,
        data: JSON.stringify(deleteAuthorsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    authorsDataTable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-deletecheckall").attr('disabled', 'true');
                authorsDataTable.rows().deselect();
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

//#region delete one author
var authorIdDelete;
function modalDelete(authorId, authorName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#authorIdDelete").html(`<b>${authorName}</b>`);
    authorIdDelete = authorId;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    let authorIds = [];
    authorIds.push(authorIdDelete);

    const deleteAuthorsRequest = {
        authorIds: authorIds
    };

    $.ajax({
        method: "DELETE",
        url: `/authors/delete-authors`,
        data: JSON.stringify(deleteAuthorsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                authorsDataTable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            authorsDataTable.rows().deselect();
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

//#region restore author
var authorIdRestore = null;
function modalRestore(authorId, authorName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#author-name-restore").html(`<b>${authorName}</b>`);
    authorIdRestore = authorId;
}

$("button#submit-restore-author").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (authorIdRestore !== null && authorIdRestore !== undefined && authorIdRestore > 0) {
        let authorId = authorIdRestore;

        $.ajax({
            method: "POST",
            url: `/authors/restore-author`,
            data: JSON.stringify(authorId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    authorsDataTable.ajax.reload();
                    authorIdRestore = null;
                }
                else {
                    ShowToastError(response.message);
                }

                //authorsDataTable.rows().deselect();
                //$('input[type="checkbox"]').prop('checked', false);
                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No author selected for restoring.");
    }
    //let authorIds = [];
    //authorIds.push(localAuthorId);

    
});
//#endregion

//#region information author
var authorIdInformation = null;
function modalInformation(authorId) {
    authorIdInformation = authorId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/authors/get-author-by-author-id/${authorId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='author-name']").text(response.resultObj.authorName);
                getModalInformation.find("label[name='alternative']").text(response.resultObj.alternative);
                getModalInformation.find("label[name='author-seo-alias']").text(response.resultObj.authorSEOAlias);
                getModalInformation.find("label[name='summary']").text(response.resultObj.summary);
                getModalInformation.find("label[name='author-seo-summary']").text(response.resultObj.authorSEOSummary);
                getModalInformation.find("label[name='author-seo-title']").text(response.resultObj.authorSEOTitle);

                setStatusTextInField(getModalInformation, "author-is-deleted", response.resultObj.isDeleted);
                setInfoUserCreateAndUpdateObject(getModalInformation, "author", response);

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