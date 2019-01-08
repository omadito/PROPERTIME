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
    public class ClsLogin
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
        public ClsLogin()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        public DataSet RetornarDatosLogin(string strLogin, string strPassword)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsLogin().RetornarDatosLogin(strLogin, strPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarGrupoMenuPantalla(int intCodigoGrupo)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsLogin().RetornarGrupoMenuPantalla(intCodigoGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarMenuBotonAcceso(int intCodigoNivelAcceso)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsLogin().RetornarMenuBotonAcceso(intCodigoNivelAcceso);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
