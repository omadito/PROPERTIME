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
    public partial class feriado : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {            
            if (!IsPostBack && !IsCallback)
            {
                ObtenerFeriados();
                RetornarMenuSuperior();

            }
            CrearMenuSuperior();
            CrearGrilla();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region CREAR GRILLA

        private void ObtenerFeriados()
        {
            try
            {
                if (Session[Constantes.SesionTablaFeriados] == null)
                    Session[Constantes.SesionTablaFeriados] = new ClsConfiguracion().ObtenerFeriados();
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
               
                DataTable dtbTmp = (DataTable)Session[Constantes.SesionTablaFeriados];

                new ClsGeneral().ConfigurarGridView(grvFeriados, (DataTable)Session[Constantes.SesionTablaFeriados], Constantes.ColumnaFeriadosCodigo, new ClsConfiguracion().RetornarColumnasFeriado());
                grvFeriados.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);
                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region EVENTOS GRILLA

        protected void Grid_BatchUpdate(object sender, ASPxDataBatchUpdateEventArgs e)
        {
            DataTable dtbEliminados = new DataTable();
            try
            {
                dtbEliminados.Columns.Add(Constantes.ColumnaFeriadosCodigo, typeof(int));

                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, dtbEliminados);

                new ClsConfiguracion().GestionarFeriado((DataTable)Session[Constantes.SesionTablaFeriados], dtbEliminados);
                //Session[Constantes.TablaDistribucion] = null;
                grvFeriados.DataSource = (DataTable)Session[Constantes.SesionTablaFeriados];
                grvFeriados.DataBind();
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
                dataTable = (DataTable)Session[Constantes.SesionTablaFeriados];

                dtrNueva = dataTable.NewRow();
                foreach (var item in newValues.Keys)
                {
                    dtrNueva[(string)item] = Convert.ToString(newValues[item]);
                }
                // Ingresa el nuevo código
                dtrNueva[Constantes.ColumnaFeriadosCodigo] = new ClsGeneral().ObtenerNuevoCodigo(dataTable, Constantes.ColumnaFeriadosCodigo);
                // Agrega la nueva fila a la tabla
                dataTable.Rows.Add(dtrNueva);
                Session[Constantes.SesionTablaFeriados] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaFeriados];
                Update(keys, newValues, dataTable);
                Session[Constantes.SesionTablaFeriados] = dataTable;
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
                    row[(string)item] = Convert.ToString(newValues[item]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void DeleteItem(OrderedDictionary keys,DataTable dtbEliminados)
        {
            try
            {
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaFeriados];
                Delete(keys, dataTable, dtbEliminados);
                Session[Constantes.SesionTablaFeriados] = dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete(OrderedDictionary keys, DataTable dataTable,DataTable dtbEliminados)
        {
            try
            {
                // Obtiene el registro a eliminar keys[0] por que el foreach envia el registro especifico
                DataRow row = dataTable.Rows.Find(keys[0]);
                row.Delete();
                DataRow dtr = dtbEliminados.NewRow();
                dtr[Constantes.ColumnaFeriadosCodigo] = keys[0];
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
                Session[Constantes.MenuSuperior] = new ClsMenu().RetornarMenuSuperior(1, 0);
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

                new ClsMenu().CrearMenuSuperior(mnuSuperior, (DataTable)Session[Constantes.MenuSuperior], Constantes.ColumnaMenuCodigo, Constantes.ColumnaMenuPadre, Constantes.ColumnaMenuNombre);
                mnuSuperior.ClientSideEvents.ItemClick = "OnClickMenu";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        
    }
}