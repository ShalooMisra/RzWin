
function SetDateCriteria(selectId, startId, endId) {
    var selected = $('#' + selectId).val();
    if (selected == "Any Date") {
        $('#' + startId).hide();
        $('#' + endId).hide();
    }
    else if (selected == "On") {
        $('#' + startId).show();
        $('#' + endId).hide();
    }
    else if (selected == "Before") {
        $('#' + startId).hide();
        $('#' + endId).show();
    }
    else if (selected == "After") {
        $('#' + startId).show();
        $('#' + endId).hide();
    }
    else {
        $('#' + startId).show();
        $('#' + endId).show();
    }
}

function AutoCompleteCompany(txtID, txtReturnID, customerId) {
    $("#" + txtID).autocomplete(
    {
        source: "CompanySearchLogic.aspx?cid=" + customerId,
        minLength: 1,
        select: function (event, ui) {
            if (ui.item) {
                $("#" + txtReturnID).val(ui.item.id);
                //                alert('Value: ' + ui.item.value);
                //                alert('ID: ' + ui.item.id);
            }
            else {
            }
        }
    });
}

function AddColumn(fieldName, caption) {

    if (ColumnExists(fieldName)) {
        alert('This column is already part of the layout');
        return;
    }

    AddColumnWithWidth(fieldName, caption, 60);
}

function ColumnExists(fieldName) {

    var exists = false;
    $('.rz-fieldcolumn-input').each(function (index) {

        if (fieldName == $(this).val())
            exists = true;

    });
    return exists;
}

function AddColumnWithWidth(fieldName, caption, width) {
    var dv = $('<div class="rz-column-placeholder" id="field_' + fieldName + '" style="float: left; margin: 2px; border: thin solid #CCCCCC; font-size: xx-small; overflow: hidden; width: ' + (width - 4) + 'px">' + caption + '<br /><img src="Graphics/Cancel.png" width="12" height="12" onclick="$(\'#field_' + fieldName + '\').remove();" /><br /><input class="rz-caption-input" name="caption_' + fieldName + '" type="text" style="font-size: xx-small; width: 100px" value="' + caption + '" /><input class="rz-fieldcolumn-input" name="fieldcolumn_' + fieldName + '" type="hidden" value="' + fieldName + '" /><input class="rz-size-input" name="width_' + fieldName + '" type="hidden" value="' + width + '" /><input class="rz-order-input" name="order_' + fieldName + '" type="hidden" value="" /></div>');

    dv.resizable({

        resize: function (event, ui) {  },
        handles: "e",
        stop: function () {
            $(this).find('.rz-size-input').val($(this).outerWidth(true));
        }
    });

    $('#columnDiv').append(dv);
    dv.get(0).fieldName = fieldName;
}

function AddColumnOrders() {

    var order = 0;
    $('#columnDiv').find('.rz-column-placeholder').each(function (index) {
        $(this).find('.rz-order-input').val(order);
        order++;
    });
}

function PropertySearch() {

    var text = $('#propertySearch').val();
    $('.rz-property-line').each(function (index) {

        if (text == '')
            $(this).show();
        else {
            var propertyText = $(this).text();
            if (propertyText.toLowerCase().indexOf(text) >= 0)
                $(this).show();
            else
                $(this).hide();
        }
    });
}

function CommaFormatted(amount) {
    var delimiter = ","; // replace comma if desired
    var a = new String(amount).split('.', 2)
    var d = a[1];
    var i = parseInt(a[0]);
    if (isNaN(i)) { return ''; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d == undefined || d.length < 1) { amount = n; }
    else { amount = n + '.' + d; }
    amount = minus + amount;
    return amount;
}




