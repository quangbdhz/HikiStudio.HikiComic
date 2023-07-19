function GetChartUserAge() {
    $.ajax({
        type: "GET",
        url: "/dob-user-group-age",
    })
        .done(function (response) {
            if (response.resultObj.labels.length !== 0) {
                let optionsVisitorsProfile = {
                    series: response.resultObj.data,
                    labels: response.resultObj.labels,
                    colors: response.resultObj.colorColumn,
                    chart: {
                        type: "donut",
                        width: "100%",
                        height: "350px"
                    },
                    legend: {
                        position: "bottom"
                    },
                    plotOptions: {
                        pie: {
                            donut: {
                                size: "30%"
                            }
                        }
                    }
                };

                let chartVisitorsProfile = new ApexCharts(document.getElementById("chart-group-age"), optionsVisitorsProfile);

                chartVisitorsProfile.render();
            }
            else {
                $("#message-chart-age").css({ "display": "flex" });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}

function GetChartUserGender() {
    $.ajax({
        type: "GET",
        url: "/group-genders",
    })
        .done(function (response) {
            if (response.resultObj.labels.length !== 0) {
                var options = {
                    series: [{
                        name: "users",
                        data: response.resultObj.data,
                    }],
                    chart: {
                        height: 350,
                        type: 'bar',
                        events: {
                            click: function (chart, w, e) {
                                // console.log(chart, w, e)
                            }
                        }
                    },
                    plotOptions: {
                        bar: {
                            columnWidth: '45%',
                            distributed: true,
                        }
                    },
                    dataLabels: {
                        enabled: false
                    },
                    legend: {
                        show: false
                    },
                    xaxis: {
                        categories: response.resultObj.labels,
                    }
                };

                let configs = {
                    series: response.resultObj.data,
                    labels: response.resultObj.labels,
                    colors: response.resultObj.colorColumn,
                    chart: {
                        type: "donut",
                        width: "100%",
                        height: "350px"
                    },
                    legend: {
                        position: "bottom"
                    },
                    plotOptions: {
                        pie: {
                            donut: {
                                size: "30%"
                            }
                        }
                    }
                };

                let chartVisitorsGender = new ApexCharts(document.getElementById("chart-group-gender"), options);

                chartVisitorsGender.render();
            }
            else {
                $("#message-chart-gender").css({ "display": "flex" });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}


function GetChartNewComic(year, chartNewComic) {
    let intYear = parseInt(year);
    $.ajax({
        type: "GET",
        url: `/created-comic-by-year/${intYear}`,
    })
        .done(function (response) {
            if (response.resultObj.labels.length !== 0) {
                $("#chart-new-comic").css({ "display": "flex" });
                $("#year-new-comic").removeAttr("disabled")

                chartNewComic.updateOptions({
                    xaxis: {
                        categories: response.resultObj.labels
                    },
                    series: [{
                        data: response.resultObj.data
                    }],
                });
            }
            else {
                $("#message-chart-register-user").css({ "display": "flex" });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}

function GetChartRegisterUser(year, chartRegisterUser) {
    $.ajax({
        type: "GET",
        url: `/register-user-by-year/${year}`,
    })
        .done(function (response) {
            if (response.resultObj.labels.length !== 0) {
                $("#chart-register-user").css({ "display": "flex" });
                $("#year-register-user").removeAttr("disabled")

                chartRegisterUser.updateOptions({
                    xaxis: {
                        categories: response.resultObj.labels
                    },
                    series: [{
                        data: response.resultObj.data
                    }],
                });
            }
            else {
                $("#message-chart-register-user").css({ "display": "flex" });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
        });
}

$(document).ready(function () {
    let currentYear = new Date().getFullYear(); 

    GetChartUserAge();
    GetChartUserGender();

    //#region chart register user
    let optionsChartUserAge = {
        annotations: {
            position: "back"
        },
        dataLabels: {
            enabled: !1
        },
        chart: {
            type: "bar",
            height: 300
        },
        fill: {
            opacity: 1
        },
        plotOptions: {},
        series: [{
            name: "users",
            data: [9, 20, 30, 20, 10, 20, 30, 20, 10, 20, 30, 20]
        }],
        colors: "#435ebe",
        xaxis: {
            categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
        }
    };

    let chartRegisterUser = new ApexCharts(document.querySelector("#chart-register-user"), optionsChartUserAge)
    chartRegisterUser.render();

    GetChartRegisterUser(currentYear, chartRegisterUser);
    $('#year-register-user').on('change', function () {
        GetChartRegisterUser(this.value, chartRegisterUser);
    });
    //#endregion

    //#region new comic strip
    var chartNewComicOptions = {
        chart: {
            type: "line",
            height: "350px",
        },
        stroke: {
            width: 3
        },
        markers: {
            size: 5,
        },
        series: [{
            name: "Comics",
            data: [30, 40, 35, 50, 49, 60, 70, 91, 125]
        }],
        xaxis: {
            categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
        }
    };

    var chartNewComic = new ApexCharts(document.querySelector("#chart-new-comic"), chartNewComicOptions);
    chartNewComic.render();

    GetChartNewComic(currentYear, chartNewComic);
    $('#year-new-comic').on('change', function () {
        GetChartNewComic(this.value, chartNewComic);
    });
    //#endregion
});