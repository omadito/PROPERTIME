using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
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
    public partial class InformacionAdicional : System.Web.UI.Page
    {
        bool isEditing = false;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                Session[Constantes.SessionTblInfoAdicional] = null;
                Session[Constantes.SessionTblInfoAdicional1] = null;
                RetornarInfoAdicional();
            }
            ConfigurarTreListDepartamento();
            GenerarGrilla();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session[Constantes.SessionTblInfoAdicional1] != null)
            {
                // Asigna la fuente de datos
                grvEmpleados.DataSource = (DataTable)Session[Constantes.SessionTblInfoAdicional1];
                // rederizar data 
                grvEmpleados.DataBind();
            }
        }

        #region DEPARTAMENTOS
        protected void ObtenerDepartamento()
        {
            try
            {
                if (Session[Constantes.SesionTblDepartamentoSm] == null)
                {
                    DataTable dtbDepartamento = new App_Start.ClsEmpresa().ObtenerDepartamentos();
                    Session[Constantes.SesionTblDepartamentoSm] = dtbDepartamento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ConfigurarTreListDepartamento()
        {
            try
            {
                ObtenerDepartamento();
                trlDepartamentos.DataSource = (DataTable)Session[Constantes.SesionTblDepartamentoSm];

                trlDepartamentos.ExpandToLevel(1);
                trlDepartamentos.KeyFieldName = Constantes.ColumnaDepartamentoCodigo;
                trlDepartamentos.ParentFieldName = Constantes.ColumnaDepartamentoPadre;
                trlDepartamentos.DataBind();
                for (int i = 0; i < trlDepartamentos.Columns.Count; i++)
                {
                    trlDepartamentos.Columns[i].Visible = false;
                }
                trlDepartamentos.Columns[Constantes.ColumnaDepartamentoNombre].Visible = true;
                trlDepartamentos.ExpandToLevel(1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region EMPLEADOS

        private void RetornarInfoAdicional()
        {
            try
            {
                if (Session[Constantes.SessionTblInfoAdicional] == null)
                {
                    Session[Constantes.SessionTblInfoAdicional] = new ClsEmpleados().RetornarInformacionAdicional();
                    Session[Constantes.SessionTblInfoAdicional1] = new ClsEmpleados().RetornarInformacionAdicional();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GenerarGrilla()
        {
            try
            {
                //RetornarInfoAdicional();
                DataTable dtbTmp = (DataTable)Session[Constantes.SessionTblInfoAdicional];

                // Propiedades de la tabla
                grvEmpleados.AutoGenerateColumns = false;
                grvEmpleados.KeyFieldName = Constantes.ColumnaInfoAdicUserId;
               // Propiedades de paginación
                grvEmpleados.SettingsPager.AlwaysShowPager = false;
                grvEmpleados.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
                // Genera columnas
                foreach (DataColumn dtc in dtbTmp.Columns)
                {
                    string strTipoDato = dtc.DataType.Name.ToString();
                    string strColumna = dtc.Caption.ToString();
                    bool bolEsVisible = true;
                    bool bolEsCodigo = true;

                    //switch (dtc.Caption)
                    //{
                    //    case Constantes.ColumnaInfoAdicUserId:
                    //        bolEsCodigo = true;
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, null, null, null);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicNumCA:
                    //        bolEsCodigo = false;
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, null, null, null);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicSueldo:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerSueldo(), Constantes.ColumnaGrupoSalarialCodigo, Constantes.ColumnaGrupoSalarialNombre);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicTipoContrato:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerTipoContrato(),
                    //            Constantes.ColumnaTipoContratoCodigo, Constantes.ColumnaTipoContratoNombre);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicCentroCostos:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerCentroCostos(),
                    //            Constantes.ColumnaCentroCostosCodigo, Constantes.ColumnaCentroCostosNombreCbo);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicTipoIdentificacion:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerDocumentoIdentificacion(),
                    //            Constantes.ColumnaIdentificacionCodigo, Constantes.ColumnaIdentificacionNombre);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicTipoCuenta:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerTipoCuenta(),
                    //            Constantes.ColumnaTipoCuentaCodigo, Constantes.ColumnaTipoCuentaNombre);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicNumeroCuenta:
                    //        bolEsCodigo = false;
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, null,
                    //            null, null);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicCargasFamiliares:
                    //        bolEsCodigo = false;
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, null,
                    //            null, null);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicEstadoCivil:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerEstadoCivil(),
                    //            Constantes.ColumnaEstadoCivilCodigo, Constantes.ColumnaEstadoCivilNombre);
                    //        break;
                    //    case Constantes.ColumnaInfoAdicTipoSangre:
                    //        bolEsCodigo = false;
                    //        strTipoDato = "ComboBox";
                    //        new ClsGeneral().CrearColumnas(strTipoDato, strColumna, grvEmpleados, bolEsVisible, bolEsCodigo, new ClsGeneral().ObtenerTipoSangre(),
                    //            Constantes.ColumnaTipoSangreCodigo, Constantes.ColumnaTipoSangreNombre);
                    //        break;
                    //}
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grvEmpleados_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                ASPxGridView grid = (sender as ASPxGridView);
                //Switch the grid to edit mode for the last selected row
                if (e.Parameters == "StartEditing")
                {
                    object lastSelectedRowKeyValue = grid.GetSelectedFieldValues(Constantes.ColumnaInfoAdicUserId)[grid.Selection.Count - 1];
                    int lastSelectedRowVisibleIndex = grid.FindVisibleIndexByKeyValue(lastSelectedRowKeyValue);
                    grid.StartEdit(lastSelectedRowVisibleIndex);
                }
                else
                {
                    string strKey = "";
                    List<TreeListNode> lstSelectedNodes = trlDepartamentos.GetSelectedNodes();
                    if (lstSelectedNodes.Count > 0)
                    {
                        foreach (TreeListNode Node in lstSelectedNodes)
                        {
                            strKey += Node.Key + ",";
                        }
                        strKey = strKey.Substring(0, strKey.Length - 1);
                        Session["DepartamentoSelected"] = strKey;
                        DataTable dtbEmpleados = (DataTable)Session[Constantes.SessionTblInfoAdicional];
                        String strFilter = Constantes.ColumnaInfoAdicUserId + " in (" + strKey + ")";
                        DataRow[] dtrFilter = dtbEmpleados.Select(strFilter);
                        DataTable dtbFilter = dtbEmpleados.Clone();

                        foreach (DataRow row in dtrFilter)
                        {
                            dtbFilter.ImportRow(row);
                        }
                        Session[Constantes.SessionTblInfoAdicional1] = dtbFilter;

                        grid.DataSource = dtbFilter;
                        grid.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region PARA EDICION MULTIPLE

       private DataTable CreateDataSource()
        {
            DataTable dataTable = new DataTable("MyTable");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Song", typeof(string));
            dataTable.Columns.Add("Genre", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };
            for (int i = 0; i < 15; i++)
            {
                dataTable.Rows.Add(new object[] { i, "Song" + i.ToString(), "Rock" });
            }
            return dataTable;
        }

        protected void grvEmpleados_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            isEditing = true;
        }

        protected void grvEmpleados_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            //Make sure that the code initializing editor values in EditForm is executed only once - when switching the grid to edit mode
            if (!(grid.IsEditing && isEditing)) return;
            if (grid.Selection.Count == 1 || e.Column.ReadOnly) return;
            //Initialize an editor's value depending upon the value's uniqueness within a column
            e.Editor.Value = IsCommonValueForAllSelectedRows(e.Column, e.Value) ? e.Value : null;

        }

        private bool IsCommonValueForAllSelectedRows(GridViewDataColumn column, object value)
        {
            //Determine whether the passed value is common for all rows within the specified column
            bool res = true;
            List<object> selectedRowValues = grvEmpleados.GetSelectedFieldValues(column.FieldName);
            for (int i = 0; i < selectedRowValues.Count; i++)
            {
                if (selectedRowValues[i].ToString() != value.ToString())
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        protected void grvEmpleados_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataTable dt = Session[Constantes.SessionTblInfoAdicional1] as DataTable;

            //Modify row values after a single grid row has been edited
            if (grvEmpleados.Selection.Count == 1)
            {
                DataRow row = dt.Rows.Find(e.Keys[Constantes.ColumnaInfoAdicUserId]) as DataRow;
                //row[Constantes.ColumnaInfoAdicUserId] = e.NewValues[Constantes.ColumnaInfoAdicUserId];
                row[Constantes.ColumnaInfoAdicNumCA] = e.NewValues[Constantes.ColumnaInfoAdicNumCA];
                row[Constantes.ColumnaInfoAdicNombre] = e.NewValues[Constantes.ColumnaInfoAdicNombre];
                row[Constantes.ColumnaInfoAdicSueldo] = e.NewValues[Constantes.ColumnaInfoAdicSueldo];
                row[Constantes.ColumnaInfoAdicTipoContrato] = e.NewValues[Constantes.ColumnaInfoAdicTipoContrato];
                row[Constantes.ColumnaInfoAdicEstadoCivil] = e.NewValues[Constantes.ColumnaInfoAdicEstadoCivil];
                row[Constantes.ColumnaInfoAdicCentroCostos] = e.NewValues[Constantes.ColumnaInfoAdicCentroCostos];
                row[Constantes.ColumnaInfoAdicTipoIdentificacion] = e.NewValues[Constantes.ColumnaInfoAdicTipoIdentificacion];
                row[Constantes.ColumnaInfoAdicTipoCuenta] = e.NewValues[Constantes.ColumnaInfoAdicTipoCuenta];
                row[Constantes.ColumnaInfoAdicCargasFamiliares] = e.NewValues[Constantes.ColumnaInfoAdicCargasFamiliares];
                row[Constantes.ColumnaInfoAdicTipoSangre] = e.NewValues[Constantes.ColumnaInfoAdicTipoSangre];
                row[Constantes.ColumnaInfoAdicNumeroCuenta] = e.NewValues[Constantes.ColumnaInfoAdicNumeroCuenta];
            }
            //Modify row values after multiple grid rows have been edited
            if (grvEmpleados.Selection.Count > 1)
            {
                //Obtain key field values of the selected rows
                List<object> selectedRowKeys = grvEmpleados.GetSelectedFieldValues(Constantes.ColumnaInfoAdicUserId);
                for (int i = 0; i < selectedRowKeys.Count; i++)
                {
                    //Find a row in the data table by the row's key field value
                    DataRow row = dt.Rows.Find(selectedRowKeys[i]) as DataRow;
                    //Modify data rows by leaving old values (if the EditForm's editors are left blank) or saving new values entered into editors
                    //row["Song"] = (e.NewValues["Song"] == null) ? row["Song"] : e.NewValues["Song"];
                    //row["Genre"] = (e.NewValues["Genre"] == null) ? row["Genre"] : e.NewValues["Genre"];

                    //row[Constantes.ColumnaInfoAdicUserId] = (e.NewValues[Constantes.ColumnaInfoAdicUserId] == null) ? row[Constantes.ColumnaInfoAdicUserId] : e.NewValues[Constantes.ColumnaInfoAdicUserId];
                    row[Constantes.ColumnaInfoAdicNumCA] = (e.NewValues[Constantes.ColumnaInfoAdicNumCA] == null) ? row[Constantes.ColumnaInfoAdicNumCA] : e.NewValues[Constantes.ColumnaInfoAdicNumCA];
                    row[Constantes.ColumnaInfoAdicNombre] = (e.NewValues[Constantes.ColumnaInfoAdicNombre] == null) ? row[Constantes.ColumnaInfoAdicNombre] : e.NewValues[Constantes.ColumnaInfoAdicNombre];
                    row[Constantes.ColumnaInfoAdicSueldo] = (e.NewValues[Constantes.ColumnaInfoAdicSueldo] == null) ? row[Constantes.ColumnaInfoAdicSueldo] : e.NewValues[Constantes.ColumnaInfoAdicSueldo];
                    row[Constantes.ColumnaInfoAdicTipoContrato] = (e.NewValues[Constantes.ColumnaInfoAdicTipoContrato] == null) ? row[Constantes.ColumnaInfoAdicTipoContrato] : e.NewValues[Constantes.ColumnaInfoAdicTipoContrato];
                    row[Constantes.ColumnaInfoAdicEstadoCivil] = (e.NewValues[Constantes.ColumnaInfoAdicEstadoCivil] == null) ? row[Constantes.ColumnaInfoAdicEstadoCivil] : e.NewValues[Constantes.ColumnaInfoAdicEstadoCivil];
                    row[Constantes.ColumnaInfoAdicCentroCostos] = (e.NewValues[Constantes.ColumnaInfoAdicCentroCostos] == null) ? row[Constantes.ColumnaInfoAdicCentroCostos] : e.NewValues[Constantes.ColumnaInfoAdicCentroCostos];
                    row[Constantes.ColumnaInfoAdicTipoIdentificacion] = (e.NewValues[Constantes.ColumnaInfoAdicTipoIdentificacion] == null) ? row[Constantes.ColumnaInfoAdicTipoIdentificacion] : e.NewValues[Constantes.ColumnaInfoAdicTipoIdentificacion];
                    row[Constantes.ColumnaInfoAdicTipoCuenta] = (e.NewValues[Constantes.ColumnaInfoAdicTipoCuenta] == null) ? row[Constantes.ColumnaInfoAdicTipoCuenta] : e.NewValues[Constantes.ColumnaInfoAdicTipoCuenta];
                    row[Constantes.ColumnaInfoAdicCargasFamiliares] = (e.NewValues[Constantes.ColumnaInfoAdicCargasFamiliares] == null) ? row[Constantes.ColumnaInfoAdicCargasFamiliares] : e.NewValues[Constantes.ColumnaInfoAdicCargasFamiliares];
                    row[Constantes.ColumnaInfoAdicTipoSangre] = (e.NewValues[Constantes.ColumnaInfoAdicTipoSangre] == null) ? row[Constantes.ColumnaInfoAdicTipoSangre] : e.NewValues[Constantes.ColumnaInfoAdicTipoSangre];
                    row[Constantes.ColumnaInfoAdicNumeroCuenta] = (e.NewValues[Constantes.ColumnaInfoAdicNumeroCuenta] == null) ? row[Constantes.ColumnaInfoAdicNumeroCuenta] : e.NewValues[Constantes.ColumnaInfoAdicNumeroCuenta];

                    continue;
                }
            }

            dt.AcceptChanges();
            Session[Constantes.SessionTblInfoAdicional1] = dt;

            // actualizo la tabla de daos originales 
            DataTable dtbOriginal = (DataTable)Session[Constantes.SessionTblInfoAdicional];
            foreach(DataRow dtrF in dt.Rows)
            {
                DataRow row = dtbOriginal.Rows.Find(dtrF[Constantes.ColumnaInfoAdicUserId]) as DataRow;
                row[Constantes.ColumnaInfoAdicNumCA] = dtrF[Constantes.ColumnaInfoAdicNumCA];
                row[Constantes.ColumnaInfoAdicNombre] = dtrF[Constantes.ColumnaInfoAdicNombre];
                row[Constantes.ColumnaInfoAdicSueldo] = dtrF[Constantes.ColumnaInfoAdicSueldo];
                row[Constantes.ColumnaInfoAdicTipoContrato] = dtrF[Constantes.ColumnaInfoAdicTipoContrato];
                row[Constantes.ColumnaInfoAdicEstadoCivil] = dtrF[Constantes.ColumnaInfoAdicEstadoCivil];
                row[Constantes.ColumnaInfoAdicCentroCostos] = dtrF[Constantes.ColumnaInfoAdicCentroCostos];
                row[Constantes.ColumnaInfoAdicTipoIdentificacion] = dtrF[Constantes.ColumnaInfoAdicTipoIdentificacion];
                row[Constantes.ColumnaInfoAdicTipoCuenta] = dtrF[Constantes.ColumnaInfoAdicTipoCuenta];
                row[Constantes.ColumnaInfoAdicCargasFamiliares] = dtrF[Constantes.ColumnaInfoAdicCargasFamiliares];
                row[Constantes.ColumnaInfoAdicTipoSangre] = dtrF[Constantes.ColumnaInfoAdicTipoSangre];
                row[Constantes.ColumnaInfoAdicNumeroCuenta] = dtrF[Constantes.ColumnaInfoAdicNumeroCuenta];
            }
            Session[Constantes.SessionTblInfoAdicional1] = dtbOriginal;
            //Close the grid's EditForm and avoid default update processing from being executed
            e.Cancel = true;
            grvEmpleados.Selection.UnselectAll();
            grvEmpleados.CancelEdit();
        }

        #endregion

        #endregion

        #region ASIGNAR COMBOS
        protected void SeleccionarComboPorCodigo(int intValue, ASPxComboBox cboCombo)
        {
            try
            {
                foreach (ListEditItem item in cboCombo.Items)
                {
                    if (Convert.ToInt32(item.Value) == intValue)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void cboSueldo_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerSueldo();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaGrupoSalarialCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaGrupoSalarialNombre;
            cmbParent.DataBindItems();
        }
        protected void cboDocumentoIdentificacion_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerDocumentoIdentificacion();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaIdentificacionCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaIdentificacionNombre;
            cmbParent.DataBindItems();
        }
        protected void cboTipoContrato_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoContrato();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaTipoContratoCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaTipoContratoNombre;
            cmbParent.DataBindItems();
        }
        protected void cboCuenta_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoCuenta();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaTipoCuentaCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaTipoCuentaNombre;
            cmbParent.DataBindItems();
        }
        protected void cboEstadoCivil_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerEstadoCivil();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaEstadoCivilCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaEstadoCivilNombre;
            cmbParent.DataBindItems();
        }
        protected void cboCentroCostos_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerCentroCostos();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaCentroCostosCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaCentroCostosNombreCbo;
            cmbParent.DataBindItems();
        }
        protected void cboTipoSangre_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoSangre();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaTipoSangreCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaTipoSangreNombre;
            cmbParent.DataBindItems();
        }

        #endregion
              
    }
}