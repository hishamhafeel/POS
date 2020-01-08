
$(document).ready(function () {
//Populating the other fields of product in row according to the selected product
    $("#SelectedProductId").change(function () {
        var textValue = $('#SelectedProductId option:selected').val();
        abp.ajax({
            url: 'http://localhost:21021/api/v1/Product/' + textValue,
            method: 'GET',
            datatype: 'JSON',
            success: function (data) {
                $('#ProductDescription').val(data.productDescription);
                $('#ProductPrice').val(data.productUnitPrice);

                $("#ProductQuantity").change(function () {
                    var qty = $(this).val();
                    var subTotal = qty * data.productUnitPrice;
                    $('#ProductSubTotal').val(subTotal);
                });
            },
            error: function (data) { }
        });
    });



//on click add item button populate next row with existing data
var GrandTotal = 0;
$("#AddOrderItem").click(function () {
    var productId = $('#SelectedProductId').val();
    //var productName = $('#SelectedProductId').children(":selected").attr("data-product-name");
    var productName = $('#SelectedProductId option:selected').text();
    //var productName = this.products.find(product => product.value == productId).value;
    var total = GrandTotal + parseInt($('#ProductSubTotal').val());
    //check if valid product is selected
    if ($('#SelectedProductId').val() == "" || $('#SelectedProductId').val() <= "0") {
        $('#SelectedProductId').focus();
        $('#SelectedProductId').css("border-color", "#ff0000");
        $('#errorMessageProduct').html("<p>Please select a product to add</p>");
        $('#errorMessageProduct').css("font-size", "12px");
    }
    //check if quantity added is valid
    else if (parseInt($('#ProductQuantity').val()) <= 0 || parseInt($('#ProductQuantity').val()) > 10 || $('#ProductQuantity').val() == "") {
        $('#ProductQuantity').focus();
        $('#ProductQuantity').css("border-color", "#ff0000");
        $('#errorMessageQty').html("<p>Please enter a valid quantity (1 - 10)</p>");
        $('#errorMessageQty').css("font-size", "12px");
    }
    //check if grand total is below 10000
    else if (total > 10000) {
        $('#errorMessageTotal').html("<p>Grand Total Must Be Less Than 10000 Rs To Make The Order </p>");
    }
    //execute if all validations are passed
    else {
        $('#orderItemsTable').append('<tr class="orderItemList text-center">' +
            '<td style="display:none;  data-table-head="Product">' + $('#SelectedProductId').val() + '</td>' +
            '<td data-table-head="Product">' + productName + '</td>' +
            '<td data-table-head="Description">' + $('#ProductDescription').val() + '</td>' +
            '<td data-table-head="Price">' + $('#ProductPrice').val() + '</td>' +
            '<td data-table-head="Quantity">' + $('#ProductQuantity').val() + '</td>' +
            '<td data-table-head="Subtotal">' + $('#ProductSubTotal').val() + '</td>' +
            '<td class="actions" data-table-head=""><input type="button" class="btn btn-danger" id="removeItem" value="Remove Item">' +
                '<input type="hidden" id="SelectedProductId" value="" />' +
            '<input type="hidden" id="ProductAvailableStock" value="" /></td></tr>');

        GrandTotal = GrandTotal + parseInt($('#ProductSubTotal').val());
        $('#GrandTotal').val(GrandTotal);
       
        $('#ProductQuantity').css("border-color", "#c0c0c0");
        $('#SelectedProductId').css("border-color", "#c0c0c0");
        $('#SelectedProductId').val('-1');
        $('#ProductDescription').val('');
        $('#ProductPrice').val('');
        $("#ProductQuantity").val('');
        $('#ProductSubTotal').val('');
        
        //$('.orderLine1 input[type="text"],input[type="number"]').val('');

        $('#errorMessageQty').html("");
        $('#errorMessageProduct').html("");
        $('#errorMessageTotal').html("");
    }
});


//On click remove item from table of order items
$(document).on('click', '#removeItem', function (e) {
    GrandTotal = GrandTotal - parseInt($(this).parents('tr').find("td:eq( 5 )").html());
    $('#GrandTotal').val(GrandTotal.toString());
    $(this).parents('tr').first().remove();
});

//On click send POST request to create order and order items
$('#SaveOrders').click(function (e) {
    var orderDate = $('#OrderDate').val();
    var customerId = $('#CustomerId').val();
    var orderTotal = $('#GrandTotal').val();
    if (orderTotal > 0) {
        var array = [];
        var headers = ["SelectedProductId", "Quantity", "SubTotal"];
        //Populate array with product id, quantity and subtotal
        $('#orderItemsTable .orderItemList').each(function () {
            var arrayItem = {};
            var headersIndex = 0;
            $('td', $(this)).each(function (index, item) {
                if (index == 0 || index == 4 || index == 5) {
                    arrayItem[headers[headersIndex]] = $(item).html();
                    headersIndex++;
                }
            });
            array.push(arrayItem);
        });
        var dataToSend = {
            CustomerId: customerId,
            OrderDate: orderDate,
            OrderItems: array,
            OrderTotal: orderTotal
        };
        //Create a function to abstract AJAX call
        var saveOrder = function (order) {
            return abp.ajax({
                method: 'POST',
                datatype: 'json',
                url: 'http://localhost:21021/api/v1/Order/Create',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(order)
            });
        };
        //Save the order
        saveOrder(dataToSend).done(function (data) {
            abp.notify.success('New order created successfully');
            window.location.href = '/Order/Index';
        });
    } else {
        $('#errorMessageTotal').html("<p>Please Add An Item To Cart</p>");
    }
});

    });



