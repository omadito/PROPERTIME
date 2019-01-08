using DevExpress.Web;
using ProperTimeToGo.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxTreeList;

namespace ProperTimeToGo
{
    public partial class SiteMaster : MasterPage
    {
        string _strUrl = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            //obtiene los datos para arbol y menu horizonta
            if (!IsPostBack)
            {
                //Obtiene datos de login
                if(Session[Constantes.TablaLogin]!=null && !((DataTable)Session[Constantes.TablaLogin]).Columns.Contains(Constantes.ColumnaErrorLogin))
                {
                    Session[Constantes.SesionLogin] = ((DataTable)Session[Constantes.TablaLogin]).Rows[0][7].ToString();
                    Session[Constantes.SesionAcceso] = ((DataTable)Session[Constantes.TablaLogin]).Rows[0][1].ToString();
                    Session[Constantes.SesionGrupo] = ((DataTable)Session[Constantes.TablaLogin]).Rows[0][0].ToString();
                    Session[Constantes.SesionLoginNombre] = ((DataTable)Session[Constantes.TablaLogin]).Rows[0][11].ToString();
                }
                
                
                //CrearMenuPrincipal();
            }
            RetornarMenuSperior();
            RetornarArbol();
            _strUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToUpper();
            if (_strUrl.ToUpper().Contains("REPORTES"))
            {
                mnuAdministracion.Visible = true;
                mnuReportes.Visible = false;
                navPage2.Visible = true;
                navPage1.Visible = false;
            }
            else
            {
                mnuAdministracion.Visible = false;
                mnuReportes.Visible = true;
                navPage2.Visible = false;
                navPage1.Visible = true;
            }
            //menu de reportes
            ConfigurarTreListDepartamento();
            ConfigurarTreListEmpleados();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // PAra seleccionar el menu correspondiente segun la páginas
            if (Session[Constantes.SessionMenuSeleccionado] != null)
            {
                TreeListNode trN = trlMenuPrincipal.FindNodeByKeyValue(Session[Constantes.SessionMenuSeleccionado].ToString());
                trN.Focus();

            }
        }

        #region ARBOL

        protected void RetornarArbol()
        {
            try
            {
                int intGrupo = Session[Constantes.SesionGrupo] == null ? 0 : Convert.ToInt32(Session[Constantes.SesionGrupo]);
                DataTable dtbMenu = new ClsAcceso().RetornarArbol(intGrupo);
                Session[Constantes.SesionArbol] = dtbMenu;
                CrearMenuPrincipal();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void RetornarMenuSperior()
        {
            try
            {
                int intAcceso = Session[Constantes.SesionAcceso] == null ? 0 : Convert.ToInt32(Session[Constantes.SesionAcceso]);
                DataTable dtbMenuSuperior = new ClsAcceso().RetornarMenuPagina(intAcceso);
                Session[Constantes.TablaMenuSuperior] = dtbMenuSuperior;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MENU IZQUIERDA

        protected void ObtenerMenuIzquierda(DataTable dtbArbol)
        {
            try
            {
                int intCodigoUsuario = Session["CodigoUsuario"] == null ? 0 : (int)Session["CodigoUsuario"];
                int intCodigoAcceso = Session["CodigoAcceso"] == null ? 0 : (int)Session["CodigoAcceso"];
                DataTable dtbMenu = new ClsMenu().ObtenerMenu(intCodigoUsuario, intCodigoAcceso);
                Session["MenuIzquierda"] = dtbMenu;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void CrearMenuPrincipal()
        {
            try
            {
                //ObtenerMenuIzquierda();
                trlMenuPrincipal.DataSource = (DataTable)Session[Constantes.SesionArbol];
                trlMenuPrincipal.KeyFieldName = Constantes.ColumnaArbolCodigo;
                trlMenuPrincipal.ParentFieldName = Constantes.ColumnaArbolPadre;
                trlMenuPrincipal.DataBind();

                //trlMenuPrincipal.ExpandToLevel(1);
                for (int i = 0; i < trlMenuPrincipal.Columns.Count; i++)
                {
                    trlMenuPrincipal.Columns[i].Visible = false;
                }
                trlMenuPrincipal.Columns[Constantes.ColumnaArbolNombre].Visible = true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MENU PRINCIPAL

        protected void trlMenuPrincipal_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
        {
            try
            {
                string strKey = e.Argument;
                Session[Constantes.SessionMenuSeleccionado] = strKey;
                // Busco la fila según el codigo
                DataTable dataTable = (DataTable)Session[Constantes.SesionArbol];

                DataRow row = dataTable.Rows.Find(new object[] { strKey });

                if (row[Constantes.ColumnaArbolUrl].ToString() != string.Empty)
                {
                    ASPxWebControl.RedirectOnCallback("" + row[Constantes.ColumnaArbolUrl].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region MENU REPORTES

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
                if (_strUrl.ToUpper().Contains("EMPLEADO"))
                {
                    trlEmpresaRep.SettingsSelection.Recursive = false;
                    trlEmpresaRep.SettingsSelection.AllowSelectAll = false;
                }
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

                if (_strUrl.ToUpper().Contains("EMPLEADO"))
                {
                    trlEmpleadoRep.SettingsSelection.Recursive = false;
                    trlEmpleadoRep.SettingsSelection.AllowSelectAll = false;
                }

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

        #endregion

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx", false);
            //ASPxWebControl.RedirectOnCallback("/login.aspx");
        }
    }
}