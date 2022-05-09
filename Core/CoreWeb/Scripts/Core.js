var viewId = "";
//var spotId = "";
var requestNumber = 0;

var AsyncCancel = false;
function Redirect(url) {

    AsyncAbort();
    window.location.href = url;
}

function AsyncAbort() {
    try {
        AsyncCancel = true;
        AsyncConnected = false;
        if (AjaxAsyncRequestToken != undefined)
            AjaxAsyncRequestToken.abort();
    }
    catch (Error) { }
}

function Dialog(request) {

    $("#dialog_div").html("");

    requestNumber++;
    $.ajax(
        {
            method: "get",
            url: request.url + "?skipcache=" + requestNumber,
            dataType: "html",
            timeout: 0,
            success: function (data) {
                $("#dialog_div").html(data).dialog(
                    {
                        modal: true
                    }
                );
            }
        });
}

var askDialogVar;
function Ask(askId, caption) {

    if (askDialogVar == undefined) {

        askDialogVar = $('#dialog_div').dialog({
            autoOpen: false,
            height: 250,
            width: 250,
            modal: true,
            resizable: true,
            draggable: true
        });
    }

    requestNumber++;
    $.ajax(
        {
            method: "get",
            url: "Ask.aspx?skipcache=" + requestNumber + "&askId=" + askId,
            //dataType: "html",
            dataType: "json",
            timeout: 0,
            success: function (data) {
                //askDialogVar.dialog('option', 'title', caption);

                var ask = data.d[0];

                //test 2013_02_13 removed
                //askDialogVar.dialog('open');
                $('.ui-dialog-titlebar').hide();

                try {
                    if (caption == '')
                        askDialogVar.html(ask.html);
                    else
                        askDialogVar.html('<font size="larger">' + caption + '</font><br /><br />' + ask.html);

                    //anything here potentially will not run in IE; the .html() method can throw an error for no reason
                }
                catch (Error) {
                    //removed because of meaningless IE error message
                    //alert('Ask RTE: ' + Error);
                }

                askDialogVar.dialog('open');

                if (ask.after != undefined) {
                    if (ask.after != "")
                        askDialogVar.append(ask.after);
                }
            }
        });
}

function AskDialogClose() {
    askDialogVar.dialog('close');
}

function Reply(askId, dataArray) {

    AskDialogClose();

    requestNumber++;

    var holdArray = [];
    holdArray.push({ name: "askId", value: askId });

    var useArray = holdArray.concat(dataArray);

    AsyncLink();

    $.ajax(
        {
            method: "post",
            data: useArray,
            url: "Action.aspx?skipcache=" + requestNumber,
            dataType: "json",
            timeout: 0,
            success: function (data) {
                AsyncResponseHandle(data);
            },

            error: function (objAJAXRequest, strError) {
                ActionErrorHandle(strError);
            }
        });
}

var askCancelArgsVar;
function AskCancelArgs(askId, caption) {
    if (askCancelArgsVar == undefined) {
        askCancelArgsVar = $('#dialog_div').dialog({
            autoOpen: false,
            height: 210,
            width: 470,
            modal: true,
            resizable: true,
            draggable: true
        });
    }
    requestNumber++;
    $.ajax(
        {
            method: "get",
            url: "Ask.aspx?skipcache=" + requestNumber + "&askId=" + askId,
            dataType: "html",
            timeout: 0,
            success: function (data) {
                askCancelArgsVar.dialog('open');
                $('.ui-dialog-titlebar').hide();
                if (caption == '')
                    askCancelArgsVar.html(data);
                else
                    askCancelArgsVar.html('<font size="large">' + caption + '</font><br /><br />' + data);
            }
        });
}

function AskCancelClose() {
    askCancelArgsVar.dialog('close');
}

function ReplyCancel(askId, dataArray) {
    AskCancelClose();
    requestNumber++;
    var holdArray = [];
    holdArray.push({ name: "askId", value: askId });
    var useArray = holdArray.concat(dataArray);

    AsyncLink();

    $.ajax(
        {
            method: "post",
            data: useArray,
            url: "Action.aspx?skipcache=" + requestNumber,
            dataType: "json",
            timeout: 0,
            success: function (data) {
                AsyncResponseHandle(data);
            },
            error: function (objAJAXRequest, strError) {
                ActionErrorHandle(strError);
            }

        });
}

function Refresh(request) {

    var xDiv = $("#" + request.div);
    if (xDiv.length == 0) {

        var pDiv = $("#" + request.parentdiv);
        if (pDiv.length != 0) {
            pDiv.append(request.definitionhtml + request.html + "</div>");
            return;
        }
    }

    //trying to get the ui to refresh first
    //setTimeout(function () {

        $("#" + request.div).html(request.html);

        for (i = 0; i < request.css.length; i++) {
            var css = request.css[i];
            $("#" + request.div).css(css.key, css.value);
        }

    //}, 0);
}

