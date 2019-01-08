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
    public class ClsDatosAlmuerzo
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
        public ClsDatosAlmuerzo()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        public DataSet RetornarCostoComida()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosAlmuerzo().RetornarCostoComida();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region CostoComida
        public void AdministrarCostoComida(DataSet dsDatosCostoComida)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosAlmuerzo().AdministrarCostoComida(dsDatosCostoComida);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCostoComida(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosAlmuerzo().AdministrarCostoComida(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarCostoComida()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosAlmuerzo().ConsultarCostoComida();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
