<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="redondeohorasextras.aspx.cs" Inherits="ProperTimeToGo.redondeohorasextras" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
    </dx:ASPxMenu>
    <div class="separador"></div>    
    <div>
        <span>Redondeo Horas Extras</span>
        <dx:ASPxRadioButtonList ID="rbtRedondeoHorasExtras" ClientInstanceName="rbtredondeoHorasExtras" runat="server">
            <Items>
                <dx:ListEditItem Text="Hacia Arriba" Value="1"/>
                <dx:ListEditItem Text="Al Más Cercano" Value="2"/>
                <dx:ListEditItem Text="Hacia Abajo" Value="3"/>
            </Items>
        </dx:ASPxRadioButtonList>
        <div>
            <span>Forma de Redondeo</span>
            <dx:ASPxRadioButtonList ID="rbtFormaRedondeo" ClientInstanceName="rbtFormaRedondeo" runat="server">
            <Items>
                <dx:ListEditItem Text="Hora Entera" Value="1"/>
                <dx:ListEditItem Text="Media Hora" Value="2"/>
                <dx:ListEditItem Text="15 Minutos" Value="3"/>
                <dx:ListEditItem Text="Sin Redondeo" Value="4"/>
            </Items>
        </dx:ASPxRadioButtonList>
        </div>
        <div>
            <span>Redondeo A</span>
        </div>
    </div>
</asp:Content>