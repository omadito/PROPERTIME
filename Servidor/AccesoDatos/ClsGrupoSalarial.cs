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
    public class ClsGrupoSalarial
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
        public DataSet RetornarGrupoSalarial()
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

        #region GrupoSalarial
        public void AdministrarGrupoSalarial(DataSet dsDatosGrupoSalarial)
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            string strNombreStoreProcedure = string.Empty;

            // Pasar a aun arreglo de datarrows.
            DataRow[] arrDataRow = dsDatosGrupoSalarial.Tables[0].Select();
            try
            {
                foreach (DataRow dr in arrDataRow)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        objListaParametros = new ClsListaParametros();

                        // Si el estado es modificado, añade el parámetro código de supuesto
                        if (dr.RowState == DataRowState.Modified)
                            objListaParametros.Add(new ClsParametro("@i_idGrupo", SqlDbType.Int, 4, dr["idGrupo"].ToString(), DBParameterDireccion.Input));

                        // Añade los parámetros comunes
                        objListaParametros.Add(new ClsParametro("@i_nomGrupo", SqlDbType.Text, 50, dr["nomGrupo"].ToString().ToUpper(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_automatico", SqlDbType.Int, 4, dr["automatico"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_sueldo", SqlDbType.Float, 10, dr["Sueldo"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_bono", SqlDbType.Float, 10, dr["Bono"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_he50", SqlDbType.Float, 10, dr["HE50"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_he100", SqlDbType.Float, 10, dr["HE100"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_jn25", SqlDbType.Float, 10, dr["JN25"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_descuentoHora", SqlDbType.Float, 10, dr["descuentoHora"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@i_descuentoDia", SqlDbType.Float, 10, dr["descuentoDia"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        // Evalua el estado del DataRow y coloca el nombre del sp
                        if (dr.RowState == DataRowState.Added)
                            strNombreStoreProcedure = "sppt_insertar_grupoS_slarial";
                        if (dr.RowState == DataRowState.Modified)
                            strNombreStoreProcedure = "sppt_actualizar_grupo_salarial";


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

                        strNombreStoreProcedure = "sppt_eliminar_grupo_salarial";

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

        public void EliminarGrupoSalarial(DataSet dsDatos)
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

                    strNombreStoreProcedure = "sppt_eliminar_grupo_salarial";

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

        public DataSet ConsultarGrupoSalarial()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();
                // Añade los parámetros comunes
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
        #endregion GrupoSalarial
    }
}
