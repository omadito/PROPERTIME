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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioProperTime : IServicioProperTime
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool GuardarEmpleado(int userid, string numCA, string nombre, string sexo, string cedula,
                                    string CorreoOficina, string ciudad, string teleoficina, string correoPersonal, string titulo,
                                    DateTime dtFechaNac, DateTime dtFechaEmpleo, DateTime dtFechaSalida, string codEmp, string celular,
                                    string direccion, int tipoUsuario, DataTable dtAuditoria)
        {
            try
            {
                ProperTime.LogicaNegocio.ClsDatosEmpleado objEmpleados = new ProperTime.LogicaNegocio.ClsDatosEmpleado();
                objEmpleados.dtAuditoria = dtAuditoria;
                objEmpleados.GuardarEmpleado(userid, numCA, nombre, sexo, cedula,
                                    CorreoOficina, ciudad, teleoficina, correoPersonal, titulo,
                                    dtFechaNac, dtFechaEmpleo, dtFechaSalida, codEmp, celular,
                                    direccion, tipoUsuario);
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        //public DataTable RetornarDepartamentosArbol(int tipoAdministrador, string codAdministrador,  DataTable dtAuditoria)
        //{
        //    try
        //    {
        //        ProperTime.LogicaNegocio.ClsDatosDepartamentos objDepartamento = new ProperTime.LogicaNegocio.ClsDatosDepartamentos();
        //        objDepartamento.dtAuditoria = dtAuditoria;
        //        return objDepartamento.RetornarDepartamentosArbol(tipoAdministrador, codAdministrador);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public DataTable RetornarDepartamentosArbol(int tipoAdministrador, string codAdministrador)
        {
            try
            {
                DataTable dtAuditoria = new DataTable() { TableName = "Auditoria" };
                ProperTime.LogicaNegocio.ClsDatosDepartamentos objDepartamento = new ProperTime.LogicaNegocio.ClsDatosDepartamentos();
                objDepartamento.dtAuditoria = dtAuditoria;
                return objDepartamento.RetornarDepartamentosArbol(tipoAdministrador, codAdministrador);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public DataSet RetornaEmpleados(string condiciones, DataTable dtAuditoria)
        //{
        //    try
        //    {
        //        ProperTime.LogicaNegocio.ClsDatosEmpleado objEmpleado = new ProperTime.LogicaNegocio.ClsDatosEmpleado();
        //        objEmpleado.dtAuditoria = dtAuditoria;
        //        return objEmpleado.RetornaEmpleados(condiciones);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public DataSet RetornaEmpleados(string condiciones)
        {
            try
            {
                DataTable dtAuditoria = new DataTable() { TableName = "Auditoria" };
                ProperTime.LogicaNegocio.ClsDatosEmpleado objEmpleado = new ProperTime.LogicaNegocio.ClsDatosEmpleado();
                objEmpleado.dtAuditoria = dtAuditoria;
                return objEmpleado.RetornaEmpleados(condiciones);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarGrupoSalarial()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGrupoSalarial().RetornarGrupoSalarial();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarTipoSangre()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarTipoSangre();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarEstadoCivil()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarEstadoCivil();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarTipoCuenta()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarTipoCuenta();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarCentroCostos()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarCentroCostos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarContrato()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarContrato();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarCiudad()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarCiudad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarFotos(string condiciones)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().RetornarFotos(condiciones);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarEmpleado_v1(int intDpto)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().InsertarEmpleado_v1(intDpto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarDepartamento(int codigoDepartamento, string nombreDepartamento)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosDepartamentos().ActualizarDepartamento(codigoDepartamento, nombreDepartamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarDepartamento(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosDepartamentos().InsertarDepartamento(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarCentroCosto(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().InsertarCentroCosto(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarCiudad(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().InsertarCiudad(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarCiudad(int codigoCiudad, string nombreCiudad)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().ActualizarCiudad(codigoCiudad, nombreCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCiudad(int codigoCiudad)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().EliminarCiudad(codigoCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarCentroCostos(int codigoCentroCostos, string nombreCentroCostos, int codigoCentroCostosPadre)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().ActualizarCentroCostos(codigoCentroCostos, nombreCentroCostos, codigoCentroCostosPadre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCentroCostos(int codigoCentroCostos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().EliminarCentroCostos(codigoCentroCostos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Feriado
        public void AdministrarFeriado(DataSet dsDatosFeriado)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().AdministrarFeriado(dsDatosFeriado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarFeriado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().EliminarFeriado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarFeriado()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarFeriado();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Horario
        public void AdministrarHorario(DataSet dsDatosHorario)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().AdministrarHorario(dsDatosHorario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarHorario(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().EliminarHorario(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarHorario()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarHorario();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GrupoSalarial
        public void AdministrarGrupoSalarial(DataSet dsDatosGrupoSalarial)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGrupoSalarial().AdministrarGrupoSalarial(dsDatosGrupoSalarial);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarGrupoSalarial(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGrupoSalarial().EliminarGrupoSalarial(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarGrupoSalarial()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGrupoSalarial().ConsultarGrupoSalarial();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TipoPermiso
        public void AdministrarTipoPermiso(DataSet dsDatosTipoPermiso)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().AdministrarTipoPermiso(dsDatosTipoPermiso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarTipoPermiso(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsGeneral().EliminarTipoPermiso(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarTipoPermiso()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarTipoPermiso();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Seleccion
        public DataSet ConsultarSeleccion()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarSeleccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Clasificar
        public DataSet ConsultarClasificar()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarClasificar();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CostoComida
        public void AdministrarCostoComida(DataSet dsDatosCostoComida)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosAlmuerzo().AdministrarCostoComida(dsDatosCostoComida);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarCostoComida(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosAlmuerzo().EliminarCostoComida(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarCostoComida()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosAlmuerzo().ConsultarCostoComida();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Turno
        public void AdministrarTurno(DataSet dsDatosTurno)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosHorariosTurnos().AdministrarTurno(dsDatosTurno);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarTurno(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosHorariosTurnos().EliminarTurno(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarTurno()
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosHorariosTurnos().ConsultarTurno();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Login
        public DataSet RetornarDatosLogin(string strLogin, string strPassword)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsLogin().RetornarDatosLogin(strLogin, strPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarGrupoMenuPantalla(int intCodigoGrupo)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsLogin().RetornarGrupoMenuPantalla(intCodigoGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet RetornarMenuBotonAcceso(int intCodigoNivelAcceso)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsLogin().RetornarMenuBotonAcceso(intCodigoNivelAcceso);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region empleado mantenimiento
        public void InsertarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().InsertarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().ActualizarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarEmpleado(DataSet dsDatos)
        {
            try
            {
                new ProperTime.LogicaNegocio.ClsDatosEmpleado().EliminarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ConsultarEmpleado(DataSet dsDatos)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsDatosEmpleado().ConsultarEmpleado(dsDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Botones
        public DataSet ConsultarBoton(int intCodigoPantalla)
        {
            try
            {
                return new ProperTime.LogicaNegocio.ClsGeneral().ConsultarBoton(intCodigoPantalla);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
