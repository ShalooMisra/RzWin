function SkyLatticeDraggable(draggableId) {
    $('#' + draggableId).draggable({

        stop: function () {
            PositionSave($(this));
        },
        handle: '.skylattice-drag-handle'
    });
}

function SkyLatticeResizable(resizableId) {

    var target = $('#' + resizableId);
    if (target.length == 0)
        return;

    if (target.hasClass('ui-resizable')) {
        target.resizable('destroy');  //if the div is cleared then resizable needs to be re-done
    }

    target.resizable({

        resize: function (event, ui) { PositionGet($(this)); },

        stop: function () {
            PositionSave($(this));
            DoResize();
        }
    });
}

//function SkyLatticeResizable(resizableId) {

//    var target = $('#' + resizableId);
//    if (target.length == 0)
//        return;

//    if (target.hasClass('ui-resizable')) {
//        target.resizable('destroy');  //if the div is cleared then resizable needs to be re-done
//    }

//    target.resizable({

//        resize: function (event, ui) { PositionGet($(this)); },

//        stop: function () {
//            PositionSave($(this));
//            DoResize();
//        }
//    });
//}

function PositionGet(item) {

    var content = $(item).parent();

    var obj = item.get(0);
    obj.xFactor = item.position().left / content.width();
    obj.yFactor = item.position().top / content.height();
    obj.wFactor = item.width() / content.width();
    obj.hFactor = item.height() / content.height();

    return obj;
}

function PositionSave(item) {

    var obj = PositionGet($(item));

    if (obj == undefined)
        return;

    //async post the positions
    var datarray = [];
    datarray.push({ name: "action_id", value: "move" });
    datarray.push({ name: "action_params", value: $(item).attr('id').substring(2) });

    var pos = item.position();
    datarray.push({ name: "position_left", value: obj.xFactor });
    datarray.push({ name: "position_top", value: obj.yFactor });
    datarray.push({ name: "position_width", value: obj.wFactor });
    datarray.push({ name: "position_height", value: obj.hFactor });

    PostAction(spotId, spotId, datarray);
}

function PositionByFactor(divId, xFactor, yFactor, wFactor, hFactor) {

    var jbo = $('#' + divId);
    var obj = jbo.get(0);
    obj.xFactor = xFactor;
    obj.yFactor = yFactor;
    obj.wFactor = wFactor;
    obj.hFactor = hFactor;

    ResizeOneByFactors(jbo);
}

function ResizeByFactors() {

    $('.spot-control-div').each(
        function (index) {
            ResizeOneByFactors($(this));
        });
}

function ResizeOneByFactors(item) {
    var obj = item.get(0);
    var xFactor = obj.xFactor;
    if (xFactor != undefined) {

        var content = item.parent();

        item.css('left', (content.width() * xFactor))
                .css('top', (content.height() * obj.yFactor))
                .css('width', (content.width() * obj.wFactor))
                .css('height', (content.height() * obj.hFactor));
    }
}



function SkyLatticeResizeAll() {

    $('.skylattice-resize').each(
        function (index) {
            SkyLatticeResize($(this));
        });
}

function SkyLatticeResize(item) {
    var obj = item.get(0);

    if (obj.Resize != undefined)
        obj.Resize();
}