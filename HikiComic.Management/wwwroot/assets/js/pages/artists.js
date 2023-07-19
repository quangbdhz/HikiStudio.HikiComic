//#region init artist datatable
var artistsDatatable = $("#artistsDatatable").DataTable({
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
        "url": "/artists/get-artists",
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
                    return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.artistId}' /> `;
                }
                else {
                    return "";
                    //return `<input type='checkbox' disabled class='form-check-input bg-secondary ms' data-id='${data.id}' />`;
                }
            },
        },
        { "data": "artistName", "name": "ArtistName", "Width": 110 },
        { "data": "alternative", "name": "Alternative", "Width": 110 },
        { "data": "artistSEOAlias", "name": "ArtistSEOAlias", "Width": 110 },
        {
            "data": "dateCreated", "name": "DateCreated",
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
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.artistId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.artistId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalRestore('${data.artistId}', '${data.artistName}')" style="background: transparent; border: none; color: #198754; padding: 0px;"><i class="fa-solid fa-trash-arrow-up"></i></a></div>`;
                }
                else {
                    return `<div class="d-flex gap-2 justify-content-center"><a href="javascript:void(0)" onclick="modalInformation(${data.artistId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #435ebe; padding: 0px;" ><i class="bi bi-info-circle"></i></i></a><a href="javascript:void(0)" onclick="modalEdit(${data.artistId})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #0dcaf0; padding: 0px;" ><i class='bi bi-pencil-square'></i></a><a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.artistId}', '${data.artistName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class='bi bi-trash'></i></a></div>`;
                }
            },
        },
    ]
});

artistsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#artistsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});
//#endregion

