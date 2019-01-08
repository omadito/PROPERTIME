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
    public class ClsDatosHorariosTurnos
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
        public ClsDatosHorariosTurnos()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion

        #region Turno
        public void AdministrarTurno(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosHorariosTurnos().AdministrarTurno(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarTurno(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosHorariosTurnos().EliminarTurno(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarTurno()
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosHorariosTurnos().ConsultarTurno();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
