using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Comun.Utilitario;

namespace ProperTimeToGo.App_Start
{
    public class ClsEmpleados
    {
        public DataTable RetornarEmpleado()
        {
            DataTable dtbEmpleados = new DataTable();
            DataTable dtbAuditoria = new DataTable("Auditoria");
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            int intRandom = 1;
            Random rnd = new Random();
            
            try
            {
                objServicioProperTime.Open();
                dtbEmpleados = objServicioProperTime.RetornaEmpleados("1=1").Tables[0];
                dtbEmpleados.Columns.Add(Constantes.ColumnaDatoEmpleadoPHOTOB, typeof(byte[]));
                foreach (DataRow dtr in dtbEmpleados.Rows)
                {
                    intRandom = rnd.Next(1, 5);
                    string sTemp = HttpContext.Current.Server.MapPath("/Imagenes/empleado"+intRandom+".jpg");
#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
#pragma warning disable IDE0017 // Simplify object initialization
                    FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
#pragma warning restore IDE0017 // Simplify object initialization
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
                    //img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                    fs.Position = 0;

                    int imgLength = Convert.ToInt32(fs.Length);
                    byte[] bytes = new byte[imgLength];
                    dtr[Constantes.ColumnaDatoEmpleadoPHOTOB] = bytes;
                    fs.Read(bytes, 0, imgLength);
                    fs.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                if(objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbEmpleados;
        }

        public DataTable RetornarDatosEmpleado(int intCodigoUsuario)
        {
            DataTable dtbEmpleados = new DataTable();
            DataTable dtbAuditoria = new DataTable("Auditoria");
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                dtbEmpleados = objServicioProperTime.RetornarFotos("u.UserId="+ intCodigoUsuario).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbEmpleados;
        }

        public void InsertarEmpleado(int intDpto)
        {
            DataTable dtbAuditoria = new DataTable("Auditoria");
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                objServicioProperTime.InsertarEmpleado_v1(intDpto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
        }
        public void GuardarEmpleado(int intUserId, string strNumCa, string strNombre, string strSexo, string strCedula, string strCorreoOficina, string strCiudad, string strTeleOficina,
            string strCorreoPersonal,string strTitulo,DateTime dtmFechaNacimiento, DateTime dtmFechaEmpleo, DateTime dtmFechaSalida, string strCodEmp, string strCelular, 
            string strDireccion, int  intTipoUsuario)
        {
            DataTable dtbAuditoria = new DataTable("Auditoria");
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            try
            {
                objServicioProperTime.Open();
                objServicioProperTime.GuardarEmpleado(intUserId,strNumCa,strNombre,strSexo,strCedula,strCorreoOficina,strCiudad,strTeleOficina,strCorreoPersonal,
                    strTitulo,dtmFechaNacimiento,dtmFechaEmpleo,dtmFechaSalida,strCodEmp,strCelular,strDireccion,intTipoUsuario,dtbAuditoria);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }           
        }
        
        #region MENU EMPLEADO

        public DataTable ObtenerMenuEmpleado(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add("Codigo", typeof(int));
                dtbMenu.Columns.Add("Padre", typeof(int));
                dtbMenu.Columns.Add("Nombre", typeof(string));
                dtbMenu.Columns.Add("IcoPath", typeof(string));
                dtbMenu.Columns.Add("Url", typeof(string));

                DataRow dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 1;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Agregar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 2;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Guardar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);                

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 4;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Desactivar";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }
        #endregion

        #region INFORMACIÓN ADICIONAL

        public DataTable RetornarInformacionAdicional()
        {
            DataTable dtbInfoAdic = new DataTable();
            try
            {                
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicUserId, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicNumCA, typeof(string));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicNombre, typeof(string));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicSueldo, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicTipoContrato, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicEstadoCivil, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicCentroCostos, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicTipoIdentificacion, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicTipoCuenta, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicCargasFamiliares, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicTipoSangre, typeof(int));
                dtbInfoAdic.Columns.Add(Constantes.ColumnaInfoAdicNumeroCuenta, typeof(string));

                dtbInfoAdic.PrimaryKey = new DataColumn[] { dtbInfoAdic.Columns[Constantes.ColumnaInfoAdicUserId] };

                DataRow dtrFila = dtbInfoAdic.NewRow();
                dtrFila[Constantes.ColumnaInfoAdicUserId]= 3;
                dtrFila[Constantes.ColumnaInfoAdicNumCA] = 3;
                dtrFila[Constantes.ColumnaInfoAdicNombre] = "ANITA CARRASCO";
                dtrFila[Constantes.ColumnaInfoAdicSueldo] =1;
                dtrFila[Constantes.ColumnaInfoAdicTipoContrato] =1;
                dtrFila[Constantes.ColumnaInfoAdicEstadoCivil] =1;
                dtrFila[Constantes.ColumnaInfoAdicCentroCostos] =1;
                dtrFila[Constantes.ColumnaInfoAdicTipoIdentificacion] =1;
                dtrFila[Constantes.ColumnaInfoAdicTipoCuenta] =1;
                dtrFila[Constantes.ColumnaInfoAdicCargasFamiliares] =2;
                dtrFila[Constantes.ColumnaInfoAdicTipoSangre] =1;
                dtrFila[Constantes.ColumnaInfoAdicNumeroCuenta] ="1231231231231";
                dtbInfoAdic.Rows.Add(dtrFila);

                dtrFila = dtbInfoAdic.NewRow();
                dtrFila[Constantes.ColumnaInfoAdicUserId] = 5;
                dtrFila[Constantes.ColumnaInfoAdicNumCA] = 3;
                dtrFila[Constantes.ColumnaInfoAdicNombre] = "ANITA SOTLIN";
                dtrFila[Constantes.ColumnaInfoAdicSueldo] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoContrato] = 1;
                dtrFila[Constantes.ColumnaInfoAdicEstadoCivil] = 1;
                dtrFila[Constantes.ColumnaInfoAdicCentroCostos] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoIdentificacion] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoCuenta] = 1;
                dtrFila[Constantes.ColumnaInfoAdicCargasFamiliares] = 2;
                dtrFila[Constantes.ColumnaInfoAdicTipoSangre] = 1;
                dtrFila[Constantes.ColumnaInfoAdicNumeroCuenta] = "1231231231231";
                dtbInfoAdic.Rows.Add(dtrFila);

