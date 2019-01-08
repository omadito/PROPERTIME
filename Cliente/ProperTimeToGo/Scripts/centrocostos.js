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
    grvCentroCostos.AddNewRow();
}
// Actualiza los datos ingresados o modificados
function OnUpdateRow(e) {
    grvCentroCostos.UpdateEdit();
}
// habilita la edicion en la fila con focus
function OnEditRow(e) {
    var index = grvCentroCostos.GetFocusedRowIndex();
    grvCentroCostos.StartEditRow(index);
}
// Elimina datos
function OnDeleteRow(e) {
    var index = grvCentroCostos.GetFocusedRowIndex();
    grvCentroCostos.DeleteRow(index);
}

function OnCancelEdit(s) {
    grvCentroCostos.CancelEdit();
}