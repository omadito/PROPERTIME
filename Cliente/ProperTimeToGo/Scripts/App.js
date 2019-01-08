$(".nav-menu").click(function (e) {
    var mnuNombre = $(this).attr("id");
    console.log(this);
    switch (mnuNombre) {
        case "mnuAdministracion":
            $("#navPage1").removeClass('ocultar').addClass('active');
            $("#navPage2").removeClass('active').addClass('ocultar');
            $(this).removeClass('active').addClass('ocultar');
            $("#mnuReportes").removeClass('ocultar').addClass('active');
            break;
        case "mnuReportes":
            $("#navPage2").removeClass('ocultar').addClass('active');
            $("#navPage1").removeClass('active').addClass('ocultar');
            $(this).removeClass('active').addClass('ocultar');
            $("#mnuAdministracion").removeClass('ocultar').addClass('active');
            break;
    }
});