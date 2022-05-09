function MenuInit() {
    //$('#CoreContextMenuDivTable').find('tbody').on('click', 'tr', function (evt) {
    $('#CoreContextMenuDivTable').find('tbody').on('click', 'td.menu_cell', function (evt) {
        var jqdiv = $('#CoreContextMenuDiv');
        var TargetSpotId = jqdiv.get(0).TargetSpotId;
        var MenuParameters = jqdiv.get(0).MenuParameters;
        jqdiv.hide();

        var split = $(this).attr('id').substring(16).split('__');  //ContextMenuLine_name__parameters
        var actionName = split[0];
        var actionParams = split[1];

        var datarray = [];
        datarray.push({ name: "action_id", value: actionName });
        datarray.push({ name: "action_params", value: actionParams });
        datarray = datarray.concat(MenuParameters);

        PostAction(spotId, TargetSpotId, datarray);
    });

    $('#CoreContextMenuDiv').bind('mouseleave', function (event) //CoreContextMenuDivTable
    {
        $('#CoreContextMenuDiv').hide();
    });
}

//$().offset().left, $('#mainMenuButton').offset().top

function MenuShowOn(TargetSpotId, TargetElementId) {
    var target = $('#' + TargetElementId);
    if (target.length == 0)
        return;
    MenuShow(TargetSpotId, target.offset().left + (target.width() / 2), target.offset().top + (target.height() / 2));
}

function MenuShow(TargetSpotId, x, y) {
    MenuShowWithParameters(TargetSpotId, x, y, []);
}

function MenuShowOnWithParameters(TargetSpotId, TargetElementId, pars) {
    var target = $('#' + TargetElementId);
    if (target.length == 0)
        return;
    MenuShowWithParameters(TargetSpotId, target.offset().left + (target.width() / 2), target.offset().top + (target.height() / 2), pars);
}

function MenuShowWithParameters(TargetSpotId, x, y, pars) {

    $('#CoreWaitingDiv').show().offset({ top: y, left: x });
    
    $('#CoreContextMenuDivTable').find('tr').remove();
    $('#CoreContextMenuDiv').get(0).TargetSpotId = TargetSpotId;
    $('#CoreContextMenuDiv').get(0).MenuParameters = pars;
    requestNumber++;

    var holdArray = [];
    holdArray.push({ name: "sid", value: spotId });
    holdArray.push({ name: "cid", value: TargetSpotId });
    holdArray.push({ name: "vid", value: viewId });

    var useArray = holdArray.concat(pars);

    $.post("ContextMenu.aspx?skipcache=" + requestNumber,
        useArray,
        function (data) {
            $('#CoreWaitingDiv').hide();
            if (data == "") return;
            $('#CoreContextMenuDivTable').find('tbody').append($(data));

            if ($(window).height() - y < 150)
                y -= $('#CoreContextMenuDiv').height();

            $('#CoreContextMenuDiv').show().offset({ top: y, left: x });
            $('#CoreContextMenuDiv').css('zIndex', 9999);
            $('#CoreContextMenuDiv').css('max-height', ($(window).height() - y) - 25);
        } 
    );
}