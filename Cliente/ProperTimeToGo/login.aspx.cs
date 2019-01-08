using DevExpress.Web;
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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida que el usuario y password no esten vacios
                if (txtUsuario.Text != "" && txtPwd.Text != "") {
                    // Retorna información del usuario y nivel acceso
                    ClsAcceso objAcceso = new ClsAcceso();
                    string strPwd = new ClsGeneral().Encriptar(txtPwd.Text);
                    DataTable dtbUsuario = objAcceso.RetornarLogin(txtUsuario.Text, strPwd);
                    if (dtbUsuario.Columns.Contains(Constantes.ColumnaErrorLogin))
                    {
                        lblErrorLogin.Text = dtbUsuario.Rows[0][1].ToString();
                    }
                    else
                    {
                        lblErrorLogin.Text = string.Empty;
                        Session[Constantes.IdSession] = Session.SessionID;
                        Session[Constantes.TablaLogin] = dtbUsuario;
                        //Response.Redirect("~/reportes");
                        Response.Redirect("~/horarios");
                    }
                }
                else
                {
                    lblErrorLogin.Text = Constantes.MensajeErrorLoginVacios;
                }
            }
            catch(Exception)
            {
                lblErrorLogin.Text = "Ocurrio un error con la comunicación con el servidor, contacte con su Administrador";
            }
        }
    }
}