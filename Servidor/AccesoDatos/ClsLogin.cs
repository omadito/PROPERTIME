//===================================================================================================
// Sistema ProperTime
// http://www.propertime.com/
//
// ClsLogin.cs
// Clase que gestiona el logeo de los usuarios en la aplicación 
//
// Autor: Fernando Nieto
// Fecha Creación: 2018-10-16
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
    public class ClsLogin
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

        public DataSet RetornarDatosLogin(string strLogin, string strPassword)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_login", SqlDbType.Text, 50, strLogin, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_password", SqlDbType.Text, 100, strPassword, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_login";

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

        public DataSet RetornarGrupoMenuPantalla(int intCodigoGrupo)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_codigoGrupo", SqlDbType.Int, 4, intCodigoGrupo.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_grupo_menu_pantalla";

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

        public DataSet RetornarMenuBotonAcceso(int intCodigoNivelAcceso)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_codigoNivelAcceso", SqlDbType.Int, 4, intCodigoNivelAcceso.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_menu_boton_acceso";

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

    }
}
