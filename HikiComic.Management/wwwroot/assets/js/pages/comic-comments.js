const commentsContainer = document.getElementById('comments');
const paginationContainer = document.getElementById('pagination');
var comicIdLocal = -1;

function createChildComments(childComments, micknameParent) {
    let childCommentsHTML = '';

    childComments.forEach((childComment, index) => {
        const childCommentHTML = `
      <div class="d-flex flex-start ${index == 0 ? "mt-2" : "mt-3"}">
        <a class="me-3" href="#">
          <img class="rounded-circle shadow-1-strong" src="${childComment.urlImageUser}" alt="avatar" width="65" height="65" />
        </a>
        <div class="flex-grow-1 flex-shrink-1">
          <div>
            <div class="d-flex justify-content-between align-items-center">
              <p class="mb-1">
                <span class="nickname-comment-child">${childComment.userName}</span>
                <span class="small">- ${childComment.stringDateCreated}</span>
                ${childComment.userIsVerified === true ? `<i class='fa-sharp fa-solid fa-shield-check' style='color: #7bddff;'></i>` : ""}
              </p>
            </div>
            <p class="small mb-0">
                <span>
                    <i class="fa-sharp fa-solid fa-reply fa-rotate-180"></i>
                    <i class="nickname-comment-parent">${micknameParent}</i>
                </span>
                <span style="padding-left: 5px;">
                ${childComment.commentContent}
                </span>
            </p>
          </div>
        </div>
      </div>
    `;

        childCommentsHTML += childCommentHTML;
    });

    return childCommentsHTML;
}

function showComments(page, commentsPerPage, data) {
    commentsContainer.innerHTML = '';

    const commentsToShow = data.items;

    commentsToShow.forEach((comment, index) => {
        const childCommentsHTML = comment.childComments ? createChildComments(comment.childComments, comment.userName) : '';
        console.log(comment.userIsVerified);
        const commentHTML = `
          <div class="d-flex flex-start ${index != 0 ? "mt-4" : ""}">
            <img class="rounded-circle shadow-1-strong me-3" src="${comment.urlImageUser}" alt="avatar" width="65" height="65" />
            <div class="flex-grow-1 flex-shrink-1">
              <div>
                <div class="d-flex justify-content-between align-items-center">
                  <p class="mb-1">
                    <span class="nickname-comment-parent">${comment.userName}</span>
                    <span class="small">- ${comment.stringDateCreated}</span>
                    ${comment.userIsVerified === true ? `<i class='fa-sharp fa-solid fa-shield-check' style='color: #7bddff;'></i>` : ""}
                  </p>
                </div>
                <p class="small mb-0">${comment.commentContent}</p>
              </div>

              <div class="d-flex flex-start mt-4">
                <div class="flex-grow-1 flex-shrink-1">
                  ${childCommentsHTML}
                </div>
              </div>
            </div>
          </div>
        `;

        commentsContainer.innerHTML += commentHTML;
    });
}

function createPagination(pageIndex, pageSize, comicId, pageCount) {
    let paginationHTML = `<ul class="pagination">
    <li class="paginate_button page-item first ${pageIndex === 1 ? "disabled" : ""}">
        <a href="#" onclick="getComments(1, ${pageSize}, ${comicId})" aria-controls="usersDatatable" data-dt-idx="0" tabindex="0" class="page-link">First</a>
    </li>
    <li class="paginate_button page-item previous ${pageIndex === 1 ? "disabled" : ""}">
        <a href="#" onclick="getComments(${pageIndex === 1 ? 1 : pageIndex - 1}, ${pageSize}, ${comicId})" aria-controls="usersDatatable" data-dt-idx="1" tabindex="0" class="page-link">Previous</a>
    </li>`;


    for (let i = 1; i <= pageCount; i++) {
        paginationHTML += `<li class="paginate_button page-item ${pageIndex === i ? "active" : ""}">
                            <a href="#" onclick="getComments(${i}, ${pageSize}, ${comicId})" aria-controls="usersDatatable" data-dt-idx="3" tabindex="0" class="page-link">${i}</a>
                        </li>`;
    }

    paginationHTML += `<li class="paginate_button page-item next ${pageIndex === pageCount ? "disabled" : ""}">
        <a href="#" onclick="getComments(${pageIndex === pageCount ? pageCount : pageIndex + 1}, ${pageSize}, ${comicId})" aria-controls="usersDatatable" data-dt-idx="4" tabindex="0" class="page-link">Next</a>
        </li>
        <li class="paginate_button page-item last ${pageIndex === pageCount ? "disabled" : ""}">
            <a href="#" onclick="getComments(${pageCount}, ${pageSize}, ${comicId})" aria-controls="usersDatatable" data-dt-idx="5" tabindex="0" class="page-link">Last</a>
        </li>
    </ul>` 

    paginationContainer.innerHTML = paginationHTML;
}

function getComments(pageIndex, pageSize, comicId) {
    const commentPaging = {
        pageIndex: pageIndex,
        pageSize: pageSize,
        comicId: comicId,
        chapterId: null
    };

    $.ajax({
        method: "POST",
        url: `/comics/comments`,
        data: JSON.stringify(commentPaging),
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.items.length > 0) {
                createPagination(pageIndex, pageSize, comicId, response.pageCount);
                showComments(pageIndex, pageSize, response);
            }
            else {
                commentsContainer.innerHTML = `<div style="text-align: center;">No data available in table</div>`
            }

            return;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
}

function getComicInformationForReadComments() {
    $.ajax({
        method: "POST",
        url: `/comics/get-comic-information-for-read-comments`,
        async: false,
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            comicIdLocal = response.resultObj.comicId;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
}

$(document).ready(function () {
    getComicInformationForReadComments();

    if (comicIdLocal !== -1) {
        getComments(1, 10, comicIdLocal, true);
    }
})