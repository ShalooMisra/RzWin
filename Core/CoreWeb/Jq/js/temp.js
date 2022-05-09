$('#dialog').dialog({
  autoOpen: false,
  height: 280,
  modal: true,
  resizable: false,
  buttons: {
    Continue: function() {
      $(this).dialog('close');
    },
  'Change Rating': function() {
    $(this).dialog('close');
    }
  }
});