using Comun.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperTime.LogicaNegocio
{
    public static class Globalizacion
    {
        #region METODOS
        /// <summary>
        /// Asigna por referencia la Cultura General para los tipos de datos
        /// </summary>
        /// <param name="cuiCultura">CultureInfo parámetro por referencia a la que se asigna la Cultura</param>
        public static void CulturaGeneral(ref CultureInfo cuiCultura, DataTable dtAuditoria)
        {
            try
            {
                // Asigna Cultura a Inglés Estados Unidos
                cuiCultura = new CultureInfo(Idioma.InglesEstadosUnidos, false);

                // Separador de decimales
                cuiCultura.NumberFormat.NumberDecimalSeparator = Separador.Punto();

                // Separador de moneda
                cuiCultura.NumberFormat.CurrencyDecimalSeparator = Separador.Punto();

                // Separador de Fecha
                cuiCultura.DateTimeFormat.DateSeparator = Separador.Guion();

                // Obtiene el Formato de Fecha desde la Base de Datos
                //GrupoCONTEXT.Finanware.FinanwareSBE.AccesoDatosSBE.ClsGeneral objGeneral = new GrupoCONTEXT.Finanware.FinanwareSBE.AccesoDatosSBE.ClsGeneral();
                //objGeneral.dtAuditoria = dtAuditoria;
                //cuiCultura.DateTimeFormat.ShortDatePattern = objGeneral.ObtenerPreferenciaSistemaSinLog(2);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