//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#artistsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#artistsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = artistsDatatable.data().count();
    var count = $('#artistsDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region validation form create artist
function CheckEnableSaveChange(event) {
    if ($('#form-create-artist').validate().checkForm()) {
        $("#submit-create-artist").removeAttr("disabled");
    }
    else {
        $("#submit-create-artist").attr("disabled", "disabled");
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
    $("#submit-create-artist").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-artist').find("input[name='CreateDate']").val(today);
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

    var formValidateCreate = $("#form-create-artist").validate({
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
            "artist-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
                validateName: true,
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
            "artist-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "artist-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "artist-name": {
                required: "Please enter Artist Name.",
                notFullSpaceName: "Please enter Artist Name.",
                minlength: "Artist Name must be from 2 to 32 characters.",
                maxlength: "Artist Name must be from 2 to 32 characters.",
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
            "artist-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "artist-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let artistName = $(form).find('input[name="artist-name"]').val();
            let alternative = $(form).find('input[name="alternative"]').val();
            let summary = $(form).find('textarea[name="summary"]').val();
            let artistSEOSummary = $(form).find('input[name="artist-seo-summary"]').val();
            let artistSEOTitle = $(form).find('input[name="artist-seo-title"]').val();

            let createArtistDataRequest = {
                artistName: artistName,
                alternative: alternative,
                summary: summary,
                artistSEOSummary: artistSEOSummary,
                artistSEOTitle: artistSEOTitle
            };

            $.ajax({
                method: "POST",
                url: `artists/create-artist`,
                data: JSON.stringify(createArtistDataRequest),
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

                        $('#form-create-artist :input[type="text"]').val('');
                        $('#form-create-artist :input[type="date"]').val('');
                        artistsDatatable.ajax.reload();
                        $("#form-create-artist").validate().resetForm();
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

    $(document).on('click', '#cancel-create-artist', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-artist :input[type="text"]').val('');
        $('#form-create-artist :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit artist
var artistIdEdit = null;
function modalEdit(artistId) {
    artistIdEdit = artistId;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-artist').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/artists/get-artist-by-artist-id/${artistId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='artist-name']").val(response.resultObj.artistName);
                getModalEdit.find("input[name='alternative']").val(response.resultObj.alternative);
                getModalEdit.find("textarea[name='summary']").val(response.resultObj.summary);
                getModalEdit.find("input[name='artist-seo-summary']").val(response.resultObj.artistSEOSummary);
                getModalEdit.find("input[name='artist-seo-title']").val(response.resultObj.artistSEOTitle);
                getModalEdit.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-artist'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-artist').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-artist').prop('disabled', true);
                    }
                    if ($("#form-edit-artist").valid() == false) {
                        $('#submit-edit-artist').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-artist").validate({
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
            "artist-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 2,
                maxlength: 32,
                validateName: true,
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
            "artist-seo-summary": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 500,
            },
            "artist-seo-title": {
                notFullSpaceName: true,
                minlength: 10,
                maxlength: 150,
            },
        },
        messages: {
            "artist-name": {
                required: "Please enter Artist Name.",
                notFullSpaceName: "Please enter Artist Name.",
                minlength: "Artist Name must be from 2 to 32 characters.",
                maxlength: "Artist Name must be from 2 to 32 characters.",
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
            "artist-seo-summary": {
                notFullSpaceName: "Please enter SEO Summary.",
                minlength: "SEO Summary must be from 10 to 500 characters.",
                maxlength: "SEO Summary must be from 10 to 500 characters.",
            },
            "artist-seo-title": {
                notFullSpaceName: "Please enter SEO Title.",
                minlength: "SEO Title must be from 10 to 150 characters.",
                maxlength: "SEO Title must be from 10 to 150 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let artistName = $(form).find('input[name="artist-name"]').val();
            let alternative = $(form).find('input[name="alternative"]').val();
            let summary = $(form).find('textarea[name="summary"]').val();
            let artistSEOSummary = $(form).find('input[name="artist-seo-summary"]').val();
            let artistSEOTitle = $(form).find('input[name="artist-seo-title"]').val();

            let updateArtistDataRequest = {
                artistName: artistName,
                alternative: alternative,
                summary: summary,
                artistSEOSummary: artistSEOSummary,
                artistSEOTitle: artistSEOTitle
            };

            if (artistIdEdit !== null && artistIdEdit !== undefined && artistIdEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `artists/update-artist/${artistIdEdit}`,
                    data: JSON.stringify(updateArtistDataRequest),
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
                        artistIdEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-artist :input[type="text"]').val('');
                            $('#form-edit-artist :input[type="date"]').val('');
                            artistsDatatable.ajax.reload();
                            $("#form-edit-artist").validate().resetForm();
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

    $(document).on('click', '#cancel-edit-artist', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-artist :input[type="text"]').val('');
        $('#form-edit-artist :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete multiple artists
$("#checkbox-all").click(function () {
    var data_list = $('#artistsDatatable input[type="checkbox"].ms');

    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', true);
                }
            });
            artistsDatatable.rows(`:has(td:eq(5):contains("Active"))`).select();
            $("input#checkbox-all").addClass("selected");
        }
        else {
            data_list.each(function () {
                if (!this.disabled) {
                    $(this).prop('checked', false);
                }
            });
            artistsDatatable.rows().deselect();
            $("input#checkbox-all").removeClass("selected");
        }
    });
})

$(window).change(function () {
    var data_list = $('#artistsDatatable input[type="checkbox"].ms')
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
    var artistIds = [];
    $('input[type="checkbox"]').each(function () {
        if ($(this).is(':checked')) {
            artistIds.push($(this).data("id"))
        }
    });

    if (artistIds[0] === null || artistIds[0] === undefined) {
        artistIds[0] = -1;
    }

    const deleteArtistsRequest = {
        artistIds: artistIds
    };

    $.ajax({
        method: "DELETE",
        url: `/artists/delete-artists`,
        data: JSON.stringify(deleteArtistsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    artistsDatatable.ajax.reload();
                }
                else {
                    ShowToastError(response.message);
                }

                $("#btn-deletecheckall").attr('disabled', 'true');
                artistsDatatable.rows().deselect();
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

//#region delete one artist
var artistIdDelete;
function modalDelete(artistId, artistName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#artistIdDelete").html(`<b>${artistName}</b>`);
    artistIdDelete = artistId;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    let artistIds = [];
    artistIds.push(artistIdDelete);

    const deleteArtistsRequest = {
        artistIds: artistIds
    };

    $.ajax({
        method: "DELETE",
        url: `/artists/delete-artists`,
        data: JSON.stringify(deleteArtistsRequest),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                artistsDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            artistsDatatable.rows().deselect();
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

//#region restore artist
var artistIdRestore = null;
function modalRestore(artistId, artistName) {
    let modalRestore = new bootstrap.Modal(document.getElementById('modal-restore'), {
        keyboard: false
    })
    modalRestore.show();
    $("#artist-name-restore").html(`<b>${artistName}</b>`);
    artistIdRestore = artistId;
}

$("button#submit-restore-artist").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-restore');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    if (artistIdRestore !== null && artistIdRestore !== undefined && artistIdRestore > 0) {
        let artistId = artistIdRestore;

        $.ajax({
            method: "POST",
            url: `/artists/restore-artist`,
            data: JSON.stringify(artistId),
            headers: {
                "Content-Type": "application/json;",
            },
            datatype: 'json',
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    ShowToastSuccess(response.message);
                    artistsDatatable.ajax.reload();
                    artistIdRestore = null;
                }
                else {
                    ShowToastError(response.message);
                }

                //artistsDatatable.rows().deselect();
                //$('input[type="checkbox"]').prop('checked', false);
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
    //let artistIds = [];
    //artistIds.push(localartistId);


});
//#endregion

//#region information artist
var artistIdInformation = null;
function modalInformation(artistId) {
    artistIdInformation = artistId;

    let modalInformation = new bootstrap.Modal(document.getElementById('modal-information'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/artists/get-artist-by-artist-id/${artistId}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalInformation = $("#modal-information");

                getModalInformation.find("label[name='artist-name']").text(response.resultObj.artistName);
                getModalInformation.find("label[name='alternative']").text(response.resultObj.alternative);
                getModalInformation.find("label[name='artist-seo-alias']").text(response.resultObj.artistSEOAlias);
                getModalInformation.find("label[name='summary']").text(response.resultObj.summary);
                getModalInformation.find("label[name='artist-seo-summary']").text(response.resultObj.artistSEOSummary);
                getModalInformation.find("label[name='artist-seo-title']").text(response.resultObj.artistSEOTitle);

                setStatusTextInField(getModalInformation, "artist-is-deleted", response.resultObj.isDeleted);
                setInfoUserCreateAndUpdateObject(getModalInformation, "artist", response);

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