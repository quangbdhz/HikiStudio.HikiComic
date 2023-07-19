function getCreatorRevenueByOption(statistics, elementId, title) {
    $.ajax({
        type: "GET",
        url: `/revenue/${statistics}`,
    })
        .done(function (response) {
            if (response.isSuccessed) {
                const labels = response.resultObj.labels;
                const values = response.resultObj.data;

                let chartData = labels.map((label, index) => ({
                    label: label,
                    value: values[index]
                }));

                const chartConfig = {
                    type: 'column2d',
                    renderAt: elementId,
                    width: '100%',
                    height: '355',
                    dataFormat: 'json',
                    dataSource: {
                        // Chart Configuration
                        "chart": {
                            "caption": "Total Revenue by " + title,
                            "xAxisName": title,
                            "yAxisName": "Revenue",
                            "numberSuffix": "C",
                            "theme": "fusion",
                        },
                        // Chart Data
                        "data": chartData
                    }
                };
                FusionCharts.ready(function () {
                    var fusioncharts = new FusionCharts(chartConfig);
                    fusioncharts.render();
                });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}

function getCreatedComics() {
    $.ajax({
        type: "GET",
        url: `/created-comics`,
    })
        .done(function (response) {
            if (response.isSuccessed) {
                const labels = response.resultObj.labels;
                const values = response.resultObj.data;

                let chartData = labels.map((label, index) => ({
                    label: label,
                    value: values[index]
                }));

                const chartConfig = {
                    type: 'line',
                    renderAt: 'chart-container-created-comics',
                    width: '100%',
                    height: '355',
                    dataFormat: 'json',
                    dataSource: {
                        chart: {
                            caption: 'Monthly Created Comics',
                            subCaption: 'Last 12 months',
                            xAxisName: 'Month',
                            yAxisName: 'Comics',
                            theme: 'fusion',
                        },
                        data: chartData,
                    },
                };

                FusionCharts.ready(function () {
                    var fusioncharts = new FusionCharts(chartConfig);
                    fusioncharts.render();
                });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}

var currentTabNameRevenue = "date";
$(document).ready(function () {
    getCreatorRevenueByOption(1, "chart-container-revenue-day", "Day");
    getCreatedComics();

    $('.nav-link').on('click', function () {
        var tabName = $(this).attr('aria-controls');

        if (tabName === "day" && currentTabNameRevenue !== tabName) {
            currentTabNameRevenue = "day";
            getCreatorRevenueByOption(1, "chart-container-revenue-day", "Day")
        }
        else if (tabName == "month") {
            currentTabNameRevenue = "month";
            getCreatorRevenueByOption(2, "chart-container-revenue-month", "Month")
        }
        else if (tabName == "year") {
            currentTabNameRevenue = "year";
            getCreatorRevenueByOption(3, "chart-container-revenue-year", "Year")
        }
        else {

        }
    });


});