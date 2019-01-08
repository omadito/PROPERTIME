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
    public class ClsDatosEmpleado
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

        public bool GuardarEmpleado(int userid,string numCA, string nombre , string sexo, string cedula , 
                                    string CorreoOficina , string ciudad , string teleoficina , string correoPersonal , string titulo, 
                                    DateTime dtFechaNac , DateTime dtFechaEmpleo , DateTime dtFechaSalida , string codEmp , string celular , 
                                    string direccion, int tipoUsuario ) 
        {
            int intCodigoError;
            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@i_numCA", SqlDbType.Text, 48, numCA, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_nombre", SqlDbType.Text, 120, nombre, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_cedula", SqlDbType.Text, 40, cedula, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_sexo", SqlDbType.Text, 20, sexo, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_celular", SqlDbType.Text, 40, celular, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_correoPersonal", SqlDbType.Text, 100, correoPersonal, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_correoOficina", SqlDbType.Text, 100, CorreoOficina, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_tipoUsuario", SqlDbType.Int, 4, tipoUsuario.ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_telefonoOficina", SqlDbType.Text, 40, teleoficina, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_codEmp", SqlDbType.Text, 40, codEmp, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_fechaNacimiento", SqlDbType.DateTime, 10, dtFechaNac.ToShortDateString().ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_fechaEmpleo", SqlDbType.DateTime, 10, dtFechaEmpleo.ToShortDateString().ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_fechaSalida", SqlDbType.DateTime, 10, dtFechaSalida.ToShortDateString().ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_codigoCiudad", SqlDbType.Int, 4, ciudad.ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_userId", SqlDbType.Int, 4, userid.ToString(), ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_titulo", SqlDbType.Text, 100, titulo, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@i_direccion", SqlDbType.Text, 160, titulo, ParameterDirection.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", ParameterDirection.Output));

                string strNombreStoreProcedure = "sppt_actualizar_empleado";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                new Comun.BaseDatos.ClsAccesoDatos().ExecuteNonQuery(strNombreStoreProcedure, objListaParametros, EnuBaseDatos.Finanware.ToString());

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);

                if (intCodigoError > 0)
                    throw new ArgumentException("No se puede insertar, registro duplicado");
            }
            catch (Exception ex)
            {
                 Logeo.Error(ex.ToString());
            }
            return true;

        }

        public DataSet RetornaEmpleados(string condiciones)
        {
            int intCodigoError;
            DataSet ds = new DataSet();
            
            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@i_condiciones", SqlDbType.Text, 400, condiciones, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_empleados";

                Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);
             
                ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                // recuperar error del Store Procedure
                ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                intCodigoError = int.Parse(objParametroSalida.Valor);
            }
            catch (Exception ex)
            {
                 Logeo.ErrorMensaje (ex.ToString());
            }
            return ds;
        }

        public DataSet RetornarTipoSangre()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_tipo_sangre";

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

        public DataSet RetornarEstadoCivil()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_estado_civil";

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

        public DataSet RetornarTipoCuenta()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_tipo_cuenta";

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

        public DataSet RetornarCentroCostos()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_centro_costo";

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

        public DataSet RetornarContrato()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_contrato";

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

        public DataSet RetornarCiudad()
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_ciudad";

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

        public DataSet RetornarFotos(string condiciones)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@i_condiciones", SqlDbType.Text, 400, condiciones, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_consultar_datos_empleados";

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

        public void InsertarEmpleado_v1(int intDpto)
        {
            int intCodigoError;

            ClsListaParametros objListaParametros = null;
            try
            {
                objListaParametros = new ClsListaParametros();

                objListaParametros.Add(new ClsParametro("@i_idDep", SqlDbType.Int, 4, intDpto.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_insertar_empleado";

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

        public void InsertarCentroCosto(DataSet dsDatos)
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

                        objListaParametros.Add(new ClsParametro("@i_nombreCentroCostos", SqlDbType.Text, 100, dr["nomCentroCostos"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        string strNombreStoreProcedure = "sppt_insertar_centro_costos";

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

        public void InsertarCiudad(DataSet dsDatos)
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

                        objListaParametros.Add(new ClsParametro("@i_nombreCiudad", SqlDbType.Text, 50, dr["nomCiudad"].ToString(), DBParameterDireccion.Input));
                        objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                        string strNombreStoreProcedure = "sppt_insertar_ciudad";

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

        public void ActualizarCiudad(int codigoCiudad, string nombreCiudad)
        {
            int intCodigoError = 0;

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_idCiudad", SqlDbType.Int, 4, codigoCiudad.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_nombreCiudad", SqlDbType.Int, 4, nombreCiudad, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_actualizar_ciudad";

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

        public void EliminarCiudad(int codigoCiudad)
        {
            int intCodigoError = 0;

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_idCiudad", SqlDbType.Int, 4, codigoCiudad.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_eliminar_ciudad";

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

        public void ActualizarCentroCostos(int codigoCentroCostos, string nombreCentroCostos, int codigoCentroCostosPadre)
        {
            int intCodigoError = 0;

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_idCentroCostos", SqlDbType.Int, 4, codigoCentroCostos.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_nombreCentroCostos", SqlDbType.Text, 100, nombreCentroCostos, DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@i_idCentroCostosPadre", SqlDbType.Int, 4, codigoCentroCostosPadre.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_actualizar_centro_costos";

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

        public void EliminarCentroCostos(int codigoCentroCostos)
        {
            int intCodigoError = 0;

            ClsListaParametros objListaParametros = new ClsListaParametros();
            try
            {
                /// La variable strcaso indica el reporte que se obtendrá
                objListaParametros.Add(new ClsParametro("@i_idCentroCostos", SqlDbType.Int, 4, codigoCentroCostos.ToString(), DBParameterDireccion.Input));
                objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                string strNombreStoreProcedure = "sppt_eliminar_centro_costos";

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

        #region Empleado Mantenimiento
        public void InsertarEmpleado(DataSet dsDatos)
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
                    byte[] bytPhoto = (byte[])dr["photob"];
                    byte[] bytFirma = (byte[])dr["firma"];

                    objListaParametros = new ClsListaParametros();
                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@i_UserId", SqlDbType.Int, 4, dr["UserId"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Badgenumber", SqlDbType.Int, 4, dr["Badgenumber"].ToString().ToUpper(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Name", SqlDbType.Text, 120, dr["Name"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_ssn", SqlDbType.Text, 40, dr["ssn"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_gender", SqlDbType.Text, 20, dr["gender"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Pager", SqlDbType.Text, 40, dr["Pager"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CorreoPersonal", SqlDbType.Text, 100, dr["CorreoPersonal"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CorreoOficina", SqlDbType.Text, 100, dr["CorreoOficina"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_idTipoEmpleado", SqlDbType.Int, 4, dr["idTipoEmpleado"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_idCiudad", SqlDbType.Int, 4, dr["idCiudad"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_OPhone", SqlDbType.Text, 40, dr["OPhone"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Title", SqlDbType.Text, 100, dr["Title"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CardNo", SqlDbType.Text, 40, dr["CardNo"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Street", SqlDbType.Text, 160, dr["Street"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_BirthDay", SqlDbType.DateTime, 10, dr["BirthDay"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_HiredDay", SqlDbType.DateTime, 10, dr["HireDay"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_FechaSalida", SqlDbType.DateTime, 10, dr["FechaSalida"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_DEFAULTDEPTID", SqlDbType.Int, 4, dr["HE100"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_photob", SqlDbType.Binary, int.MaxValue, bytPhoto, DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_firma", SqlDbType.Binary, int.MaxValue, bytFirma, DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_insertar_empleado";

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

        public void ActualizarEmpleado(DataSet dsDatos)
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
                    byte[] bytPhoto = (byte[])dr["photob"];
                    byte[] bytFirma = (byte[])dr["firma"];

                    objListaParametros = new ClsListaParametros();
                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@i_UserId", SqlDbType.Int, 4, dr["UserId"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Badgenumber", SqlDbType.Int, 4, dr["Badgenumber"].ToString().ToUpper(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Name", SqlDbType.Text, 120, dr["Name"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_ssn", SqlDbType.Text, 40, dr["ssn"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_gender", SqlDbType.Text, 20, dr["gender"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Pager", SqlDbType.Text, 40, dr["Pager"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CorreoPersonal", SqlDbType.Text, 100, dr["CorreoPersonal"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CorreoOficina", SqlDbType.Text, 100, dr["CorreoOficina"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_idTipoEmpleado", SqlDbType.Int, 4, dr["idTipoEmpleado"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_idCiudad", SqlDbType.Int, 4, dr["idCiudad"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_OPhone", SqlDbType.Text, 40, dr["OPhone"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Title", SqlDbType.Text, 100, dr["Title"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_CardNo", SqlDbType.Text, 40, dr["CardNo"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_Street", SqlDbType.Text, 160, dr["Street"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_BirthDay", SqlDbType.DateTime, 10, dr["BirthDay"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_HiredDay", SqlDbType.DateTime, 10, dr["HireDay"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_FechaSalida", SqlDbType.DateTime, 10, dr["FechaSalida"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_DEFAULTDEPTID", SqlDbType.Int, 4, dr["HE100"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_photob", SqlDbType.Binary, int.MaxValue, bytPhoto, DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@i_firma", SqlDbType.Binary, int.MaxValue, bytFirma, DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_actualizar_empleado";

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

        public void EliminarEmpleado(DataSet dsDatos)
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
                    byte[] bytPhoto = (byte[])dr["photob"];
                    byte[] bytFirma = (byte[])dr["firma"];

                    objListaParametros = new ClsListaParametros();
                    // Añade los parámetros comunes
                    objListaParametros.Add(new ClsParametro("@i_UserId", SqlDbType.Int, 4, dr["UserId"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_eliminar_empleado";

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

        public DataSet ConsultarEmpleado(DataSet dsDatos)
        {
            int intCodigoError;
            DataSet ds = new DataSet();

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
                    objListaParametros.Add(new ClsParametro("@i_UserId", SqlDbType.Int, 4, dr["UserId"].ToString(), DBParameterDireccion.Input));
                    objListaParametros.Add(new ClsParametro("@o_retorno", SqlDbType.Int, 4, "0", DBParameterDireccion.Output));

                    strNombreStoreProcedure = "sppt_consultar_empleado";

                    Logeo.InfoMensaje(strNombreStoreProcedure, objListaParametros);

                    ds = new Comun.BaseDatos.ClsAccesoDatos().ExecuteDataSet(strNombreStoreProcedure, objListaParametros);

                    // recuperar error del Store Procedure
                    ClsParametro objParametroSalida = (ClsParametro)objListaParametros.List[objListaParametros.List.Count - 1];
                    intCodigoError = int.Parse(objParametroSalida.Valor);

                }
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
