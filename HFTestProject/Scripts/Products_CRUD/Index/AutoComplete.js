
$("#tbProductID").autocomplete({
    minLength: 1,
    source: function (request, response) {
        $.ajax({
            url: "http://" + window.location.host + '/api/products_acbproductid/' + $("#tbProductID").val(),
            type: 'GET',
            position: { my: "right top", at: "right bottom" },
            success: function (json) {
                response($.map(json, function (ProductName, ProductID) {
                    return { label: ProductID + " " + ProductName, value: ProductID }
                }));
            },
        });
    },
    position: { collision: "flip" },
    select: function (event, ui) {
        $('#tbProductID').val(ui.item.value);
        return false;
    }
});

$("#tbProductName").autocomplete({
    minLength: 1,
    source: function (request, response) {
        $.ajax({
            url: "http://" + window.location.host + '/api/products_acbproductname/' + $("#tbProductName").val(),
            type: 'GET',
            position: { my: "right top", at: "right bottom" },
            success: function (json) {
                response($.map(json, function (ProductName, ProductID) {
                    return { label: ProductName, value: ProductName }
                }));
            },
        });
    },
    position: { collision: "flip" },
    select: function (event, ui) {
        $('#tbProductName').val(ui.item.value);
        return false;
    }
});

$("#tbSupplierID").autocomplete({
    minLength: 1,
    source: function (request, response) {
        $.ajax({
            url: "http://" + window.location.host + '/api/products_acbsupplierid/' + $("#tbSupplierID").val(),
            type: 'GET',
            position: { my: "right top", at: "right bottom" },
            success: function (json) {
                response($.map(json, function (CompanyName, SupplierID) {
                    return { label: SupplierID + " " + CompanyName, value: SupplierID, display: CompanyName }
                }));
            },
        });
    },
    position: { collision: "flip" },
    select: function (event, ui) {
        $('#tbSupplierID').val(ui.item.value);
        $('#tbSupplierID_dis').val(ui.item.display);
        return false;
    }
});