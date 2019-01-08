using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using ProperTimeToGo.App_Start;

namespace ProperTimeToGo
{
    public partial class detalleempleado : System.Web.UI.Page
    {

        string _strDepartamento = string.Empty;
        byte[] _bytImagen;
        string _strNotas = string.Empty;
        string _strTipoSangre = string.Empty;

        string _strGenero = string.Empty;
        string _strCentroCostos = string.Empty;
        string _strTipoContrato = string.Empty;
        string _strCiudad = string.Empty;
        string _strTipoEmpleado = string.Empty;
        string _strSupervisor1 = string.Empty;
        string _strSupervisor2 = string.Empty;
        string _strEstadoCivil = string.Empty;


        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                // Cuando viene desde elmenu nuevo 
                if (Session[Constantes.SesionUserIdEmpleado] == null)
                {
                    Session[Constantes.SesionUserIdEmpleado] = 3;
                    Session[Constantes.SessionNuevoEmpleado] = true;
                }
                //Session[Constantes.SesionCodigoEmpleado] = 3;
                DataTable dtbDatosEmpleado = new DataTable();
                ObtenerMenuEmpleado();
                ObtenerDatosEmpleado();
                dtbDatosEmpleado = (DataTable)Session[Constantes.SesionTblDatosEmpleado];
                if (Session[Constantes.SessionNuevoEmpleado] != null)
                {
                    foreach (DataColumn dtc in dtbDatosEmpleado.Columns)
                    {
                        foreach (DataRow dtr in dtbDatosEmpleado.Rows)
                        {
                            if (dtc.DataType.Name == "Int32")
                                dtr[dtc] = 0;
                            else if (dtc.DataType.Name == "DateTime")
                                dtr[dtc] = DateTime.Now;
                            else if (dtc.DataType.Name == "Byte[]")
                                dtr[dtc] = null;
                            else
                                dtr[dtc] = "";

                        }
                    }
                }

                grvDatosEmpleado.DataSource = dtbDatosEmpleado;
                grvDatosEmpleado.DataBind();
                grvDatosEmpleado.Settings.ShowColumnHeaders = false;
                grvDatosEmpleado.KeyFieldName = Constantes.ColumnaDatoEmpleadoUserId;
                grvDatosEmpleado.StartEdit(0);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerDatosEmpleado();

        }

        #region DATOSEMPLEADO
        
