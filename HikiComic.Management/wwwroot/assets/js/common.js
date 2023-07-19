//#region initialize toast
const toast = new bootstrap.Toast(document.getElementById('myToast'))
const ERROR = "ERROR",
    SUCCESS = "SUCCESS",
    WARNING = "WARNING";

//show toast
function showToast(message, type) {
    const className = $("#myToast .alert")
    const icon = $("#myToast .alert i")
    className.removeClass();
    icon.removeClass();
    const content = $("#myToast #toast-content")
    content.text(message)
    switch (type) {
        case ERROR: {
            className.addClass("alert mb-0 alert-danger");
            icon.addClass("bi bi-file-excel")
            break;
        }
        case SUCCESS: {
            className.addClass("alert mb-0 alert-success");
            icon.addClass("bi bi-check-circle")
            break;
        }
        case WARNING: {
            className.addClass("alert mb-0 alert-warning");
            icon.addClass("bi bi-exclamation-triangle")
            break;
        }
        default: {
            className.addClass("alert mb-0 alert-success");
            icon.addClass("bi bi-check-circle")
            break;
        }
    }
    toast.show();
}

function ShowToastSuccess(message) {
    showToast(message, SUCCESS);
}

function ShowToastError(message) {
    showToast(message, ERROR);
}
//#endregion

//#region set text for span
const setStatusTextInField = (parentElement, elementId, value) => {
    if (!value) {
        parentElement.find(`label[name='${elementId}']`).html(`<span class="badge rounded-pill text-white text-bg-secondary active-span" style="">Active</span>`);
    } else {
        parentElement.find(`label[name='${elementId}']`).html(`<span class="badge rounded-pill text-white text-bg-secondary">Inactive</span>`);
    }
}
//#endregion

//#region format date by format MM/dd/yyyy hh:mm
function formatMMDDYYYYHHMM(dateTimeString) {
    var date = new Date(dateTimeString);
    var day = padZero(date.getDate());
    var month = padZero(date.getMonth() + 1);
    var year = date.getFullYear();
    var hours = padZero(date.getHours());
    var minutes = padZero(date.getMinutes());

    return month + "/" + day + "/" + year + " " + hours + ":" + minutes;
}

function padZero(value) {
    return value.toString().padStart(2, "0");
}
//#endregion

//#region set info create & update object
function setInfoUserCreateAndUpdateObject(parentElement, elementId, data) {
    parentElement.find(`label[name='${elementId}-username-created']`).text(data.resultObj.userNameCreatedBy);
    parentElement.find(`label[name='${elementId}-username-updated']`).text(data.resultObj.userNameUpdatedBy);
    parentElement.find(`label[name='${elementId}-date-created']`).text(formatMMDDYYYYHHMM(data.resultObj.dateCreated));
    parentElement.find(`label[name='${elementId}-date-updated']`).text(data.resultObj.dateUpdated === null ? "" : formatMMDDYYYYHHMM(data.resultObj.dateUpdated));

}
//#endregion

//#region loading
function showLoadingOverlay() {
    $(".loading-overlay").show();
}

function hideLoadingOverlay() {
    $(".loading-overlay").hide();
}
//#endregion