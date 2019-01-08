<%@ Page Title="Feriados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="feriado.aspx.cs" Inherits="ProperTimeToGo.feriado" EnableEventValidation="false" %>


<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/feriados.js"></script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">       
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvFeriados" ClientInstanceName="grvFeriados" runat="server" >
    </dx:ASPxGridView>
</asp:Content>