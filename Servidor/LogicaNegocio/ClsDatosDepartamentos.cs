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
    public class ClsDatosDepartamentos
    {
        #region ATRIBUTOS

        //private CultureInfo _cuiCulturaGeneral;
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
        public ClsDatosDepartamentos()
        {
            //Globalizacion.CulturaGeneral(ref _cuiCulturaGeneral, dtAuditoria);
            //Thread.CurrentThread.CurrentCulture = _cuiCulturaGeneral;
        }
        #endregion
        public DataTable RetornarDepartamentosArbol(int tipoAdministrador, string codAdministrador)
        {
            try
            {
                return new ProperTime.AccesoDatos.ClsDatosDepartamentos().RetornarDepartamentosArbol(tipoAdministrador, codAdministrador);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarDepartamento(int codigoDepartamento, string nombreDepartamento)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosDepartamentos().ActualizarDepartamento(codigoDepartamento, nombreDepartamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarDepartamento(DataSet dsDatos)
        {
            try
            {
                new ProperTime.AccesoDatos.ClsDatosDepartamentos().InsertarDepartamento(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
