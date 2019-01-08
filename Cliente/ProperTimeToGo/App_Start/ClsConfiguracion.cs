using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsConfiguracion
    {

        #region FERIADO

        public DataTable ObtenerFeriados()
        {
            DataTable dtbFeriado = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();

            try
            {
                objServicioProperTime.Open();
                dtbFeriado = objServicioProperTime.ConsultarFeriado().Tables[0];
                dtbFeriado.PrimaryKey = new DataColumn[] { dtbFeriado.Columns[Constantes.ColumnaFeriadosCodigo] };
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
            return dtbFeriado;
        }

        public DataTable RetornarColumnasFeriado()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaFeriadosCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaFeriadosNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaFeriadosFecha;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Date";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCiudadesCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboCiudad;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaCiudadesCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaCiudadesNombre;
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public void GestionarFeriado(DataTable dtbFeriado, DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbFeriado.TableName = "Feriado";
                dtsDatos.Tables.Add(dtbFeriado.Copy());
                objServicioProperTime.AdministrarFeriado(dtsDatos);

                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "FeriadoEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
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

        public void ElimiarFeriado(DataTable dtbFeriado)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbFeriado.TableName = "Feriado";
                dtsDatos.Tables.Add(dtbFeriado.Copy());
                objServicioProperTime.EliminarFeriado(dtsDatos);
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

        #region TIPOS DE PERMISOS

        public DataTable ObtenerTiposPermisos()
        {
            //DataTable dtbMenu = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataTable dtbTmp = new DataTable();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.ConsultarTipoPermiso().Tables[0];
                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaPermisoCodigo] };
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

        public DataTable RetornarColumnasTipoPermiso()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermisoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermisoPermiso;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermisoSimbolo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermisoSolicitable;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboPermisoSolicitable;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaSolicitableCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaSolicitableNombre;
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermisoTipo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboTipoPermiso;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaTipoPermisoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaTipoPermisoNombre;
                dtbTmp.Rows.Add(dtr);

                //dtr = dtbTmp.NewRow();
                //dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                //dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaPermis;
                //dtr[Constantes.ColumnaGrillaColumnaTipo] = "DateTime";
                //dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                //dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                //dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                //dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                //dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public void GestionarTipoPermiso(DataTable dtbTipoPermiso, DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbTipoPermiso.TableName = "TipoPermiso";
                dtsDatos.Tables.Add(dtbTipoPermiso.Copy());
                objServicioProperTime.AdministrarTipoPermiso(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "TipoPermisoEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
                objServicioProperTime.EliminarTipoPermiso(dtsDatos);
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

        public void ElimiarTipoPermiso(DataTable dtbFeriado)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbFeriado.TableName = "TipoPermiso";
                dtsDatos.Tables.Add(dtbFeriado.Copy());
                objServicioProperTime.EliminarTipoPermiso(dtsDatos);
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

        #region GRUPO SALARIAL

        public DataTable ObtenerGrupoSalarial()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialAutomatico, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialSueldo, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialBono, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialHE50, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialHE100, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialJN25, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialDstoH, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaGrupoSalarialDstoD, typeof(double));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrupoSalarialCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrupoSalarialCodigo] = 1;
                dtr[Constantes.ColumnaGrupoSalarialNombre] = "Basico";
                dtr[Constantes.ColumnaGrupoSalarialAutomatico] = 1;
                dtr[Constantes.ColumnaGrupoSalarialSueldo] = 386.00;
                dtr[Constantes.ColumnaGrupoSalarialBono] = 0.00;
                dtr[Constantes.ColumnaGrupoSalarialHE50] = 2.4125;
                dtr[Constantes.ColumnaGrupoSalarialHE100] = 3.2167;
                dtr[Constantes.ColumnaGrupoSalarialJN25] = 0.4021;
                dtr[Constantes.ColumnaGrupoSalarialDstoH] = 1.6083;
                dtr[Constantes.ColumnaGrupoSalarialDstoD] = 12.8667;
                dtbTmp.Rows.Add(dtr);



            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasGrupoSalarial()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialAutomatico;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialSueldo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialBono;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 6;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialHE50;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 7;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialHE100;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 8;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialJN25;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 9;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialDstoH;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 10;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaGrupoSalarialDstoD;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);


            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public void GestionarGrupoSalarial(DataTable dtbGrupoSalarial, DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbGrupoSalarial.TableName = "GrupoSalarial";
                dtsDatos.Tables.Add(dtbGrupoSalarial.Copy());
                objServicioProperTime.AdministrarGrupoSalarial(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "GrupoSalarialEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
                objServicioProperTime.EliminarGrupoSalarial(dtsDatos);
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

        public void ElimiarGrupoSalarial(DataTable dtbGrupoSalarial)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbGrupoSalarial.TableName = "GrupoSalarial";
                dtsDatos.Tables.Add(dtbGrupoSalarial.Copy());
                objServicioProperTime.EliminarGrupoSalarial(dtsDatos);
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

        #region COSTO COMIDAS

        public DataTable ObtenerCostoComida()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaCostoEmpresa, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaCostoTrabajador, typeof(double));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaHoraInicio, typeof(DateTime));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaHoraFin, typeof(DateTime));
                dtbTmp.Columns.Add(Constantes.ColumnaCostoComidaReloj, typeof(int));


                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaCostoComidaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCostoComidaCodigo] = 1;
                dtr[Constantes.ColumnaCostoComidaNombre] = "Almuerzo";
                dtr[Constantes.ColumnaCostoComidaCostoEmpresa] = 2.00;
                dtr[Constantes.ColumnaCostoComidaCostoTrabajador] = 1.00;
                dtr[Constantes.ColumnaCostoComidaHoraInicio] = "12:00:00";
                dtr[Constantes.ColumnaCostoComidaHoraFin] = "13:00:00";
                dtr[Constantes.ColumnaCostoComidaReloj] = 0;
                dtbTmp.Rows.Add(dtr);



            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasCostoComida()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaCostoEmpresa;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaCostoTrabajador;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaHoraInicio;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 6;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaHoraFin;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 7;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCostoComidaReloj;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public void GestionarCostoComida(DataTable dtbTmp, DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbTmp.TableName = "CostoComida";
                dtsDatos.Tables.Add(dtbTmp.Copy());
                objServicioProperTime.AdministrarCostoComida(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "CostoComidaEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
                objServicioProperTime.EliminarCostoComida(dtsDatos);
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

        public void ElimiarCostoComida(DataTable dtbCostoComida)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbCostoComida.TableName = "CostoComida";
                dtsDatos.Tables.Add(dtbCostoComida.Copy());
                objServicioProperTime.EliminarCostoComida(dtsDatos);
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

        public DataTable RetornarColumnasCiudades()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };


                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCiudadesCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCiudadesNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);


            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasCentroCostos()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };


                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCentroCostosCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCentroCostosNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);


            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }
    }
}