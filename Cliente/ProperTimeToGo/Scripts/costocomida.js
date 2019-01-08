function OnClickMenu(s, e) {
    var i = e.item.name;
    switch (i) {
        case "mnuNuevo":
            OnNewRow(e);
            break;
        case "mnuGuardar":
            OnUpdateRow(e);
            break;
        case "mnuEditar":
            OnEditRow(e);
            break;
        case "mnuEliminar":
            OnDeleteRow(e);
            break;
        case "mnuCancelar":
            OnCancelEdit(s);
            break;
    }
}

// Crea una nueva fila
function OnNewRow(e) {
    grvCostoComida.AddNewRow();
}
// Actualiza los datos ingresados o modificados
function OnUpdateRow(e) {
    grvCostoComida.UpdateEdit();
}
// habilita la edicion en la fila con focus
function OnEditRow(e) {
    var index = grvCostoComida.GetFocusedRowIndex();
    grvCostoComida.StartEditRow(index);
}
// Elimina datos
function OnDeleteRow(e) {
    var index = grvCostoComida.GetFocusedRowIndex();
    grvCostoComida.DeleteRow(index);
}

function OnCancelEdit(s) {
    grvCostoComida.CancelEdit();
}