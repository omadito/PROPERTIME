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
    public partial class reportes : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && !IsCallback)
                {
                    //RetornarMenuSuperior();
                }

            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Data"] == null)
            {
                Data();
            }
            ASPxGridView1.DataSource = (DataTable)Session["Data"];
            ASPxGridView1.DataBind();

        }

        #region MENUSUPERIOR

        private void RetornarMenuSuperior()
        {
            DataTable dtbMenuSuperior = new DataTable();
            try
            {
                if (Session[Constantes.TablaMenuSuperior] != null)
                {
                    DataTable dtbMenuSuperioPagina = (DataTable)Session[Constantes.TablaMenuSuperior];
                    dtbMenuSuperior = dtbMenuSuperioPagina.Clone();
                    DataRow[] dtrFilasSelect = dtbMenuSuperioPagina.Select(Constantes.ColumnaArbolCodigo + " = " + (int)EnumPagina.Reportes);
                    foreach (DataRow dtr in dtrFilasSelect)
                    {
                        dtbMenuSuperior.ImportRow(dtr);
                    }
                    new ClsMenu().CrearMenuSuperior(mnuSuperior, dtbMenuSuperior, Constantes.ColumnaMenuCodigo, Constantes.ColumnaMenuPadre, Constantes.ColumnaMenuNombre);
                    mnuSuperior.ClientSideEvents.ItemClick = "OnClickMenu";
                }

            }
            catch (Exception ex)
            {
                Mostrarerror(ex.Message);
            }
        }



        #endregion

        #region ERROR

        protected void Mostrarerror(string strMensaje)
        {
            lblMensajeError.Text = strMensaje;
            pcLogin.ShowOnPageLoad = true;
        }
        #endregion


        protected DataTable Data()
        {

            DataTable dtb = new DataTable();
            dtb.Columns.Add("NumCa");
            dtb.Columns.Add("Empleado");
            dtb.Columns.Add("Departamento");
            dtb.Columns.Add("Día");
            dtb.Columns.Add("Fecha");
            dtb.Columns.Add("Hora");
            dtb.Columns.Add("Estado");
            dtb.Columns.Add("Verificación");
            dtb.Columns.Add("RelojID");
            dtb.Columns.Add("Cédula");
            dtb.Columns.Add("Cargo");
            dtb.Columns.Add("Ciudad");
            dtb.Columns.Add("CentroCostos");

            DataRow dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "ARNALDO MEZA"; dtr["Departamento"] = "SISTEMAS"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "11/03/2018"; dtr["Hora"] = "14:57"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "17"; dtr["Cédula"] = "0926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "ARNALDO MEZA"; dtr["Departamento"] = "SISTEMAS"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "08:39"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "17"; dtr["Cédula"] = "0926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "ARNALDO MEZA"; dtr["Departamento"] = "SISTEMAS"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "13:55"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "17"; dtr["Cédula"] = "0926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "ARNALDO MEZA"; dtr["Departamento"] = "SISTEMAS"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "14:41"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "17"; dtr["Cédula"] = "0926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "ARNALDO MEZA"; dtr["Departamento"] = "SISTEMAS"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "19:13"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "17"; dtr["Cédula"] = "0926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);



            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "LUIS MEZA"; dtr["Departamento"] = "SISTEMAS3"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "11/03/2018"; dtr["Hora"] = "14:57"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "16"; dtr["Cédula"] = "09266531144"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "LUIS MEZA"; dtr["Departamento"] = "SISTEMAS3"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "08:39"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "16"; dtr["Cédula"] = "09266531144"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "LUIS MEZA"; dtr["Departamento"] = "SISTEMA3S"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "13:55"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "16"; dtr["Cédula"] = "09266531144"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "LUIS MEZA"; dtr["Departamento"] = "SISTEMAS3"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "14:41"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "16"; dtr["Cédula"] = "09266531144"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "LUIS MEZA"; dtr["Departamento"] = "SISTEMAS3"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "19:13"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "16"; dtr["Cédula"] = "09266531144"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);


            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "FERNANDO MEZA"; dtr["Departamento"] = "SISTEMAS2"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "11/03/2018"; dtr["Hora"] = "14:57"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "14"; dtr["Cédula"] = "109266531146"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "FERNANDO MEZA"; dtr["Departamento"] = "SISTEMAS2"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "08:39"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "14"; dtr["Cédula"] = "109266531146"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "FERNANDO MEZA"; dtr["Departamento"] = "SISTEMAS2"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "13:55"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "14"; dtr["Cédula"] = "109266531146"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "FERNANDO MEZA"; dtr["Departamento"] = "SISTEMAS2"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "14:41"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "14"; dtr["Cédula"] = "109266531146"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "FERNANDO MEZA"; dtr["Departamento"] = "SISTEMAS2"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "19:13"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "14"; dtr["Cédula"] = "109266531146"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);


            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "JUAN MEZA"; dtr["Departamento"] = "SISTEMAS1"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "11/03/2018"; dtr["Hora"] = "14:57"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "12"; dtr["Cédula"] = "20926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "JUAN MEZA"; dtr["Departamento"] = "SISTEMAS1"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "08:39"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "12"; dtr["Cédula"] = "20926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "JUAN MEZA"; dtr["Departamento"] = "SISTEMAS1"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "13:55"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "12"; dtr["Cédula"] = "20926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "JUAN MEZA"; dtr["Departamento"] = "SISTEMAS1"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "14:41"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "12"; dtr["Cédula"] = "20926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            dtr = dtb.NewRow();
            dtr["NumCa"] = 1; dtr["Empleado"] = "JUAN MEZA"; dtr["Departamento"] = "SISTEMAS1"; dtr["Día"] = "DOMINGO"; dtr["Fecha"] = "25/03/2018"; dtr["Hora"] = "19:13"; dtr["Estado"] = "AUTOMATICO"; dtr["Verificación"] = "CONTRASEÑA"; dtr["RelojID"] = "12"; dtr["Cédula"] = "20926653114"; dtr["Cargo"] = ""; dtr["Ciudad"] = ""; dtr["CentroCostos"] = "";
            dtb.Rows.Add(dtr);
            Session["Data"] = dtb;
            return dtb;
        }

    }
}