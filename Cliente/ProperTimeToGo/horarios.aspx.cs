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
    public partial class horarios : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && !IsCallback)
                {
                    ObtenerHorarios();
                    RetornarMenuSuperior();
                }
                //CrearMenuSuperior();
                CrearGrilla();
            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
            {
                string strMensaje = (string)Session["Error"];
                Session["Error"] = null;
                Mostrarerror(strMensaje);
            }
        }

        #region GENERAR GRILLA

        private void ObtenerHorarios()
        {
            try
            {
                if (Session[Constantes.SesionTablaHorario] == null)
                {
                    Session[Constantes.SesionTablaHorario] = new ClsHorariosAsistencia().RetornarHorarios();
                }
            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }

        private void CrearGrilla()
        {
            try
            {

                new ClsGeneral().ConfigurarGridView(grvHorarios, (DataTable)Session[Constantes.SesionTablaHorario], Constantes.ColumnaHorarioSchclassid, new ClsHorariosAsistencia().RetornarColumnasHorario());
                //eventos                
                grvHorarios.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);
                grvHorarios.RowValidating += new ASPxDataValidationEventHandler(grvHorarios_RowValidating);


            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }
        #endregion

        #region EVENTOS GRILLA

        protected void grvHorarios_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DateTime dtmFechaDesde = new DateTime();
            DateTime dtmFechaHasta = new DateTime();
            try
            {
                foreach (GridViewColumn column in grvHorarios.Columns)
                {
                    GridViewDataColumn dataColumn = column as GridViewDataColumn;
                    if (dataColumn == null) continue;
                    switch (dataColumn.FieldName)
                    {
                        case Constantes.ColumnaHorarioEntrada:
                            if (e.NewValues[dataColumn.FieldName] == null)
                                dtmFechaDesde = Convert.ToDateTime(e.OldValues[dataColumn.FieldName]);
                            else
                                dtmFechaDesde = Convert.ToDateTime(e.NewValues[dataColumn.FieldName]);
                            break;
                        case Constantes.ColumnaHorarioSalida:
                            if (e.NewValues[dataColumn.FieldName] == null)
                                dtmFechaHasta = Convert.ToDateTime(e.OldValues[dataColumn.FieldName]);
                            else
                                dtmFechaHasta = Convert.ToDateTime(e.NewValues[dataColumn.FieldName]);
                            break;
                    }
                    if (dataColumn.FieldName == Constantes.ColumnaHorarioTipo)
                    {
                        if (e.NewValues[dataColumn.FieldName] != null)
                        {
                            if (Convert.ToInt32(e.NewValues[dataColumn.FieldName]) > 1)
                            {
                                if (dtmFechaDesde != dtmFechaHasta)
                                {
                                    e.Errors[dataColumn] = "Los horarios de 24 y 48 horas deben tener la misma hora de entrada y salida";
                                }
                            }
                        }

                    }
                    //if (e.NewValues[dataColumn.FieldName] == null)
                    //    e.Errors[dataColumn] = "Value cannot be null.";
                }
                // Displays the error row if there is at least one error.
                if (e.Errors.Count > 0) e.RowError = "Error: Los horarios de 24 y 48 horas deben tener la misma hora de entrada y salida";
            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
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
                grvHorarios.DataSource = (DataTable)Session[Constantes.SesionTablaHorario];
                grvHorarios.DataBind();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                ASPxWebControl.RedirectOnCallback("~/horarios.aspx");
            }            
        }

        protected void InsertNewItem(OrderedDictionary newValues)
        {
            try
            {
                Insert(newValues);
            }
            catch (Exception ex)
            {
                //Mostrarerror(ex.Message);
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
                    //    if (item.ToString() == "STARTTIME" || item.ToString() == "ENDTIME" ||
                    //item.ToString() == "CHECKINTIME1" || item.ToString() == "CHECKINTIME2" ||
                    //item.ToString() == "CHECKOUTTIME1" || item.ToString() == "CHECKOUTTIME2")
                    //    {
                    //        row[(string)item] = (Convert.ToString(newValues[item]).Split(' ')[1]).Substring(0,5);
                    //    }
                    //    else
                    //    {
                    row[(string)item] = Convert.ToString(newValues[item]);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MENUSUPERIOR

        private void RetornarMenuSuperior()
        {
            DataTable dtbMenuSuperior = new DataTable();
            try
            {
                if(Session[Constantes.TablaMenuSuperior] != null)
                {
                    DataTable dtbMenuSuperioPagina = (DataTable)Session[Constantes.TablaMenuSuperior];
                    dtbMenuSuperior = dtbMenuSuperioPagina.Clone();
                    DataRow[] dtrFilasSelect = dtbMenuSuperioPagina.Select(Constantes.ColumnaArbolCodigo + " = " + (int)EnumPagina.Horario);
                    foreach(DataRow dtr in dtrFilasSelect)
                    {
                        dtbMenuSuperior.ImportRow(dtr);
                    }
                    new ClsMenu().CrearMenuSuperior(mnuSuperior, dtbMenuSuperior, Constantes.ColumnaMenuCodigo, Constantes.ColumnaMenuPadre, Constantes.ColumnaMenuNombre);
                    mnuSuperior.ClientSideEvents.ItemClick = "OnClickMenu";
                }

            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }

        //private void CrearMenuSuperior()
        //{
        //    try
        //    {

        //        new ClsMenu().CrearMenuSuperior(mnuSuperior, (DataTable)Session[Constantes.MenuSuperior], Constantes.ColumnaMenuCodigo, Constantes.ColumnaMenuPadre, Constantes.ColumnaMenuNombre);
        //        mnuSuperior.ClientSideEvents.ItemClick = "OnClickMenu";
        //    }
        //    catch (Exception ex)
        //    {
        //        Mostrarerror(ex.Message);
        //    }
        //}

        #endregion
        #region ERROR

        protected void Mostrarerror(string strMensaje)
        {
            lblMensajeError.Text = strMensaje;
            pcLogin.ShowOnPageLoad = true;
        }
        #endregion
    }
}