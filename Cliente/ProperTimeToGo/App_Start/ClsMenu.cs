using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProperTimeToGo.App_Start
{
    public class ClsMenu
    {

        #region CREAR MENU SUPERIOR

        public void CrearMenuSuperior(DevExpress.Web.ASPxMenu menu, DataTable dtbMenu, string strColumnaCodigo, string strColumnaPadre, string strColumnaEtiqueta)
        {
            try
            {
                // Build Menu Items
                Dictionary<string, DevExpress.Web.MenuItem> menuItems =
                    new Dictionary<string, DevExpress.Web.MenuItem>();

                foreach (DataRow dtr in dtbMenu.Rows)
                {
                    DevExpress.Web.MenuItem item = CreateMenuItem(dtr, strColumnaEtiqueta);
                    string itemID = dtr[strColumnaCodigo].ToString();
                    string parentID = dtr[strColumnaPadre].ToString();

                    if (menuItems.ContainsKey(parentID))
                        menuItems[parentID].Items.Add(item);
                    else
                    {
                        if (parentID == "0") // It's Root Item
                            menu.Items.Add(item);
                    }
                    menuItems.Add(itemID, item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DevExpress.Web.MenuItem CreateMenuItem(DataRow row, string strColumnaEtiqueta)
        {
            DevExpress.Web.MenuItem ret = new DevExpress.Web.MenuItem();
            ret.Name = "mnu" + row[strColumnaEtiqueta].ToString();
            ret.Text = row[strColumnaEtiqueta].ToString();
            return ret;
        }

        #endregion

        public DataTable ObtenerMenu(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add("Codigo", typeof(int));
                dtbMenu.Columns.Add("Padre", typeof(int));
                dtbMenu.Columns.Add("Nombre", typeof(string));
                dtbMenu.Columns.Add("IcoPath", typeof(string));
                dtbMenu.Columns.Add("Url", typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns["Codigo"] };

                DataRow dtr = dtbMenu.NewRow();
                dtr["Codigo"] =1;
                dtr["Padre"] =0;
                dtr["Nombre"] ="Empleados";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 2;
                dtr["Padre"] = 1;
                dtr["Nombre"] = "Nuevo Empleado";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/datosempleado";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 3;
                dtr["Padre"] = 1;
                dtr["Nombre"] = "Lista Emplados";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/empleados";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 4;
                dtr["Padre"] = 1;
                dtr["Nombre"] = "Información Adicional";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/informacionadicional";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 5;
                dtr["Padre"] = 1;
                dtr["Nombre"] = "Asignar Supervisores";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/asignarsupervisores";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 6;
                dtr["Padre"] = 1;
                dtr["Nombre"] = "Corte Vacaciones";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/cortevacaciones";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 7;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Datos Empresa";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 8;
                dtr["Padre"] = 7;
                dtr["Nombre"] = "Departamentos";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/departamento";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 9;
                dtr["Padre"] = 7;
                dtr["Nombre"] = "Centro de Costos";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/centrocostos";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 10;
                dtr["Padre"] = 7;
                dtr["Nombre"] = "Ciudades";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/ciudades";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 11;
                dtr["Padre"] = 7;
                dtr["Nombre"] = "Administración";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 12;
                dtr["Padre"] = 11;
                dtr["Nombre"] = "Configuración";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);


                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 13;
                dtr["Padre"] = 11;
                dtr["Nombre"] = "Cambiar Clave Admin.";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 14;
                dtr["Padre"] = 11;
                dtr["Nombre"] = "Cambiar Clave Usuario";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 15;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Horarios/Asistencia";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 16;
                dtr["Padre"] = 15;
                dtr["Nombre"] = "Horarios";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/horarios";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 17;
                dtr["Padre"] = 15;
                dtr["Nombre"] = "Turnos";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/turnos";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 18;
                dtr["Padre"] = 15;
                dtr["Nombre"] = "Asignar Horarios a Empleados";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 19;
                dtr["Padre"] = 15;
                dtr["Nombre"] = "Parámetros Asistencia";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 20;
                dtr["Padre"] = 0;
                dtr["Nombre"] = "Configuraciones";
                dtr["IcoPath"] = "";
                dtr["Url"] = "";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 21;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Feriados";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/feriado";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 22;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Tipos Permiso";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/tipospermisos";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 23;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Redondeo Horas Extra";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 24;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Grupos Salariales";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/grupossalariales";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 25;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Tiempo Almuerzo";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 26;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Número Comidas";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/costocomida";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr["Codigo"] = 27;
                dtr["Padre"] = 20;
                dtr["Nombre"] = "Correos automáticos";
                dtr["IcoPath"] = "";
                dtr["Url"] = "/";
                dtbMenu.Rows.Add(dtr);

                //dtr = dtbMenu.NewRow();
                //dtr["Codigo"] = 28;
                //dtr["Padre"] = 20;
                //dtr["Nombre"] = "Manejo Sistema";
                //dtr["IcoPath"] = "";
                //dtr["Url"] = "/";
                //dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        #region MENU SUPERIOR

        public DataTable RetornarMenuSuperior(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));
                
                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Nuevo";               
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Guardar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 3;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Editar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 4;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Eliminar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 5;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Cancelar";
                dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        public DataTable RetornarMenuSuperior2(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Nuevo";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Guardar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 3;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Asignar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 4;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Eliminar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 5;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Cancelar";
                dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        //Confguracion TiempoAlmuerzo y RedondeoHorasExtras
        public DataTable RetornarMenuSuperior3(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Guardar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Cerrar";
                dtbMenu.Rows.Add(dtr);

            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        public DataTable RetornarMenuSuperior4(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Test Envio 1 Correo gmail";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Activar Pruebas de Timer";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 3;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Activar Correos Diarios";
                dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        //administracion usuarios aadministradores
        public DataTable RetornarMenuSuperior5(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Nuevo";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Guardar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 3;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Editar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 4;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Eliminar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 5;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Modificar Contraseña";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 6;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Cancelar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 7;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Privilegios";
                dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        public DataTable RetornarMenuSuperior6(int intCodigoUsuario, int intCodigoAcceso)
        {
            DataTable dtbMenu = new DataTable();
            try
            {
                dtbMenu.Columns.Add(Constantes.ColumnaMenuCodigo, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuPadre, typeof(int));
                dtbMenu.Columns.Add(Constantes.ColumnaMenuNombre, typeof(string));

                dtbMenu.PrimaryKey = new DataColumn[] { dtbMenu.Columns[Constantes.ColumnaMenuCodigo] };

                DataRow dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Configuraciones";
                dtbMenu.Rows.Add(dtr);

                dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Configuraciones";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 1;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Nuevo";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 2;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Guardar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 3;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Editar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 4;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Eliminar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 5;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Modificar Contraseña";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 6;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Cancelar";
                dtbMenu.Rows.Add(dtr);

                dtr = dtbMenu.NewRow();
                dtr[Constantes.ColumnaMenuCodigo] = 7;
                dtr[Constantes.ColumnaMenuPadre] = 0;
                dtr[Constantes.ColumnaMenuNombre] = "Privilegios";
                dtbMenu.Rows.Add(dtr);
            }
            catch (Exception)
            {
                throw;
            }
            return dtbMenu;
        }

        #endregion
    }
}