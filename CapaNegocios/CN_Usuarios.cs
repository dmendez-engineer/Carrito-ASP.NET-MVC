using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        
        public List<Usuario> Listar()
        {
            return this.objCapaDato.ListarUsuarios();
        }
        public int InsertUsuario(Usuario obj,out string Mensaje)
        {
            Mensaje = string.Empty;

            if(string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";
                obj.Clave=CN_Recursos.ConvertirSHA256(clave);
               
                
                return this.objCapaDato.InsertarUsuario(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
           
        }
        public bool EditarUsuario(Usuario obj,out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacío";
            }
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacío";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";
                obj.Clave = CN_Recursos.ConvertirSHA256(clave);


                return this.objCapaDato.EditarUsuario(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }
        public bool EliminarUsuario(int id,out string Mensaje)
        {
            Mensaje = string.Empty;
            return this.objCapaDato.Eliminar(id, out Mensaje);
        }


    }
}
