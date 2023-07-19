//#region init genre datatable
var genresDatatable = $("#genresDatatable").DataTable({
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
        "url": "/genres/get-genres",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    { 
        "orderable": false, "targets": 3 
    },
    { 
        "orderable": false, "targets": 4 
    },
    { 
        "orderable": false, "targets": 5 
    },
    {
        className: "text-start",
        targets: [1, 2, 3]
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
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.genreId}' /> `;
                }
                else {
                    return "";
                }
            },
        },
        { "data": "genreName", "name": "GenreName", "Width": 70 },
        { "data": "genreSEOAlias", "name": "GenreSEOAlias", "Width": 70 },
        { "data": "summary", "name": "Summary", "Width": 300 },
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
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.genreId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.genreId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.genreId}', '${data.genreName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.genreId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.genreId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.genreId}', '${data.genreName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

genresDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#genresDatatable').on('page.dt', function () {
    $("#btn-multiple-delete-genre").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#genresDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-multiple-delete-genre").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#genresDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-multiple-delete-genre").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = genresDatatable.data().count();
    var count = $('#genresDatatable tbody').find("input[type='checkbox']:checked").length;
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
        $("#btn-multiple-delete-genre").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-genre").attr('disabled', 'true');
    }

    if (count == countRow) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
});
//#endregion

//#region validation form create genre
function CheckEnableSaveChange() {
    if ($('#form-create-genre').validate().checkForm()) {
        $("#submit-create-genre").removeAttr("disabled");
    }
    else {
        $("#submit-create-genre").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-genre").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-genre').find("input[name='CreateDate']").val(today);
});

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

$('#summary-update').on('input', function () {
    let summary = $("#summary-update").val();

    if (this.scrollHeight <= 44 || summary === null || summary === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }
    this.style.height = (this.scrollHeight) + 'px';
});

$('#summary-update').click('input', function () {
    let summary = $("#summary-update").val();

    if (this.scrollHeight <= 44 || summary === null || summary === "") {
        this.style.height = '43px';
    }
    else {
        this.style.height = 'auto';
    }
    this.style.height = (this.scrollHeight) + 'px';
});

