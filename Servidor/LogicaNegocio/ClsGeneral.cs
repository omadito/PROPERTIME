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
    public class ClsGeneral
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
        public ClsGeneral()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        #region Feriado
        public void AdministrarFeriado(DataSet dsDatosFeriado)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().AdministrarFeriado(dsDatosFeriado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarFeriado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().EliminarFeriado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarFeriado()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGeneral().ConsultarFeriado();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Horario
        public void AdministrarHorario(DataSet dsDatosHorario)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().AdministrarHorario(dsDatosHorario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarHorario(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().EliminarHorario(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarHorario()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGeneral().ConsultarHorario();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TipoPermiso
        public void AdministrarTipoPermiso(DataSet dsDatosTipoPermiso)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().AdministrarTipoPermiso(dsDatosTipoPermiso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarTipoPermiso(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGeneral().EliminarTipoPermiso(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarTipoPermiso()
            {
                try
                {
                    return new ProperTime.AccesoDatos.ClsGeneral().ConsultarTipoPermiso();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        #endregion

        #region Seleccion
        public DataSet ConsultarSeleccion()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGeneral().ConsultarSeleccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Clasificar
        public DataSet ConsultarClasificar()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGeneral().ConsultarClasificar();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Boton
        public DataSet ConsultarBoton(int intCodigoPantalla)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGeneral().ConsultarBoton(intCodigoPantalla);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion  

    }
}
