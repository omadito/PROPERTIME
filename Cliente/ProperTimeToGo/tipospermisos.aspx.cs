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
    public partial class tipospermisos : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                ObtenerTiposPermisos();
                RetornarMenuSuperior();

            }
            CrearMenuSuperior();
            CrearGrilla();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region CREAR GRILLA

        private void ObtenerTiposPermisos()
        {
            try
            {
                if (Session[Constantes.SesionTablaPermisos] == null)
                    Session[Constantes.SesionTablaPermisos] = new ClsConfiguracion().ObtenerTiposPermisos();
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
                DataTable dtbTmp = (DataTable)Session[Constantes.SesionTablaPermisos];

                new ClsGeneral().ConfigurarGridView(grvTiposPermisos, (DataTable)Session[Constantes.SesionTablaPermisos], Constantes.ColumnaPermisoCodigo, new ClsConfiguracion().RetornarColumnasTipoPermiso());
                grvTiposPermisos.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);
                                
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
                dtbEliminados.Columns.Add(Constantes.ColumnaTipoPermisoCodigo, typeof(int));

                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, dtbEliminados);
                
                new ClsConfiguracion().GestionarTipoPermiso((DataTable)Session[Constantes.SesionTablaPermisos], dtbEliminados);
                
                grvTiposPermisos.DataSource = (DataTable)Session[Constantes.SesionTablaPermisos];
                grvTiposPermisos.DataBind();
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
                dataTable = (DataTable)Session[Constantes.SesionTablaPermisos];

                dtrNueva = dataTable.NewRow();
                foreach (var item in newValues.Keys)
                {
                    dtrNueva[(string)item] = Convert.ToString(newValues[item]);
                }
                // Ingresa el nuevo código
                dtrNueva[Constantes.ColumnaPermisoCodigo] = new ClsGeneral().ObtenerNuevoCodigo(dataTable, Constantes.ColumnaPermisoCodigo);
                // Agrega la nueva fila a la tabla
                dataTable.Rows.Add(dtrNueva);
                Session[Constantes.SesionTablaPermisos] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaPermisos];
                Update(keys, newValues, dataTable);
                Session[Constantes.SesionTablaPermisos] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaPermisos];
                Delete(keys, dataTable, dtbEliminados);
                Session[Constantes.SesionTablaPermisos] = dataTable;
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
                dtr[Constantes.ColumnaTipoPermisoCodigo] = keys[0];
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