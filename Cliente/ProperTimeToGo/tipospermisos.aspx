<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tipospermisos.aspx.cs" Inherits="ProperTimeToGo.tipospermisos" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/tipospermiso.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">       
    </dx:ASPxMenu>
    <dx:ASPxGridView ID="grvTiposPermisos" ClientInstanceName="grvTiposPermisos" runat="server" >        
    </dx:ASPxGridView>
</asp:Content>
