<%@ Page Title="Ciudades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ciudades.aspx.cs" Inherits="ProperTimeToGo.ciudades" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/ciudades.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvCiudades" ClientInstanceName="grvCiudades" runat="server">
    </dx:ASPxGridView>
</asp:Content>
