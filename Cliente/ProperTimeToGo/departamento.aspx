<%@ Page Title="Departamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departamento.aspx.cs" Inherits="ProperTimeToGo.departamento" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/departamentos.js"></script>
    
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server" Theme="MetropolisBlue">
        <ClientSideEvents ItemClick="MenuItemClic" />
    </dx:ASPxMenu>
    <div class="separador"></div>
    <%--<dx:ASPxGridView ID="grvDepartamentos" ClientInstanceName="grvDepartamentos" runat="server" Theme="Office365" Width="100%" OnRowDeleting="grvDepartamentos_RowDeleting" OnRowInserting="grvDepartamentos_RowInserting" OnRowUpdating="grvDepartamentos_RowUpdating" Settings-VerticalScrollBarMode="Auto">
        <SettingsAdaptivity>
            <AdaptiveDetailLayoutProperties ColCount="1">
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager Visible="False">
        </SettingsPager>
        <EditFormLayoutProperties ColCount="1">
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="80px">
            </dx:GridViewCommandColumn>
        </Columns>
    </dx:ASPxGridView>--%>

    <dx:ASPxTreeList ID="trlDepartamentos" ClientInstanceName="trlDepartamentos" runat="server"
        OnInitNewNode="trlDepartamentos_InitNewNode" OnNodeDeleting="trlDepartamentos_NodeDeleting" OnNodeInserting="trlDepartamentos_NodeInserting" OnNodeUpdating="trlDepartamentos_NodeUpdating" Theme="Office365">

        <Settings ShowColumnHeaders="False" ShowTreeLines="False" />
<SettingsBehavior AllowAutoFilter="True" AllowFocusedNode="True"></SettingsBehavior>

<SettingsCustomizationWindow PopupHorizontalAlign="RightSides" PopupVerticalAlign="BottomSides"></SettingsCustomizationWindow>
<SettingsPopupEditForm VerticalOffset="-1"></SettingsPopupEditForm>
</dx:ASPxTreeList>
    <dx:ASPxPopupControl ID="popConfirm" runat="server" ClientInstanceName="popConfirm" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="Office365" Modal="True" CloseAction="CloseButton" CloseOnEscape="True" HeaderText="Advertencia">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                    <br />
                    <dx:ASPxLabel ID="lItemInfo" runat="server" Text="Esta seguro de eliminar el elemento?" ClientInstanceName="lItemInfo">
                    </dx:ASPxLabel>
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnYes" runat="server" Text="YES" AutoPostBack="False" Theme="Office365">
                                    <ClientSideEvents Click="DeleteConfirmed" />
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnNo" runat="server" Text="NO" AutoPostBack="False" Theme="Office365">
                                    <ClientSideEvents Click="function(s, e) {  popConfirm.Hide();  e.processOnServer = false; }" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
</asp:Content>
