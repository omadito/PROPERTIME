using DevExpress.Web;
using DevExpress.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProperTimeToGo.App_Start
{
    public class ClsGeneral
    {
        public int ObtenerNuevoCodigo(DataTable dtbTmp, string strColumna)
        {
            int intCodigo = 0;
            try
            {
                int intMinAccountLevel = int.MaxValue;
                int intMaxAccountLevel = int.MinValue;
                foreach (DataRow dr in dtbTmp.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        int intAccountLevel = dr.Field<int>(strColumna);
                        intMinAccountLevel = Math.Min(intMinAccountLevel, intAccountLevel);
                        intMaxAccountLevel = Math.Max(intMaxAccountLevel, intAccountLevel);
                        intCodigo = intMaxAccountLevel + 1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return intCodigo;
        }

        #region DATOS PARA COMBOS

        public DataTable ObtenerGenero()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Femenino";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "Masculino";
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }
        
        public DataTable ObtenerTipoEmpleado()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Usuario";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "Supervisor 1";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 3;
                dtr["Nombre"] = "Supervisor 2";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable ObtenerSupervisor1()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Supervisor 1.1";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "Supervisor 1.2";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 3;
                dtr["Nombre"] = "Supervisor 1.3";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable ObtenerSupervisor2()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Supervisor 2.1";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "Supervisor 2.2";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 3;
                dtr["Nombre"] = "Supervisor 2.3";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable ObtenerSueldo()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarGrupoSalarial().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        public DataTable ObtenerDocumentoIdentificacion()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Cédula";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "RUC";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 3;
                dtr["Nombre"] = "Pasaporte";
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable ObtenerTipoContrato()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarContrato().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        public DataTable ObtenerTipoCuenta()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarTipoCuenta().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        public DataTable ObtenerEstadoCivil()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarEstadoCivil().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }
               
        public DataTable ObtenerTipoSangre()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarTipoSangre().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        #region PANTALLA TIPOS PERMISO

        public DataTable ObtenerTipoPermisoCbo()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns["Codigo"] };

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Trabajado";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "No Trabajado";
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable ObtenerSolicitableCbo()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add("Codigo", typeof(int));
                dtbTmp.Columns.Add("Nombre", typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns["Codigo"] };

                DataRow dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 1;
                dtr["Nombre"] = "Solo por ProperTime";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr["Codigo"] = 2;
                dtr["Nombre"] = "usuario Web Time";
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        #endregion

        #endregion

        #region CREACIÓN DE GRIDVIEWS

        public void CrearColumnas(string strTipoDato, string strColumna, ASPxGridView grvGrilla, bool bolVisible, DataTable dtbCombo,
    string strCampoClave, string strCampoTexto,string srEtiqueta,string strFormato)
        {
            switch (strTipoDato)
            {
                case "String":
                    // columna normal
                    GridViewDataTextColumn colText = new GridViewDataTextColumn();
                    colText.FieldName = strColumna;
                    colText.Visible = bolVisible;
                    //colText.Caption = srEtiqueta;
                    grvGrilla.Columns.Add(colText);
                    break;
                case "Int32":
                    // columna normal
                    if (!bolVisible)
                    {
                        GridViewDataTextColumn colInt = new GridViewDataTextColumn();
                        colInt.FieldName = strColumna;
                        //colInt.Caption = srEtiqueta;
                        colInt.Visible = false;
                        grvGrilla.Columns.Add(colInt);
                    }
                    else
                    {
                        GridViewDataSpinEditColumn colInt1 = new GridViewDataSpinEditColumn();
                        colInt1.FieldName = strColumna;
                        //colInt1.Caption = srEtiqueta;
                        colInt1.Visible = bolVisible;
                        colInt1.PropertiesSpinEdit.SpinButtons.ShowIncrementButtons = false;
                        colInt1.PropertiesEdit.DisplayFormatString = "N0";
                        grvGrilla.Columns.Add(colInt1);
                    }
                    break;
                case "Double":
                    GridViewDataSpinEditColumn colDouble = new GridViewDataSpinEditColumn();
                    colDouble.FieldName = strColumna;
                    //colDouble.Caption = srEtiqueta;
                    colDouble.Visible = bolVisible;
                    colDouble.PropertiesSpinEdit.SpinButtons.ShowIncrementButtons = false;
                    colDouble.PropertiesEdit.DisplayFormatString = "N4";
                    grvGrilla.Columns.Add(colDouble);
                    break;
                case "Time":
                    GridViewDataTimeEditColumn colTime = new GridViewDataTimeEditColumn();
                    colTime.FieldName = strColumna;
                    //colTime.Caption = srEtiqueta;
                    colTime.Visible = bolVisible;
                    colTime.PropertiesTimeEdit.DisplayFormatString = "HH:mm";
                    colTime.PropertiesTimeEdit.EditFormat = EditFormat.Custom;
                    colTime.PropertiesTimeEdit.EditFormatString = "HH:mm";
                    colTime.PropertiesTimeEdit.SpinButtons.ShowIncrementButtons = false;
                    colTime.PropertiesTimeEdit.DisplayFormatInEditMode = true;
                    grvGrilla.Columns.Add(colTime);
                    
                    break;
                case "Date":
                    // columna normal
                    GridViewDataDateColumn colDate = new GridViewDataDateColumn();
                    colDate.FieldName = strColumna;
                    //colDate.Caption = srEtiqueta;
                    colDate.Visible = bolVisible;
                    colDate.PropertiesDateEdit.DisplayFormatString = "dd-MM-yyyy";
                    //colDate.PropertiesDateEdit.ValidationSettings.RequiredField.IsRequired = ValidationSettings.;
                    grvGrilla.Columns.Add(colDate);
                    break;
                case "DateTime":
                    // columna normal
                    GridViewDataDateColumn colDateTime = new GridViewDataDateColumn();
                    colDateTime.FieldName = strColumna;
                    //colDateTime.Caption = srEtiqueta;
                    colDateTime.Visible = bolVisible;
                    colDateTime.PropertiesDateEdit.DisplayFormatString = "dd-MM-yyyy HH:mm";
                    grvGrilla.Columns.Add(colDateTime);
                    break;
                case "ComboBox":
                    GridViewDataComboBoxColumn colCbo = new GridViewDataComboBoxColumn();
                    colCbo.FieldName = strColumna;
                    //colCbo.Caption = srEtiqueta;
                    colCbo.PropertiesComboBox.ValueType = typeof(int);
                    colCbo.PropertiesComboBox.ValueField = strCampoClave;
                    colCbo.PropertiesComboBox.TextField = strCampoTexto;
                    colCbo.PropertiesComboBox.TextFormatString = "{0}"; // imprime la columna con indice 0
                                                                        //colCbo.PropertiesComboBox.EnableSynchronization = DevExpress.Utils.DefaultBoolean.True;
                    colCbo.PropertiesComboBox.DataSource = dtbCombo;
                    grvGrilla.Columns.Add(colCbo);
                    break;
            }
        }

        public DataTable ObtenerTablaFuenteColCombo(string strCombo)
        {
            DataTable dtbCombo = new DataTable();
            try
            {
                switch (strCombo)
                {
                    case Constantes.ComboTipoHorario:
                        dtbCombo = new ClsHorariosAsistencia().RetornarTipoHorario();
                        break;
                    case Constantes.ComboAutoBindHorario:
                        dtbCombo = new ClsHorariosAsistencia().RetornarAutoBindHorario();
                        break;
                    case Constantes.ComboCiudad:
                        dtbCombo = new ClsGeneral().ObtenerCiudad();
                        break;
                    case Constantes.ComboTipoPermiso:
                        dtbCombo = new ClsGeneral().ObtenerTipoPermisoCbo();
                        break;
                    case Constantes.ComboPermisoSolicitable:
                        dtbCombo = new ClsGeneral().ObtenerSolicitableCbo();
                        break;
                    case Constantes.ComboTurnoTiempo:
                        dtbCombo = new ClsHorariosAsistencia().RetornarTiempoTurno();
                        break;
                    case Constantes.CboTipoEmpleado:
                        dtbCombo = new ClsEmpleados().RetornarTipoEmpleadoAdmin();
                        break;
                }
                return dtbCombo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ConfigurarGridView(ASPxGridView grvTmp, DataTable dtbDatos, string strColumnaCodigo, DataTable dtbColumnas)
        {
            try
            {
                // Propiedades de la tabla
                grvTmp.AutoGenerateColumns = false;
                grvTmp.KeyFieldName = strColumnaCodigo;
                grvTmp.Theme = "Office365";
                grvTmp.Width = Unit.Percentage(100);
                // Para la edicion en linea
                grvTmp.SettingsEditing.Mode = GridViewEditingMode.Batch;
                grvTmp.SettingsEditing.EditFormColumnCount = 1;
                grvTmp.SettingsEditing.UseFormLayout = false;
                grvTmp.SettingsEditing.BatchEditSettings.ShowConfirmOnLosingChanges = false;
                grvTmp.SettingsEditing.BatchEditSettings.StartEditAction = GridViewBatchStartEditAction.DblClick;
                grvTmp.SettingsEditing.BatchEditSettings.AllowEndEditOnValidationError = false;
                grvTmp.SettingsEditing.BatchEditSettings.AllowValidationOnEndEdit = false;
                grvTmp.SettingsEditing.BatchEditSettings.ErrorImagePosition = GridBatchEditErrorImagePosition.Left;
                grvTmp.Settings.VerticalScrollableHeight = 400;
                grvTmp.Settings.VerticalScrollBarMode = ScrollBarMode.Auto;
                grvTmp.SettingsBehavior.AllowFocusedRow = true;
                grvTmp.SettingsBehavior.AllowSelectByRowClick = true;
                // Propiedades de paginación
                grvTmp.SettingsPager.AlwaysShowPager = false;
                grvTmp.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
                // Genera columnas
                foreach (DataRow dtr in dtbColumnas.Rows)
                {
                    new ClsGeneral().CrearColumnas(
                    dtr[Constantes.ColumnaGrillaColumnaTipo].ToString(),
                    dtr[Constantes.ColumnaGrillaColumnaNombre].ToString(),
                    grvTmp,
                    dtr[Constantes.ColumnaGrillaColumnaVisible].ToString() == "1" ? true : false,
                    ObtenerTablaFuenteColCombo(dtr[Constantes.ColumnaGrillaColumnaCboTabla].ToString()),
                    dtr[Constantes.ColumnaGrillaColumnaCboCodigo].ToString(),
                    dtr[Constantes.ColumnaGrillaColumnaCboNombre].ToString(), null,null
                    //dtr[Constantes.ColumnaGrillaColumnaEtiqueta].ToString(),
                    //dtr[Constantes.ColumnaGrillaColumnaFormato].ToString()
                    );
                }
                // Asigna la fuente de datos
                grvTmp.DataSource = dtbDatos;

                // rederizar data 
                grvTmp.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region CREARNUEVACLAVE

        public Int32 GetLastKey(DataTable dtbTable, string strColumna)
        {
            try
            {
                Int32 max = Int32.MinValue;
                if (dtbTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dtbTable.Rows)
                    {
                        if (Convert.ToInt32(row[strColumna]) > max)
                            max = Convert.ToInt32(row[strColumna]);
                    }
                }
                else
                {
                    max = 0;
                }
                return max + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region CENTRO DE COSTOS

        public DataTable ObtenerCentroCostos()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarCentroCostos().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        public void GestionarCentroCostos(DataTable dtbTmp, DataTable dtbEliminados)
        {
            DataTable dtbTmpEliminados = new DataTable();
            DataSet dtsDatos = new DataSet();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                dtbTmpEliminados.Columns.Add(Constantes.ColumnaCentroCostosCodigo, typeof(int));

                
                objServicioProperTime.Open();
                // Enviar lo nuevos y editados
                dtbTmp.TableName = "CentroCostos";
                dtsDatos.Tables.Add(dtbTmp.Copy());
                //objServicioProperTime.AdministrarCentroCostos(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "CentroCostosEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
                //objServicioProperTime.EiminarCentroCostos(dtsDatos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }           
        }

        #endregion

        #region CIUDADES

        public DataTable ObtenerCiudad()
        {
            DataTable dtbTmp = new DataTable();

            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.RetornarCiudad().Tables[0];

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaCiudadesCodigo] };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbTmp;
        }

        public void GestionarCiudad(DataTable dtbTmp, DataTable dtbEliminados)
        {
            DataTable dtbTmpEliminados = new DataTable();
            DataSet dtsDatos = new DataSet();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                dtbTmpEliminados.Columns.Add(Constantes.ColumnaCentroCostosCodigo, typeof(int));
                
                objServicioProperTime.Open();
                // Enviar lo nuevos y editados
               
                // Crea tablas para insertar y actualizar
                DataTable dtbInsertar = dtbTmp.Clone();
                DataTable dtbActualizar = dtbTmp.Clone();

                foreach (DataRow dtrFila in dtbTmp.Rows)
                {
                    if(dtrFila.RowState == DataRowState.Added)
                    {
                        dtbInsertar.ImportRow(dtrFila);
                    }
                    else if (dtrFila.RowState == DataRowState.Modified)
                    {
                        dtbActualizar.ImportRow(dtrFila);
                    }
                }
                if(dtbInsertar.Rows.Count > 0)
                {
                    dtsDatos = new DataSet();
                    dtbInsertar.TableName = "Ciiudad";
                    dtsDatos.Tables.Add(dtbInsertar.Copy());
                    objServicioProperTime.InsertarCiudad(dtsDatos);
                }
                if (dtbActualizar.Rows.Count > 0)
                {
                    foreach (DataRow dtrFila in dtbActualizar.Rows)
                    {
                        objServicioProperTime.ActualizarCiudad(Convert.ToInt32(dtrFila[Constantes.ColumnaCiudadesCodigo].ToString()), dtrFila[Constantes.ColumnaCiudadesNombre].ToString());
                    }
                }

                if (dtbActualizar.Rows.Count > 0)
                {
                    foreach(DataRow dtrFila in dtbEliminados.Rows)
                    {
                        objServicioProperTime.EliminarCiudad(Convert.ToInt32(dtrFila[Constantes.ColumnaCiudadesCodigo]));
                    }
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
        }

        #endregion

        #region CRIPTO
        public string Encriptar(string strPasswd)
        {
            string strClave = "esuman";
            string strPass2 = string.Empty;
            string strCar = string.Empty;
            string strCodigo = string.Empty;

            for(int i=0;i < strPasswd.Length; i++)
            {
                strCar = strPasswd.Substring(i, 1);
                strCodigo = strClave.Substring(((i - 1) % strClave.Length) + 1, 1);
                strPass2 = strPass2 + ("0"+ ((int)Convert.ToChar(strCodigo) ^ (int)Convert.ToChar(strCar)).ToString("X")).Substring(1,2);
            }
            return strPass2;
        }
        public string DesEncripta(string strPasswd)
        {
            string strClave = "esuman";
            string strPass2 = string.Empty;
            string strCar = string.Empty;
            string strCodigo = string.Empty;
            int intJ = 1;
            for (int i = 1; i < strPasswd.Trim().Length; i++)
            {
                strCar = strPasswd.Substring(i, 2);
                strCodigo = strClave.Substring(((intJ - 1) % strClave.Length) + 1, 1);
                strPass2 = strPass2 + Convert.ToChar(Convert.ToChar(strCodigo) ^ Convert.ToInt32("&h" + strCar));
                intJ++;
            }
            return strPass2;
        }
           
        #endregion

    }
}