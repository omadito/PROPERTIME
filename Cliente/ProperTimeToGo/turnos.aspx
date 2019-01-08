<%@ Page Title="Turnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="turnos.aspx.cs" Inherits="ProperTimeToGo.turnos" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript" src="Scripts/turnos.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">       
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvTurnos" ClientInstanceName="grvTurnos" runat="server" >
    </dx:ASPxGridView>
</asp:Content>

