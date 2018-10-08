//HeaderCheckbox 判斷邏輯 Item checkboxs 為全選/全不選邏輯
$("#HeaderCheckbox").change(function () {
    if ($("#HeaderCheckbox").prop("checked")) {
        $("input[name='checkboxs']").each(function () {
            $(this).prop("checked", true);
        });
    }
    else {
        $("input[name='checkboxs']").each(function () {
            $(this).prop("checked", false);
        })
    }
});

//Item checkboxs 判斷 HeaderCheckBox 為 Y/N 邏輯
$('input[name="checkboxs"]').change(function () {
    checkOrRemoveCheckAll();
});

function checkOrRemoveCheckAll() {
    if ($('input[name="checkboxs"][type="checkbox"]:checked').length ==
        $('input[name="checkboxs"][type="checkbox"]').length) {

        $('#HeaderCheckbox').prop("checked", true);
    }
    else {
        $('#HeaderCheckbox').prop("checked", false);
    }
}

// 多項刪除 Action
function multidelete() {
    if ($('input[name="checkboxs"][type="checkbox"]:checked').length == 0) {
        alert("請先選擇欲刪除的產品！");
    }
    else {
        if (confirm("選取筆數共 " + $('input[name="checkboxs"][type="checkbox"]:checked').length + " 筆\n確定要刪除選取的資料嗎？")) {
            var selectedIDs = new Array();
            $("input[name='checkboxs']").each(function () {
                if ($(this).prop("checked")) {
                    selectedIDs.push($(this).val());
                }
            });
            var options = {};
            options.url = "/Products/MultiDelete";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) { alert(msg + "\n\n返回查詢頁面"); $("#ProductsList").submit(); };
            options.error = function (msg) { alert(msg); };
            $.ajax(options);
        }
        else {
            return false;
        }
    }
}

// 多項更新 Discontinued N => Y
function multiDiscontinuedY() {
    if ($('input[name="checkboxs"][type="checkbox"]:checked').length == 0) {
        alert("請先選擇欲更新的產品！");
    }
    else {
        if (confirm("選取筆數共 " + $('input[name="checkboxs"][type="checkbox"]:checked').length + " 筆\n確定要更新選取的資料嗎？")) {
            var selectedIDs = new Array();
            $("input[name='checkboxs']").each(function () {
                if ($(this).prop("checked")) {
                    selectedIDs.push($(this).val());
                }
            });
            var options = {};
            options.url = "/Products/MultiUpdateY";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) { alert(msg + "\n\n返回查詢頁面"); $("#ProductsList").submit(); };
            options.error = function (msg) { alert(msg); };
            $.ajax(options);
        }
        else {
            return false;
        }
    }
}

// 多項更新 Discontinued Y => N
function multiDiscontinuedN() {
    if ($('input[name="checkboxs"][type="checkbox"]:checked').length == 0) {
        alert("請先選擇欲更新的產品！");
    }
    else {
        if (confirm("選取筆數共 " + $('input[name="checkboxs"][type="checkbox"]:checked').length + " 筆\n確定要更新選取的資料嗎？")) {
            var selectedIDs = new Array();
            $("input[name='checkboxs']").each(function () {
                if ($(this).prop("checked")) {
                    selectedIDs.push($(this).val());
                }
            });
            var options = {};
            options.url = "/Products/MultiUpdateN";
            options.type = "POST";
            options.data = JSON.stringify(selectedIDs);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) { alert(msg + "\n\n返回查詢頁面"); $("#ProductsList").submit(); };
            options.error = function (msg) { alert(msg); };
            $.ajax(options);
        }
        else {
            return false;
        }
    }
}