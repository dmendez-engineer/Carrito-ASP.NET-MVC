using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista=new List<Usuario>();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdUsuario,Nombres,Apellidos,Correo,Clave,Reestablecer,Activo FROM Usuario";

                    SqlCommand cmd = new SqlCommand(query,oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dataReader= cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]),
                                    Nombres = dataReader["Nombres"].ToString(),
                                    Apellidos = dataReader["Apellidos"].ToString(),
                                    Correo = dataReader["Correo"].ToString(),
                                    Clave = dataReader["Clave"].ToString(),
                                    Reestablecer = Convert.ToBoolean(dataReader["Reestablecer"]),
                                    Activo = Convert.ToBoolean(dataReader["Activo"])
                                }
                                );
                        }
                    }
                }


            }catch(Exception ex)
            {
                lista = new List<Usuario>();
            }

            return lista;
        }

        public int InsertarUsuario(Usuario obj,out string Mensaje)
        {
            int idautoGenerado = 0;
            Mensaje = string.Empty;
            
            try
            {
                using (SqlConnection oConexion= new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oConexion);
                    
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idautoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }catch(Exception er)
            {
                idautoGenerado = 0;
                Mensaje = er.Message;
            }
            return idautoGenerado;
        }

        public bool EditarUsuario(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception er)
            {
                resultado = false;
                Mensaje = er.Message;
            }
            return resultado;
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Delete top (1) from Usuario where IdUsuario=@id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }

           
            return resultado;
        }
    
    
    
    }
}
