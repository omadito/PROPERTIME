using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProperTime.WcfProperTime
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioProperTime" in both code and config file together.
    [ServiceContract]
    public interface IServicioProperTime
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        #region Empleado
        [OperationContract]
        bool GuardarEmpleado(int userid, string numCA, string nombre, string sexo, string cedula,
                                    string CorreoOficina, string ciudad, string teleoficina, string correoPersonal, string titulo,
                                    DateTime dtFechaNac, DateTime dtFechaEmpleo, DateTime dtFechaSalida, string codEmp, string celular,
                                    string direccion, int tipoUsuario, DataTable dtAuditoria);

        //[OperationContract]
        //DataSet RetornaEmpleados(string condiciones, DataTable dtAuditoria);

        [OperationContract]
        DataSet RetornaEmpleados(string condiciones);
        #endregion
        #region Departamento
        //[OperationContract]
        //DataTable RetornarDepartamentosArbol(int tipoAdministrador, string codAdministrador, DataTable dtAuditoria);

        [OperationContract]
        DataTable RetornarDepartamentosArbol(int tipoAdministrador, string codAdministrador);
        #endregion

        #region Información adicional empleado
        [OperationContract]
        DataSet RetornarGrupoSalarial();

        [OperationContract]
        DataSet RetornarTipoSangre();

        [OperationContract]
        DataSet RetornarEstadoCivil();

        [OperationContract]
        DataSet RetornarTipoCuenta();

        [OperationContract]
        DataSet RetornarCentroCostos();

        [OperationContract]
        DataSet RetornarContrato();

        [OperationContract]
        DataSet RetornarCiudad();

        [OperationContract]
        DataSet RetornarFotos(string condiciones);

        [OperationContract]
        void InsertarEmpleado_v1(int intDpto);

        [OperationContract]
        void ActualizarDepartamento(int codigoDepartamento, string nombreDepartamento);

        [OperationContract]
        void InsertarDepartamento(DataSet dsDatos);

        [OperationContract]
        void InsertarCentroCosto(DataSet dsDatos);

        [OperationContract]
        void InsertarCiudad(DataSet dsDatos);

        [OperationContract]
        void ActualizarCiudad(int codigoCiudad, string nombreCiudad);

        [OperationContract]
        void EliminarCiudad(int codigoCiudad);

        [OperationContract]
        void ActualizarCentroCostos(int codigoCentroCostos, string nombreCentroCostos, int codigoCentroCostosPadre);

        [OperationContract]
        void EliminarCentroCostos(int codigoCentroCostos);

        #endregion

        #region Feriado

        [OperationContract]
        void AdministrarFeriado(DataSet dsDatosFeriado);

        [OperationContract]
        void EliminarFeriado(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarFeriado();

        #endregion

        #region Horario

        [OperationContract]
        void AdministrarHorario(DataSet dsDatosHorario);

        [OperationContract]
        void EliminarHorario(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarHorario();

        #endregion

        #region GrupoSalarial

        [OperationContract]
        void AdministrarGrupoSalarial(DataSet dsDatosGrupoSalarial);

        [OperationContract]
        void EliminarGrupoSalarial(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarGrupoSalarial();

        #endregion

        #region TipoPermiso

        [OperationContract]
        void AdministrarTipoPermiso(DataSet dsDatosTipoPermiso);

        [OperationContract]
        void EliminarTipoPermiso(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarTipoPermiso();

        #endregion

        #region Seleccion
        [OperationContract]
        DataSet ConsultarSeleccion();
        #endregion

        #region Clasificar
        [OperationContract]
        DataSet ConsultarClasificar();
        #endregion

        #region Costo Comida

        [OperationContract]
        void AdministrarCostoComida(DataSet dsDatosCostoComida);

        [OperationContract]
        void EliminarCostoComida(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarCostoComida();
        #endregion  

        #region Turno

        [OperationContract]
        void AdministrarTurno(DataSet dsDatos);

        [OperationContract]
        void EliminarTurno(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarTurno();

        #endregion

        #region Login
        [OperationContract]
        DataSet RetornarDatosLogin(string strLogin, string strPassword);

        [OperationContract]
        DataSet RetornarGrupoMenuPantalla(int intCodigoGrupo);

        [OperationContract]
        DataSet RetornarMenuBotonAcceso(int intCodigoNivelAcceso);

        #endregion

        #region empleado mantenimiento
        [OperationContract]
        void InsertarEmpleado(DataSet dsDatos);

        [OperationContract]
        void ActualizarEmpleado(DataSet dsDatos);

        [OperationContract]
        void EliminarEmpleado(DataSet dsDatos);

        [OperationContract]
        DataSet ConsultarEmpleado(DataSet dsDatos);

        #endregion

        #region Botones
        [OperationContract]
        DataSet ConsultarBoton(int intCodigoPantalla);
        #endregion
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }


    }
}