function isEnterKeyPress(event) {
    return (event.keyCode == 13);
}

function Replace(request) {
    $("#" + request.elementid).replaceWith(request.html);
}

function Script(script) {
    //alert(script.src);
    eval(script.src);
}

function Remove(request) {
    $("#" + request.div).remove();
}



function ProcessRequest(request) {

    if (request.id == "dialog") {
        Dialog(request);
    }
    else if (request.id == "refresh") {
        Refresh(request);
    }
    else if (request.id == "script") {
        Script(request);
    }
    else if (request.id == "remove") {
        Remove(request);
    }
    else if (request.id == "replace") {
        Replace(request);
    }
}

function Spin(id) {

    var x = $('#' + id);
    if (x == undefined)
        return;

    x.html('<div class="asyncprogressdiv" style="padding: 4px"><img class="asyncspin" border="0" src="Jq/images/ui-anim_basic_16x16.gif"/><div class="asyncstatus">Searching...</div><div class="asyncprogress" style=\"width: 120px; height: 10px\"></div>');
}
function SpinDownload(id) {

    var x = $('#' + id);
    if (x == undefined)
        return;

    x.html('<div class="asyncprogressdiv" style="padding: 4px"><img class="asyncspin" border="0" src="Jq/images/ui-anim_basic_16x16.gif"/><div class="asyncstatus">Downloading...</div><div class="asyncprogress" style=\"width: 120px; height: 10px\"></div>');
}
function SpinSimple(id) {

    var x = $('#' + id);
    if (x == undefined)
        return;

    x.html('<div style="padding: 4px"><img border="0" src="Jq/images/ui-anim_basic_16x16.gif"/></div>');
}

function updateProgressPercent(pct) {
    $('.asyncprogress').progressbar({
        value: pct
    });
}

function updateProgress(evt) {

    if (evt.lengthComputable) {  //evt.loaded the bytes browser receive
        //evt.total the total bytes seted by the header
        //
        updateProgressPercent((evt.loaded / evt.total) * 100);
    }
}

var AsyncLinkPostProcess;

function xhrProvider() {

    var xhr = jQuery.ajaxSettings.xhr();
    xhr.onprogress = updateProgress;

//    xhr.onreadystatechange = function (aEvt) {
////        if (xhr.readyState == 4) {
////            alert("done");
////        }
//    };

    return xhr;
}

function AsyncResponseHandle(data) {

    var i = 0;
    //var refreshIncluded = false;
    //refresh requests first, to make sure the dom objects are there for scripts
    for (i = 0; i < data.d.length; i++) {

        var request = data.d[i];
        if (request.id == "stop")
            return;

        if (request.id == "refresh") {
            try {
                //refreshIncluded = true;
                ProcessRequest(request);
            } catch (Error) { alert('Process RTE: ' + Error + '  Request: ' + request.src); }
        }
    }

    //process everything else
    for (i = 0; i < data.d.length; i++) {

        var request = data.d[i];

        if (request.id != "refresh") {
            try {
                ProcessRequest(request);
            } catch (Error) { alert('Process RTE: ' + Error + '  Request: ' + request.src); }
        }
    }

    if (AsyncLinkPostProcess != undefined) {
        try {
            AsyncLinkPostProcess();
        } catch (Error) { alert('Post Process RTE: ' + Error); }
    }

//    if( refreshIncluded )
    DoResize();
    
    AsyncLink();
}

var AjaxAsyncRequestToken;
var AsyncConnected = false;
function AsyncLink() {

    return;

//    if (AsyncCancel)
//        return;

//    if (AsyncConnected)
//        return;

//    requestNumber++;
//    AsyncConnected = true;
//    AjaxAsyncRequestToken = $.ajax(
//        {
//            method: "get",
//            url: "AsyncLink.aspx?vid=" + viewId + "&sid=" + spotId + "&skipcache=" + requestNumber,
//            dataType: "json",
//            //alternative
//            //timeout: 0,

//            timeout: 60000,

//            success: function (data) {

//                AsyncConnected = false;
//                var progressDisplay = $('.asyncprogressdiv');
//                if (progressDisplay.length > 0) {
//                    updateProgressPercent(100);
//                    $('.asyncstatus').text('Loading...');
//                    $('.asyncspin').hide();

//                    //trying to get the ui to refresh first
//                    setTimeout(function () {
//                        AsyncResponseHandle(data);
//                    }, 10);
//                }
//                else
//                    AsyncResponseHandle(data);
//            },

//            error: function (objAJAXRequest, strError) {
//                AsyncConnected = false;
//                //disabled for alternative
//                //AsyncLink();
//            }

//            , xhr: xhrProvider
//        });
}

