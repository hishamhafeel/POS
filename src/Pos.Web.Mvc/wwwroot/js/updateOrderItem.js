//On click view Order Item for a given Order Item ID
$(document).on('click', '#btnEditOrderItem', function () {
    var $row = $(this).closest("tr");    // Find the row
    var $id = $row.find("#OrderItemId").val(); // Find the text
    var url = "/Order/ViewOrderItem?orderItemId=" + $id;
    window.location.href = url;

});

//On click show delete confirmation modal
$(document).on('click', '#btnDeleteOrderItem', function () {
    var rowCount = $('tbody tr').length;
    if (rowCount == 1) {
        $('#errorMessage').html("<p>Order cannot be empty. There should be one or more order items in Order. </p>");
    }
    else if (rowCount > 1) {
        var $row = $(this).closest("tr");    // Find the row
        var $id = $row.find("#OrderItemId").val(); // Find the text
        // show Modal
        $('#myModal').modal('show');
        $('#orderIdOnDelete').append($id);
    }
});

//On click send DELETE request to delete Order Item
$(document).on('click', '#btnDeleteConfirmed', function () {
    var id = $("#orderIdOnDelete").html();
    abp.ajax({
        type: 'DELETE',
        url: 'http://localhost:21021/api/v1/Order/Delete/' + id,
        contentType: "application/json",
        success: function () {  
            $('#myModal').modal('hide');
            jQuery("#getCodeModal").modal('show');
        },
        error: function (data) { }
    });
});

//On click close the modal
$(document).on('click', '#btnCloseModal', function () {
    jQuery("#getCodeModal").modal('hide');
    var url = "/Order/Index";
    window.location.href = url;

});


//On click send PUT request to update Order
$(document).on('click', '#btnSaveOrderItem', function () {
    var id = $("#OrderItemId").val();
    var unitPrice = $("#UnitPrice").val();
    var quantity = $("#Quantity").val();
    var subTotal = $("#SubTotal").val();
    var productId = $("#ProductId").val();
    var dataToSend = {
        Id: id,
        UnitPrice: unitPrice,
        Quantity: quantity,
        SubTotal: subTotal,
        ProductId: productId
    };
    //Create a function to abstract AJAX call
    var updateOrder = function (order) {
        return abp.ajax({
            method: 'PUT',
            datatype: 'json',
            url: 'http://localhost:21021/api/v1/Order/Update',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(order)
        });
    };
    //Save the order
    updateOrder(dataToSend).done(function (data) {
        abp.notify.success('Order update successfully');
        window.location.href = '/Order/ViewDetails?orderId=' + data.id;
    });
   
});