                dtrFila = dtbInfoAdic.NewRow();
                dtrFila[Constantes.ColumnaInfoAdicUserId] = 4;
                dtrFila[Constantes.ColumnaInfoAdicNumCA] = 3;
                dtrFila[Constantes.ColumnaInfoAdicNombre] = "ANITA GUERFANITA";
                dtrFila[Constantes.ColumnaInfoAdicSueldo] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoContrato] = 1;
                dtrFila[Constantes.ColumnaInfoAdicEstadoCivil] = 1;
                dtrFila[Constantes.ColumnaInfoAdicCentroCostos] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoIdentificacion] = 1;
                dtrFila[Constantes.ColumnaInfoAdicTipoCuenta] = 1;
                dtrFila[Constantes.ColumnaInfoAdicCargasFamiliares] = 2;
                dtrFila[Constantes.ColumnaInfoAdicTipoSangre] = 1;
                dtrFila[Constantes.ColumnaInfoAdicNumeroCuenta] = "1231231231231";
                dtbInfoAdic.Rows.Add(dtrFila);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbInfoAdic;
        }

        #endregion

        #region EMPLEADOS ADMINISTRADORES

        public DataTable RetornarEmpleadoAdministrador()
        {
            DataTable dtbEmpleados = new DataTable();
            DataTable dtbAuditoria = new DataTable("Auditoria");
            ServicioProperTime.ServicioProperTimeClient objServicioProperTime;
            objServicioProperTime = new ServicioProperTime.ServicioProperTimeClient();
            int intRandom = 1;
            Random rnd = new Random();

            try
            {
                objServicioProperTime.Open();
                dtbEmpleados = objServicioProperTime.RetornaEmpleados("1=1").Tables[0];
                dtbEmpleados.Columns.Add(Constantes.ColumnaDatoEmpleadoPHOTOB, typeof(byte[]));
                foreach (DataRow dtr in dtbEmpleados.Rows)
                {                   
                    if(Convert.ToInt32(dtr[Constantes.ColumnaEmpleadoOTAdmin]) == 0)
                    {
                        dtr.Delete();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objServicioProperTime != null && objServicioProperTime.State == System.ServiceModel.CommunicationState.Opened)
                {
                    objServicioProperTime.Close();
                }
            }
            return dtbEmpleados;
        }

        public DataTable RetornarColumnasEmpleadoAdmin()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaNombre, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaTipo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaVisible, typeof(int));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboTabla, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaGrillaColumnaCboNombre, typeof(string));

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 1;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaEmpleadoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 0;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 2;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaEmpleadoNumCA;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "Int32";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 3;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaEmpleadoNombre;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 4;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaDatosEmpleadoLogin;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "String";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = "";
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = "";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaGrillaColumnaCodigo] = 5;
                dtr[Constantes.ColumnaGrillaColumnaNombre] = Constantes.ColumnaTipoEmpleadoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaTipo] = "ComboBox";
                dtr[Constantes.ColumnaGrillaColumnaVisible] = 1;
                dtr[Constantes.ColumnaGrillaColumnaCboTabla] = Constantes.CboTipoEmpleado;
                dtr[Constantes.ColumnaGrillaColumnaCboCodigo] = Constantes.ColumnaTipoEmpleadoCodigo;
                dtr[Constantes.ColumnaGrillaColumnaCboNombre] = Constantes.ColumnaTipoEmpleadoNombre;
                dtbTmp.Rows.Add(dtr);
                                
            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        public DataTable RetornarTipoEmpleadoAdmin()
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                dtbTmp.Columns.Add(Constantes.ColumnaTipoEmpleadoCodigo, typeof(string));
                dtbTmp.Columns.Add(Constantes.ColumnaTipoEmpleadoNombre, typeof(string));                

                dtbTmp.PrimaryKey = new DataColumn[] { dtbTmp.Columns[Constantes.ColumnaGrillaColumnaCodigo] };

                DataRow dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoEmpleadoCodigo] = 1;
                dtr[Constantes.ColumnaTipoEmpleadoNombre] = "Super Administrador";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoEmpleadoCodigo] = 2;
                dtr[Constantes.ColumnaTipoEmpleadoNombre] = "Administrador Departamento";
                dtbTmp.Rows.Add(dtr);

                dtr = dtbTmp.NewRow();
                dtr[Constantes.ColumnaTipoEmpleadoCodigo] = 3;
                dtr[Constantes.ColumnaTipoEmpleadoNombre] = "Administrador Local";
                dtbTmp.Rows.Add(dtr);                              

            }
            catch (Exception)
            {
                throw;
            }
            return dtbTmp;
        }

        #endregion
    }
}