$(document).ready(function () {
    $.validator.addMethod("validateName", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z\s]+\s*$/.test(value);
    }, 'Numeric and Special characters are not allowed.');

    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    $('input').on('blur keyup', function () {
        CheckEnableSaveChange();
    })

    var formValidateCreate = $("#form-create-genre").validate({
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
            "genre-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 25,
                validateName: true,
            },
            "summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 1000,
            },
            "genre-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "genre-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "genre-name": {
                required: "Please enter Genre Name.",
                notFullSpaceName: "Please enter Genre Name.",
                minlength: "Genre Name must be from 2 to 25 characters.",
                maxlength: "Genre Name must be from 2 to 25 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "summary": {
                notFullSpaceName: "Please enter Summary.",
                minlength: "Summary must be from 10 to 1000 characters.",
                maxlength: "Summary must be from 10 to 1000 characters.",
            },
            "genre-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "genre-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let genreName = $(form).find('input[name="genre-name"]').val();
            let summary = $(form).find('textarea[name="summary"]').val();
            let genreSEOSummary = $(form).find('input[name="genre-seo-summary"]').val();
            let genreSEOTitle = $(form).find('input[name="genre-seo-title"]').val();

            let createGenreRequest = {
                genreName: genreName,
                summary: summary,
                genreSEOSummary: genreSEOSummary,
                genreSEOTitle: genreSEOTitle,
                isShowHome: false,
                genreImageURL: "#"
            };

            $.ajax({
                method: "POST",
                url: `genres/create-genre`,
                data: JSON.stringify(createGenreRequest),
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

                        $('#form-create-genre :input[type="text"]').val('');
                        $('#summary').val('');
                        genresDatatable.ajax.reload();
                        $("#form-create-genre").validate().resetForm();
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

    $(document).on('click', '#cancel-create-genre', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-genre :input[type="text"]').val('');
        $('#summary').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit genre
var genreIdEdit = null;
function modalEdit(genreId) {
    genreIdEdit = genreId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-genre').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/genres/get-genre-by-genre-id/${genreId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='genre-name']").val(response.resultObj.genreName);
                getModalEdit.find("textarea[name='summary']").val(response.resultObj.summary);
                getModalEdit.find("input[name='genre-seo-summary']").val(response.resultObj.genreSEOSummary);
                getModalEdit.find("input[name='genre-seo-title']").val(response.resultObj.genreSEOTitle);

                var $form = $('#form-edit-genre'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-genre').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-genre').prop('disabled', true);
                    }
                    if ($("#form-edit-genre").valid() == false) {
                        $('#submit-edit-genre').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-genre").validate({
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
            "summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 1000,
            },
            "genre-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "genre-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "summary": {
                notFullSpaceName: "Please enter Summary.",
                minlength: "Summary must be from 10 to 1000 characters.",
                maxlength: "Summary must be from 10 to 1000 characters.",
            },
            "genre-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "genre-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let summary = $(form).find('textarea[name="summary"]').val();
            let genreSEOSummary = $(form).find('input[name="genre-seo-summary"]').val();
            let genreSEOTitle = $(form).find('input[name="genre-seo-title"]').val();

            let updategenreRequest = {
                summary: summary,
                genreSEOSummary: genreSEOSummary,
                genreSEOTitle: genreSEOTitle
            };

            if (genreIdEdit !== null && genreIdEdit !== undefined && genreIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `genres/update-genre/${genreIdEdit}`,
                    data: JSON.stringify(updategenreRequest),
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
                        genreIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-genre :input[type="text"]').val('');
                            $('#summary-update').val('');
                            genresDatatable.ajax.reload();
                            $("#form-edit-genre").validate().resetForm();
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
                ShowToastError("No genre selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-genre', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-genre :input[type="text"]').val('');
        $('#form-edit-genre :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete multiple genres
$("#checkbox-all").click(function () {
    let data_list = $('#genresDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            genresDatatable.rows(`:has(td:eq(4):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            genresDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    let data_list = $('#genresDatatable input[type="checkbox"].ms')
    let sum_checked = 0;

    data_list.each(function () {
        if ($(this).is(':checked')) {
            sum_checked += 1;
        }
    });

    if (sum_checked > 0) {
        $("#btn-multiple-delete-genre").removeAttr('disabled');
    } else {
        $("#btn-multiple-delete-genre").attr('disabled', 'true');
    }

    if ((data_list.length) == sum_checked) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
})

$("#submit-delete-genre-multiple").click(function () {
    var genreIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            genreIds.push($(this).data("id"))
        }
    });

    if (genreIds[0] === null || genreIds[0] === undefined) {
        genreIds[0] = -1;
    }

    const deleteGenresRequest = {
        genreIds: genreIds
    };

    $.ajax({
        method: "DELETE",
        url: `/genres/delete-genres`,
        data: JSON.stringify(deleteGenresRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    genresDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-multiple-delete-genre").attr('disabled', 'true');
                genresDatatable.rows().deselect();
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

//#region detete one genre 
var genreIdDeleteInLine;
function modalDelete(genreId, genreName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#genre-name-delete").html(`<b>${genreName}</b>`);
    genreIdDeleteInLine = genreId;
}

$("button#submit-delete-genre").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (genreIdDeleteInLine !== null && genreIdDeleteInLine !== undefined && genreIdDeleteInLine > 0) {
        let genreIds = [];
        genreIds.push(genreIdDeleteInLine);

        const deleteGenresRequest = {
            genreIds: genreIds
        };

        $.ajax({
            method: "DELETE",
            url: `/genres/delete-genres`,
            data: JSON.stringify(deleteGenresRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    genresDatatable.ajax.reload();
                    genreIdDeleteInLine = null;
                }
                else {
                    ShowToastError(response.message);
                }

                genresDatatable.rows().deselect();
                $("#btn-multiple-delete-genre").attr('disabled', 'true');
                $('input[type="checkbox"]').prop('checked', false);
                modal.hide();
                return;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
    else {
        ShowToastError("No genre selected for delete.");
    }
});
//#endregion

//#region restore genre
var genreIdRestore = null;
function modalRestore(genreId, genreName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#genre-name-restore").html(`<b>${genreName}</b>`);
    genreIdRestore = genreId;
}

$("button#submit-restore-genre").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (genreIdRestore !== null && genreIdRestore !== undefined && genreIdRestore > 0) {
        let genreId = genreIdRestore;

        $.ajax({
            method: "POST",
            url: `/genres/restore-genre`,
            data: JSON.stringify(genreId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    genresDatatable.ajax.reload();
                    genreIdRestore = null;
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
        ShowToastError("No genre selected for restoring.");
    }
});
//#endregion

//#region information genre
var genreIdInformation = null;
function modalInformation(genreId) {
    genreIdInformation = genreId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/genres/get-genre-by-genre-id/${genreId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {

                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='genre-name']").text(response.resultObj.genreName);
                getModalInformation.find("label[name='genre-seo-alias']").text(response.resultObj.genreSEOAlias);
                getModalInformation.find("label[name='summary']").text(response.resultObj.summary);
                getModalInformation.find("label[name='genre-seo-summary']").text(response.resultObj.genreSEOSummary);
                getModalInformation.find("label[name='genre-seo-title']").text(response.resultObj.genreSEOTitle);

                setStatusTextInField(getModalInformation, "genre-is-deleted", response.resultObj.isDeleted);
                setInfoUserCreateAndUpdateObject(getModalInformation, "genre", response);

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