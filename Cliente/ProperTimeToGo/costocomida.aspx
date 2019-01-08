<%@ Page Title="Costo Comida" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="costocomida.aspx.cs" Inherits="ProperTimeToGo.costocomida" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
     <script type="text/javascript" src="Scripts/costocomida.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">       
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvCostoComida" ClientInstanceName="grvCostoComida" runat="server"  >        
    </dx:ASPxGridView>
</asp:Content>