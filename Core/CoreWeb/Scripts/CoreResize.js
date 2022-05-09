function RunToBottom(spotId, parentId) {

    try {
        $('#' + spotId).css('height', $('#' + parentId).height() - ($('#' + spotId).position().top + ($('#' + spotId).outerHeight(true) - $('#' + spotId).height())));
    } catch(e) {}
    
    //RunToBottomScreen(spotId);
}

function RunToBottomScreen(spotId) {
    try {
        $('#' + spotId).css('height', $(window).height() - $('#' + spotId).offset().top);
    } catch (e) { }
}

function RunToRight(spotId, parentId) {

    try {
        var size = $('#' + spotId);
        var horizMargin = size.outerWidth(true) - size.width();
        size.css('width', $('#' + parentId).width() - ($('#' + spotId).position().left + horizMargin));
    } catch (e) { }
}

function RunToBottomExcept(spotId, parentId, exceptId) {

    if( $('#' + exceptId + ':visible').attr('id') == undefined ) {
        RunToBottom(spotId, parentId);
    }
    else {
        try {
            $('#' + spotId).css('height', $('#' + parentId).height() - ($('#' + spotId).position().top + $('#' + exceptId).outerHeight()));
        } catch(e) {}
    }
}

function PlaceAtBottom(spotId, parentId) {

    try {
        var size = $('#' + spotId);
        size.css('top', $('#' + parentId).height() - size.outerHeight(true));
    } catch(e) {}
}

function PlaceLeftEdge(spotId) {

    try {
        var size = $('#' + spotId);
        size.css('left', 0);
    } catch (e) { }
}

function PlaceRightEdge(spotId, parentId) {

    try {
        var size = $('#' + spotId);
        size.css('left', $('#' + parentId).width() - size.outerWidth(true));
    } catch (e) { }
}

function PlaceTopEdge(spotId) {
    try {
        var size = $('#' + spotId);
        size.css('top', 0);
    } catch (e) { }
}

function PlaceDivBelow(divToPlace, divOnTop) {
    $('#' + divToPlace).css('top', $('#' + divOnTop).position().top + $('#' + divOnTop).outerHeight(true));  //.height()
}

function PlaceDivRight(divToPlace, divOnLeft) {
    $('#' + divToPlace).css('left', $('#' + divOnLeft).position().left + $('#' + divOnLeft).width());
}

function PlaceDivCenterX(divToPlace, divBehind) {
    $('#' + divToPlace).css('left', ($('#' + divBehind).width() / 2) - ($('#' + divToPlace).width() / 2));
}

function MarginWidth(divId) {
    var div = $('#' + divId);
    return div.outerWidth(true) - div.width();
}

function MarginHeight(divId) {
    var div = $('#' + divId);
    return div.outerHeight(true) - div.height();
}

function InlineResizeAll() {

    $('.core-inline-resize').each(
        function (index) {
            SkyLatticeResize($(this));
        });
}

function InlineResize(item) {
    var obj = item.get(0);

    if (obj.Resize != undefined)
        obj.Resize();
}