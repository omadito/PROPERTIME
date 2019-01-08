<%@ Page Title="Cenro de Costos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="centrocostos.aspx.cs" Inherits="ProperTimeToGo.centrocostos" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="Scripts/centrocostos.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">       
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvCentroCostos" ClientInstanceName="grvCentroCostos" runat="server">        
    </dx:ASPxGridView>
</asp:Content>
