$("#tbQuantityPerUnit").autocomplete({
    minLength: 1,
    source: function (request, response) {
        $.ajax({
            url: "http://" + window.location.host + '/api/products_acbquantityperunit/' + $("#tbQuantityPerUnit").val(),
            type: 'GET',
            position: { my: "right top", at: "right bottom" },
            success: function (json) {
                response($.map(json, function (QuantityPerUnit, QuantityPerUnit) {
                    return { label: QuantityPerUnit, value: QuantityPerUnit }
                }));
            },
        });
    },
    position: { collision: "flip" },
    select: function (event, ui) {
        $('#tbQuantityPerUnit').val(ui.item.value);
        return false;
    }
});