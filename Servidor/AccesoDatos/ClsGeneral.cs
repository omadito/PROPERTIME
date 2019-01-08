//===================================================================================================
// Sistema ProperTime
// http://www.propertime.com/
//
// ClsDatosEmpleados.cs
// Clase que gestiona los datos de los Empleados con la base de datos 
//
// Autor: Fernando Nieto
// Fecha Creación: 2018-07-08
//===================================================================================================
// Modificaciones:
// Modificador              Fecha Modificación      Descripción
// --------------------------------------------------------------------------------------------------
// 
//
//===================================================================================================
// Copyright (C) 2018 GrupoSOFT
// All rights reserved.
//===================================================================================================
using Comun.BaseDatos;
using Comun.Utilitario.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperTime.AccesoDatos
{
    public class ClsGeneral
    {
        #region ATRIBUTOS

        private DataTable _dtAuditoria;

        #endregion

        #region PROPIEDADES

        public DataTable dtAuditoria
        {
            set { _dtAuditoria = value; }
            get { return _dtAuditoria; }
        }

        #endregion

        
        public DataSet RetornarFeriado()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_grupo_salarial";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }

        #region Feriado
        public void AdministrarFeriado(DataSet dsDatosFeriado)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatosFeriado.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        // Extrae la fecha de creación e inicializa la lista de parámetros
                        DateTime dtmFechaCreacion = Convert.ToDateTime(dr["STARTTIME"].ToString());
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_codigoFeriado", SqlDbType.Int, 4, dr["HOLIDAYID"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_nombreFeriado", SqlDbType.Text, 50, dr["HOLIDAYNAME"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_fechaFeriado", SqlDbType.DateTime, 10, dtmFechaCreacion.ToShortDateString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_codigoCiudad", SqlDbType.Int, 4, dr["idCiudad"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_feriado";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_feriado";


                        Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                        new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                        // recuperar error del Store Procedure
                        ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                        intCodigoError = int.Parse(objParametroSalida.Valor);
                    }
                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }

        public void EliminarFeriado(DataSet dsDatos)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatos.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    objListaParametros = new ClsListaParametros();
                    objListaParametros.Add(new ClsParametro("@i_codigoFeriado", SqlDbType.Int, 4, dr["HOLIDAYID"].ToString(), DBParameterDireccion.Input));

                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_feriado";

                    Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                    new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                    // recuperar error del Store Procedure
                    ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                    intCodigoError = int.Parse(objParametroSalida.Valor);
                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }

        public DataSet ConsultarFeriado()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_feriado";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        #endregion Feriado

        #region Horario
        public void AdministrarHorario(DataSet dsDatosHorario)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatosHorario.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        // Extrae la fecha de creación e inicializa la lista de parámetros
                        DateTime dtmFechaCreacion = Convert.ToDateTime(dr["STARTTIME"].ToString());
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_schclassid", SqlDbType.Int, 4, dr["SCHCLASSID"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_schname", SqlDbType.Text, 50, dr["SCHNAME"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_starttime", SqlDbType.DateTime, 10, dr["STARTTIME"].ToString() , DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_endtime", SqlDbType.DateTime, 20, dr["ENDTIME"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_lateminutes", SqlDbType.Int, 4, dr["LATEMINUTES"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_earlyminutes", SqlDbType.Int, 4, dr["EARLYMINUTES"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_checkintime1", SqlDbType.DateTime, 20, dr["CHECKINTIME1"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_checkintime2", SqlDbType.DateTime, 20, dr["CHECKINTIME2"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_checkouttime1", SqlDbType.DateTime, 20, dr["CHECKOUTTIME1"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_checkouttime2", SqlDbType.DateTime, 20, dr["CHECKOUTTIME2"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_workday", SqlDbType.Float, 10, dr["WorkDay"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_workmins", SqlDbType.Float, 10, dr["WorkMins"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_tipo", SqlDbType.Int, 4, dr["Tipo"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_autobind", SqlDbType.Int, 4, dr["Autobind"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_horario";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_horario";


                        Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                        new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                        // recuperar error del Store Procedure
                        ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                        intCodigoError = int.Parse(objParametroSalida.Valor);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        objListaParametros = new ClsListaParametros();

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_schclassid", SqlDbType.Int, 4, dr["SCHCLASSID"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        strNombreStoreProcedure = "sppt_eliminar_horario";

                        Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                        new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                        // recuperar error del Store Procedure
                        ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                        intCodigoError = int.Parse(objParametroSalida.Valor);
                    }


                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }


        public void EliminarHorario(DataSet dsDatos)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatos.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    
                    objListaParametros = new ClsListaParametros();

                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@i_schclassid", SqlDbType.Int, 4, dr["SCHCLASSID"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_horario";

                    Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                    new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                    // recuperar error del Store Procedure
                    ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                    intCodigoError = int.Parse(objParametroSalida.Valor);
                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }
        public DataSet ConsultarHorario()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_horario";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        #endregion Horario

        #region TipoPermiso
        public void AdministrarTipoPermiso(DataSet dsDatosTipoPermiso)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatosTipoPermiso.Tables[0].Select();
            try
            {
                foreach (DataRow dr in dsDatosTipoPermiso.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        // Extrae la fecha de creación e inicializa la lista de parámetros
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_LeaveId", SqlDbType.Int, 4, dr["LeaveId"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_LeaveName", SqlDbType.Text, 50, dr["LeaveName"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_ReportSymbol", SqlDbType.Text, 50, dr["ReportSymbol"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_Classify", SqlDbType.Int, 4, dr["Classify"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_Seleccionable", SqlDbType.Int, 4, dr["Seleccionable"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_tipo_permiso";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_tipo_permiso";


                        Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                        new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                        // recuperar error del Store Procedure
                        ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                        intCodigoError = int.Parse(objParametroSalida.Valor);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        objListaParametros = new ClsListaParametros();

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_schclassid", SqlDbType.Int, 4, dr["LeaveId"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        strNombreStoreProcedure = "sppt_eliminar_tipo_permiso";

                        Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                        new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                        // recuperar error del Store Procedure
                        ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                        intCodigoError = int.Parse(objParametroSalida.Valor);
                    }


                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }

        public void EliminarTipoPermiso(DataSet dsDatos)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            try
            {
                foreach (DataRow dr in dsDatos.Tables[0].Rows)
                {
                    objListaParametros = new ClsListaParametros();

                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@i_schclassid", SqlDbType.Int, 4, dr["LeaveId"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_tipo_permiso";

                    Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                    new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                    // recuperar error del Store Procedure
                    ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                    intCodigoError = int.Parse(objParametroSalida.Valor);
                }
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }

        public DataSet ConsultarTipoPermiso()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_tipo_permiso";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        #endregion TipoPermiso

        #region Seleccion
        public DataSet ConsultarSeleccion()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_seleccion";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        #endregion

        #region Clasificar
        public DataSet ConsultarClasificar()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_clasificar";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        #endregion

        #region Botones
        public DataSet ConsultarBoton(int intCodigoPantalla)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@i_codigoPantalla", SqlDbType.Int, 4, intCodigoPantalla.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_boton";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return ds;
        }
        

        #endregion

    }
}