        protected void ObtenerDatosEmpleado()
        {
            try
            {
                if (Session[Constantes.SesionTblDatosEmpleado] == null)
                {
                                        int intUsserIdEmpleado = Convert.ToInt32(Session[Constantes.SesionUserIdEmpleado].ToString());
                    DataTable dtbDatosEmpleado = new ClsEmpleados().RetornarDatosEmpleado(intUsserIdEmpleado);
                    Session[Constantes.SesionTblDatosEmpleado] = dtbDatosEmpleado;
                    foreach (DataRow dr in dtbDatosEmpleado.Rows)
                    {
                        _strGenero = dr["Género"].ToString();
                        _strDepartamento = dr["Departamento"].ToString();
                        _strCentroCostos = dr["Centro de costos"].ToString();
                        _strTipoContrato = dr["Tipo Contrato"].ToString();
                        _strCiudad = dr["Ciudad"].ToString();
                        if (dr["PHOTOB"].ToString() != "")
                        {
                            _bytImagen = Encoding.ASCII.GetBytes(dr["PHOTOB"].ToString());
                        }
                        _strTipoEmpleado = dr["TipoEmpleado"].ToString();
                        _strSupervisor1 = dr["Supervisor1"].ToString();
                        _strSupervisor2 = dr["Supervisor2"].ToString();
                        _strEstadoCivil = dr["Estado Civil"].ToString();
                        _strTipoSangre = dr["TipoSangre"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grvDatosEmpleado_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                if (Session[Constantes.SesionTblDatosEmpleado] != null || Session[Constantes.SessionNuevoEmpleado] != null)
                {
                    DataTable dtbDatosEmpleado = (DataTable)Session[Constantes.SesionTblDatosEmpleado];
                    foreach (DataRow dr in dtbDatosEmpleado.Rows)
                    {
                        //dr[Constantes.ColumnaDatoEmpleadoUserId] = ;
                        dr[Constantes.ColumnaDatoEmpleadoNumCA] = ObtenerValorTxt("txtNumCA", (int)EnumTipoComponente.TextBox);
                        dr[Constantes.ColumnaDatoEmpleadoNombre] = ObtenerValorTxt("txtNombre", (int)EnumTipoComponente.TextBox);
                        dr[Constantes.ColumnaDatoEmpleadoCédula] = ObtenerValorTxt("txtCedula", (int)EnumTipoComponente.SpinEdit);
                        dr[Constantes.ColumnaDatoEmpleadoGénero] = ObtenerValorTxt("cboGenero", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoCargo] = ObtenerValorTxt("txtCargo", (int)EnumTipoComponente.TextBox);
                        dr[Constantes.ColumnaDatoEmpleadoCelular] = ObtenerValorTxt("txtCelular", (int)EnumTipoComponente.SpinEdit);
                        dr[Constantes.ColumnaDatoEmpleadoDepartamento] = ObtenerValorTxt("cboDepartamento", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoCentroCostos] = ObtenerValorTxt("cboCentroCostos", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoTipoContrato] = ObtenerValorTxt("cboTipoContrato", (int)EnumTipoComponente.ComboBox);
                        if (ObtenerValorTxt("txtFechaNacimiento", (int)EnumTipoComponente.DateEdit) != string.Empty)
                            dr[Constantes.ColumnaDatoEmpleadoFechaNacimiento] = ObtenerValorTxt("txtFechaNacimiento", (int)EnumTipoComponente.DateEdit);
                        if (ObtenerValorTxt("txtFechaEmpleo", (int)EnumTipoComponente.DateEdit) != string.Empty)
                            dr[Constantes.ColumnaDatoEmpleadoFechaEmpleo] = ObtenerValorTxt("txtFechaEmpleo", (int)EnumTipoComponente.DateEdit);
                        if (ObtenerValorTxt("txtFechaSalida", (int)EnumTipoComponente.DateEdit) != string.Empty)
                            dr[Constantes.ColumnaDatoEmpleadoFechaSalida] = ObtenerValorTxt("txtFechaSalida", (int)EnumTipoComponente.DateEdit);
                        dr[Constantes.ColumnaDatoEmpleadoDirección] = ObtenerValorTxt("txtDireccion", (int)EnumTipoComponente.Memo);
                        //dr[Constantes.ColumnaDatoEmpleadoidCiudad] 			= ObtenerValorTxt("txt", (int)EnumTipoComponente.TextBox);
                        dr[Constantes.ColumnaDatoEmpleadoCiudad] = ObtenerValorTxt("cboCiudad", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoTelOficina] = ObtenerValorTxt("txtTelOficina", (int)EnumTipoComponente.SpinEdit);
                        dr[Constantes.ColumnaDatoEmpleadoCodigoEmpleado] = ObtenerValorTxt("txtCodigoEmpleado", (int)EnumTipoComponente.TextBox);
                        dr[Constantes.ColumnaDatoEmpleadoCorreoPersonal] = ObtenerValorTxt("txtCorreoPersonal", (int)EnumTipoComponente.TextBox);
                        if (Session[Constantes.SesionImegenEmpleado] != null && Session[Constantes.SesionImegenEmpleado].ToString() != "")
                            dr[Constantes.ColumnaDatoEmpleadoPHOTOB] = Session[Constantes.SesionImegenEmpleado];
                        dr[Constantes.ColumnaDatoEmpleadoNotes] = ObtenerValorTxt("txtNotes", (int)EnumTipoComponente.Memo);
                        dr[Constantes.ColumnaDatoEmpleadoTipoEmpleado] = ObtenerValorTxt("cboTipoEmpleado", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoSupervisor1] = ObtenerValorTxt("cboSupervisor1", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoSupervisor2] = ObtenerValorTxt("cboSupervisor2", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoCargasFamiliares] = ObtenerValorTxt("txtCargasFamiliares", (int)EnumTipoComponente.SpinEdit);
                        dr[Constantes.ColumnaDatoEmpleadoEstadoCivil] = ObtenerValorTxt("cboEstadoCivil", (int)EnumTipoComponente.ComboBox);
                        dr[Constantes.ColumnaDatoEmpleadoTiposangre] = ObtenerValorTxt("cboTipoSangre", (int)EnumTipoComponente.ComboBox);

                    }
                }
                Session[Constantes.SessionNuevoEmpleado] = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string ObtenerValorTxt(string strComponente, int intTipoComponente)
        {
            string strValor = string.Empty;
            try
            {
                //ASPxPageControl pageControl = grvDatosEmpleado.FindEmptyDataRowTemplateControl("pageControl") as ASPxPageControl;
                switch (intTipoComponente)
                {
                    case (int)EnumTipoComponente.TextBox: // textbox
                        ASPxTextBox txtTmp = grvDatosEmpleado.FindEditFormTemplateControl(strComponente) as ASPxTextBox;
                        strValor = txtTmp.Text;
                        break;
                    case (int)EnumTipoComponente.Memo: // Memo
                        ASPxMemo memTmp = grvDatosEmpleado.FindEditFormTemplateControl(strComponente) as ASPxMemo;
                        strValor = memTmp.Text;
                        break;
                    case (int)EnumTipoComponente.ComboBox: // Combo
                        ASPxComboBox cboTmp = grvDatosEmpleado.FindEditFormTemplateControl(strComponente) as ASPxComboBox;
                        strValor = cboTmp.Text;
                        break;
                    case (int)EnumTipoComponente.DateEdit: // Datetime
                        ASPxDateEdit dteTmp = grvDatosEmpleado.FindEditFormTemplateControl(strComponente) as ASPxDateEdit;
                        strValor = dteTmp.Text.ToString();
                        break;
                    case (int)EnumTipoComponente.SpinEdit: // SpinEdit
                        ASPxSpinEdit speTmp = grvDatosEmpleado.FindEditFormTemplateControl(strComponente) as ASPxSpinEdit;
                        strValor = speTmp.Text;
                        break;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return strValor;
        }


        #endregion

        #region MENUEMPLEADO

        private void ObtenerMenuEmpleado()
        {
            try
            {
                int intCodigoUsuario = Session[Constantes.SesionCodigoEmpleado] == null ? 3 : (int)Session[Constantes.SesionCodigoEmpleado];
                int intCodigoAcceso = Session["CodigoAcceso"] == null ? 0 : (int)Session["CodigoAcceso"];

                if (Session["MenuEmpleado"] == null)
                    Session["MenuEmpleado"] = new ClsEmpleados().ObtenerMenuEmpleado(intCodigoUsuario, intCodigoAcceso);

                GenerarMenu(mnuEmplado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GenerarMenu(DevExpress.Web.ASPxMenu menu)
        {
            try
            {
                DataTable dtbMenu = (DataTable)Session["MenuEmpleado"];
                // Build Menu Items
                Dictionary<string, DevExpress.Web.MenuItem> menuItems =
                    new Dictionary<string, DevExpress.Web.MenuItem>();

                foreach (DataRow dtr in dtbMenu.Rows)
                {
                    DevExpress.Web.MenuItem item = CreateMenuItem(dtr);
                    string itemID = dtr[Constantes.ColumnaMenuCodigo].ToString();
                    string parentID = dtr[Constantes.ColumnaMenuPadre].ToString();

                    if (dtr[Constantes.ColumnaMenuPadre].ToString() == "0")
                    {
                        item.ItemStyle.CssClass = "btn-menu-interno";
                    }

                    if (menuItems.ContainsKey(parentID))
                        menuItems[parentID].Items.Add(item);
                    else
                    {
                        if (parentID == "0") // It's Root Item
                            menu.Items.Add(item);
                    }
                    menuItems.Add(itemID, item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DevExpress.Web.MenuItem CreateMenuItem(DataRow row)
        {
            DevExpress.Web.MenuItem ret = new DevExpress.Web.MenuItem();
            ret.Name = "mnu" + row[Constantes.ColumnaMenuNombre].ToString();
            ret.Text = row[Constantes.ColumnaMenuNombre].ToString();
            if (row[Constantes.ColumnaArbolUrl].ToString() != "")
                ret.NavigateUrl = row[Constantes.ColumnaArbolUrl].ToString();
            if (row[Constantes.ColumnaMenuIcoPath].ToString() != "")
                ret.Image.Url = row[Constantes.ColumnaMenuIcoPath].ToString();

            return ret;
        }

        protected void mnuEmplado_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)Master.FindControl("MainContent");
            int intCodigoEmpleado = Convert.ToInt32(Session[Constantes.SesionCodigoEmpleado]);

            switch (e.Item.Name)
            {
                case "mnuAgregar":
                    Session[Constantes.SessionNuevoEmpleado] = true;
                    //ASPxWebControl.RedirectOnCallback("~/datosempleados");
                    Response.Redirect("~/datosempleado", false);
                    break;
                case "mnuGuardar":
                    //GuardarEmpleado();
                    grvDatosEmpleado.UpdateEdit();
                    break;
                case "mnuDesactivar":
                    DesactivarEmpleado();
                    break;
            }

        }

        #endregion

        #region UPLOADFOTO
        protected void ucpImage_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            Session[Constantes.SesionImegenEmpleado] = e.UploadedFile.FileBytes;
        }

        protected void cpnImage_Callback(object sender, CallbackEventArgsBase e)
        {
            ASPxCallbackPanel panel = (ASPxCallbackPanel)sender;
            ASPxBinaryImage bImage = (ASPxBinaryImage)panel.FindControl("bimFotoEmpleado");
            bImage.ContentBytes = (byte[])Session[Constantes.SesionImegenEmpleado];     
            bImage.Visible = true;
        }

        protected void bimFotoEmpleado_Init(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatosEmpleado();
                byte[] bytes;
                if (_bytImagen == null)
                {

                    string sTemp = MapPath("~/Imagenes/usuarioDefault.jpg");
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
#pragma warning disable IDE0017 // Simplify object initialization
                    FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
#pragma warning restore IDE0017 // Simplify object initialization
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                    //img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                    fs.Position = 0;

                    int imgLength = Convert.ToInt32(fs.Length);
                    bytes = new byte[imgLength];
                    fs.Read(bytes, 0, imgLength);
                    fs.Close();
                    //return bytes;
                }
                else
                {
                    bytes = _bytImagen;
                }

                ASPxBinaryImage bImage = (ASPxBinaryImage)sender;
                // bImage.ContentBytes = _bytImagen;
                bImage.ContentBytes = bytes;
                bImage.Visible = true;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region UPLOADFIRMA
        protected void upcFirma_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            Session[Constantes.SesionFirmaEmpleado] = e.UploadedFile.FileBytes;
        }

        protected void cpnFirma_Callback(object sender, CallbackEventArgsBase e)
        {
            ASPxCallbackPanel panel = (ASPxCallbackPanel)sender;
            ASPxBinaryImage bImage = (ASPxBinaryImage)panel.FindControl("bimFirma");
            bImage.ContentBytes = (byte[])Session[Constantes.SesionFirmaEmpleado];
            bImage.Visible = true;
        }

        #endregion

        #region ADMINISTRACION EMPLEADO

        protected void GuardarEmpleado()
        {
            try
            {
                //if ((bool)Session[Constantes.SessionNuevoEmpleado])
                //{
                //    int intUserId = new ClsGeneral().ObtenerNuevoCodigo((DataTable)Session[Constantes.SesionTblEmpleadosSm], Constantes.ColumnaEmpleadoCodigo);
                //    DateTime dtmFechaSalida = dteFechaSalida.Text == "" ? Convert.ToDateTime("01/01/1999") : Convert.ToDateTime(dteFechaSalida.Text);
                //    // Envia a guradar el nuevo empleado
                //    new ClsEmpleados().InsertarEmpleado(Convert.ToInt32(Session["DepartamentoSelected"]));
                //    new ClsEmpleados().GuardarEmpleado(intUserId, txtNoCa.Text, txtNombre.Text, cboGenero.Text, txtCedula.Text, txtCorreoElectronico.Text,
                //        cboCiudad.Value.ToString(), txtTelefonoOficina.Text, txtCorreoElectronico.Text, txtTituloCargo.Text, Convert.ToDateTime(dteFechaNacimiento.Text), Convert.ToDateTime(dteFechaEmpleado.Text),
                //        dtmFechaSalida, txtCodigoEmpleado.Text, txtCelular.Text, txtDireccion.Text, 1);

                //}
                //Session[Constantes.SessionNuevoEmpleado] = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ASIGNAR COMBOS
        protected void SelecetedCbo(string strValor, ASPxComboBox cboCombo)
        {
            try
            {
                if (Session[Constantes.SessionNuevoEmpleado] == null)
                {
                    foreach (ListEditItem item in cboCombo.Items)
                    {
                        if (item.Text == strValor)
                            item.Selected = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void cboGenero_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerGenero();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = "Codigo";
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = "Nombre";
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strGenero, cmbParent);
        }
        protected void cboDepartamento_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsEmpresa().ObtenerDepartamentos();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaDepartamentoCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaDepartamentoNombre;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strDepartamento, cmbParent);
        }
        protected void cboCentroCostos_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerCentroCostos();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaCentroCostosCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaCentroCostosNombreCbo;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strCentroCostos, cmbParent);
        }
        protected void cboTipoContrato_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoContrato();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaTipoContratoCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaTipoContratoNombre;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strTipoContrato, cmbParent);
        }
        protected void cboCiudad_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerCiudad();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaCiudadesCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaCiudadesNombre;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strCiudad, cmbParent);
        }
        protected void cboTipoEmpleado_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoEmpleado();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = "Codigo";
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = "Nombre";
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strTipoEmpleado, cmbParent);
        }
        protected void cboSupervisor1_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerSupervisor1();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = "Codigo";
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = "Nombre";
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strSupervisor1, cmbParent);
        }
        protected void cboSupervisor2_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerSupervisor2();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = "Codigo";
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = "Nombre";
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strSupervisor2, cmbParent);
        }
        protected void cboEstadoCivil_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerEstadoCivil();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaEstadoCivilCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaEstadoCivilNombre;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strEstadoCivil, cmbParent);
        }
        protected void cboTipoSangre_Init(object sender, EventArgs e)
        {
            ASPxComboBox cmbParent = (ASPxComboBox)sender;
            //GridViewDataRowTemplateContainer templateContainer = (GridViewDataRowTemplateContainer)cmbParent.NamingContainer;
            GridViewEditFormTemplateContainer templateContainer = (GridViewEditFormTemplateContainer)cmbParent.NamingContainer;
            //cmbParent.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChanged(s, e, {0}); }}", templateContainer.VisibleIndex);
            DataTable dtbCombo = new ClsGeneral().ObtenerTipoSangre();
            cmbParent.DataSource = dtbCombo;
            cmbParent.ValueField = Constantes.ColumnaTipoSangreCodigo;
            cmbParent.ValueType = typeof(Int32);
            cmbParent.TextField = Constantes.ColumnaTipoSangreNombre;
            cmbParent.DataBindItems();
            ObtenerDatosEmpleado();
            SelecetedCbo(_strTipoSangre, cmbParent);
        }

        #endregion

        #region DESACTIVAR EMPLEADO

        protected void DesactivarEmpleado()
        {
            try
            {
                int intCodigoUsuario = Session["CodigoUsuario"] == null ? 0 : (int)Session["CodigoUsuario"];
                lblMensaje.Text = "Usuario Desactivado exitosamente";

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error " + ex.Message;
            }
            ppcMensajeDesactivacion.ShowOnPageLoad = true;
        }
        #endregion

    }
}