function Action(sid, cid, actionId, actionParams) {

    requestNumber++;

    AsyncLink();

    $.ajax(
        {
            url: "Action.aspx?skipcache=" + requestNumber,
            type: "post",
            data: { vid: viewId, sid: sid, cid: cid, action_id: actionId, action_params: actionParams },
            dataType: "json",
            timeout: 0,
            success: function (data) {
                AsyncResponseHandle(data);
            },

            error: function (objAJAXRequest, strError) {
                ActionErrorHandle(strError);
            }
        });

}

function ActionErrorHandle(errorString) {
    //alert("Action Error: " + errorString);
}

function ActionPlusControls(sid, cid, actionId, actionParams) {
    var datarray = ControlDataArray(cid);
    datarray.push({ name: "action_id", value: actionId });
    datarray.push({ name: "action_params", value: actionParams });
    PostAction(sid, cid, datarray);
}

function PostAction(sid, cid, datarray) {

    requestNumber++;

    datarray.push({ name: "sid", value: sid });
    datarray.push({ name: "cid", value: cid });
    datarray.push({ name: "vid", value: viewId });

    AsyncLink();

    $.ajax({
        type: "POST",
        url: "Action.aspx?skipcache=" + requestNumber,
        data: datarray,
        success: function (data) {
            AsyncResponseHandle(data);
        },
        error: function (objAJAXRequest, strError) {
            ActionErrorHandle(strError);
        }

    });
}

function ControlDataArray(cid) {
    var datarray = [];
    //var d = $("#l_" + cid);

    $("#l_" + cid).find(":input[type=checkbox]").each(function (index) {

        if ($(this).attr('name').toLowerCase().indexOf('ctl_') == 0) {

            if ($(this).attr('checked')) {
                datarray.push({ name: $(this).attr("name"), value: true });
            }
            else {
                datarray.push({ name: $(this).attr("name"), value: false });
            }
        }
    });

    $("#l_" + cid).find(":input[type=radio]").each(function (index) {
        if ($(this).attr('name').toLowerCase().indexOf('ctl_') == 0 && $(this).attr('checked')) {
            datarray.push({ name: $(this).attr("name"), value: $(this).val() });
        }
    });

    $("#l_" + cid).find(":input[type!=checkbox]").each(function (index) {

        var controlType = $(this).attr('type');
        if (controlType == undefined)
            controlType = "";

        switch (controlType.toLowerCase()) {
            case 'button':
            case 'checkbox':
            case 'radio':
                break;
            default:
                if ($(this).attr('name').toLowerCase().indexOf('ctl_') == 0)
                    datarray.push({ name: $(this).attr("name"), value: $(this).val() });
                break;
        }
    });

    return datarray;
}

function ItemSave(sid, cid, close) {

    var datarray = ControlDataArray(cid);

    if (close)
        datarray.push({ name: "action_id", value: "item_save_close" });
    else
        datarray.push({ name: "action_id", value: "item_save" });

    datarray.push({ name: "action_params", value: "" });
    PostAction(sid, cid, datarray);
}

//why were these both in here?
//$(document).ready(function () {

//    //alert('document ready');
//    var t = setTimeout("AsyncLink()", 10000);  //solves the throbber of death problem

//});

$(window).load(function () {

    var t = setTimeout("AsyncLink()", 500);  //solves the throbber of death problem

    window.onbeforeunload = function (e) {
        AsyncAbort();
    }

});

