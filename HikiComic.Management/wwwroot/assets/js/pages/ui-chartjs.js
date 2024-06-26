var chartColors = {
    red: "rgb(255, 99, 132)",
    orange: "rgb(255, 159, 64)",
    yellow: "rgb(255, 205, 86)",
    green: "rgb(75, 192, 192)",
    info: "#41B1F9",
    blue: "#3245D1",
    purple: "rgb(153, 102, 255)",
    grey: "#EBEFF6"
},
    config1 = {
        type: "line",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "Balance",
                backgroundColor: "#fff",
                borderColor: "#fff",
                data: [20, 40, 20, 70, 10, 50, 20],
                fill: !1,
                pointBorderWidth: 100,
                pointBorderColor: "transparent",
                pointRadius: 3,
                pointBackgroundColor: "transparent",
                pointHoverBackgroundColor: "rgba(63,82,227,1)"
            }]
        },
        options: {
            responsive: !0,
            maintainAspectRatio: !1,
            layout: {
                padding: {
                    left: -10,
                    top: 10
                }
            },
            legend: {
                display: !1
            },
            title: {
                display: !1
            },
            tooltips: {
                mode: "index",
                intersect: !1
            },
            hover: {
                mode: "nearest",
                intersect: !0
            },
            scales: {
                xAxes: [{
                    gridLines: {
                        drawBorder: !1,
                        display: !1
                    },
                    ticks: {
                        display: !1
                    }
                }],
                yAxes: [{
                    gridLines: {
                        display: !1,
                        drawBorder: !1
                    },
                    ticks: {
                        display: !1
                    }
                }]
            }
        }
    },
    config2 = {
        type: "line",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "Revenue",
                backgroundColor: "#fff",
                borderColor: "#fff",
                data: [20, 800, 300, 400, 10, 50, 20],
                fill: !1,
                pointBorderWidth: 100,
                pointBorderColor: "transparent",
                pointRadius: 3,
                pointBackgroundColor: "transparent",
                pointHoverBackgroundColor: "rgba(63,82,227,1)"
            }]
        },
        options: {
            responsive: !0,
            maintainAspectRatio: !1,
            layout: {
                padding: {
                    left: -10,
                    top: 10
                }
            },
            legend: {
                display: !1
            },
            title: {
                display: !1
            },
            tooltips: {
                mode: "index",
                intersect: !1
            },
            hover: {
                mode: "nearest",
                intersect: !0
            },
            scales: {
                xAxes: [{
                    gridLines: {
                        drawBorder: !1,
                        display: !1
                    },
                    ticks: {
                        display: !1
                    }
                }],
                yAxes: [{
                    gridLines: {
                        display: !1,
                        drawBorder: !1
                    },
                    ticks: {
                        display: !1
                    }
                }]
            }
        }
    },
    config3 = {
        type: "line",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "Orders",
                backgroundColor: "#fff",
                borderColor: "#fff",
                data: [20, 40, 20, 200, 10, 540, 723],
                fill: !1,
                pointBorderWidth: 100,
                pointBorderColor: "transparent",
                pointRadius: 3,
                pointBackgroundColor: "transparent",
                pointHoverBackgroundColor: "rgba(63,82,227,1)"
            }]
        },
        options: {
            responsive: !0,
            maintainAspectRatio: !1,
            layout: {
                padding: {
                    left: -10,
                    top: 10
                }
            },
            legend: {
                display: !1
            },
            title: {
                display: !1,
                text: "Chart.js Line Chart"
            },
            tooltips: {
                mode: "index",
                intersect: !1
            },
            hover: {
                mode: "nearest",
                intersect: !0
            },
            scales: {
                xAxes: [{
                    gridLines: {
                        drawBorder: !1,
                        display: !1
                    },
                    ticks: {
                        display: !1
                    }
                }],
                yAxes: [{
                    gridLines: {
                        display: !1,
                        drawBorder: !1
                    },
                    ticks: {
                        display: !1
                    }
                }]
            }
        }
    },
    config4 = {
        type: "line",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "My First dataset",
                backgroundColor: "#fff",
                borderColor: "#fff",
                data: [20, 40, 20, 70, 10, 5, 23],
                fill: !1,
                pointBorderWidth: 100,
                pointBorderColor: "transparent",
                pointRadius: 3,
                pointBackgroundColor: "transparent",
                pointHoverBackgroundColor: "rgba(63,82,227,1)"
            }]
        },
        options: {
            responsive: !0,
            maintainAspectRatio: !1,
            layout: {
                padding: {
                    left: -10,
                    top: 10
                }
            },
            legend: {
                display: !1
            },
            title: {
                display: !1,
                text: "Chart.js Line Chart"
            },
            tooltips: {
                mode: "index",
                intersect: !1
            },
            hover: {
                mode: "nearest",
                intersect: !0
            },
            scales: {
                xAxes: [{
                    gridLines: {
                        drawBorder: !1,
                        display: !1
                    },
                    ticks: {
                        display: !1
                    }
                }],
                yAxes: [{
                    gridLines: {
                        display: !1,
                        drawBorder: !1
                    },
                    ticks: {
                        display: !1
                    }
                }]
            }
        }
    },
    line = document.getElementById("line").getContext("2d"),
    gradient = line.createLinearGradient(0, 0, 0, 400);
gradient.addColorStop(0, "rgba(50, 69, 209,1)"), gradient.addColorStop(1, "rgba(265, 177, 249,0)");
var gradient2 = line.createLinearGradient(0, 0, 0, 400);
gradient2.addColorStop(0, "rgba(255, 91, 92,1)"), gradient2.addColorStop(1, "rgba(265, 177, 249,0)");
var myline = new Chart(line, {
    type: "line",
    data: {
        labels: ["16-07-2018", "17-07-2018", "18-07-2018", "19-07-2018", "20-07-2018", "21-07-2018", "22-07-2018", "23-07-2018", "24-07-2018", "25-07-2018"],
        datasets: [{
            label: "Balance",
            data: [50, 25, 61, 50, 72, 52, 60, 41, 30, 45],
            backgroundColor: "rgba(50, 69, 209,.6)",
            borderWidth: 3,
            borderColor: "rgba(63,82,227,1)",
            pointBorderWidth: 0,
            pointBorderColor: "transparent",
            pointRadius: 3,
            pointBackgroundColor: "transparent",
            pointHoverBackgroundColor: "rgba(63,82,227,1)"
        }, {
            label: "Balance",
            data: [20, 35, 45, 75, 37, 86, 45, 65, 25, 53],
            backgroundColor: "rgba(253, 183, 90,.6)",
            borderWidth: 3,
            borderColor: "rgba(253, 183, 90,.6)",
            pointBorderWidth: 0,
            pointBorderColor: "transparent",
            pointRadius: 3,
            pointBackgroundColor: "transparent",
            pointHoverBackgroundColor: "rgba(63,82,227,1)"
        }]
    },
    options: {
        responsive: !0,
        layout: {
            padding: {
                top: 10
            }
        },
        tooltips: {
            intersect: !1,
            titleFontFamily: "Helvetica",
            titleMarginBottom: 10,
            xPadding: 10,
            yPadding: 10,
            cornerRadius: 3
        },
        legend: {
            display: !0
        },
        scales: {
            yAxes: [{
                gridLines: {
                    display: !0,
                    drawBorder: !0
                },
                ticks: {
                    display: !0
                }
            }],
            xAxes: [{
                gridLines: {
                    drawBorder: !1,
                    display: !1
                },
                ticks: {
                    display: !1
                }
            }]
        }
    }
});