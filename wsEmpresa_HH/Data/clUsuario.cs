using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsEmpresa_HH.Data
{
    public class clUsuario
    {
        private int id_usuario;

        public int id_usuario_prop
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        private string nombre_completo;

        public string nombre_completo_prop
        {
            get { return nombre_completo; }
            set { nombre_completo = value; }
        }

        private string apellido;

        public string apellido_prop
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string apellido2;

        public string apellido2_prop
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }

        private string nombre_usuario;

        public string nombre_usuario_prop
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        private string clave;

        public string clave_prop
        {
            get { return clave; }
            set { clave = value; }
        }

        private string estado;

        public string estado_prop
        {
            get { return estado; }
            set { estado = value; }
        }



    }
}