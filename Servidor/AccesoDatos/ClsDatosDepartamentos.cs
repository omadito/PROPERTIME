//===================================================================================================
// Sistema ProperTime
// http://www.propertime.com/
//
// ClsDatosDepartamentos.cs
// Clase que gestiona los datos de los departamentos
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
    public class ClsDatosDepartamentos
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

        public DataTable RetornarDepartamentosArbol(int tipoAdministrador , string codAdministrador )
        {
            int intCodigoError = 0;

            DataTable dt = new DataTable();

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_tipoAdministrador", SqlDbType.Int, 4, tipoAdministrador.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_codAdministrador", SqlDbType.Text, 48, codAdministrador, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_departamento_arbol";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                dt = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros).Tables[0];


                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
            return dt;
        }

        public void ActualizarDepartamento(int codigoDepartamento, string nombreDepartamento)
        {
            int intCodigoError = 0;

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_nombreDepartamento", SqlDbType.Text, 60, nombreDepartamento, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_idDepartamento", SqlDbType.Int, 4, codigoDepartamento.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_actualizar_departamento";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                Logeo.ErrorMensaje(ex.ToString());
            }
        }

        public void InsertarDepartamento(DataSet dsDatos)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            
            try
            {
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsDatos.Tables[0].Rows)
                    {
                        objListaParametros = new ClsListaParametros();

                        objListaParametros.Add(new ClsParametro("@i_nombreDepartamento", SqlDbType.Text, 60, dr["DEP_NAME"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_idDepartamentoPadre", SqlDbType.Int, 4, dr["SUPDEPTID"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        string strNombreStoreProcedure = "sppt_insertar_departamento";

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

    }
}
