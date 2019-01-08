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
    public class ClsDatosAlmuerzo
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
        public DataSet RetornarCostoComida()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_costo_comida";

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

        #region CostoComida
        public void AdministrarCostoComida(DataSet dsDatosCostoComida)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatosCostoComida.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_idComida", SqlDbType.Int, 4, dr["idComida"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_nombreComida", SqlDbType.Text, 50, dr["nombreComida"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_costoEmpresa", SqlDbType.Float, 10, dr["costoEmpresa"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_costoTrabajador", SqlDbType.Float, 10, dr["costoTrabajador"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_horaInicio", SqlDbType.DateTime, 20, dr["horaInicio"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_horaFin", SqlDbType.DateTime, 20, dr["codComidaReloj"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_grupoS_slarial";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_costo_comida";


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
                        objListaParametros.Add(new ClsParametro("@i_idGrupo", SqlDbType.Int, 4, dr["idGrupo"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        strNombreStoreProcedure = "sppt_eliminar_costo_comida";

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

        public void EliminarCostoComida(DataSet dsDatos)
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
                    objListaParametros.Add(new ClsParametro("@i_idGrupo", SqlDbType.Int, 4, dr["idGrupo"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_costo_comida";

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

        public DataSet ConsultarCostoComida()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_costo_comida";

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
        #endregion CostoComida
    }
}
