﻿<%@ Page Title="Información Adicional" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="informacionadicional.aspx.cs" Inherits="ProperTimeToGo.InformacionAdicional" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function OnDepartmentChanged(s, e) {
            grvEmpleados.PerformCallback(s.GetFocusedNodeKey());
        }
        function mnuItemClick(s, e) {
            var i = e.item.name;
            //console.log(i);
            switch (i) {
                case "mnuEditar":
                    if (grvEmpleados.GetSelectedRowCount() > 0)
                        grvEmpleados.PerformCallback('StartEditing');
                    break;
            }
        }
    </script>
    <div class="content">
        <dx:ASPxMenu ID="mnuPantalla" runat="server" Theme="MetropolisBlue" EnableTheming="True">
            <ClientSideEvents ItemClick="mnuItemClick" />
            <Items>
                <dx:MenuItem Text="Editar" Name="mnuEditar"></dx:MenuItem>
            </Items>
        </dx:ASPxMenu>
        <div id="divInfoAdicional">
            <h5>Información Adicional</h5>
            <div>
                <%--<table style="width: 100%;">
                    <tr>--%>
                       <div style="margin-right:5px;width: 200px;float: left;">
                            <dx:ASPxTreeList ID="trlDepartamentos" ClientInstanceName="trlDepartamentos" runat="server" AllowSelectNode="true" AllowCheckNodes="true"
                                Width="100%" CheckNodesRecursive="true" Font-Size="10pt" >
                                <Settings ShowColumnHeaders="False" ShowFilterBar="Auto" VerticalScrollBarMode="Visible" ShowTreeLines="False" />
                                <SettingsBehavior AllowAutoFilter="False"></SettingsBehavior>
                                <SettingsCustomizationWindow PopupHorizontalAlign="RightSides" PopupVerticalAlign="BottomSides"></SettingsCustomizationWindow>
                                <SettingsPopupEditForm VerticalOffset="-1"></SettingsPopupEditForm>
                                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                <SettingsSelection Enabled="true" Recursive="true" AllowSelectAll="true" />
                                <SettingsSearchPanel Visible="False" />
                                <SettingsPopup>
                                    <EditForm VerticalOffset="-1"></EditForm>
                                </SettingsPopup>
                                <ClientSideEvents SelectionChanged="OnDepartmentChanged" />
                            </dx:ASPxTreeList>
                        </div>
                        <div style="margin-right:5px;float: left;">
                            <dx:ASPxGridView ID="grvEmpleados" ClientInstanceName="grvEmpleados" runat="server"
                                Theme="Office365" OnCustomCallback="grvEmpleados_CustomCallback"
                                OnCellEditorInitialize="grvEmpleados_CellEditorInitialize" OnRowUpdating="grvEmpleados_RowUpdating" 
                                OnStartRowEditing="grvEmpleados_StartRowEditing" Width="100%" Settings-VerticalScrollBarMode="Auto" Settings-HorizontalScrollBarMode="Auto">
                                <SettingsAdaptivity>
                                    <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                                </SettingsAdaptivity>

                                <SettingsPager Mode="EndlessPaging">
                                </SettingsPager>
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" PopupEditFormModal="True" PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormVerticalAlign="WindowCenter" />
                                <Settings HorizontalScrollBarMode="Auto" />
                                <SettingsBehavior AllowSelectByRowClick="True" ProcessSelectionChangedOnServer="False" />
                                <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                                <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>

                                <Columns>
                                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True"></dx:GridViewCommandColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                   <%-- </tr>
                </table>--%>
            </div>
           
        </div>
    </div>
</asp:Content>
