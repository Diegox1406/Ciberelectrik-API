using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using pe.com.ciberelectrik.api.Models.db;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class DistritoRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<Distrito> findAll()
        {
            List<Distrito> distritos = new List<Distrito>();
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_MostrarDistrito",
                    Connection = objconexion.Conectar()
                };

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Distrito obj = new Distrito
                    {
                        codigo = Convert.ToInt32(dr["coddis"]),
                        nombre = dr["nomdis"].ToString(),
                        estado = Convert.ToBoolean(dr["estdis"])
                    };
                    distritos.Add(obj);
                }
                return distritos;
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

        public List<Distrito> findAllCustom()
        {
            List<Distrito> distritos = new List<Distrito>();
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_MostrarDistritoTodo",
                    Connection = objconexion.Conectar()
                };

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Distrito obj = new Distrito
                    {
                        codigo = Convert.ToInt32(dr["coddis"]),
                        nombre = dr["nomdis"].ToString(),
                        estado = Convert.ToBoolean(dr["estdis"])
                    };
                    distritos.Add(obj);
                }
                return distritos;
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

        public bool add(Distrito d)
        {
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_RegistrarDistrito",
                    Connection = objconexion.Conectar()
                };

                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en add: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool update(Distrito d)
        {
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_ActualizarDistrito",
                    Connection = objconexion.Conectar()
                };

                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en update: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool delete(int codigo)
        {
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_EliminarDistrito",
                    Connection = objconexion.Conectar()
                };

                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en delete: " + ex.Message);
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool enable(int codigo)
        {
            try
            {
                cmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SP_HabilitarDistrito",
                    Connection = objconexion.Conectar()
                };

                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
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
