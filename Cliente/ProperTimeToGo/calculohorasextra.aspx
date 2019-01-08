<%@ Page Title="Cálculo Horas Extra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="calculohorasextra.aspx.cs" Inherits="ProperTimeToGo.calculohorasextra" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/calculohorasextra.js"></script>
    <style>
        .table-calculo, .table-calculo table {
            width: 100%;
        }

        .td-border-padding {
            border: 1px solid rgba(0,0,0,0.1);
            padding: 5px;
        }

        .dxeRadioButtonList, .dxeCheckBoxList {
            border: none !important;
        }

        .scroll-vertical {
            overflow: auto;
            overflow-y: auto;
            overflow-x: hidden;
        }
        .vertical-align-top{
            vertical-align:top;
        }
    </style>
    <script>
        $(document).ready(function () {
            resizeDiv();
        });

        window.onresize = function (event) {
            resizeDiv();
        }

        function resizeDiv() {
            vpw = $(window).width();
            vph = $(window).height();
            $('.scroll-vertical').css({ 'height': (vph - 150) + 'px' });
        }
    </script>

    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
        <Items>
            <dx:MenuItem></dx:MenuItem>
            <dx:MenuItem></dx:MenuItem>
            <dx:MenuItem></dx:MenuItem>
            <dx:MenuItem></dx:MenuItem>
            <dx:MenuItem></dx:MenuItem>
        </Items>
    </dx:ASPxMenu>
    <div class="separador"></div>
    <div class="scroll-vertical">
        <table class="table-calculo dxgvTable_Office365 dxgvRBB">
            <tr>
                <td colspan="2" class="text-center td-border-padding"><strong>Marcaciones Imcompletas</strong></td>
                <td colspan="2" class="text-center td-border-padding"><strong>Antes Entrada / Despu&#233;s Salida</strong></td>
            </tr>
            <tr>
                <td class="td-border-padding vertical-align-top">
                    <dx:ASPxGridView runat="server" ClientInstanceName="grvMarcacionesCompletas" ID="grvMarcacionesCompletas">
                    </dx:ASPxGridView>
                </td>
                <td class="td-border-padding">
                    <table>
                        <tr>
                            <td>Si no registra la entrada </td>
                            <td class="vertical-align-top">
                                <dx:ASPxComboBox runat="server" ClientInstanceName="cboRegistraEntrada" ID="cboRegistraEntrada" Width="150px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Si no registra la salida </td>
                            <td class="vertical-align-top">
                                <dx:ASPxComboBox runat="server" ClientInstanceName="cboRegistraSalida" ID="cboRegistraSalida" Width="150px">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Jornada máxima de trabajo </td>
                            <td>
                                <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="speJornadaMaximaTrabajo" ID="speJornadaMaximaTrabajo" Width="150px">
                                </dx:ASPxSpinEdit>
                            </td>
                            <td>minutos</td>
                        </tr>
                        <tr>
                            <td>Jornada mínima de trabajo </td>
                            <td>
                                <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="speJornadaMinimaTrabajo" ID="speJornadaMinimaTrabajo" Width="150px">
                                </dx:ASPxSpinEdit>
                            </td>
                            <td>minutos</td>
                        </tr>
                        <tr>
                            <td>Intervalo mínimo entre turnos </td>
                            <td>
                                <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="speIntervaloMinimoTurnos" ID="speIntervaloMinimoTurnos" Width="150px">
                                </dx:ASPxSpinEdit>
                            </td>
                            <td>minutos</td>
                        </tr>
                    </table>
                </td>
                <td class="td-border-padding vertical-align-top">
                    <dx:ASPxGridView runat="server" ClientInstanceName="grdAntEntDespSal" ID="grdAntEntDespSal">
                    </dx:ASPxGridView>
                </td>
                <td class="td-border-padding">
                    <table>
                        <tr>
                            <td>
                                <span><strong>Considerar llegada temprano como</strong></span>
                                <dx:ASPxRadioButtonList runat="server" ClientInstanceName="rblLlegadaTemprano" Theme="Default" ID="rblLlegadaTemprano">
                                    <Items>
                                        <dx:ListEditItem Text="Hora Extra" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Tiempo Trabajo" Value="2"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Entrada Puntual" Value="3"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxRadioButtonList>
                            </td>
                            <td>
                                <span><strong>Considerar salida tarde como</strong></span>
                                <dx:ASPxRadioButtonList runat="server" ClientInstanceName="rblSAlidaTarde" ID="rblSAlidaTarde" Theme="Default">
                                    <Items>
                                        <dx:ListEditItem Text="Hora Extra" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Tiempo Trabajo" Value="2"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Salida Puntual" Value="3"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxRadioButtonList>
                            </td>
                        </tr>
                        <td colspan="2">
                            <span><strong>Considerar Hora Extra en Día Libre con Fin en Día Laborable</strong></span>
                            <dx:ASPxRadioButtonList runat="server" ClientInstanceName="rblConsiderarHE" ID="rblConsiderarHE" Theme="Default" Width="100%">
                                <Items>
                                    <dx:ListEditItem Text="Como en D&#237;a Laborable" Value="1"></dx:ListEditItem>
                                    <dx:ListEditItem Text="Como en D&#237;a Libre" Value="2"></dx:ListEditItem>
                                </Items>
                            </dx:ASPxRadioButtonList>
                        </td>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="text-center td-border-padding"><strong>D&#237;as H&#225;biles</strong></td>
                <td colspan="2" class="text-center td-border-padding"><strong>Multa Atrasos</strong></td>
            </tr>
            <tr>
                <td class="td-border-padding vertical-align-top">
                    <dx:ASPxGridView runat="server" ClientInstanceName="grdDiasHabiles" ID="grdDiasHabiles">
                    </dx:ASPxGridView>
                </td>
                <td class="td-border-padding">
                    <table>
                        <tr>
                            <td rowspan="2">
                                <span><strong>Días Hábiles</strong></span>
                                <dx:ASPxCheckBoxList runat="server" ClientInstanceName="chkDias" ID="chkDias">
                                    <Items>
                                        <dx:ListEditItem Text="Lunes" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Martes" Value="2"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Mi&#233;rcoles" Value="3"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Jueves" Value="4"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Viernes" Value="5"></dx:ListEditItem>
                                        <dx:ListEditItem Text="S&#225;bado" Value="6"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Domingo" Value="7"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxCheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span><strong>Los días Hábiles son</strong></span>
                                <dx:ASPxRadioButtonList runat="server" ClientInstanceName="rdoDiasHabiles" ID="rdoDiasHabiles" Theme="Default">
                                    <Items>
                                        <dx:ListEditItem Text="Rotativos" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Obligatorios" Value="2"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxRadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span><strong>Horarios de Trabajo Extra cuando hay Turno Fijo</strong></span>
                                <dx:ASPxCheckBoxList runat="server" ClientInstanceName="chkHorTETF" ID="chkHorTETF">
                                    <Items>
                                        <dx:ListEditItem Text="Los Horarios Rotativos de Turnos Fijos cuentan como Horas Extraordinarias" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="D&#237;as Libres de Turnos Fijos cuenta como Horas Extraordinarias" Value="2"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxCheckBoxList>
                            </td>
                        </tr>
                    </table>
                </td>

                <td class="td-border-padding vertical-align-top">
                    <dx:ASPxGridView runat="server" ClientInstanceName="grdMultaAtrasos" ID="grdMultaAtrasos">
                    </dx:ASPxGridView>
                </td>
                <td class="td-border-padding">
                    <table>
                        <tr>
                            <td colspan="2">
                                <span><strong>Llegada tarde en tiempo de gracia</strong></span>
                                <dx:ASPxCheckBoxList runat="server" ClientInstanceName="chkLLegadTardeGracia" Theme="Default" ID="chkLLegadTardeGracia">
                                    <Items>
                                        <dx:ListEditItem Text="COnsiderar como entrada ppuntual" Value="1"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxCheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="1">
                                <span><strong>Multa Atrasos</strong></span>
                                <dx:ASPxCheckBoxList runat="server" ClientInstanceName="chkmultaAtrasos" Theme="Default" ID="chkmultaAtrasos" Width="100px">
                                    <Items>
                                        <dx:ListEditItem Text="Multar los Atrasos" Value="1"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxCheckBoxList>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 71px">Valor Multa / Hora</td>
                                        <td>
                                            <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="spnValorMultaHora" ID="spnValorMultaHora" Width="100px">
                                            </dx:ASPxSpinEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 71px">Multa Máxima</td>
                                        <td>
                                            <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="spnMultaMaxima" ID="spnMultaMaxima" Width="100px">
                                            </dx:ASPxSpinEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 71px">Multa desde (min)</td>
                                        <td>
                                            <dx:ASPxSpinEdit runat="server" Number="0" ClientInstanceName="spnMultaddesde" ID="spnMultaddesde" Width="100px">
                                            </dx:ASPxSpinEdit>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxRadioButtonList runat="server" ClientInstanceName="cboMultarAtrasos" Theme="Default" ID="cboMultarAtrasos" Width="100px">
                                    <Items>
                                        <dx:ListEditItem Text="USD $" Value="1"></dx:ListEditItem>
                                        <dx:ListEditItem Text="Porcentaje" Value="2"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxRadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
