using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsHorariosAsistencia
    {
        #region HORARIOS

        public DataTable RetornarHorarios()
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataTable dtbTmp = new DataTable();
            try
            {
                objServicioProperTime.Open();
                dtbTmp = objServicioProperTime.ConsultarHorario().Tables[0];
                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaHorarioSchclassid] };
                              
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
            //try
            //{
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioSchclassid, typeof(int));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioNombreHorario, typeof(string));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioEntrada, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioSalida, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioGraciaEntrada, typeof(int));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioGraciaSalida, typeof(int));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioInicioEntrada, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioFinEntrada, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioInicioSalida, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioFinSalida, typeof(DateTime));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioDiaLaboral, typeof(double));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioDuraciónJornada, typeof(double));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioTipo, typeof(int));
            //    dtbTmp.Columns.Add(Constantes.ColumnaHorarioAutoBind, typeof(int));

            //    dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaHorarioSchclassid] };

            //    DataRow dtr = dtbTmp.NewRow();
            //    dtr[Constantes.ColumnaHorarioSchclassid] = 3;
            //    dtr[Constantes.ColumnaHorarioNombreHorario] = "08:00 A 17:00 ";
            //    dtr[Constantes.ColumnaHorarioEntrada] = "08:00";
            //    dtr[Constantes.ColumnaHorarioSalida] = "17:00";
            //    dtr[Constantes.ColumnaHorarioGraciaEntrada] = 0;
            //    dtr[Constantes.ColumnaHorarioGraciaSalida] = 0;
            //    dtr[Constantes.ColumnaHorarioInicioEntrada] = "06:00";
            //    dtr[Constantes.ColumnaHorarioFinEntrada] = "12:00";
            //    dtr[Constantes.ColumnaHorarioInicioSalida] = "14:00";
            //    dtr[Constantes.ColumnaHorarioFinSalida] = "23:59";
            //    dtr[Constantes.ColumnaHorarioDiaLaboral] = 1;
            //    dtr[Constantes.ColumnaHorarioDuraciónJornada] = 60;
            //    dtr[Constantes.ColumnaHorarioTipo] = 1;
            //    dtr[Constantes.ColumnaHorarioAutoBind] = 1;
            //    dtbTmp.Rows.Add(dtr);

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return dtbTmp;
        }

        public DataTable RetornarTipoHorario()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaTipoHorarioCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaTipoHorarioNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaTipoHorarioCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoHorarioCodigo] = 1;
                dtr[Constantes.ColumnaTipoHorarioNombre] = "Menos de 24 horas";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoHorarioCodigo] = 2;
                dtr[Constantes.ColumnaTipoHorarioNombre] = "24 horas";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoHorarioCodigo] = 3;
                dtr[Constantes.ColumnaTipoHorarioNombre] = "48 horas";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }
        public DataTable RetornarAutoBindHorario()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaAutobindCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaAutobindNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaAutobindCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaAutobindCodigo] = 1;
                dtr[Constantes.ColumnaAutobindNombre] = "Descontar Tiempo Almuerzo";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaAutobindCodigo] = 2;
                dtr[Constantes.ColumnaAutobindNombre] = "Considerar como tiempo trabajado";
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasHorario()
        {
            DataTable dtbTmp = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            
            try
            {
                objServicioProperTime.Open();
                //objServicioProperTime.RetornarColumnas(Convert.ToInt32(EnumPagina.Horario));
                //dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

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
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioSchclassid;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioNombreHorario;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioEntrada;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioSalida;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioGraciaEntrada;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 6;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioGraciaSalida;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 7;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioInicioEntrada;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 8;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioFinEntrada;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 9;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioInicioSalida;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 10;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioFinSalida;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Time";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 11;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioDiaLaboral;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 12;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioDuraciónJornada;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Double";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 13;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioTipo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboTipoHorario;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaTipoHorarioCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaTipoHorarioNombre;
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 14;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaHorarioAutoBind;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboAutoBindHorario;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaAutobindCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaAutobindNombre;
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
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

        public void GestionarHorario(DataTable dtbHorarios, DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbHorarios.TableName = "Horarios";
                dtsDatos.Tables.Add(dtbHorarios.Copy());
                objServicioProperTime.AdministrarHorario(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "HorariosEliminados";
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

        public void ElimiarHorario(DataTable dtbHorario)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbHorario.TableName = "Horario";
                dtsDatos.Tables.Add(dtbHorario.Copy());
                objServicioProperTime.EliminarHorario(dtsDatos);
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

        #region ASISTENCIA

        public DataTable RetornarTurnos()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoFreuencia, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoTiempo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoHLaborables, typeof(int));


                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaTurnoCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTurnoCodigo] = 1;
                dtr[Constantes.ColumnaTurnoNombre] = "08:00 A 17:00";
                dtr[Constantes.ColumnaTurnoFreuencia] = 1;
                dtr[Constantes.ColumnaTurnoTiempo] = 1;
                dtr[Constantes.ColumnaTurnoHLaborables] = -1;
                dtbTmp.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarTiempoTurno()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoTiempoCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaTurnoTiempoNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaTurnoTiempoCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTurnoTiempoCodigo] = 1;
                dtr[Constantes.ColumnaTurnoTiempoNombre] = "Semana";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTurnoTiempoCodigo] = 2;
                dtr[Constantes.ColumnaTurnoTiempoNombre] = "Día";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTurnoTiempoCodigo] = 3;
                dtr[Constantes.ColumnaTurnoTiempoNombre] = "Mes";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasTurno()
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
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTurnoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTurnoNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTurnoFreuencia;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTurnoTiempo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboTurnoTiempo;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaTurnoTiempoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaTurnoTiempoNombre;
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTurnoHLaborables;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
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

        public void GestionarTurno(DataTable dtbTurnos,DataTable dtbEliminados)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbTurnos.TableName = "Turno";
                dtsDatos.Tables.Add(dtbTurnos.Copy());
                //objServicioProperTime.AdministrarTurno(dtsDatos);
                //**Envia los codigos de los elementos eliminados
                dtbEliminados.TableName = "TurnoEliminados";
                dtsDatos = new DataSet();
                dtsDatos.Tables.Add(dtbEliminados.Copy());
                //objServicioProperTime.EliminarTurno(dtsDatos);
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

        public void ElimiarTurno(DataTable dtbTurno)
        {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();
                dtbTurno.TableName = "Turno";
                dtsDatos.Tables.Add(dtbTurno.Copy());
                //objServicioProperTime.EliminarTurno(dtsDatos);
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

        #region CALCULO HORAS EXTRAS

        public DataTable RetornarCboEntrada()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaEntradaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaEntradaNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaCboReglasAsistenciaEntradaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaCodigo] = 1;
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaNombre] = "Entrada Puntual";

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaCodigo] = 2;
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaNombre] = "Llegada Tarde";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaCodigo] = 3;
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaNombre] = "Ausente";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarCboSalida()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaSalidaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaSalidaNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaCboReglasAsistenciaSalidaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaCodigo] = 1;
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaNombre] = "Salida Puntual";

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaCodigo] = 2;
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaNombre] = "Salida Tarde";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaCodigo] = 3;
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaNombre] = "Ausente";
                dtbTmp.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarCHEAsistencia()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaJMaximaT, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaJMinimaT, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaIntervalo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaEntradaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaCboReglasAsistenciaSalidaCodigo, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaMultaIngreso, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaReglasAsistenciaMultaSalida, typeof(int));


                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaReglasAsistenciaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaReglasAsistenciaCodigo] = 1;
                dtr[Constantes.ColumnaReglasAsistenciaNombre] = "Ausente";
                dtr[Constantes.ColumnaReglasAsistenciaJMaximaT] = 720;
                dtr[Constantes.ColumnaReglasAsistenciaJMinimaT] = 120;
                dtr[Constantes.ColumnaReglasAsistenciaIntervalo] = 30;
                dtr[Constantes.ColumnaCboReglasAsistenciaEntradaCodigo] = 1;
                dtr[Constantes.ColumnaReglasAsistenciaMultaIngreso] = 60;
                dtr[Constantes.ColumnaCboReglasAsistenciaSalidaCodigo] = 2;
                dtr[Constantes.ColumnaReglasAsistenciaMultaSalida] = 60;
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarColumnasCHEAsistencia()
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
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaJMaximaT;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaIntervalo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCboReglasAsistenciaEntradaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboReglasAsistenciaEntrada;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaCboReglasAsistenciaEntradaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaCboReglasAsistenciaEntradaNombre;
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaMultaIngreso;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaCboReglasAsistenciaSalidaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.ComboReglasAsistenciaSalida;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaCboReglasAsistenciaSalidaCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaCboReglasAsistenciaSalidaNombre;
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaReglasAsistenciaMultaSalida;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
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

        #endregion
    }
}