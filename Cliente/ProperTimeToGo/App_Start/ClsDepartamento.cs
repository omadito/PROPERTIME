using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsDepartamento
    {
        public DataTable ObtenerMenuDepartamento(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add("Codigo", typeof(int));
                dtbMenu.Columns.Add("Padre", typeof(int));
                dtbMenu.Columns.Add("Nombre", typeof(string));
                dtbMenu.Columns.Add("IcoPath", typeof(string));
                dtbMenu.Columns.Add("Url", typeof(string));

                DataRow dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 1;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Nuevo";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 2;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Guardar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 3;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Eliminar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 4;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Cargar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        public void AdministrarDepartamento(DataTable dtbTable, int intAccionTabla) {
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            DataSet dtsDatos = new DataSet();
            try
            {
                objServicioProperTime.Open();

                dtbTable.TableName = "Departamento";
                dtsDatos.Tables.Add(dtbTable.Copy());
                switch (intAccionTabla)
                {
                    case (int)EnumAccionTabla.Insert:
                        objServicioProperTime.InsertarDepartamento(dtsDatos);
                        break;
                    case (int)EnumAccionTabla.Update:
                        foreach(DataRow dtrFila in dtsDatos.Tables[0].Rows)
                        {
                            objServicioProperTime.ActualizarDepartamento(Convert.ToInt32(dtrFila[Constantes.ColumnaDepartamentoCodigo].ToString()), dtrFila[Constantes.ColumnaDepartamentoNombre].ToString());
                        }                        
                        break;
                    case (int)EnumAccionTabla.Delete:
                        //objServicioProperTime.EliminarDepartmento(dtsDatos);
                        break;
                }
                objServicioProperTime.AdministrarCostoComida(dtsDatos);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
        }
    }
}