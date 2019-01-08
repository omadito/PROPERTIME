using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsAcceso
    {
        public DataTable RetornarLogin(String strUsuario, string strPaswword)
        {
            DataTable dtbLogin = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();

            try
            {
                objServicioProperTime.Open();
                dtbLogin = objServicioProperTime.RetornarDatosLogin(strUsuario,strPaswword).Tables[0];                
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
            return dtbLogin;
        }

        //Retorna los elementos del árbol e la izquierda
        public DataTable RetornarArbol(int intGrupo)
        {
            DataTable dtbArbol = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();

            try
            {
                objServicioProperTime.Open();
                dtbArbol = objServicioProperTime.RetornarGrupoMenuPantalla(intGrupo).Tables[0];
                dtbArbol.PrimaryKey = new DataColumn[] { dtbArbol.Columns[Constantes.ColumnaArbolCodigo] };
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
            return dtbArbol;
        }

        public DataTable RetornarMenuPagina(int intAcceso)
        {
            DataTable dtbLogin = new DataTable();
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();

            try
            {
                objServicioProperTime.Open();
                dtbLogin = objServicioProperTime.RetornarMenuBotonAcceso(intAcceso).Tables[0];
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
            return dtbLogin;
        }

    }
}