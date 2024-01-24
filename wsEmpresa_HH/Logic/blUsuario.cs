using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using wsEmpresa_HH.Connection;
using wsEmpresa_HH.Data;


namespace wsEmpresa_HH.Logic
{
    public class blUsuario
    {
        /// <summary>
        /// Función para consultar base de datos y reflejar en lista
        /// </summary>
        /// <param name="pError"></param>
        /// <returns></returns>
       public List<clUsuario> ConsultarUsuarioS(ref string pError)
        {
            //Lista que devuelve el procedimiento
            List<clUsuario> listaUsuarioS = new List<clUsuario>();

            // Declarar e instanciar clase conexion para obtener cadena de conexion
            clConexion conexion = new clConexion();

            // Declarar e inicializar el objeto con el que nos conectamos a la base de datos
            // se debe enviar por parámetro la cadena de conexión en la inicialización del objeto.
            SqlConnection conn = new SqlConnection(conexion.CadenaConexion());

            //Comando para manipular la base de datos
            SqlCommand cmd = new SqlCommand();


            try
            {
                // Objeto para ejecutar el comando en la base de datos
                SqlDataReader dr; // El datareader es como crear la tabla que existe en la base de datos.
                cmd.CommandType = CommandType.StoredProcedure; // Indicamos que el comando es de tipo procedimiento almacenado.
                cmd.CommandText = "sp_consultarUsuarioS"; // Indicamos el nombre del comando.
                cmd.Connection = conn; // Indicamos el objeto conexión que va a utilizar el comando.
                conn.Open();
                dr = cmd.ExecuteReader(); // Trae toda la información del procedimiento almacenado y lo mete 

                while (dr.Read())
                {

                    clUsuario vUsuario = new clUsuario();

                    if (!string.IsNullOrEmpty(dr["id_usuario"].ToString()))
                    {
                        vUsuario.id_usuario_prop = Convert.ToInt32(dr["id_usuario"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["nombre_completo"].ToString()))
                    {
                        vUsuario.nombre_completo_prop = dr["nombre_completo"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["apellido"].ToString()))
                    {
                        vUsuario.apellido_prop = dr["apellido"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["apellido2"].ToString()))
                    {
                        vUsuario.apellido2_prop = dr["apellido2"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["nombre_usuario"].ToString()))
                    {
                        vUsuario.nombre_usuario_prop = dr["nombre_usuario"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["clave"].ToString()))
                    {
                        vUsuario.clave_prop = dr["clave"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["estado"].ToString()))
                    {
                        vUsuario.estado_prop = dr["estado"].ToString();
                    }
                    listaUsuarioS.Add(vUsuario);
                }

            }
            catch (Exception ex)
            {

                pError = "Error al ejecutar sp_consultarUsuarioS. Detalle:" + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
            return listaUsuarioS; 
        }
        /// <summary>
        /// Función logica para registrar un usuario en la base de datos ofreciendoo web service
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pError"></param>
        public void RegistrarUsuario(clUsuario pUsuario, ref string pError)

        {
            //Lista que devuelve el procedimiento
            List<clUsuario> listaUsuarioS = new List<clUsuario>();

            // Declarar e instanciar clase conexion para obtener cadena de conexion
            clConexion conexion = new clConexion();

            // Declarar e inicializar el objeto con el que nos conectamos a la base de datos
            // se debe enviar por parámetro la cadena de conexión en la inicialización del objeto.
            SqlConnection conn = new SqlConnection(conexion.CadenaConexion());

            //Comando para manipular la base de datos
            SqlCommand cmd = new SqlCommand();

            int vRespuesta = 0;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;//Declaración para el uso de un procedimiento almacenado
                cmd.CommandText = "[sp_insertarUsuario]";


                cmd.Parameters.Add("@pNombre_completo", SqlDbType.VarChar);
                cmd.Parameters["@pNombre_completo"].Value = pUsuario.nombre_completo_prop;

                cmd.Parameters.Add("@pApellido", SqlDbType.VarChar);
                cmd.Parameters["@pApellido"].Value = pUsuario.apellido_prop;

                cmd.Parameters.Add("@pApellido2", SqlDbType.VarChar);
                cmd.Parameters["@pApellido2"].Value = pUsuario.apellido2_prop;

                cmd.Parameters.Add("@pNombre_usuario", SqlDbType.VarChar);
                cmd.Parameters["@pNombre_usuario"].Value = pUsuario.nombre_usuario_prop;

                cmd.Parameters.Add("@pClave", SqlDbType.VarChar);
                cmd.Parameters["@pClave"].Value = pUsuario.clave_prop;



                cmd.Connection = conn; //se le asigna la conexion al comando 
                conn.Open();// se inicia la conexion a la BB

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                pError = "Error general al ejecutar sp_registrarUsuarioS. Detalle: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
        }
       /// <summary>
       /// Funcion logica para modificar un usuario ofreciendo un web service
       /// </summary>
       /// <param name="pUsuario"></param>
       /// <param name="pError"></param>
        public void ModificarUsuario(clUsuario pUsuario, ref string pError)
        {
   
            // Declarar e instanciar clase conexion para obtener cadena de conexion
            clConexion conexion = new clConexion();

            // Declarar e inicializar el objeto con el que nos conectamos a la base de datos
            // se debe enviar por parámetro la cadena de conexión en la inicialización del objeto.
            SqlConnection conn = new SqlConnection(conexion.CadenaConexion());

            //Comando para manipular la base de datos
            SqlCommand cmd = new SqlCommand();

            int vRespuesta = 0;

            try
            {
                //segmento para procedimiento almacenado 

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_modificarUsuario";

                cmd.Parameters.Add("@pNombre_completo", SqlDbType.VarChar);
                cmd.Parameters["@pNombre_completo"].Value = pUsuario.nombre_completo_prop;

                cmd.Parameters.Add("@pApellido", SqlDbType.VarChar);
                cmd.Parameters["@pApellido"].Value = pUsuario.apellido_prop;

                cmd.Parameters.Add("@pApellido2", SqlDbType.VarChar);
                cmd.Parameters["@pApellido2"].Value = pUsuario.apellido2_prop;

                cmd.Parameters.Add("@pNombre_usuario", SqlDbType.VarChar);
                cmd.Parameters["@pNombre_usuario"].Value = pUsuario.nombre_usuario_prop;

                cmd.Parameters.Add("@pClave", SqlDbType.VarChar);
                cmd.Parameters["@pClave"].Value = pUsuario.clave_prop;

                cmd.Parameters.Add("@pId_usuario", SqlDbType.Int);
                cmd.Parameters["@pId_usuario"].Value = pUsuario.id_usuario_prop;

                cmd.Parameters.Add("@pEstado", SqlDbType.VarChar);
                cmd.Parameters["@pEstado"].Value = pUsuario.estado_prop;

                cmd.Connection = conn; //se le asigna la conexion al comando 
                conn.Open();// se inicia la conexion a la BB


                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                pError = "Error general al ejecutar sp_modificarUsuarioS. Detalle: " + ex.Message; 
            }
            finally
            { //no ovlidar cerrar las variables de la base de datos NUNCA 
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

        }

        public void EliminarUsuario(clUsuario pUsuario,ref string pError)
        {

            // Declarar e instanciar clase conexion para obtener cadena de conexion
            clConexion conexion = new clConexion();

            // Declarar e inicializar el objeto con el que nos conectamos a la base de datos
            // se debe enviar por parámetro la cadena de conexión en la inicialización del objeto.
            SqlConnection conn = new SqlConnection(conexion.CadenaConexion());

            //Comando para manipular la base de datos
            SqlCommand cmd = new SqlCommand();

            int vRespuesta = 0;

            try
            {
                //segmentos para procedimientos almacenados
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.CommandText = "sp_eliminarUsuario";

                cmd.Parameters.Add("@pId_usuario", SqlDbType.Int);
                cmd.Parameters["@pId_usuario"].Value = pUsuario.id_usuario_prop;

                cmd.Connection = conn; //se le asigna la conexion al comando 
                conn.Open();// se inicia la conexion a la BB

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                pError = "Error general al invocar el proceso de eliminar productos. Detalle: " + ex.Message;

            }

            finally
            { //no ovlidar cerrar las variables de la base de datos NUNCA 
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
        }
    }
}