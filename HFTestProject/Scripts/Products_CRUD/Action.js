
// btn:查詢
function query() {
    if ($('#tbProductID').val() == "" ||
        $('#tbProductID').val() == null ||
        $('#tbProductName').val() == "" ||
        $('#tbProductName').val() == null ||
        $('#tbSupplierID').val() == "" ||
        $('#tbSupplierID').val() == null ||
        $('#cbCategoryID option:selected').val() == "" ||
        $('#cbCategoryID option:selected').val() == null ||
        $('#cbCategoryID option:selected').val() == undefined ||
        $('#cbDiscontinued option:selected').val() == "" ||
        $('#cbDiscontinued option:selected').val() == null ||
        $('#cbDiscontinued option:selected').val() == undefined) {
        alert("請先輸入至少 1 查詢條件！");
    }
    else {
        $("#ProductsList").submit();
    }
}

//btn:新增/修改
function createedit(type, comcod, itemno, itemtype, class1, class2) {
    if (type == "Create") {
        alert("Create");
        if ($('#cbItemType option:selected').val() == "" ||
            $('#cbItemType option:selected').val() == null ||
            $('#cbItemType option:selected').val() == undefined ||
            $('#cbClass1 option:selected').val() == "" ||
            $('#cbClass1 option:selected').val() == null ||
            $('#cbClass1 option:selected').val() == undefined ||
            $('#cbClass2 option:selected').val() == "" ||
            $('#cbClass2 option:selected').val() == null ||
            $('#cbClass2 option:selected').val() == undefined) {
            alert("請先選取查詢畫面的類別、大類、中類！");
        }
        else {
            var tbitemname = $('#tbItemName').val();
            var tbshortname = $('#tbShortName').val();
            var cbitemtype = $('#cbItemType option:selected').val();
            var cbclass1 = $('#cbClass1 option:selected').val();
            var cbclass2 = $('#cbClass2 option:selected').val();
            var obj = { 'type': "Create", 'p1': tbitemname, 'p2': tbshortname, 'itemtype': cbitemtype, 'class1': cbclass1, 'class2': cbclass2 };

            post_to_url("http://" + window.location.host + "/A6424P03/Create", obj);
        }
    }
    else {
        if (type == "Edit") {
            alert("Edit");
            var obj = { 'type': "Edit", 'p1': comcod, 'p2': itemno, 'itemtype': itemtype, 'class1': class1, 'class2': class2 };
            post_to_url("http://" + window.location.host + "/A6424P03/Edit", obj);
        }
        else {
            alert("Detail");
            var obj = { 'type': "Detail", 'p1': comcod, 'p2': itemno, 'itemtype': itemtype, 'class1': class1, 'class2': class2 };
            post_to_url("http://" + window.location.host + "/A6424P03/Detail", obj);
        }
    }

}