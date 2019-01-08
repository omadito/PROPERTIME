<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="asignacionusuarios.aspx.cs" Inherits="ProperTimeToGo.asignacionusuarios" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function OnDepartmentChanged(s, e) {
            trlEmpleadoRep.PerformCallback(s.GetFocusedNodeKey());
        }
    </script>
    <div class="panel-izq">
        <div id="content-departamento">
            <span>Departamento</span>
            <dx:ASPxTreeList ID="trlEmpresaRep" ClientInstanceName="trlEmpresaRep" runat="server" allowselectnode="true" allowchecknodes="true"
                KeyFieldName="codNodo" ParentFieldName="codPadre" Width="125%" checknodesrecursive="true" Font-Size="10pt" Height="220px">
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
                <ClientSideEvents FocusedNodeChanged="OnDepartmentChanged" SelectionChanged="OnDepartmentChanged" />
            </dx:ASPxTreeList>

        </div>
        <div class="separador"></div>
        <div id="content-usuarios">
            <span>Empleados</span>
            <dx:ASPxTreeList ID="trlEmpleadoRep" ClientInstanceName="trlEmpleadoRep" runat="server" allowselectnode="true" allowchecknodes="true"
                KeyFieldName="Codigo" ParentFieldName="Padre" Width="125%" checknodesrecursive="true" Font-Size="10pt" Height="220px" OnCustomCallback="trvEmpleados_CustomCallback" OnSelectionChanged="trvEmpleados_SelectionChanged">
                <Settings ShowColumnHeaders="False" ShowFilterBar="Auto" VerticalScrollBarMode="Visible" ShowTreeLines="False" />
                <SettingsBehavior AllowAutoFilter="False"></SettingsBehavior>
                <SettingsCustomizationWindow PopupHorizontalAlign="RightSides" PopupVerticalAlign="BottomSides"></SettingsCustomizationWindow>
                <SettingsPopupEditForm VerticalOffset="-1"></SettingsPopupEditForm>
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <SettingsSelection Enabled="True" Recursive="true" AllowSelectAll="true" />
                <SettingsSearchPanel Visible="True" />
                <SettingsPopup>
                    <EditForm VerticalOffset="-1"></EditForm>
                </SettingsPopup>
            </dx:ASPxTreeList>
        </div>
    </div>
    <div class="panel-der">
        <dx:ASPxGridView ID="grdDatos" ClientInstanceName="grdDatos" runat="server"></dx:ASPxGridView>
    </div>
</asp:Content>
