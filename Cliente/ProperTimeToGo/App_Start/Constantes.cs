using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public static class Constantes
    {
        #region GENERALES

        public const string SesionLogin = "CodigoLogin";
        public const string SesionAcceso = "CodigoAcceso";
        public const string SesionGrupo = "CodigoGrupo";
        public const string SesionLoginNombre = "NombreLogin";
        public const string SesionArbol = "Arbol";

        public const string ColumnaErrorLogin = "ERROR_DESCRIPCION";
        public const string IdSession = "idSession";
        public const string TablaLogin = "tblLogin";
        public const string MensajeErrorLoginVacios = "Los campos no pueden estar vacios";
      
        public const string MenuSuperior = "TblMenuSuperior";
        #endregion

        #region ARBOL

        public const string TblArbol = "tblArbol";
        public const string SessionMenuSeleccionado = "MenuSeleccionado";
        public const string ColumnaArbolCodigo = "PANT_IN_CODIGO";
        public const string ColumnaArbolPadre = "PANT_IN_PADRE";
        public const string ColumnaArbolNombre = "PANT_A0_NOMBRE";
        public const string ColumnaArbolUrl = "PANT_A0_PAGINA";

        #endregion
        
        #region EMPLEADOS

        public const string SessionNuevoEmpleado = "NuevoEmpleado";
        public const string SesionCodigoEmpleado = "CodigoEmpleado";
        public const string SesionUserIdEmpleado = "UserId";

        public const string ColumnaEmpleadoCodigo = "Codigo";
        public const string ColumnaEmpleadoPadre = "Padre";
        public const string ColumnaEmpleadoUserId = "UserId";
        public const string ColumnaEmpleadoNumCA = "NumCA";
        public const string ColumnaEmpleadoNombre = "Nombre";
        public const string ColumnaEmpleadoDefaultDepId = "DefaultDeptId";
        public const string ColumnaEmpleadoOTAdmin = "OTAdmin";
        public const string ColumnaEmpleadoOTPrivAdmin = "OTPrivAdmin";
        public const string SesionTblEmpleadosSm = "EmpleadosSm";
        public const string SesionTblEmpleadosSm1 = "EmpleadosSm1";
        public const string SesionTblEmpleados = "Empleados";
        public const string SesionTablaEmpleadoAdministrador = "EmpleadoAdmin";

        public const string ColumnaTipoEmpleadoCodigo= "Codigo";
        public const string ColumnaTipoEmpleadoNombre = "Nombre";
        public const string CboTipoEmpleado = "CboTipoEmpleado";
        

        #endregion

        #region MENU SUPERIOR

        public const string TablaMenuSuperior = "TblMenu";       
        public const string ColumnaMenuCodigo = "BOTO_IN_CODIGO";
        public const string ColumnaMenuPadre = "BOTO_IN_PADRE";
        public const string ColumnaMenuNombre = "BOTO_A0_NOMBRE";
        public const string ColumnaMenuIcoPath = "BOTO_IN_IMAGEN";        

        #endregion

        #region DEPARTAMENTO
        public const string SesionTblDepartamentoSm = "DepartamentosSm";
        public const string SesionTablaDepartamentos = "Departamentos";
        public const string ColumnaDepartamentoCodigo = "codNodo";
        public const string ColumnaDepartamentoPadre = "codPadre";
        public const string ColumnaDepartamentoNombre = "NomDepto";
        #endregion

        #region CENTRO DE COSTOS

        public const string SesionTablaCentroCostos = "tblCentroCostos";
        public const string ColumnaCentroCostosCodigo = "idCentroCostos";
        public const string ColumnaCentroCostosNombre = "nomCentroCostos";
        public const string ColumnaCentroCostosNombreCbo = "Centro de Costos";
        public const string ColumnaCentroCostosPadres = "PadreCentroCostos";

        #endregion

        #region CIUDADES

        public const string SesionTablaCiudades = "tblCiudades";
        public const string ColumnaCiudadesCodigo = "idCiudad";
        public const string ColumnaCiudadesNombre = "Ciudad";

        #endregion

        #region FERIADOS

        public const string SesionTablaFeriados = "tblFeriados";
        public const string ColumnaFeriadosCodigo = "HOLIDAYID";
        public const string ColumnaFeriadosNombre = "HOLIDAYNAME";
        public const string ColumnaFeriadosFecha = "STARTTIME";
        public const string ColumnaFeriadosCiudad = "IdCiudad";

        #endregion

        #region PERMISO

        public const string SesionTablaPermisos = "tblPermisos";
        public const string ColumnaPermisoCodigo = "LeaveId";
        public const string ColumnaPermisoPermiso = "LeaveName";
        public const string ColumnaPermisoSimbolo = "ReportSymbol";
        public const string ColumnaPermisoTipo = "Classify";
        public const string ColumnaPermisoSolicitable = "Seleccionable";

        #endregion

        #region TIPO_PERMISO

        public const string ColumnaTipoPermisoCodigo = "Codigo";
        public const string ColumnaTipoPermisoNombre = "Nombre";

        #endregion

        #region TIPO_CUENTA

        public const string ColumnaTipoCuentaCodigo = "idTipoCuenta";
        public const string ColumnaTipoCuentaNombre = "nomTipoCuenta";

        #endregion

        #region TIPO_CONTRATO

        public const string ColumnaTipoContratoCodigo = "idContrato";
        public const string ColumnaTipoContratoNombre = "nomContrato";

        #endregion

        #region ESTADO_CIVIL

        public const string ColumnaEstadoCivilCodigo = "idEstadoCivil";
        public const string ColumnaEstadoCivilNombre = "Estado Civil";

        #endregion

        #region TIPO_SANGRE

        public const string ColumnaTipoSangreCodigo = "idTipoSangre";
        public const string ColumnaTipoSangreNombre = "Tipo De Sangre";

        #endregion

        #region SOLICITANTE

        public const string ColumnaSolicitableCodigo = "Codigo";
        public const string ColumnaSolicitableNombre = "Nombre";

        #endregion

        #region GRUPO SALARIAL

        public const string SesionTablaGrupoSalarial = "tblGrupoSalarial";
        public const string ColumnaGrupoSalarialCodigo = "idGrupo";
        public const string ColumnaGrupoSalarialNombre = "nomGrupo";
        public const string ColumnaGrupoSalarialAutomatico = "automatico";
        public const string ColumnaGrupoSalarialSueldo = "Sueldo";
        public const string ColumnaGrupoSalarialBono = "Bono";
        public const string ColumnaGrupoSalarialHE50 = "HE50";
        public const string ColumnaGrupoSalarialHE100 = "HE100";
        public const string ColumnaGrupoSalarialJN25 = "JN25";
        public const string ColumnaGrupoSalarialDstoH = "descuentoHora";
        public const string ColumnaGrupoSalarialDstoD = "descuentoDia";

        #endregion

        #region NUMERO DE COMIDAS

        public const string SesionTablaCostoComida = "tblCostoComidas";
        public const string ColumnaCostoComidaCodigo = "IdComida";
        public const string ColumnaCostoComidaNombre = "NombreComida";
        public const string ColumnaCostoComidaCostoEmpresa = "CostoEmpresa";
        public const string ColumnaCostoComidaCostoTrabajador = "CostoTrabajador";
        public const string ColumnaCostoComidaHoraInicio = "HoraInicio";
        public const string ColumnaCostoComidaHoraFin = "HoraFin";
        public const string ColumnaCostoComidaReloj = "codComidaReloj";

        #endregion

        #region DATOS EMPLEADOS

        public const string SesionTblDatosEmpleado = "tblDatoEmpleado";
        public const string SesionImegenEmpleado = "ImagenEmpleado";
        public const string SesionFirmaEmpleado = "FirmaEmpleado";
        public const string ColumnaDatoEmpleadoUserId = "UserId";
        public const string ColumnaDatoEmpleadoNumCA = "NumCA";
        public const string ColumnaDatoEmpleadoNombre = "Nombre";
        public const string ColumnaDatoEmpleadoCédula = "Cédula";
        public const string ColumnaDatoEmpleadoGénero = "Género";
        public const string ColumnaDatoEmpleadoCargo = "Cargo";
        public const string ColumnaDatoEmpleadoCelular = "Celular";
        public const string ColumnaDatoEmpleadoDepartamento = "Departamento";
        public const string ColumnaDatoEmpleadoCentroCostos = "Centro de Costos";
        public const string ColumnaDatoEmpleadoTipoContrato = "Tipo Contrato";
        public const string ColumnaDatoEmpleadoFechaNacimiento = "Fecha Nacimiento";
        public const string ColumnaDatoEmpleadoFechaEmpleo = "Fecha Empleo";
        public const string ColumnaDatoEmpleadoFechaSalida = "Fecha Salida";
        public const string ColumnaDatoEmpleadoDirección = "Dirección";
        public const string ColumnaDatoEmpleadoidCiudad = "idCiudad";
        public const string ColumnaDatoEmpleadoCiudad = "Ciudad";
        public const string ColumnaDatoEmpleadoTelOficina = "TelOficina";
        public const string ColumnaDatoEmpleadoCodigoEmpleado = "CodigoEmpleado";
        public const string ColumnaDatoEmpleadoCorreoPersonal = "CorreoPersonal";
        public const string ColumnaDatoEmpleadoPHOTOB = "PHOTOB";
        public const string ColumnaDatoEmpleadoNotes = "Notes";
        public const string ColumnaDatoEmpleadoTipoEmpleado = "TipoEmpleado ";
        public const string ColumnaDatoEmpleadoSupervisor1 = "Supervisor1";
        public const string ColumnaDatoEmpleadoSupervisor2 = "Supervisor2";
        public const string ColumnaDatoEmpleadoCargasFamiliares = "CargasFamiliares ";
        public const string ColumnaDatoEmpleadoEstadoCivil = "Estado Civil";
        public const string ColumnaDatoEmpleadoTiposangre = "Tiposangre";
        public const string ColumnaDatosEmpleadoLogin = "zip";

        #endregion

        #region INFO ADICIONAL EMPLEADO

        public const string SessionTblInfoAdicional = "tblInfoAdicional";
        public const string SessionTblInfoAdicional1 = "tblInfoAdicional1";
        public const string ColumnaInfoAdicUserId = "USERID";
        public const string ColumnaInfoAdicNumCA="Badgenumber";
        public const string ColumnaInfoAdicNombre="Name";
        public const string ColumnaInfoAdicSueldo="Sueldo";
        public const string ColumnaInfoAdicTipoContrato="idContrato";
        public const string ColumnaInfoAdicEstadoCivil="idEstadoCivil";
        public const string ColumnaInfoAdicCentroCostos="idCentroCostos";
        public const string ColumnaInfoAdicTipoIdentificacion="TipoDocID";
        public const string ColumnaInfoAdicTipoCuenta="TipoCuenta";
        public const string ColumnaInfoAdicCargasFamiliares="CargasFamiliares";
        public const string ColumnaInfoAdicTipoSangre="IdTipoSangre";
        public const string ColumnaInfoAdicNumeroCuenta="NumCuenta";

        #endregion

        #region DOCUMENTO IDENTIFICACION

        public const string ColumnaIdentificacionCodigo = "Codigo";
        public const string ColumnaIdentificacionNombre = "Nombre";

        #endregion

        #region HORARIOS

        public const string SesionTablaHorario = "tblHorario";
        public const string ColumnaHorarioSchclassid = "SCHCLASSID";
        public const string ColumnaHorarioNombreHorario = "SCHNAME";
        public const string ColumnaHorarioEntrada = "STARTTIME";
        public const string ColumnaHorarioSalida = "ENDTIME";
        public const string ColumnaHorarioGraciaEntrada = "LATEMINUTES";
        public const string ColumnaHorarioGraciaSalida = "EARLYMINUTES";
        public const string ColumnaHorarioInicioEntrada = "CHECKINTIME1";
        public const string ColumnaHorarioFinEntrada = "CHECKOUTTIME1";
        public const string ColumnaHorarioInicioSalida = "CHECKINTIME2";
        public const string ColumnaHorarioFinSalida = "CHECKOUTTIME2";
        public const string ColumnaHorarioDiaLaboral = "WorkDay";
        public const string ColumnaHorarioDuraciónJornada = "WorkMins";
        public const string ColumnaHorarioTipo = "Tipo";
        public const string ColumnaHorarioAutoBind = "AutoBind";

        #region TIPO

        public const string SesionTablaTipoHorario = "tblTipoHorario";
        public const string ColumnaTipoHorarioCodigo = "Codigo";
        public const string ColumnaTipoHorarioNombre = "Nombre";

        #endregion

        #region AUTOBIND

        public const string SesionTablaAutobindHorario = "tblAutobindHorario";
        public const string ColumnaAutobindCodigo = "Codigo";
        public const string ColumnaAutobindNombre = "Nombre";

        #endregion

        #endregion

        #region TURNOS

        public const string SesionTablaTurnos = "tblTurnos";
        public const string ColumnaTurnoCodigo = "Codigo";
        public const string ColumnaTurnoNombre = "Nombre";
        public const string ColumnaTurnoFreuencia = "Frecuencia";
        public const string ColumnaTurnoTiempo = "Tiempo";
        public const string ColumnaTurnoHLaborables = "HLaborables";

        #region TIEMPO

        public const string ColumnaTurnoTiempoCodigo = "Codigo";
        public const string ColumnaTurnoTiempoNombre = "Nombre";

        #endregion

        #endregion

        #region PARA SOLICITAR COMBOS

        public const string ComboTipoHorario    = "TipoHorario";
        public const string ComboAutoBindHorario = "AutoBindHorario";
        public const string ComboCiudad = "Ciudad";
        public const string ComboPermisoSolicitable = "PermisoSolicitable";
        public const string ComboTipoPermiso = "TipoPermiso";
        public const string ComboTurnoTiempo = "TurnoTiempo";
        public const string ComboReglasAsistenciaEntrada = "HEEntrada";
        public const string ComboReglasAsistenciaSalida = "HESalida";

        public const string ColumnaGrillaColumnaCodigo = "COLU_IN_CODIGO";
        public const string ColumnaGrillaColumnaNombre = "COLU_A6_NOMBRE";
        public const string ColumnaGrillaColumnaTipo = "COLU_A2_TIPO_DATO";
        public const string ColumnaGrillaColumnaVisible = "COLU_IN_VISIBLE";
        public const string ColumnaGrillaColumnaCboTabla = "COLU_A6_TABLA_COMBO";
        public const string ColumnaGrillaColumnaCboCodigo = "COLU_A6_CODIGO_COMBO";
        public const string ColumnaGrillaColumnaCboNombre = "COLU_A6_NOMBRE_COMBO";
        public const string ColumnaGrillaColumnaFormato = "COLU_A3_FORMATO";
        public const string ColumnaGrillaColumnaEtiqueta = "COLU_A0_ETIQUETA";

        #endregion

        #region DATOS REGLAS ASISTENCIA

        public const string SesionTablaReglasAsistencia = "tblReglasAsistencia";
        public const string ColumnaReglasAsistenciaCodigo = "id_RegAsistencia";
        public const string ColumnaReglasAsistenciaNombre = "Des_RegAsis";
        public const string ColumnaReglasAsistenciaJMaximaT = "JMaximaT";
        public const string ColumnaReglasAsistenciaJMinimaT = "JMinimaT";
        public const string ColumnaReglasAsistenciaIntervalo = "Intervalo";        
        public const string ColumnaReglasAsistenciaMultaIngreso = "MultaIngreso";
        public const string ColumnaReglasAsistenciaMultaSalida = "MultaSalida";

        #endregion

        #region COMBOS CALCULO HORAS EXTRAS

        public const string ColumnaCboReglasAsistenciaEntradaCodigo = "NoTIngreso";
        public const string ColumnaCboReglasAsistenciaEntradaNombre = "Nombre";

        public const string ColumnaCboReglasAsistenciaSalidaCodigo = "NoTSalida";
        public const string ColumnaCboReglasAsistenciaSalidaNombre = "Nombre";

        #endregion
    }
}