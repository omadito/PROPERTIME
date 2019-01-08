using DevExpress.Web;
using ProperTimeToGo.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProperTimeToGo
{
    public partial class empleado : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[Constantes.SesionTblDatosEmpleado] = null;
            Session[Constantes.SessionNuevoEmpleado] = null;
            DataTable dtbDatosEmpleado = new ClsEmpleados().RetornarEmpleado();
            grid.DataSource = dtbDatosEmpleado;
            grid.DataBind();
            grid.Settings.ShowColumnHeaders = false;
        }

        protected void grid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                int intIndiceRow = Convert.ToInt32(e.Parameters);
                DataRow dtr = grid.GetDataRow(intIndiceRow);
                //Session[Constantes.SesionCodigoEmpleado] = dtr[Constantes.ColumnaEmpleadoUserId].ToString();
                Session[Constantes.SesionUserIdEmpleado] = dtr[Constantes.ColumnaEmpleadoUserId].ToString();
                ASPxWebControl.RedirectOnCallback("~/datosempleado");
                //Response.Redirect("~/datosempleado", false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}