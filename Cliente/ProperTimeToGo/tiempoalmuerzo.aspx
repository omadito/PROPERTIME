<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tiempoalmuerzo.aspx.cs" Inherits="ProperTimeToGo.tiempoalmuerzo" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
    </dx:ASPxMenu>
    <div class="separador"></div>
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server"></dx:ASPxGridView>
        <table>
            <tr>
                <td>Tiempo de Almuerzo</td>
                <td>
                    <dx:ASPxSpinEdit ID="spnTiempoAlmuerzo" ClientInstanceName="spnTiempoAlmuerzo" runat="server" Number="0">
                    </dx:ASPxSpinEdit>
                </td>
            </tr>
            <tr>
                <td>Hora de Salida al Almuerzo</td>
                <td>
                    <dx:ASPxSpinEdit ID="spnHoraSalidaAlmuerzo" ClientInstanceName="spnHoraSalidaAlmuerzo" runat="server" Number="0">
                    </dx:ASPxSpinEdit>
                </td>
            </tr>
            <tr>
                <td>Hora de Llegada del Almuerzo</td>
                <td>
                    <dx:ASPxSpinEdit ID="spnHoraLlegdaAlmuerzo" ClientInstanceName="spnHoraLlegdaAlmuerzo" runat="server" Number="0">
                    </dx:ASPxSpinEdit>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
