let jquery_datatable = $("#table1").DataTable({
    scrollY: '310px',
    scrollCollapse: true,
    paging: false,
    searching: false,
    columnDefs: [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
        "width": "10px",
    },
    { "className": "text-start", "width": "200px", "targets": "_all" },
    { "className": "text-center", "targets": 5 },
        // { "className": "text-center", "width": "200px", "targets": 7 },

    ],
    select: {
        style: 'os',
        selector: 'td:first-child'
    },
    order: [[1, 'asc']],
});

$(document).ready(function () {
    $("#btn-save-file").hide();
    $("#data-import-file").hide();
    var data_list = $('#data-list').find('input[type="checkbox"]')
    $("#checkbox-all").change(function () {
        if (this.checked) {
            data_list.each(function () {
                $(this).prop('checked', true);
            });
        } else {
            data_list.each(function () {
                $(this).prop('checked', false);
            });
        }
    });
    $(window).change(function () {
        let sum_checked = 0;
        data_list.each(function () {
            if ($(this).is(':checked')) {
                sum_checked += 1;
            }
        });

        if (sum_checked > 0) {
            $("#btn-delete").removeAttr('disabled');
            $("#btn-change-status").removeAttr('disabled');
        } else {
            $("#btn-delete").attr('disabled', 'true');
            $("#btn-change-status").attr('disabled', 'true');
        }

        if (data_list.length == sum_checked) {
            $("#checkbox-all").prop('checked', true);
        }
        else { $("#checkbox-all").prop('checked', false); }
    });

    $("#delete-with-checkbox").click(function () {
        data_list.each(function () {
            if ($(this).is(':checked')) {
                // Xử lý ajax
                console.log($(this))
            }
        });
    })
});

document.addEventListener(
    "DOMContentLoaded",
    function () {
        var tooltipTriggerList = [].slice.call(
            document.querySelectorAll('[data-bs-toggle="tooltip"]')
        );
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    },
    false
);