using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using ProperTimeToGo.App_Start;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProperTimeToGo
{
    public partial class departamento : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                RetornarmenuSuperiorCrearMenuSuperior();
                CrearMenuSuperior();
                ObtenerDepartamentos();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CrearArbolDpartamentos();
        }

        #region OBTENER FUENTE DE DATOS

        private void ObtenerDepartamentos()
        {
            try
            {
                if (Session[Constantes.SesionTablaDepartamentos] == null)
                    Session[Constantes.SesionTablaDepartamentos] = new ClsEmpresa().ObtenerDepartamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private void CrearGrillaDepartamento()
        //{
        //    try
        //    {
        //        ObtenerDepartamentos();
        //        DataTable dtbTmp = (DataTable)Session[Constantes.SesionTablaDepartamentos];

        //        // Propiedades de la tabla
        //        grvDepartamentos.AutoGenerateColumns = false;
        //        grvDepartamentos.KeyFieldName = Constantes.ColumnaDepartamentoCodigo;
        //        // Para la edicion en linea
        //        grvDepartamentos.SettingsEditing.Mode = GridViewEditingMode.Batch;
        //        grvDepartamentos.SettingsEditing.BatchEditSettings.StartEditAction = GridViewBatchStartEditAction.DblClick;
        //        // Propiedades de paginación
        //        grvDepartamentos.SettingsPager.AlwaysShowPager = false;
        //        grvDepartamentos.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
        //        // Genera columnas
        //        foreach (DataColumn dtc in dtbTmp.Columns)
        //        {
        //            // columna normal
        //            GridViewDataTextColumn colText = new GridViewDataTextColumn();
        //            colText.FieldName = dtc.Caption.ToString();
        //            if (dtc.Caption.ToUpper() != Constantes.ColumnaDepartamentoNombre.ToUpper())
        //            {
        //                colText.Visible = false;
        //            }
        //            grvDepartamentos.Columns.Add(colText);
        //            //break;

        //        }
        //        // Asigna la fuente de datos
        //        grvDepartamentos.DataSource = dtbTmp;
        //        // rederizar data 
        //        grvDepartamentos.DataBind();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion

        #region CREARTREELIST

        private void CrearArbolDpartamentos()
        {
            try
            {
                trlDepartamentos.DataSource = (DataTable)Session[Constantes.SesionTablaDepartamentos];
                trlDepartamentos.KeyFieldName = Constantes.ColumnaDepartamentoCodigo;
                trlDepartamentos.ParentFieldName = Constantes.ColumnaDepartamentoPadre;
                //trlDepartamentos.Width = Unit.Percentage(100);
                //trlDepartamentos.Theme = "Office365";
                //trlDepartamentos.Settings.ShowTreeLines = false;
                //trlDepartamentos.Settings.ShowColumnHeaders = false;
                //trlDepartamentos.SettingsBehavior.AllowFocusedNode = true;
                //trlDepartamentos.SettingsBehavior.AllowAutoFilter = true;
                //trlDepartamentos.SettingsEditing.Mode = TreeListEditMode.Batch;

                trlDepartamentos.DataBind();
                trlDepartamentos.StartEdit("2");
                trlDepartamentos.StartEdit("3");
                trlDepartamentos.ExpandToLevel(1);
                //trlDepartamentos.ExpandToLevel(1);
                //trlDepartamentos.StartEdit("1");
                //for (int i = 0; i < trlDepartamentos.Columns.Count; i++)
                //{
                //    trlDepartamentos.Columns[i].Visible = false;
                //}
                //trlDepartamentos.Columns[Constantes.ColumnaDepartamentoNombre].Visible = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        
        #region EVENTOS GRILLA
             
        #endregion

        #region MENUSUPERIOR

        private void RetornarmenuSuperiorCrearMenuSuperior()
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

        protected void CrearMenuSuperior()
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

        protected void trlDepartamentos_InitNewNode(object sender, ASPxDataInitNewRowEventArgs e)
        {
            // int intCodigo = new ClsGeneral().ObtenerNuevoCodigo((DataTable)Session[Constantes.SesionTablaDepartamentos], Constantes.ColumnaDepartamentoCodigo);
            if (trlDepartamentos.FocusedNode != null)
            {
                string strParentKey = trlDepartamentos.FocusedNode.Key;
                // e.NewValues[Constantes.ColumnaDepartamentoCodigo] = intCodigo;
                if (e.NewValues.Count > 0)
                {
                    e.NewValues[Constantes.ColumnaDepartamentoPadre] = strParentKey;
                    trlDepartamentos.StartEditNewNode(strParentKey);
                }
            }
            
        }
        
        protected void trlDepartamentos_NodeInserting(object sender, ASPxDataInsertingEventArgs e)
        {

            string strParentKey = trlDepartamentos.FocusedNode.Key;
            DataTable dtbTrl = (DataTable)Session[Constantes.SesionTablaDepartamentos];
            DataRow dtrNew = dtbTrl.NewRow();
            dtrNew[Constantes.ColumnaDepartamentoCodigo] = new ClsGeneral().ObtenerNuevoCodigo(dtbTrl, Constantes.ColumnaDepartamentoCodigo);
            dtrNew[Constantes.ColumnaDepartamentoPadre] = Convert.ToInt32(strParentKey);
            dtrNew[Constantes.ColumnaDepartamentoNombre] = e.NewValues[Constantes.ColumnaDepartamentoNombre];
            dtbTrl.Rows.Add(dtrNew);
            new ClsDepartamento().AdministrarDepartamento((DataTable)Session[Constantes.SesionTablaCentroCostos],(int)EnumAccionTabla.Insert);
            Session[Constantes.SesionTablaDepartamentos] = dtbTrl;
            trlDepartamentos.DataBind();
            e.Cancel = true;
            trlDepartamentos.CancelEdit();
        }

        protected void trlDepartamentos_NodeUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            string strParentKey = trlDepartamentos.FocusedNode.Key;
            DataTable dtbTrl = (DataTable)Session[Constantes.SesionTablaDepartamentos];
            DataRow dtrRow = dtbTrl.Rows.Find(new object[] { e.Keys[0] });
            dtrRow[Constantes.ColumnaDepartamentoNombre] = e.NewValues[Constantes.ColumnaDepartamentoNombre];
            new ClsDepartamento().AdministrarDepartamento((DataTable)Session[Constantes.SesionTablaCentroCostos], (int)EnumAccionTabla.Update);
            Session[Constantes.SesionTablaDepartamentos] = dtbTrl;
            trlDepartamentos.DataBind();
            e.Cancel = true;
            trlDepartamentos.CancelEdit();
        }

        protected void trlDepartamentos_NodeDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            string strParentKey = trlDepartamentos.FocusedNode.Key;
            DataTable dtbTrl = (DataTable)Session[Constantes.SesionTablaDepartamentos];
            DataRow dtrRow = dtbTrl.Rows.Find(new object[] { e.Keys[0] });
            dtrRow.Delete();
            new ClsDepartamento().AdministrarDepartamento((DataTable)Session[Constantes.SesionTablaCentroCostos], (int)EnumAccionTabla.Delete);
            Session[Constantes.SesionTablaDepartamentos] = dtbTrl;
            trlDepartamentos.DataBind();
            e.Cancel = true;
            trlDepartamentos.CancelEdit();
        }
    }
}