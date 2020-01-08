//Get all Orders in descending order
$(document).ready(function () {
    abp.ajax({
        type: 'GET',
        url: 'http://localhost:21021/api/v1/Order',
        datatype: JSON,
        success: function (data) {
            $.each(data, function (i, row) {
                var newDate = new Date(row['orderDate']).toDateString();
                $("#ordersTable").append("<tr><td id='customerId'>" + row['customerId'] + "</td><td id='orderId'>" + row['id'] + "</td><td id='orderDate'>" + newDate + "</td><td class='text-center' id='orderTotal'>" + row['orderTotal'] + "</td><td><input class='btn btn-primary' type='button' id='viewOrder' value='More Details'/></td></tr>");
            })

        },
        error: function (data) {
            alert('error');
        }
    });


});

//Get Orders according to the selected customer
$("#SelectedCustomerId").change(function () {
    var textValue = $('#SelectedCustomerId option:selected').val();
    $('#ordersTable tbody tr').remove();
    $.ajax({
        url: 'http://localhost:21021/api/v1/Customer/' + textValue + '/Order',
        type: 'GET',
        datatype: JSON,
        success: function (data) {
            $.each(data, function (i, row) {
                var newDate = new Date(row['orderDate']).toDateString();
                $("#ordersTable").append("<tr><td id='customerId'>" +
                    row['customerId'] + "</td><td id='orderId'>" +
                    row['id'] + "</td><td id='orderDate'>" +
                    newDate + "</td><td class='text-center' id='orderTotal'>" +
                    row['orderTotal'] +
                    "</td><td><input class='btn btn-primary' type='button' id='viewOrder' value='More Details'/></td></tr>");

            })

        },
        error: function (data) {
            console.log(data);

        }

        // error: function (XMLHttpRequest, textStatus, errorThrown) {
        //    $.log('XHR ERROR ' + XMLHttpRequest.status);
        //    return JSON.parse(XMLHttpRequest.responseText);
        //}
    });
});

//On click view the Order details
$(document).on('click', '#viewOrder', function () {
    var $row = $(this).closest("tr");    // Find the row
    var $id = $row.find("#orderId").text(); // Find the text

    var url = "/Order/ViewDetails?orderId=" + $id;
    window.location.href = url;

});