<%@ Page Title="DatosEmpleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detalleempleado.aspx.cs" Inherits="ProperTimeToGo.detalleempleado" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .templateTable {
            border-collapse: collapse;
            width: 100% !important;
        }

            .templateTable td {
                border: solid 1px #C2D4DA;
                padding: 6px;
                background-color: #f4f4f4;
            }

                .templateTable td.value {
                    font-weight: bold;
                }

        .imageCell {
            width: 160px;
        }

        .dxuc-root td {
            padding: 0 !important;
            border: none !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var isValidUpload;
    </script>
    <div class="content">
        <dx:ASPxMenu ID="mnuEmplado" runat="server" Theme="Metropolis" OnItemClick="mnuEmplado_ItemClick" AutoPostBack="True"></dx:ASPxMenu>
        <div id="divInfoEmpleado">
            <h5>Información Empleado</h5>

            <dx:ASPxGridView ID="grvDatosEmpleado" ClientInstanceName="grvDatosEmpleado" runat="server" AutoGenerateColumns="False" Theme="Office365" Width="100%"
                 OnRowUpdating="grvDatosEmpleado_RowUpdating">
                <SettingsPager Visible="False">
                </SettingsPager>
                <Settings HorizontalScrollBarMode="Visible" VerticalScrollBarMode="Auto"  />
                <SettingsDataSecurity AllowDelete="False" />
                <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn FieldName="UserId" Visible="False" />
                    <dx:GridViewDataColumn FieldName="NumCA" VisibleIndex="1" Visible="false" />
                    <dx:GridViewDataColumn FieldName="Nombre" VisibleIndex="2" Visible="false" />
                    <dx:GridViewDataColumn FieldName="Cédula" VisibleIndex="3" Visible="False" />
                    <dx:GridViewDataColumn FieldName="Cargo" VisibleIndex="5" Visible="False" />
                    <dx:GridViewDataColumn FieldName="Celular" VisibleIndex="6" Visible="False" />
                    <dx:GridViewDataColumn FieldName="Direcci&#243;n" VisibleIndex="13" Visible="False" />
                    <dx:GridViewDataColumn FieldName="Ciudad" Visible="False" VisibleIndex="15" />
                    <dx:GridViewDataColumn FieldName="TelOficina" VisibleIndex="16" Visible="False" />
                    <dx:GridViewDataColumn FieldName="CodigoEmpleado" VisibleIndex="17" Visible="False" />
                    <dx:GridViewDataColumn FieldName="CorreoPersonal" VisibleIndex="18" Visible="False" />
                    <dx:GridViewDataColumn FieldName="PHOTOB" VisibleIndex="19" Visible="False" />
                    <dx:GridViewDataColumn FieldName="Notes" VisibleIndex="20" Visible="False" />
                    <dx:GridViewDataColumn FieldName="CargasFamiliares" VisibleIndex="24" Visible="False" />
                    <dx:GridViewDataComboBoxColumn FieldName="Género" VisibleIndex="4" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Departamento" VisibleIndex="7" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Centro de Costos" VisibleIndex="8" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Tipo Contrato" VisibleIndex="9" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="Fecha Nacimiento" VisibleIndex="10" Visible="False">
                        <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Fecha Empleo" VisibleIndex="11" Visible="False">
                        <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Fecha Salida" VisibleIndex="12" Visible="False">
                        <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="idCiudad" VisibleIndex="14" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="TipoEmpleado" VisibleIndex="21" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Supervisor1" VisibleIndex="22" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Supervisor2" VisibleIndex="23" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Estado Civil" VisibleIndex="25" Visible="False"></dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Tiposangre" VisibleIndex="26" Visible="False"></dx:GridViewDataComboBoxColumn>
                </Columns>
                <SettingsAdaptivity>
                    <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                </SettingsAdaptivity>
                <Templates>
                    <EditForm>
                        <div style="padding: 5px">
                            <table class="templateTable">
                                <tr>
                                    <td class="imageCell" rowspan="6">
                                        <dx:ASPxCallbackPanel ID="cpnImage" runat="server" ClientInstanceName="cpnImage"
                                            OnCallback="cpnImage_Callback" Width="200px">
                                            <PanelCollection>
                                                <dx:PanelContent ID="PanelContent1" runat="server">
                                                    <dx:ASPxBinaryImage ID="bimFotoEmpleado" runat="server" Height="300px"
                                                        Width="200px" OnInit="bimFotoEmpleado_Init">
                                                    </dx:ASPxBinaryImage>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxCallbackPanel>
                                        <div>
                                            <div>
                                                <dx:ASPxUploadControl ID="ucpImage" runat="server" ClientInstanceName="ucpImage"
                                                    OnFileUploadComplete="ucpImage_FileUploadComplete" ShowUploadButton="True" ShowClearFileSelectionButton="False"
                                                    ShowTextBox="False" Height="39px" UploadMode="Auto">
                                                    <ClientSideEvents FilesUploadComplete="function(s, e) { if (isValidUpload) { cpnImage.PerformCallback();} }"
                                                        FileUploadComplete="function(s, e) { isValidUpload = e.isValid; }" Init="function(s, e) { isValidUpload = false; }" />
                                                    <UploadButton Text="Visualizar" ImagePosition="right">
                                                    </UploadButton>
                                                    <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.png,.gif" MaxFileSize="1000000">
                                                    </ValidationSettings>
                                                    <AdvancedModeSettings EnableDragAndDrop="True">
                                                    </AdvancedModeSettings>
                                                </dx:ASPxUploadControl>
                                            </div>
                                        </div>

                                    </td>
                                    <td>NumCA
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="lblNombre" runat="server" Text='<%# Eval("NumCA") %>' />--%>
                                        <dx:ASPxTextBox ID="txtNumCA" runat="server" Theme="Office365" Text='<%# Eval("NumCA") %>'></dx:ASPxTextBox>
                                    </td>
                                    <td>Nombre
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="lblLastName" runat="server" Text='<%# Eval("Nombre") %>' />--%>
                                        <dx:ASPxTextBox ID="txtNombre" runat="server" Theme="Office365" Text='<%# Eval("Nombre") %>'></dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cédula
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="lblTitle" runat="server" Text='<%# Eval("Cédula") %>' />--%>
                                        <dx:ASPxSpinEdit ID="txtCedula" runat="server" Theme="Office365" Text='<%# Eval("Cédula") %>'>
                                            <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td>Género
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel3" runat="server" Text='<%# Eval("Género") %>' />--%>
                                        <dx:ASPxComboBox ID="cboGenero" runat="server" Theme="Office365"
                                            OnInit="cboGenero_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cargo
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="lblBirthDate" runat="server" Text='<%# Eval("Cargo") %>' />--%>
                                        <dx:ASPxTextBox ID="txtCargo" runat="server" Theme="Office365" Text='<%# Eval("Cargo") %>'></dx:ASPxTextBox>
                                    </td>
                                    <td>Celular
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="lblHireDate" runat="server" Text='<%# Eval("Celular") %>' />--%>
                                        <dx:ASPxSpinEdit ID="txtCelular" runat="server" Theme="Office365" Text='<%# Eval("Celular") %>'>
                                            <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Departamento
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("[Departamento]") %>' />--%>
                                        <dx:ASPxComboBox ID="cboDepartamento" runat="server" Theme="Office365"
                                            OnInit="cboDepartamento_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>Centro de Costos
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel2" runat="server" Text='<%# Eval("Centro de Costos") %>' />--%>
                                        <dx:ASPxComboBox ID="cboCentroCostos" runat="server" Theme="Office365"
                                            OnInit="cboCentroCostos_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tipo Contrato
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel4" runat="server" Text='<%# Eval("Tipo Contrato") %>' />--%>
                                        <dx:ASPxComboBox ID="cboTipoContrato" runat="server" Theme="Office365"
                                            OnInit="cboTipoContrato_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>Fecha Nacimiento
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel5" runat="server" Text='<%# Eval("Fecha Nacimiento") %>' />--%>
                                        <dx:ASPxDateEdit ID="txtFechaNacimiento" runat="server" Theme="Office365" Text='<%# Eval("Fecha Nacimiento") %>'></dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Fecha Empleo
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel6" runat="server" Text='<%# Eval("[Fecha Empleo]") %>' />--%>
                                        <dx:ASPxDateEdit ID="txtFechaEmpleo" runat="server" Theme="Office365" Text='<%# Eval("Fecha Empleo") %>'></dx:ASPxDateEdit>
                                    </td>
                                    <td>Fecha Salida
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel7" runat="server" Text='<%# Eval("Fecha Salida") %>' />--%>
                                        <dx:ASPxDateEdit ID="txtFechaSalida" runat="server" Theme="Office365" Text='<%# Eval("Fecha Salida") %>'></dx:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="imageCell" rowspan="6">
                                        <div id="divImagenFirma">
                                            <dx:ASPxCallbackPanel ID="cpnFirma" runat="server" ClientInstanceName="cpnFirma"
                                                OnCallback="cpnFirma_Callback" Width="200px">
                                                <PanelCollection>
                                                    <dx:PanelContent ID="PanelContent2" runat="server">
                                                        <dx:ASPxBinaryImage ID="bimFirma" runat="server" Height="80px" Visible="False"
                                                            Width="100px">
                                                        </dx:ASPxBinaryImage>
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>

                                        </div>
                                        <div>
                                            <div>
                                                <dx:ASPxUploadControl ID="upcFirma" runat="server" ClientInstanceName="upcFirma"
                                                    OnFileUploadComplete="upcFirma_FileUploadComplete" ShowUploadButton="True" ShowClearFileSelectionButton="False"
                                                    ShowTextBox="False" Height="39px" UploadMode="Auto">
                                                    <ClientSideEvents FilesUploadComplete="function(s, e) { if (isValidUpload) { cpnFirma.PerformCallback();} }"
                                                        FileUploadComplete="function(s, e) { isValidUpload = e.isValid; }" Init="function(s, e) { isValidUpload = false; }" />
                                                    <UploadButton Text="Visualizar" ImagePosition="right">
                                                    </UploadButton>
                                                    <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.png,.gif" MaxFileSize="1000000">
                                                    </ValidationSettings>
                                                    <AdvancedModeSettings EnableDragAndDrop="True">
                                                    </AdvancedModeSettings>
                                                </dx:ASPxUploadControl>
                                                <%-- </td>
                                                    <td style="text-align: center; vertical-align: top;">
                                                        <dx:ASPxButton ID="btnBorrarFirma" runat="server" Text="Borrar"></dx:ASPxButton>
                                                    </td>
                                                </tr>--%>
                                            </div>
                                            <!---->
                                        </div>
                                    </td>
                                    <td>Dirección
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel8" runat="server" Text='<%# Eval("Dirección") %>' />--%>
                                        <dx:ASPxMemo ID="txtDireccion" runat="server" Text='<%# Eval("Dirección") %>'></dx:ASPxMemo>
                                    </td>
                                    <td>idCiudad
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel9" runat="server" Text='<%# Eval("idCiudad") %>' />--%>
                                        <dx:ASPxComboBox ID="cboCiudad" runat="server" Theme="Office365"
                                            OnInit="cboCiudad_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tel.Oficina
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel10" runat="server" Text='<%# Eval("[TelOficina]") %>' />--%>
                                        <dx:ASPxSpinEdit ID="txtTelOficina" runat="server" Theme="Office365" Text='<%# Eval("TelOficina") %>'>
                                            <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td>CodigoEmpleado
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel11" runat="server" Text='<%# Eval("CodigoEmpleado") %>' />--%>
                                        <dx:ASPxTextBox ID="txtCodigoEmpleado" runat="server" Theme="Office365" Text='<%# Eval("CodigoEmpleado") %>'></dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>CorreoPersonal
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel12" runat="server" Text='<%# Eval("CorreoPersonal") %>' />--%>
                                        <dx:ASPxTextBox ID="txtCorreoPersonal" runat="server" Theme="Office365" Text='<%# Eval("CorreoPersonal") %>'></dx:ASPxTextBox>
                                    </td>
                                    <td>TipoEmpleado
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel13" runat="server" Text='<%# Eval("TipoEmpleado") %>' />--%>
                                        <dx:ASPxComboBox ID="cboTipoEmpleado" runat="server" Theme="Office365"
                                            OnInit="cboTipoEmpleado_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Supervisor1
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel14" runat="server" Text='<%# Eval("[Supervisor1]") %>' />--%>
                                        <dx:ASPxComboBox ID="cboSupervisor1" runat="server" Theme="Office365"
                                            OnInit="cboSupervisor1_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>Supervisor2
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel15" runat="server" Text='<%# Eval("Supervisor2") %>' />--%>
                                        <dx:ASPxComboBox ID="cboSupervisor2" runat="server" Theme="Office365"
                                            OnInit="cboSupervisor2_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>CargasFamiliares
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel16" runat="server" Text='<%# Eval("CargasFamiliares") %>' />--%>
                                        <dx:ASPxSpinEdit ID="txtCargasFamiliares" runat="server" Theme="Office365" Text='<%# Eval("CargasFamiliares") %>'>
                                            <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td>Estado Civil
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel17" runat="server" Text='<%# Eval("Estado Civil") %>' />--%>
                                        <dx:ASPxComboBox ID="cboEstadoCivil" runat="server" Theme="Office365"
                                            OnInit="cboEstadoCivil_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tiposangre
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel18" runat="server" Text='<%# Eval("[Tiposangre]") %>' />--%>
                                        <dx:ASPxComboBox ID="cboTipoSangre" runat="server" Theme="Office365"
                                            OnInit="cboTipoSangre_Init">
                                        </dx:ASPxComboBox>
                                    </td>
                                    <td>Notes
                                    </td>
                                    <td class="value">
                                        <%--<dx:ASPxLabel ID="ASPxLabel19" runat="server" Text='<%# Eval("Notes") %>' />--%>
                                        <dx:ASPxMemo ID="txtNotes" runat="server" Theme="Office365" Text='<%# Eval("Notes") %>'></dx:ASPxMemo>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </EditForm>
                </Templates>
            </dx:ASPxGridView>
            <dx:ASPxPopupControl ID="ppcMensajeDesactivacion" runat="server" Theme="Office365" Modal="True" CloseAction="CloseButton"
                CloseOnEscape="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcMensajeDesactivacion"
                HeaderText="Información" AllowDragging="false" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true">                
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>
                    </dx:PopupControlContentControl>
                </ContentCollection>

            </dx:ASPxPopupControl>
        </div>
    </div>
</asp:Content>