function ConvertToPostString(stringValue) {
    if (typeof stringValue === "undefined") {
        return stringValue;
    }
    var v = RemoveConvertedKeyChars(stringValue);
    v = ConvertKeyChars(v);
    v = FilterChars(v);
    v = ChangeKeyChars(v);
    return v;
}
function RemoveConvertedKeyChars(stringValue) {
    var v = "";
    for (i = 0; i < stringValue.length; i++) {
        switch (stringValue.charAt(i)) {
            case "\0":
            case "\b":
                break;
            default:
                v += stringValue.charAt(i);
                break;
        }
    }
    return v;
}
function ConvertKeyChars(stringValue) {
    var v = "";
    for (i = 0; i < stringValue.length; i++) {
        switch (stringValue.charAt(i)) {
            case "[":
                v += '\0';
                break;
            case "]":
                v += '\b';
                break;
            default:
                v += stringValue.charAt(i);
                break;
        }
    }
    return v;
}
function FilterChars(stringValue) {
    var v = "";
    for (i = 0; i < stringValue.length; i++) {
        switch (stringValue.charAt(i)) {
            case ":":
                v += "[colon]";
                break;
            case "\\":
                v += "[backslash]";
                break;
            case " ":
            case String.fromCharCode(160):
            case "\xA0":
                v += "[space]";
                break;
            case ".":
                v += "[period]";
                break;
            case "&":
                v += "[and]";
                break;
            case "-":
                v += "[dash]";
                break;
            case "\'":
                v += "[singlequote]";
                break;
            case "|":
                v += "[pipe]";
                break;
            case "\"":
                v += "[doublequote]";
                break;
            case "\f":
                v += "[formfeed]";
                break;
            case "\n":
                v += "[newline]";
                break;
            case "\r":
                v += "[return]";
                break;
            case "\t":
                v += "[htab]";
                break;
            case "\v":
                v += "[vtab]";
                break;
            case "!":
                v += "[exclamation]";
                break;
            case "@":
                v += "[atsymb]";
                break;
            case "#":
                v += "[pound]";
                break;
            case "$":
                v += "[dollar]";
                break;
            case "%":
                v += "[perc]";
                break;
            case "^":
                v += "[carrot]";
                break;
            case "*":
                v += "[star]";
                break;
            case "(":
                v += "[openpar]";
                break;
            case ")":
                v += "[closepar]";
                break;
            case "_":
                v += "[uscore]";
                break;
            case "+":
                v += "[plus]";
                break;
            case "=":
                v += "[equal]";
                break;
            case "~":
                v += "[tilde]";
                break;
            case "`":
                v += "[apost]";
                break;
            case "{":
                v += "[openbrace]";
                break;
            case "}":
                v += "[closebrace]";
                break;
            case "[":
                v += "[openbrack]";
                break;
            case "]":
                v += "[closebrack]";
                break;
            case ";":
                v += "[semic]";
                break;
            case ",":
                v += "[comma]";
                break;
            case "<":
                v += "[lessthn]";
                break;
            case ">":
                v += "[greaterthn]";
                break;
            case "/":
                v += "[fslash]";
                break;
            case "?":
                v += "[question]";
                break;
            default:                
                v += stringValue.charAt(i);
                break;
        }
    }
    return v;
}
function ChangeKeyChars(stringValue) {
    var v = "";
    for (i = 0; i < stringValue.length; i++) {
        switch (stringValue.charAt(i)) {
            case "\0":
                v += "[openbrack]";
                break;
            case "\b":
                v += "[closebrack]";
                break;
            default:
                v += stringValue.charAt(i);
                break;
        }
    }
    return v;
}

function ShowDiv(showDiv) {
    $('#' + showDiv).css('visibility', 'visible');
}

function HideDiv(hideDiv) {
    $('#' + hideDiv).css('visibility', 'hidden');
}

function ShowDivIndex(showDiv, indexDiv) {
    $('#' + showDiv).css('visibility', 'visible');
    $('#' + indexDiv).css('z-index', 1000);
}

function HideDivIndex(hideDiv, indexDiv) {
    $('#' + hideDiv).css('visibility', 'hidden');
    $('#' + indexDiv).css('z-index', 10);
}

function RunLinkProtocol(url) {
    var win = window.open(url);
    if (win == undefined) {
        alert('Enable pop-ups on this page');
        return;
    }
    win.close();
}

function buttonize(bid, image) {
    $('#' + bid).css('background-image', 'url(Graphics/' + image + ')').css('background-repeat', 'no-repeat').css('background-position', 'center 2px').css('padding', '35px 6px 0px 6px').button();
}

var iFramePostAction = null;

function iframePostForm(formId) {
    var response,
		returnResponse,
		element,
		status = true,
		iframe;

    if (!$('#iframe-post-form').length) {
        $('body').append('<iframe id="iframe-post-form" name="iframe-post-form" style="display:none" />');
    }

    return $('#' + formId).each(function () {
        element = $(this);

        // Target the iframe.
        element.attr('target', 'iframe-post-form');

        // Submit listener.
        element.submit(function () {

            iframe = $('#iframe-post-form').load(function () {
                response = iframe.contents().find('body');
                returnResponse = response.html();

                iframe.unbind('load');

                setTimeout(function () {
                    response.html('');
                }, 1);

                if (iFramePostAction != null) {
                    setTimeout(iFramePostAction, 1000);
                }
            });
        });
    });
}

function endsWith(str, suffix) {
    return str.indexOf(suffix, str.length - suffix.length) !== -1;
}

function Pluralize(phrase) {

    if (endsWith(phrase, "y") && !endsWith(phrase, "ay"))  //this is a rough hack and an example of why English sucks
        return phrase.substr(0, phrase.len - 1) + "ies";
    else
        return phrase + "s";
}