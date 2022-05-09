
//var tableObjectArray = {};

//function TableAdd(tableObjectId, tableObject) {
//    tableObjectArray[tableObjectId] = tableObject;
//}

function TableGet(tableObjectId) {
    var jqTable = $('#' + tableObjectId);
    var obj = jqTable.get(0);
    return obj.TableObject;
}

function TableSet(tableObjectId, tableObject) {
    var jqTable = $('#' + tableObjectId);
    var obj = jqTable.get(0);
    obj.TableObject = tableObject;
    ResizeTable(jqTable);
}

function ResizeTables() {

    $('.coretable').each(
        function (index) {
            ResizeTable($(this));
        });
}

function ResizeTable(jqTable) {
    var obj = jqTable.get(0);
    var tableObject = obj.TableObject;

    if (tableObject != undefined) {
        try  {
            jqTable.find('.dataTables_scrollBody').css('height', jqTable.height() - (jqTable.find('.dataTables_scrollHead').height() + $('#tableToolsDiv_' + jqTable.attr('id')).height()));
            tableObject.fnAdjustColumnSizing();
        }
        catch (Error) { }
    }
}

function SelectedRowIds(tableId) {

    var ret = "";

    var i = 0;
    $('#' + tableId).find("tr.row_selected").each(function (index) {
        if (i > 0)
            ret += "|";
        ret += $(this).attr('id');
        i++;
    });

    return ret;
}

//function RowIdParse(rowId) {

//}

function SetSelectedRows(tableId, rowIds) {
    $('#' + tableId).find("tr").each(function (index) {
        var rowId = $(this).attr('id');
        if (rowId != undefined) {
            //rowId = RowIdParse(rowId);
            if (rowIds.indexOf('|' + rowId + '|') == -1 && $(this).hasClass('row_selected')) //2012_12_05 try to avoid changing classes if no change is needed
                $(this).removeClass('row_selected');
            else if (!$(this).hasClass('row_selected'))  //2012_12_05 try to avoid changing classes if no change is needed
                $(this).addClass('row_selected');
        }
    });
}

function SelectedRowCount(tableId) {
    return $('#' + tableId).find("tr.row_selected").length;
}

function SelectedActiveRowCount(tableId) {
    return $('#' + tableId).find("tr.row_selected").length;
}

function SetSelectedActiveRow(tableId, row) {

    //2012_12_05 try to avoid changing classes if no change is needed
    if (SelectedRowCount(tableId) == 1 && row.hasClass('row_selected'))
        return;  

    $('#' + tableId + ' tr').removeClass('row_selected');
    row.addClass('row_selected');
    SetActiveRow(tableId, row);
}

function SetActiveRow(tableId, row) {

    //2012_12_05 try to avoid changing classes if no change is needed
    if (SelectedActiveRowCount(tableId) == 1 && row.hasClass('row_selected_active'))
        return;  

    $('#' + tableId + ' tr').removeClass('row_selected_active');
    row.addClass('row_selected_active');
}

function SetSelectedActiveRowOrRange(tableId, selectedRow) {
    var activeRow = $('#' + tableId).find('tr.row_selected_active');
    if (activeRow.length == 0)
        SetSelectedActiveRow(tableId, selectedRow);
    else
        SetSelectedRange(tableId, activeRow, selectedRow);
}

function SetSelectedRange(tableId, activeRow, selectedRow) {

    var isIn = false;
    $('#' + tableId).find("tr.webtablerow").each(function (index) {

        if ($(this).attr('id') == activeRow.attr('id')) {
            if (isIn)
                isIn = false;
            else
                isIn = true;
        }
        else if ($(this).attr('id') == selectedRow.attr('id')) {
            $(this).addClass('row_selected');
            if (isIn)
                isIn = false;
            else
                isIn = true;
        }
        else if (isIn) {
            $(this).addClass('row_selected');
        }
    });
}

function BroadcastTableState(sid, cid, tableId) {
    Action(sid, cid, 'table_state', SelectedRowIds(tableId));
}

function ApplyTableState(tableId, tableState) {

    $('#' + tableId + ' tr').removeClass('row_selected');
    $('#' + tableId + ' tr').removeClass('row_selected_active');

    var ids = tableState.split('|');
    for (var i = 0; i < ids.length; i++) {
        $('#' + ids[i]).addClass('row_selected');
    }
}

//this might be useful for multi-level reporting
//function MakeTablesEqual() {
//    var tableArr = document.getElementsByTagName('table');
//    var cellWidths = new Array();

//    // get widest
//    for (i = 0; i < tableArr.length; i++) {
//        for (j = 0; j < tableArr[i].rows[0].cells.length; j++) {
//            var cell = tableArr[i].rows[0].cells[j];

//            if (!cellWidths[j] || cellWidths[j] < cell.clientWidth)
//                cellWidths[j] = cell.clientWidth;
//        }
//    }

//    // set all columns to the widest width found
//    for (i = 0; i < tableArr.length; i++) {
//        for (j = 0; j < tableArr[i].rows[0].cells.length; j++) {
//            tableArr[i].rows[0].cells[j].style.width = cellWidths[j] + 'px';
//        }
//    }
//}