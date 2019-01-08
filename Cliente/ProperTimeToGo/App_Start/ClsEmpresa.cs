using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsEmpresa
    {
        public DataTable ObtenerDepartamentos()
        {
            DataTable dtbDepartamentos = new DataTable();
            try
            {
                dtbDepartamentos.Columns.Add("codNodo", typeof(int));
                dtbDepartamentos.Columns.Add("NomDepto", typeof(string));
                dtbDepartamentos.Columns.Add("codPadre", typeof(int));

                dtbDepartamentos.PrimaryKey = new DataColumn[] { dtbDepartamentos.Columns["codNodo"] };

                DataRow dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 1;
                dtr["codPadre"] = 0;
                dtr["NomDepto"] = "SERVISEGUROS";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 2;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "ADMINISTRATIVO";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 3;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "COBRANZAS";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 4;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "CONTABILIDAD";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 5;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "MASIVOS";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 6;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "OPERACIONES";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 7;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "RRHH";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 8;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "SINIESTROS";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 9;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "SISTEMAS";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 10;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "VAM";
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["codNodo"] = 11;
                dtr["codPadre"] = 1;
                dtr["NomDepto"] = "VENTAS";
                dtbDepartamentos.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbDepartamentos;
        }

        public DataTable ObtenerCentroCostos()
        {
            DataTable dtbDepartamentos = new DataTable();
            try
            {
                dtbDepartamentos.Columns.Add("idCentroCostos", typeof(int));
                dtbDepartamentos.Columns.Add("nomCentroCostos", typeof(string));
                dtbDepartamentos.Columns.Add("PadreCentroCostos", typeof(int));

                dtbDepartamentos.PrimaryKey = new DataColumn[] { dtbDepartamentos.Columns["idCentroCostos"] };

                DataRow dtr = dtbDepartamentos.NewRow();
                dtr["idCentroCostos"] = 1;
                dtr["nomCentroCostos"] = "Administrativo";
                dtr["PadreCentroCostos"] = 0;
                dtbDepartamentos.Rows.Add(dtr);

                dtr = dtbDepartamentos.NewRow();
                dtr["idCentroCostos"] = 2;
                dtr["nomCentroCostos"] = "SERVISEGUROS";
                dtr["PadreCentroCostos"] = 0;
                dtbDepartamentos.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbDepartamentos;
        }
    }
}