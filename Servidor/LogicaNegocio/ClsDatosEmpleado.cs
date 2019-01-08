using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProperTime.AccesoDatos;

namespace ProperTime.LogicaNegocio
{
    public class ClsDatosEmpleado
    {
        #region ATRIBUTOS

        private CultureInfo _cuiCulturaGeneral;
        private DataTable _dtAuditoria;

        #endregion

        #region PROPIEDADES

        public DataTable dtAuditoria
        {
            set { _dtAuditoria = value; }
            get { return _dtAuditoria; }
        }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        ///  Constructor para poner parámetros de la configuración regional para el ingreso 
        ///  de los datos a la base de datos
        /// </summary>
        public ClsDatosEmpleado()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        public bool GuardarEmpleado(int userid, string numCA, string nombre, string sexo, string cedula,
                                    string CorreoOficina, string ciudad, string teleoficina, string correoPersonal, string titulo,
                                    DateTime dtFechaNac, DateTime dtFechaEmpleo, DateTime dtFechaSalida, string codEmp, string celular,
                                    string direccion, int tipoUsuario)
        {
            try
            {
                ProperTime.AccesoDatos.ClsDatosEmpleado objEmpleados = new ProperTime.AccesoDatos.ClsDatosEmpleado();
                objEmpleados.dtAuditoria = dtAuditoria;
                objEmpleados.GuardarEmpleado(userid, numCA, nombre, sexo, cedula,
                                    CorreoOficina, ciudad, teleoficina, correoPersonal, titulo,
                                    dtFechaNac, dtFechaEmpleo, dtFechaSalida, codEmp, celular,
                                    direccion, tipoUsuario);
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public DataSet RetornaEmpleados(string condiciones)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornaEmpleados(condiciones);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarTipoSangre()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarTipoSangre();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarEstadoCivil()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarEstadoCivil();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarTipoCuenta()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarTipoCuenta();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarCentroCostos()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarCentroCostos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarContrato()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarContrato();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarCiudad()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarCiudad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarFotos(string condiciones)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().RetornarFotos(condiciones);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarEmpleado_v1(int intDpto)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().InsertarEmpleado_v1(intDpto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarCentroCosto(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().InsertarCentroCosto(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarCiudad(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().InsertarCiudad(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarCiudad(int codigoCiudad, string nombreCiudad)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().ActualizarCiudad(codigoCiudad, nombreCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCiudad(int codigoCiudad)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().EliminarCiudad(codigoCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarCentroCostos(int codigoCentroCostos, string nombreCentroCostos, int codigoCentroCostosPadre)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().ActualizarCentroCostos(codigoCentroCostos, nombreCentroCostos, codigoCentroCostosPadre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCentroCostos(int codigoCentroCostos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().EliminarCentroCostos(codigoCentroCostos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region empleado mantenimiento
        public void InsertarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().InsertarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().ActualizarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosEmpleado().EliminarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarEmpleado(DataSet dsDatos)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosEmpleado().ConsultarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
