
// btn:查詢
function query() {
    if (($('#tbProductID').val() == "" || $('#tbProductID').val() == null) &&
        ($('#tbProductName').val() == "" || $('#tbProductName').val() == null) &&
        ($('#tbSupplierID').val() == "" || $('#tbSupplierID').val() == null) &&
        ($('#cbCategoryID option:selected').val() == "" ||
        $('#cbCategoryID option:selected').val() == null ||
        $('#cbCategoryID option:selected').val() == undefined) &&
        ($('#cbDiscontinued option:selected').val() == "" ||
        $('#cbDiscontinued option:selected').val() == null ||
        $('#cbDiscontinued option:selected').val() == undefined)) {
        alert("請先輸入至少 1 查詢條件！");
    }
    else {
        $("#ProductsList").submit();
    }
}

//btn:新增/修改
function createedit(type, tbproductid) {
    var obj = { 'productid': tbproductid };

    if (type == "Create") {
        alert("Create");
        post_to_url("http://" + window.location.host + "/Products/Create", obj);
    }

    if (type == "Edit") {
        alert("Edit");
        post_to_url("http://" + window.location.host + "/Products/Edit", obj);
    }

    if (type == "Detail") {
        alert("Detail");
        post_to_url("http://" + window.location.host + "/Products/Detail", obj);
    }
}