<%@ Page Title="Administraodres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administradoresconfiguracion.aspx.cs" Inherits="ProperTimeToGo.administtradoresconfiguracion" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server"></dx:ASPxMenu>
    <div class="separador"></div>
    <div class="panel-contenido">
        <dx:ASPxGridView ID="grvEmpleado" ClientInstanceName="grvEmpleado" runat="server" AutoGenerateColumns="False">
        </dx:ASPxGridView>
    </div>
</asp:Content>
