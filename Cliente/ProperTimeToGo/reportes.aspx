<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="ProperTimeToGo.reportes" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        window.onload = function (event) {
            AdjustSize1();
        }

        window.onresize = function (event) {
            AdjustSize1();
        };

        function AdjustSize1() {
            var height = Math.max(0, document.documentElement.clientHeight);
            
            var altoAreducir = 50 + 30 + 110;
                ASPxGridView1.SetHeight(height - altoAreducir);
        }
    </script>
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
        <Items>
            <dx:MenuItem Text="Reportes">
                <Items>
                    <dx:MenuItem GroupName="Calculo" Text="C&#225;lculo Asistencia"></dx:MenuItem>
                    <dx:MenuItem GroupName="Calculo" Text="C&#225;lculo Sin Horarios"></dx:MenuItem>
                    <dx:MenuItem GroupName="Calculo" Text="C&#225;lculo Personalizado"></dx:MenuItem>
                    <dx:MenuItem GroupName="Calculo" Text="Consulta Historial"></dx:MenuItem>
                    <dx:MenuItem Text="Marcaciones"></dx:MenuItem>
                    <dx:MenuItem Text="Marc.Manuales"></dx:MenuItem>
                    <dx:MenuItem Text="Sin Marcaciones"></dx:MenuItem>
                    <dx:MenuItem Text="Permisos"></dx:MenuItem>
                    <dx:MenuItem Text="Cumplea&#241;os"></dx:MenuItem>
                    <dx:MenuItem Text="Aniversarios"></dx:MenuItem>
                    <dx:MenuItem Text="Contratados"></dx:MenuItem>
                    <dx:MenuItem Text="Exportar Marcaciones MRL"></dx:MenuItem>
                </Items>
            </dx:MenuItem>
        </Items>
    </dx:ASPxMenu>
    <div class="separador"></div>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" KeyFieldName="NumCa" Theme="MetropolisBlue" Width="100%">
        <SettingsAdaptivity>
            <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>

        <SettingsPager Mode="ShowAllRecords" Visible="False">
        </SettingsPager>

        <Settings ShowHeaderFilterButton="True" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="400" VerticalScrollBarMode="Auto" />
        <SettingsBehavior AllowCellMerge="true" />
        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        <SettingsLoadingPanel Mode="ShowAsPopup" />
        <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
    </dx:ASPxGridView>
     <dx:ASPxPopupControl ID="pcLogin" runat="server" Width="320" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcLogin"
        HeaderText="Error" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true" Theme="Office365">        
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btOK">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" Width="100%" Height="100%" Theme="Office365">
                                <Items>
                                    <dx:LayoutItem Caption="Error">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="lblMensajeError" ClientInstanceName="lblMensajeError" runat="server" Text=""></dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>  
                                    <dx:LayoutItem ShowCaption="False" Paddings-PaddingTop="19">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btOK" runat="server" Text="Aceptar" Width="80px" AutoPostBack="False" Style="float: right; margin-right: 8px;" Theme="Office365">
                                                    <ClientSideEvents Click="function(s, e) { pcLogin.Hide(); }" />
                                                </dx:ASPxButton>
                                                <%--<dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                    <ClientSideEvents Click="function(s, e) { pcLogin.Hide(); }" />
                                                </dx:ASPxButton>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

<Paddings PaddingTop="19px"></Paddings>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:ASPxFormLayout>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>                
            </dx:PopupControlContentControl>
        </ContentCollection>
        <HeaderImage IconID="actions_cancel_16x16">
        </HeaderImage>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
