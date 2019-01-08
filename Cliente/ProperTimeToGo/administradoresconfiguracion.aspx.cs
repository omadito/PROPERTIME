using DevExpress.Web;
using DevExpress.Web.Data;
using ProperTimeToGo.App_Start;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProperTimeToGo
{
    public partial class administradoresconfiguracion : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                RetornarEmpleadoAdministrador();
                RetornarMenuSuperior();

            }
            CrearMenuSuperior();
            CrearGrilla();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region GENERAR GRILLA

        private void RetornarEmpleadoAdministrador()
        {
            try
            {
                if (Session[Constantes.SesionTablaHorario] == null)
                {
                    Session[Constantes.SesionTablaHorario] = new ClsEmpleados().RetornarEmpleadoAdministrador();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CrearGrilla()
        {
            try
            {

                //new ClsGeneral().ConfigurarGridView(grvEmpleado, (DataTable)Session[Constantes.SesionTablaEmpleadoAdministrador], Constantes.ColumnaEmpleadoNumCA, new ClsEmpleados().RetornarColumnasEmpleadoAdmin());
                ////eventos                
                //grvEmpleado.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);
                //grvEmpleado.RowValidating += new ASPxDataValidationEventHandler(grvEmpleados_RowValidating);


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region EVENTOS GRILLA

        protected void grvEmpleados_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //DateTime dtmFechaDesde = new DateTime();
            //DateTime dtmFechaHasta = new DateTime();
            //try
            //{
            //    foreach (GridViewColumn column in grvEmpleado.Columns)
            //    {
            //        GridViewDataColumn dataColumn = column as GridViewDataColumn;
            //        if (dataColumn == null) continue;
            //        switch (dataColumn.FieldName)
            //        {
            //            case Constantes.ColumnaHorarioEntrada:
            //                if (e.NewValues[dataColumn.FieldName] == null)
            //                    dtmFechaDesde = Convert.ToDateTime(e.OldValues[dataColumn.FieldName]);
            //                else
            //                    dtmFechaDesde = Convert.ToDateTime(e.NewValues[dataColumn.FieldName]);
            //                break;
            //            case Constantes.ColumnaHorarioSalida:
            //                if (e.NewValues[dataColumn.FieldName] == null)
            //                    dtmFechaHasta = Convert.ToDateTime(e.OldValues[dataColumn.FieldName]);
            //                else
            //                    dtmFechaHasta = Convert.ToDateTime(e.NewValues[dataColumn.FieldName]);
            //                break;
            //        }
            //        if (dataColumn.FieldName == Constantes.ColumnaHorarioTipo)
            //        {
            //            if (e.NewValues[dataColumn.FieldName] != null)
            //            {
            //                if (Convert.ToInt32(e.NewValues[dataColumn.FieldName]) > 1)
            //                {
            //                    if (dtmFechaDesde != dtmFechaHasta)
            //                    {
            //                        e.Errors[dataColumn] = "Los horarios de 24 y 48 horas deben tener la misma hora de entrada y salida";
            //                    }
            //                }
            //            }

            //        }
            //        //if (e.NewValues[dataColumn.FieldName] == null)
            //        //    e.Errors[dataColumn] = "Value cannot be null.";
            //    }
            //    // Displays the error row if there is at least one error.
            //    if (e.Errors.Count > 0) e.RowError = "Error: Los horarios de 24 y 48 horas deben tener la misma hora de entrada y salida";
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        protected void Grid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            DataTable dtbEliminados = new DataTable();
            try
            {
                dtbEliminados.Columns.Add(Constantes.ColumnaHorarioSchclassid, typeof(int));

                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, dtbEliminados);

                new ClsHorariosAsistencia().GestionarHorario((DataTable)Session[Constantes.SesionTablaHorario], dtbEliminados);
                //Session[Constantes.TablaDistribucion] = null;
                //grvEmpleado.DataSource = (DataTable)Session[Constantes.SesionTablaHorario];
                //grvEmpleado.DataBind();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                //Session["ErrorMessage"] = ex.Message;
                //if (Page.IsCallback)
                //    ASPxWebControl.RedirectOnCallback("~/error.aspx");
                //else
                //    Response.Redirect("~/error.aspx", false);
            }
        }

        protected void InsertNewItem(OrderedDictionary newValues)
        {
            try
            {
                Insert(newValues);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Insert(OrderedDictionary newValues)
        {
            DataTable dataTable;
            DataRow dtrNueva = null;
            try
            {
                dataTable = (DataTable)Session[Constantes.SesionTablaHorario];

                dtrNueva = dataTable.NewRow();
                foreach (var item in newValues.Keys)
                {
                    dtrNueva[(string)item] = Convert.ToString(newValues[item]);
                }
                // Ingresa el nuevo código
                dtrNueva[Constantes.ColumnaHorarioSchclassid] = new ClsGeneral().ObtenerNuevoCodigo(dataTable, Constantes.ColumnaHorarioSchclassid);
                // Agrega la nueva fila a la tabla
                dataTable.Rows.Add(dtrNueva);
                Session[Constantes.SesionTablaHorario] = dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaHorario];
                Update(keys, newValues, dataTable);
                Session[Constantes.SesionTablaHorario] = dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Update(OrderedDictionary keys, OrderedDictionary newValues, DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows.Find(keys[0]);
                foreach (var item in newValues.Keys)
                {
                    //DataRow row = dataTable.Rows.Find(keys);
                    if (item.ToString() == "STARTTIME" || item.ToString() == "ENDTIME" ||
                item.ToString() == "CHECKINTIME1" || item.ToString() == "CHECKINTIME2" ||
                item.ToString() == "CHECKOUTTIME1" || item.ToString() == "CHECKOUTTIME2")
                    {
                        row[(string)item] = (Convert.ToString(newValues[item]).Split(' ')[1]).Substring(0, 5);
                    }
                    else
                    {
                        row[(string)item] = Convert.ToString(newValues[item]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void DeleteItem(OrderedDictionary keys, DataTable dtbEliminados)
        {
            try
            {
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaHorario];
                Delete(keys, dataTable, dtbEliminados);
                Session[Constantes.SesionTablaHorario] = dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete(OrderedDictionary keys, DataTable dataTable, DataTable dtbEliminados)
        {
            try
            {
                // Obtiene el registro a eliminar keys[0] por que el foreach envia el registro especifico
                DataRow row = dataTable.Rows.Find(keys[0]);
                row.Delete();
                DataRow dtr = dtbEliminados.NewRow();
                dtr[Constantes.ColumnaHorarioSchclassid] = keys[0];
                dtbEliminados.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MENUSUPERIOR

        private void RetornarMenuSuperior()
        {
            try
            {
                Session[Constantes.MenuSuperior] = new ClsMenu().RetornarMenuSuperior(1, 1);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CrearMenuSuperior()
        {
            try
            {

                //new ClsMenu().CrearMenuSuperior(mnuSuperior, (DataTable)Session[Constantes.MenuSuperior], Constantes.ColumnaMenuCodigo, Constantes.ColumnaMenuPadre, Constantes.ColumnaMenuNombre);
                //mnuSuperior.ClientSideEvents.ItemClick = "OnClickMenu";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}