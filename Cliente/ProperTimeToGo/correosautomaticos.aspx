<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="correosautomaticos.aspx.cs" Inherits="ProperTimeToGo.correosautomaticos" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
    </dx:ASPxMenu>
    <div class="separador"></div>
    <table>
        <tr>
            <td>De:</td>            
            <td><dx:ASPxTextBox ID="txtEmailDe" ClientInstanceName="txtEmailDe" runat="server"></dx:ASPxTextBox></td>
        </tr>
        <tr>
            <td>Para:</td>            
            <td><dx:ASPxTextBox ID="txtEmailPara" ClientInstanceName="txtEmailPara" runat="server"></dx:ASPxTextBox></td>
        </tr>
        <tr>
            <td>Asunto:</td>            
            <td><dx:ASPxTextBox ID="txtEmailAsunto" ClientInstanceName="txtEmailAsunto" runat="server"></dx:ASPxTextBox></td>
        </tr>   
        <tr>
            <td>Mensaje:</td>            
            <td><dx:ASPxMemo ID="txtEmailMensaje" ClientInstanceName="txtEmailMensaje" runat="server" Height="71px" Width="170px"></dx:ASPxMemo></td>
        </tr>
    </table>
</asp:Content>