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
    public partial class costocomida : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                ObtenerCostoComida();
                RetornarMenuSuperior();

            }
            CrearMenuSuperior();
            CrearGrilla();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region CREAR GRILLA

        private void ObtenerCostoComida()
        {
            try
            {
                if (Session[Constantes.SesionTablaCostoComida] == null)
                    Session[Constantes.SesionTablaCostoComida] = new ClsConfiguracion().ObtenerCostoComida();
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
                               
                new ClsGeneral().ConfigurarGridView(grvCostoComida, (DataTable)Session[Constantes.SesionTablaCostoComida], 
                    Constantes.ColumnaCostoComidaCodigo, new ClsConfiguracion().RetornarColumnasCostoComida());
                grvCostoComida.BatchUpdate += new ASPxDataBatchUpdateEventHandler(Grid_BatchUpdate);

                //// Propiedades de la tabla
                //grvCostoComida.AutoGenerateColumns = false;
                //grvCostoComida.KeyFieldName = Constantes.ColumnaCostoComidaCodigo;
                //// Para la edicion en linea
                //grvCostoComida.SettingsEditing.Mode = GridViewEditingMode.Batch;
                //grvCostoComida.SettingsEditing.BatchEditSettings.StartEditAction = GridViewBatchStartEditAction.DblClick;
                //// Propiedades de paginación
                //grvCostoComida.SettingsPager.AlwaysShowPager = false;
                //grvCostoComida.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
                //// Genera columnas
                //foreach (DataColumn dtc in dtbTmp.Columns)
                //{
                //    string strTipoDato = dtc.DataType.Name.ToString();
                //    string strColumna = dtc.Caption.ToString();
                //    bool bolEsVisible = true;
                //    bool bolEsCodigo = true;

                //    if (dtc.Caption.ToUpper() == Constantes.ColumnaCostoComidaCodigo.ToUpper())
                //    {
                //        bolEsCodigo = true;
                //    }
                //    else
                //    {
                //        bolEsCodigo = false;
                //    }
                //    if (strTipoDato == "DateTime")
                //    {
                //        strTipoDato = "time";
                //    }
                //    else if (dtc.Caption.ToUpper() == Constantes.ColumnaFeriadosCiudad.ToUpper())
                //    {
                //        strTipoDato = "ComboBox";
                //    }

                //    //new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvCostoComida, bolEsVisible, bolEsCodigo, null,
                //    //   string.Empty, string.Empty);

                //}
                //// Asigna la fuente de datos
                //grvCostoComida.DataSource = dtbTmp;
                //// rederizar data 
                //grvCostoComida.DataBind();
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
                dtbEliminados.Columns.Add(Constantes.ColumnaCostoComidaCodigo, typeof(int));

                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, dtbEliminados);

                new ClsConfiguracion().GestionarCostoComida((DataTable)Session[Constantes.SesionTablaCostoComida], dtbEliminados);
                //Session[Constantes.TablaDistribucion] = null;
                grvCostoComida.DataSource = (DataTable)Session[Constantes.SesionTablaCostoComida];
                grvCostoComida.DataBind();
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
                dataTable = (DataTable)Session[Constantes.SesionTablaCostoComida];

                dtrNueva = dataTable.NewRow();
                foreach (var item in newValues.Keys)
                {
                    dtrNueva[(string)item] = Convert.ToString(newValues[item]);
                }
                // Ingresa el nuevo código
                dtrNueva[Constantes.ColumnaCostoComidaCodigo] = new ClsGeneral().ObtenerNuevoCodigo(dataTable, Constantes.ColumnaCostoComidaCodigo);
                // Agrega la nueva fila a la tabla
                dataTable.Rows.Add(dtrNueva);
                Session[Constantes.SesionTablaCostoComida] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaCostoComida];
                Update(keys, newValues, dataTable);
                Session[Constantes.SesionTablaCostoComida] = dataTable;
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
                DataTable dataTable = (DataTable)Session[Constantes.SesionTablaCostoComida];
                Delete(keys, dataTable, dtbEliminados);
                Session[Constantes.SesionTablaCostoComida] = dataTable;
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
                dtr[Constantes.ColumnaCostoComidaCodigo] = keys[0];
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