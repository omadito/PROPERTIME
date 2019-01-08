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
    public partial class ciudades : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                ObtenerCiudades();
                RetornarMenuSuperior();

            }
            CrearMenuSuperior();
            CrearGrilla();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region CREAR GRILLA

        private void ObtenerCiudades()
        {
            try
            {
                if (Session[Constantes.SesionTablaCiudades] == null)
                    Session[Constantes.SesionTablaCiudades] = new ClsGeneral().ObtenerCiudad();
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
                string[] strColumnasVisibles = { Constantes.ColumnaCiudadesNombre };
                //new ClsGeneral().ConfigurarGridView(grvCiudades, (DataTable)Session[Constantes.SesionTablaCiudades], Constantes.ColumnaCiudadesCodigo, null);
                new ClsGeneral().ConfigurarGridView(grvCiudades, (DataTable)Session[Constantes.SesionTablaCiudades], Constantes.ColumnaCiudadesCodigo, new ClsConfiguracion().RetornarColumnasCiudades());
                //eventos
                grvCiudades.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);
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
                dtbEliminados.Columns.Add(Constantes.ColumnaCiudadesCodigo, typeof(int));

                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, dtbEliminados);

                new ClsGeneral().GestionarCiudad((DataTable)Session[Constantes.SesionTablaCiudades], dtbEliminados);
                grvCiudades.DataSource = (DataTable)Session[Constantes.SesionTablaCiudades];
                grvCiudades.DataBind();
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
                dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];

                dtrNueva = dataTable.NewRow();
                foreach (var item in newValues.Keys)
                {
                    dtrNueva[(string)item] = Convert.ToString(newValues[item]);
                }
                // Ingresa el nuevo código
                dtrNueva[Constantes.ColumnaCiudadesCodigo] = new ClsGeneral().ObtenerNuevoCodigo(dataTable, Constantes.ColumnaCiudadesCodigo);
                // Agrega la nueva fila a la tabla
                dataTable.Rows.Add(dtrNueva);
                Session[Constantes.SesionTablaCiudades] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];
                Update(keys, newValues, dataTable);
                Session[Constantes.SesionTablaCiudades] = dataTable;
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

        protected void DeleteItem(OrderedDictionary keys, DataTable dtbEliminados)
        {
            try
            {
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];
                Delete(keys, dataTable, dtbEliminados);
                Session[Constantes.SesionTablaCentroCostos] = dataTable;
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
                dtr[Constantes.ColumnaCiudadesCodigo] = keys[0];
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

        //#region INSERTAR

        //protected void grvCiudades_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        //{
        //    DataTable dataTable;
        //    DataRow dtrNueva = null;
        //    try
        //    {
        //        dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];

        //        dtrNueva = dataTable.NewRow();
        //        foreach (var item in e.NewValues.Keys)
        //        {
        //            dtrNueva[(string)item] = Convert.ToString(e.NewValues[item]);
        //        }
        //        // Ingresa el nuevo código
        //        dtrNueva[Constantes.ColumnaCiudadesCodigo] = Convert.ToString(GetLastKey(dataTable));
        //        // Agrega la nueva fila a la tabla
        //        dataTable.Rows.Add(dtrNueva);
        //        Session[Constantes.SesionTablaCiudades] = dataTable;
        //        e.Cancel = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public Int32 GetLastKey(DataTable dtbTable)
        //{
        //    try
        //    {
        //        Int32 max = Int32.MinValue;
        //        if (dtbTable.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dtbTable.Rows)
        //            {
        //                if (Convert.ToInt32(row[Constantes.ColumnaCiudadesCodigo]) > max)
        //                    max = Convert.ToInt32(row[Constantes.ColumnaCiudadesCodigo]);
        //            }
        //        }
        //        else
        //        {
        //            max = 0;
        //        }
        //        return max + 1;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //#endregion

        //#region EDITAR

        //protected void grvCiudades_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        //{
        //    DataTable dataTable;
        //    try
        //    {
        //        dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];

        //        DataRow row = dataTable.Rows.Find(new object[] { e.Keys[0] });
        //        foreach (var item in e.NewValues.Keys)
        //        {
        //            row[(string)item] = Convert.ToString(e.NewValues[item]);
        //        }

        //        Session[Constantes.SesionTablaCiudades] = dataTable;
        //        e.Cancel = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //#endregion

        //#region ELIMINAR

        //protected void grvCiudades_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        //{
        //    DataTable dataTable;
        //    try
        //    {
        //        dataTable = (DataTable)Session[Constantes.SesionTablaCiudades];

        //        DataRow row = dataTable.Rows.Find(new object[] { e.Keys[0] });
        //        row.Delete();
        //        Session[Constantes.SesionTablaCiudades] = dataTable;
        //        e.Cancel = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //#endregion
    }
}