<%@ Page Title="Horarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="horarios.aspx.cs" Inherits="ProperTimeToGo.horarios" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/horarios.js"></script>
    <script>
        function FocusedRowChanged(s, e) {
            grvHorarios.GetRowValues(grvHorarios.GetFocusedRowIndex(), 'STARTTIME;ENDTIME;CHECKINTIME1;CHECKOUTTIME1;CHECKINTIME2;CHECKOUTTIME2', OnGetRowValues);
        }
        function OnGetRowValues(values) {

            $('#etiquetaInicioEntrada').text(ObtenrHora(values[2]));
            $('#etiquetaEntrada').text(ObtenrHora(values[0]));
            $('#etiquetaInicioAlmuerzo').text(ObtenrHora(values[3]));
            $('#etiquetaFinAlmuerzo').text(ObtenrHora(values[4]));
            $('#etiquetaSalida').text(ObtenrHora(values[1]));
            $('#etiquetaFinSalida').text(ObtenrHora(values[5]));
        }
        function ObtenrHora(cadena) {
            var fecha = new Date(cadena);
            var horas = fecha.getHours() < 10 ? ('0' + fecha.getHours()) : fecha.getHours();
            var minut = fecha.getMinutes() < 10 ? ('0' + fecha.getMinutes()) : fecha.getMinutes();
            return horas + ':' + minut;
        }
    </script>
    <style>
        #escalaDeTiempo {
            width: 100%;
            padding: 10px;
            height: 100px;
        }

        #contentEjeXPrincipal {
            width: 960px;
            height: 15px;
            margin: 0 auto;
            position: relative;
            top: 30px;
        }

        #ejeXPrincipal {
            width: 968px;
            border: 1px solid #000;
            margin: 0 auto;
            position: relative;
            top: 6px;
        }

        .grafica-tiempo {
            float: left;
            height: 9px;
            position: relative;
            top: 19px;
        }

        #rangoInicioEntrada {
            background: orange;
            left: 53px;
            width: 254px;
        }

        #rangoEntradaSalida {
            background: blue;
            left: 135px;
            width: 421px;
        }

        #rangoFinSalida {
            background: orange;
            left: 176px;
            width: 170px;
        }

        .borde-hora {
            width: 0px;
            float: left;
            height: 12px;
            border: 1px solid #000;
            position: relative;
            top: 0;
        }

        #etiquetasGraficaTiempoHorario {
            height: 22px;
            margin-bottom: 3px;
            position: relative;
            top: 31px;
        }

        .etiqueta-tiempo {
            width: 35px;
            float: left;
            font-size: 12px;
            text-align: center;
            height: 20px;
            border: 1px solid #dedede;
            margin-bottom: 10px;
            position: relative;
        }

        #etiquetaInicioEntrada {
            left: 288px;
        }

        #etiquetaEntrada {
            left: 337px;
        }

        #etiquetaInicioAlmuerzo {
            left: 470px;
        }

        #etiquetaFinAlmuerzo {
            left: 479px;
        }

        #etiquetaSalida {
            left: 612px;
        }

        #etiquetaFinSalida {
            left: 659px;
        }
    </style>
     <script type="text/javascript">
        //function ShowLoginWindow() {
        //    console.log("lologre")
        //    pcLogin.Show();
        // }   
        // setTimeout(function(){ ShowLoginWindow(); }, 3000);
        
    </script>
    <dx:ASPxMenu ID="mnuSuperior" ClientInstanceName="mnuSuperior" runat="server">
    </dx:ASPxMenu>
    <div class="separador"></div>
    <div id="escalaDeTiempo">
        <div id="graficaTiempoHorario">
            <div id="contentEjeXPrincipal">
                <div id="ejeXPrincipal"></div>
            </div>
            <div id="rangoInicioEntrada" class="grafica-tiempo"></div>
            <div id="rangoEntradaSalida" class="grafica-tiempo"></div>
            <div id="rangoFinSalida" class="grafica-tiempo"></div>
        </div>
        <div style="clear: both;"></div>
        <div id="etiquetasGraficaTiempoHorario">
            <div id="etiquetaInicioEntrada" class="etiqueta-tiempo"></div>
            <div id="etiquetaEntrada" class="etiqueta-tiempo"></div>
            <div id="etiquetaInicioAlmuerzo" class="etiqueta-tiempo"></div>
            <div id="etiquetaFinAlmuerzo" class="etiqueta-tiempo"></div>
            <div id="etiquetaSalida" class="etiqueta-tiempo"></div>
            <div id="etiquetaFinSalida" class="etiqueta-tiempo"></div>
        </div>
    </div>
    <div class="separador"></div>
    <dx:ASPxGridView ID="grvHorarios" ClientInstanceName="grvHorarios" runat="server" AutoGenerateColumns="False">
        <ClientSideEvents FocusedRowChanged="FocusedRowChanged" />
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
    <script>
        function calcularHora() {
            var lineTiempo = 960;
            var lineaHora = parseInt(lineTiempo / 24);
            for (var i = 0; i < 24; i++) {
                $("#contentEjeXPrincipal")
                    .append('<div class="borde-hora" style="left:' + (lineaHora * i) + 'px"></div>')
            }
        }
        calcularHora();
    </script>
   
</asp:Content>
