
function ConfirmDelete(s, e) {
    var strLlave = trlDepartamentos.GetFocusedNodeKey();
    popConfirm.deletedRowKey = strLlave;
    popConfirm.Show();
}

function DeleteConfirmed() {
    popConfirm.Hide();
    trlDepartamentos.DeleteNode(popConfirm.deletedRowKey);
    popConfirm.deletedRowKey = null;
}
function OnClickMenu(s, e) {
    var i = e.item.name;
    switch (i) {
        case "mnuNuevo":
            var strLlave = trlDepartamentos.GetFocusedNodeKey();
            //if (trlDepartamentos.IsEditing) {
            //    trlDepartamentos.UpdateEdit();
            //}
            trlDepartamentos.StartEditNewNode(strLlave);
            break;
        case "mnuGuardar":
            trlDepartamentos.UpdateEdit();
            break;
        case "mnuEditar":
            var strLlave = trlDepartamentos.GetFocusedNodeKey();
            //if (trlDepartamentos.IsEditing) {
            //    trlDepartamentos.UpdateEdit();
            //}
            trlDepartamentos.StartEdit(strLlave);
            break;
        case "mnuEliminar":
            ConfirmDelete();
            break;
        case "mnuCancelar":
            trlDepartamentos.CancelEdit();
            break;
    }
}
