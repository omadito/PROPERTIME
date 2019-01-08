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
    public class ClsDatosHorariosTurnos
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

        #region Turno
        public void AdministrarTurno(DataSet dsDatos)
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
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_numRunId", SqlDbType.Int, 4, dr["num_runid"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_oldId", SqlDbType.Int, 4, dr["oldid"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@name", SqlDbType.Text, 50, dr["i_nombreTurno"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_fechaInicio", SqlDbType.DateTime, 20, dr["startdate"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_fechaFin", SqlDbType.DateTime, 20, dr["enddate"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_cyle", SqlDbType.Int, 4, dr["cyle"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@units", SqlDbType.Int, 4, dr["i_units"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_turno";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_turno";


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

        public void EliminarTurno(DataSet dsDatos)
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
                    objListaParametros.Add(new ClsParametro("@i_numRunId", SqlDbType.Int, 4, dr["num_runid"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_turno";

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

        public DataSet ConsultarTurno()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_turno";

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
        #endregion Turno
    }
}
