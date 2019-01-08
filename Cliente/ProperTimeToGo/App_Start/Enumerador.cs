using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public enum EnumTipoComponente
    {
        TextBox = 1,
        Memo = 2,
        ComboBox = 3,
        DateEdit = 4,
        SpinEdit = 5
    }

    public enum EnumMenuSuperior
    {
        Nuevo = 1,
        Editar = 2,
        Guardar = 3,
        Eliminar = 4
    }

    public enum EnumAccionTabla
    {
        Insert = 1,
        Update = 2,
        Delete = 3
    }

    public enum EnumPagina
    {
        Administracion = 1,
        Reportes = 2,
        Horario = 17
    }
}