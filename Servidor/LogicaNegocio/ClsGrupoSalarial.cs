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
    public class ClsGrupoSalarial
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
        public ClsGrupoSalarial()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        public DataSet RetornarGrupoSalarial()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGrupoSalarial().RetornarGrupoSalarial();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region GrupoSalarial
        public void AdministrarGrupoSalarial(DataSet dsDatosGrupoSalarial)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGrupoSalarial().AdministrarGrupoSalarial(dsDatosGrupoSalarial);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarGrupoSalarial(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsGrupoSalarial().EliminarGrupoSalarial(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarGrupoSalarial()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsGrupoSalarial().ConsultarGrupoSalarial();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
