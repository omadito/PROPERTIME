using DevExpress.Web.ASPxTreeList;
using ProperTimeToGo.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProperTimeToGo
{
    public partial class asignacionusuarios : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {            
            //menu de reportes
            ConfigurarTreListDepartamento();
            ConfigurarTreListEmpleados();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region DEPARTAMENTOS
        protected void ObtenerDepartamento()
        {
            try
            {
                if (Session[Constantes.SesionTblDepartamentoSm] == null)
                {
                    DataTable dtbDepartamento = new App_Start.ClsEmpresa().ObtenerDepartamentos();
                    Session[Constantes.SesionTblDepartamentoSm] = dtbDepartamento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ConfigurarTreListDepartamento()
        {
            try
            {
                ObtenerDepartamento();
                trlEmpresaRep.DataSource = (DataTable)Session[Constantes.SesionTblDepartamentoSm];
                trlEmpresaRep.DataBind();
                trlEmpresaRep.ExpandToLevel(1);
                trlEmpresaRep.KeyFieldName = Constantes.ColumnaDepartamentoCodigo;
                trlEmpresaRep.ParentFieldName = Constantes.ColumnaDepartamentoPadre;
                for (int i = 0; i < trlEmpresaRep.Columns.Count; i++)
                {
                    trlEmpresaRep.Columns[i].Visible = false;
                }
                trlEmpresaRep.Columns[Constantes.ColumnaDepartamentoNombre].Visible = true;
                
                    trlEmpresaRep.SettingsSelection.Recursive = false;
                    trlEmpresaRep.SettingsSelection.AllowSelectAll = false;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region EMPLEADOS
        protected void ObtenerEmpleados()
        {
            try
            {
                if (Session[Constantes.SesionTblEmpleadosSm] == null)
                {
                    DataTable dtbEmpleados = new App_Start.ClsEmpleados().RetornarEmpleado();
                    Session[Constantes.SesionTblEmpleadosSm] = dtbEmpleados;
                    Session[Constantes.SesionTblEmpleadosSm1] = dtbEmpleados;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ConfigurarTreListEmpleados()
        {
            try
            {
                ObtenerEmpleados();
                trlEmpleadoRep.DataSource = (DataTable)Session[Constantes.SesionTblEmpleadosSm1];
                trlEmpleadoRep.DataBind();
                trlEmpleadoRep.ExpandToLevel(1);
                for (int i = 0; i < trlEmpleadoRep.Columns.Count; i++)
                {
                    trlEmpleadoRep.Columns[i].Visible = false;
                }
                trlEmpleadoRep.Columns[Constantes.ColumnaEmpleadoNombre].Visible = true;

                    trlEmpleadoRep.SettingsSelection.Recursive = false;
                    trlEmpleadoRep.SettingsSelection.AllowSelectAll = false;
                
                if (Session[Constantes.SesionCodigoEmpleado] != null && Session[Constantes.SesionCodigoEmpleado].ToString() != string.Empty)
                {
                    TreeListNode trvEmpleadoNode = trlEmpleadoRep.FindNodeByKeyValue(Session[Constantes.SesionCodigoEmpleado].ToString());
                    if (!trvEmpleadoNode.Selected)
                    {
                        trvEmpleadoNode.Selected = true;
                    }

                    if (Session["DepartamentoEmpleado"] != null && Session["DepartamentoEmpleado"].ToString() != string.Empty)
                    {
                        TreeListNode trvEmpresaNode = trlEmpleadoRep.FindNodeByKeyValue("2");
                        if (!trvEmpresaNode.Selected)
                        {
                            trvEmpresaNode.Selected = true;
                        }

                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void trvEmpleados_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
        {
            string strKey = "";
            List<TreeListNode> lstSelectedNodes = trlEmpresaRep.GetSelectedNodes();
            foreach (TreeListNode Node in lstSelectedNodes)
            {
                strKey += Node.Key + ",";
            }
            strKey = strKey.Substring(0, strKey.Length - 1);
            Session["DepartamentoSelected"] = strKey;
            DataTable dtbEmpleados = (DataTable)Session[Constantes.SesionTblEmpleadosSm];
            String strFilter = Constantes.ColumnaEmpleadoDefaultDepId + " in (" + strKey + ")";
            DataRow[] dtrFilter = dtbEmpleados.Select(strFilter);
            DataTable dtbFilter = dtbEmpleados.Clone();

            foreach (DataRow row in dtrFilter)
            {
                dtbFilter.ImportRow(row);
            }
            Session[Constantes.SesionTblEmpleadosSm1] = dtbFilter;
            ASPxTreeList treeList = (sender as ASPxTreeList);
            treeList.DataSource = dtbFilter;
            treeList.DataBind();
            treeList.ExpandAll();
        }

        protected void trvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string strKey = "";
                List<TreeListNode> lstSelectedNodes = ((ASPxTreeList)sender).GetSelectedNodes();
                if (lstSelectedNodes.Count > 0)
                {
                    foreach (TreeListNode Node in lstSelectedNodes)
                    {
                        strKey = Node.Key;

                    }
                    Session[Constantes.SesionCodigoEmpleado] = strKey;

                    //ASPxWebControl.RedirectOnCallback("/empleado.aspx");
                }

            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        #endregion
    }
}