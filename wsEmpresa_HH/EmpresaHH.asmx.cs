using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using wsEmpresa_HH.Data;
using wsEmpresa_HH.Logic;

namespace wsEmpresa_HH
{
    /// <summary>
    /// Summary description for EmpresaHH
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmpresaHH : System.Web.Services.WebService
    {

        /*   [WebMethod]
           public string HelloWorld()
           {
               return "Hello World";
           } */


        /// <summary>
        /// Función para consultar Usuarios 
        /// </summary>
        /// <returns>Lista de usuarios ACTIVOS en la base de datos</returns>
        [WebMethod]
        public List<clUsuario>ConsultarUsuario()
        {
            blUsuario blp = new blUsuario();
            String vError = string.Empty;

            return blp.ConsultarUsuarioS(ref vError);
        }
        /// <summary>
        /// Funciòn para registrar un usuario
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pApellido"></param>
        /// <param name="pApellido2"></param>
        /// <param name="pNombre_usuario"></param>
        /// <param name="pClave"></param>
        /// <returns>UsuarioRegistrado¿¿¿</returns>
        [WebMethod]
        public string RegistrarUsuario(string pNombre, string pApellido,string pApellido2,
                                       string pNombre_usuario, string pClave)
        {
            clUsuario usuarioNuevo = new clUsuario();
            blUsuario blp = new blUsuario();
            string vError = null;
            string vRespuesta = null;

            usuarioNuevo.nombre_completo_prop = pNombre;
            usuarioNuevo.apellido_prop = pApellido;
            usuarioNuevo.apellido2_prop = pApellido2;
            usuarioNuevo.nombre_usuario_prop = pNombre_usuario;
            usuarioNuevo.clave_prop = pClave;

            blp.RegistrarUsuario(usuarioNuevo, ref vError);

            if (vError == null || vError == string.Empty)
            {
                vRespuesta = "Usuario " + pNombre + "almacenado correctamente ";
            }
            else
            {
                vRespuesta = "Error no se pudo registrar el usuario" + pNombre;
            }
            return vRespuesta;
        }
        /// <summary>
        /// Funcion para ejecutar servicio de web service 
        /// </summary>
        /// <param name="pId_usuario"></param>
        /// <param name="pNombre"></param>
        /// <param name="pApellido"></param>
        /// <param name="pApellido2"></param>
        /// <param name="pNombre_usuario"></param>
        /// <param name="pClave"></param>
        /// <param name="pEstado"></param>
        /// <returns>modificacion de ususario¿¿¿</returns>
        [WebMethod]
        public string ModificarUsuario(int pId_usuario,string pNombre, string pApellido, string pApellido2,
                                       string pNombre_usuario, string pClave, string pEstado)
        {

            clUsuario usuarioModificar = new clUsuario();
            blUsuario blu = new blUsuario();
            string vError = null;
            string vRespuesta = null;

            usuarioModificar.id_usuario_prop = pId_usuario;
            usuarioModificar.nombre_completo_prop = pNombre;
            usuarioModificar.apellido_prop = pApellido;
            usuarioModificar.apellido2_prop = pApellido2;
            usuarioModificar.nombre_usuario_prop = pNombre_usuario;
            usuarioModificar.clave_prop = pClave;
            usuarioModificar.estado_prop = pEstado;

            blu.ModificarUsuario(usuarioModificar, ref vError);

            if (vError == null || vError == string.Empty)
            {
                vRespuesta = "Usuario " + pNombre + " modificado correctamente ";
            }
            else
            {
                vRespuesta = "Error no se pudo modificar el producto " + pId_usuario;
            }
            return vRespuesta;

        }
        /// <summary>
        /// Funcion de web service para eliminado LOGICO 
        /// </summary>
        /// <param name="pId_usuario"></param>
        /// <returns></returns>
        [WebMethod]
         public string EliminarUsuario(int pId_usuario)
         {
            clUsuario usuarioEliminar = new clUsuario();
            blUsuario blu = new blUsuario();
            string vError = null;
            string vRespuesta = null;

            usuarioEliminar.id_usuario_prop = pId_usuario;

            blu.EliminarUsuario(usuarioEliminar, ref vError);

            if (vError == null || vError == string.Empty)
            {
                vRespuesta = "Usuario " + pId_usuario + " eliminado correctamente ";
            }
            else
            {
                vRespuesta = "Error no se pudo eliminar el producto " + pId_usuario;
            }
            return vRespuesta;

        } 
        ///Segmento para los servicios web para el modulo clientes
    }
}
