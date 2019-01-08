<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProperTimeToGo.login" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .login-page {
            width: 360px;
            padding: 8% 0 0;
            margin: auto;
        }

        .form {
            position: relative;
            z-index: 1;
            background: #FFFFFF;
            max-width: 360px;
            margin: 0 auto 100px;
            padding: 45px;
            text-align: center;
            box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
        }

            .form .input-txt {
                font-family: "Roboto", sans-serif;
                outline: 0;
                background: #f2f2f2;
                width: 100%;
                border: 0;
                margin: 0 0 15px;
                padding: 15px;
                box-sizing: border-box;
                font-size: 14px;
            }

            .form .input-btn {
                font-family: sans-serif;
                text-transform: uppercase;
                outline: 0;
                background: #4CAF50;
                width: 100%;
                border: 0;
                padding: 15px;
                color: #FFFFFF;
                font-size: 14px;
                -webkit-transition: all 0.3 ease;
                transition: all 0.3 ease;
                cursor: pointer;
            }

                .form .input-btn:hover, .form .input-btn:active, .form input-btn:focus {
                    background: #43A047;
                }

            .form .message {
                margin: 15px 0 0;
                color: #b3b3b3;
                font-size: 12px;
            }

                .form .message a {
                    color: #4CAF50;
                    text-decoration: none;
                }

            .form .register-form {
                display: none;
            }

        .container {
            position: relative;
            z-index: 1;
            max-width: 300px;
            margin: 0 auto;
        }

            .container:before, .container:after {
                content: "";
                display: block;
                clear: both;
            }

            .container .info {
                margin: 50px auto;
                text-align: center;
            }

                .container .info h1 {
                    margin: 0 0 15px;
                    padding: 0;
                    font-size: 36px;
                    font-weight: 300;
                    color: #1a1a1a;
                }

                .container .info span {
                    color: #4d4d4d;
                    font-size: 12px;
                }

                    .container .info span a {
                        color: #000000;
                        text-decoration: none;
                    }

                    .container .info span .fa {
                        color: #EF3B3A;
                    }

        body {
            background: #134A8B; /* fallback for old browsers */
            background: -webkit-linear-gradient(right, #134A8B, #569E89);
            background: -moz-linear-gradient(right, #134A8B, #569E89);
            background: -o-linear-gradient(right, #134A8B, #569E89);
            background: linear-gradient(to left, #134A8B, #569E89);
            font-family: "Roboto", sans-serif;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }

        .requerida-error {
            border: 1px solid red;
        }
        .error-login{
            color:red;
        }
    </style>
</head>
<body>
    <div class="login-page">
        <div class="form">
            <form id="form1" class="login-form" runat="server" >
                <dx:ASPxImage ID="imgLogo" runat="server" ShowLoadingImage="true" ImageUrl="~/Imagenes/DerechoProperTime.jpg"></dx:ASPxImage>
                <dx:ASPxTextBox ID="txtUsuario" ClientInstanceName="txtUsuario" runat="server" CssClass="input-txt" NullText="Usuario" Password="false" ViewStateMode="Enabled" Width="100%">
                    <%-- <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="Debe ingresar un usuario" ErrorTextPosition="Bottom" SetFocusOnError="True">
                        <ErrorFrameStyle Wrap="False">
                        </ErrorFrameStyle>
                        <RequiredField IsRequired="True" ErrorText="" />
                    </ValidationSettings>--%>
                </dx:ASPxTextBox>
                <dx:ASPxTextBox ID="txtPwd" ClientInstanceName="txtPwd" runat="server" CssClass="input-txt" NullText="Contraseña" Password="True" ViewStateMode="Enabled" Width="100%" ValidateRequestMode="Enabled">
                    <%--<ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="Debe ingresar la conrtraseña" ErrorTextPosition="Bottom">
                        <ErrorFrameStyle Border-BorderStyle="None" Wrap="True">
                        </ErrorFrameStyle>
                        <RequiredField IsRequired="True" ErrorText="" />
                    </ValidationSettings>--%>
                </dx:ASPxTextBox>
                <dx:ASPxLabel ID="lblErrorLogin" ClientInstanceName="lblErrorLogin" runat="server" CssClass="error-login"></dx:ASPxLabel>
                <dx:ASPxButton ID="btnlogin" ClientInstanceName="btnlogin" runat="server" Text="Login" CssClass="input-btn" BackColor="#134A8B" OnClick="btnlogin_Click" AutoPostBack="false">
                    <ClientSideEvents Click="function(s, e) {
	   e.processOnServer = true;
}" />
                </dx:ASPxButton>
            </form>
        </div>
    </div>
</body>
</html>
