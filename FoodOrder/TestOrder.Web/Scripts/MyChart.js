$(document).ready(function () {
   
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: 'Home/GetVotes',
        dataType: "json",
        success: function (votesData) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'word');
            data.addColumn('number', 'count');

            $.each(votesData, function (i, d) {
                data.addRow([votesData[i].RestaurantName, votesData[i].Broj]);
            });

            var options = {
                title: 'Rezultati glasovanja za catering',
                is3D: true
            };
            var chart = new google.visualization.PieChart(document.getElementById('piechart'));
            chart.draw(data, options);
        },
        error: function (data) {
            alert("Error In getting Records");
        }
    });
    });

