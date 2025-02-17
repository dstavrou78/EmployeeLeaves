// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetFebruaryDays(year) {
    let feb = new Date(year, 2, 0);
    if (feb.getDate() == 28) {
        $("#Feb29").html('');
    }
    else {
        $("#Feb29").html('29');
    }
}

function DrawCalendar(year, days) {

    GetFebruaryDays(year);

    let today = new Date();

    $("#calendar td").each(function () {

        $(this).removeClass("weekend");
        $(this).removeClass("today");
        $(this).removeClass("has-leave");

        if ($(this).hasClass("day-cell") && $(this).html() != "") {
            let d = new Date(year + '/' + $(this).closest('tr').attr('data-value') + '/' + $(this).html());

            //Mark weekends
            if (d.getDay() == 0 || d.getDay() == 6) {
                $(this).addClass("weekend");
            }

            //Mark leaves
            for (let i = 0; i <= days.length; i++) {
                let dd = new Date(days[i]);
                if (d.getFullYear() == dd.getFullYear() && d.getMonth() == dd.getMonth() && d.getDate() == dd.getDate()) {
                    $(this).removeClass("today");
                    $(this).addClass("has-leave");
                }
            }

            //Mark current day
            if (parseInt(d.getFullYear()) == today.getFullYear()) {
                if (d.getFullYear() == today.getFullYear() && d.getMonth() == today.getMonth() && d.getDate() == today.getDate()) {
                    $(this).addClass("today");
                }
            }
        }
    //});

    });
}