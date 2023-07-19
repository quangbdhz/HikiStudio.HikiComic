//check row click
function ClickRowUser({
    table,
    datatTable,
    checkAll,
    deleteMultiple,
    callBack,
    eventToggleCheck,
    isDisableRow,
    eventDraw,
    eventSearch,
    checkBoxAll = true,
}) {
    if (datatTable) {
        // table ususers project
        if (checkBoxAll) {
            checkAll.click(function () {
                var data_list = table.find('tbody input[type="checkbox"]').not(':disabled')
                checkAll.change(function () {
                    if (this.checked) {

                        data_list.each(function (index, item) {
                            $(item).prop('checked', true);
                        });

                        datatTable.rows().select();
                        checkAll.addClass("selected");
                    } else {
                        data_list.each(function () {
                            $(this).prop('checked', false);
                        });
                        datatTable.rows().deselect();
                        checkAll.removeClass("selected");
                    }
                });
            })
        } else {
            checkAll.attr("disabled", "disabled");
        }

        datatTable.on('select', function (e, dt, type, indexes) {
            if (type === 'row') {
                if (isDisableRow) {
                    var rows = datatTable.rows(indexes).nodes().to$();
                    $.each(rows, function () {
                        if ($(this).find("input[type='checkbox']").hasClass("disabled")) {
                            datatTable.row($(this)).deselect();
                        }
                    })
                }
                checkRowDatatable(type, indexes, true);
            }
        })

            .on('deselect', function (e, dt, type, indexes) {
                if (type === 'row') {
                    checkRowDatatable(type, indexes, false);
                }
            })
            .on('order.dt', function () {

            })
            .on('page.dt', function () {

            })
            .on('search.dt', function () {
                if (eventSearch) {
                    eventSearch();
                }
            })
            .on('draw.dt', function () {
                checkAll.prop('checked', false);
                datatTable.columns.adjust();
                if (eventDraw)
                    eventDraw();

                let rowCount = table.find('tbody input[type="checkbox"]').not(':disabled').length
                if (!checkBoxAll || rowCount == 0) {
                    checkAll.attr("disabled", "disabled");
                }
                else {
                    if (datatTable.data().count() === 0) {
                        checkAll.attr("disabled", "disabled");
                    } else {
                        checkAll.removeAttr("disabled");
                    }
                }
                if (deleteMultiple) {
                    deleteMultiple.attr('disabled', 'true');
                }
            })
            .on('init.dt', function () {

            })
            .on('processing.dt', function () {

            });
        function checkRowDatatable(type, indexes, isCheck = false) {
            datatTable[type](indexes).nodes().to$().find("input[type='checkbox']").prop('checked', isCheck)
            let rowCount = table.find('tbody input[type="checkbox"]').not(':disabled').length

            let rowCountSelect = datatTable.rows('.selected').count();

            if (checkBoxAll) {
                if (rowCount == rowCountSelect) {
                    checkAll.prop('checked', true);
                }
                else {
                    checkAll.prop('checked', false);
                }
            }

            if (deleteMultiple) {
                if (rowCountSelect > 1) {
                    deleteMultiple.removeAttr('disabled');
                } else {
                    deleteMultiple.attr('disabled', 'true');
                }
            }

            if (eventToggleCheck) {
                eventToggleCheck(rowCount, rowCountSelect);
            }
            if (isDisableRow) {
                table.find('tbody input[type="checkbox"][disabled]').first().prop('checked', false);
            }
        }
        if (callBack) {
            callBack(datatTable);
        }
    }
}

export default ClickRowUser