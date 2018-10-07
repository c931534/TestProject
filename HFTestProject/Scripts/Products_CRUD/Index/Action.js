
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
    if (type == "Create") {
        alert("Create");
        var obj = { 'type': "Create", 'p1': tbproductid };

            post_to_url("http://" + window.location.host + "/Products/Create", obj);
    }
}