using pe.com.ciberelectrik.api.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class RolRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<Rol> findAll()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                cmd = new SqlCommand("SP_MostrarRol", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Rol
                    {
                        codigo = Convert.ToInt32(dr["codrol"]),
                        nombre = dr["nomrol"].ToString(),
                        estado = Convert.ToBoolean(dr["estrol"])
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en findAll: " + ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public List<Rol> findAllCustom()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                cmd = new SqlCommand("SP_MostrarRolTodo", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Rol
                    {
                        codigo = Convert.ToInt32(dr["codrol"]),
                        nombre = dr["nomrol"].ToString(),
                        estado = Convert.ToBoolean(dr["estrol"])
                    });
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en findAllCustom: " + ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool add(Rol obj)
        {
            try
            {
                cmd = new SqlCommand("SP_RegistrarRol", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nomrol", obj.nombre);
                cmd.Parameters.AddWithValue("@estrol", obj.estado);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en add: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool update(Rol obj)
        {
            try
            {
                cmd = new SqlCommand("SP_ActualizarRol", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codrol", obj.codigo);
                cmd.Parameters.AddWithValue("@nomrol", obj.nombre);
                cmd.Parameters.AddWithValue("@estrol", obj.estado);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand("SP_EliminarRol", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codrol", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand("SP_HabilitarRol", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codrol", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en enable: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}
