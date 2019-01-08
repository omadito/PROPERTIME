<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empleado.aspx.cs" Inherits="ProperTimeToGo.empleado" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
     <style type="text/css">
        .templateTable
        {
            border-collapse: collapse;
            width: 100%;
        }
        .templateTable td
        {
            border: solid 1px #C2D4DA;
            padding: 6px;
        }
        .templateTable td.value
        {
            font-weight: bold; 
        }
        .imageCell 
        {
            width: 160px;
        }
    </style>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
        <Items>
            <dx:MenuItem Text="Nuevo"></dx:MenuItem>
            <dx:MenuItem Text="Eliminar"></dx:MenuItem>
        </Items>
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grid" runat="server"  ClientInstanceName="grid"
        KeyFieldName="NumCA" Width="100%" EnableRowsCache="false" 
        OnCustomCallback="grid_CustomCallback" Settings-VerticalScrollBarMode="Auto">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataColumn FieldName="UserId" />
            <dx:GridViewDataColumn FieldName="NumCA" />
            <dx:GridViewDataColumn FieldName="Nombre" />
            <dx:GridViewDataColumn FieldName="DEFAULTDEPTID" />
            <dx:GridViewDataColumn FieldName="OTAdmin" />
            <dx:GridViewDataColumn FieldName="OTPrivAdmin" />
        </Columns>
        <SettingsPager PageSize="5" />        
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

        <Templates>
            <DataRow>
                <div style="padding: 5px">
                    <table class="templateTable">
                        <tr>
                            <td class="imageCell" rowspan="4">
                                <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%# Eval("PHOTOB") %>' EnableServerResize="True" ImageSizeMode="FitProportional" Width="200px" />
                            </td>
                            <td>
                                UserId
                            </td>
                            <td class="value">
                                <dx:ASPxLabel ID="lblFirstName" runat="server" Text='<%# Eval("UserId") %>' />
                            </td>
                            <td>
                                NumCA
                            </td>
                            <td class="value">
                                <dx:ASPxLabel ID="lblLastName" runat="server" Text='<%# Eval("NumCA") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre
                            </td>
                            <td class="value" colspan="3">
                                <dx:ASPxLabel ID="lblTitle" runat="server" Text='<%# Eval("Nombre") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                DEFAULTDEPTID
                            </td>
                            <td class="value">
                                <dx:ASPxLabel ID="lblBirthDate" runat="server" Text='<%# Eval("DEFAULTDEPTID") %>' />
                            </td>
                            <td>
                                OTAdmin
                            </td>
                            <td class="value">
                                <dx:ASPxLabel ID="lblHireDate" runat="server" Text='<%# Eval("OTAdmin") %>' />
                            </td>
                        </tr>
                        <tr>
                            <!---->
                            <td>
                                OTPrivAdmin
                            </td>
                            <td colspan="3" class="value">
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("[OTPrivAdmin]") %>' />
                            </td>                            
                        </tr>
                    </table>
                </div>
            </DataRow>
        </Templates>
    </dx:ASPxGridView>    
</asp:Content>
