// Funciones para bloqueo de pantalla
function divBlockUI(items, msg) {
    if (items == null) {
        items = $('body');
    }

    if (msg == null) {
        msg = 'Procesando Solicitud';
    }

    $(items).block({
        'css': { border: '0', backgroundColor: 'transparent' },
        'message': '<i class="fa fa-spinner fa-spin fa-5x"></i> <h2>' + msg + '<h2>'
        //'message': '<div class="alert alert-info"><i class="fa fa-spinner fa-spin fa-5x"></i> <h2>' + msg + '<h2></div>'
    });
}
function divUnBlockUI(items) {
    if (items == null) {
        items = $('body');
    }
    $(items).unblock();
}
function UnBlockUI() {
    $.unblockUI();
}
function BlockUI(msg) {
    if (msg == null) {
        msg = 'Cargando...';
    }

    $.blockUI({
        message: $('<div style="margin:auto;"><i class="fa fa-spinner fa-spin fa-4x"></i><span class="h1"> ' + msg + '</span></div>'),
        fadeIn: 0,
        fadeOut: 0,
        showOverlay: true,
        centerY: true,
        css: {
            width: '100%',
            top: '25%',
            left: 'auto',
            right: 'auto',
            border: 'none',
            padding: 'auto',
            backgroundColor: 'transparent',
            opacity: .8,
            color: '#fff'
        }
    });
}

// Funciones para formularios
function AjaxLinkId() {
    $('.AjaxLinkId').click(function (e) {
        e.preventDefault();
        divBlockUI();
        $.ajax({
            method: "POST",
            url: $(this).attr("href")
        })
      .done(function (html) {
          $('#divRenderBodySearch').html(html);
          divUnBlockUI();
      });
    });
}