using pe.com.ciberelectrik.api.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class ClienteRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;

        // Listar activos
        public List<Cliente> findAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                cmd = new SqlCommand("SP_MostrarCliente", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente
                    {
                        codigo = Convert.ToInt32(dr["codcli"]),
                        nombre = dr["nomcli"].ToString(),
                        apellidoPaterno = dr["apepcli"].ToString(),
                        apellidoMaterno = dr["apemcli"].ToString(),
                        documento = dr["doccli"].ToString(),
                        direccion = dr["dircli"].ToString(),
                        telefono = dr["telcli"].ToString(),
                        celular = dr["celcli"].ToString(),
                        correo = dr["corcli"].ToString(),
                        estado = Convert.ToBoolean(dr["estcli"]),
                        coddis = Convert.ToInt32(dr["coddis"]),
                        codtipd = Convert.ToInt32(dr["codtipd"])
                    };
                    clientes.Add(c);
                }
                return clientes;
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

        // Listar todos
        public List<Cliente> findAllCustom()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                cmd = new SqlCommand("SP_MostrarClienteTodo", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente
                    {
                        codigo = Convert.ToInt32(dr["codcli"]),
                        nombre = dr["nomcli"].ToString(),
                        apellidoPaterno = dr["apepcli"].ToString(),
                        apellidoMaterno = dr["apemcli"].ToString(),
                        documento = dr["doccli"].ToString(),
                        direccion = dr["dircli"].ToString(),
                        telefono = dr["telcli"].ToString(),
                        celular = dr["celcli"].ToString(),
                        correo = dr["corcli"].ToString(),
                        estado = Convert.ToBoolean(dr["estcli"]),
                        coddis = Convert.ToInt32(dr["coddis"]),
                        codtipd = Convert.ToInt32(dr["codtipd"])
                    };
                    clientes.Add(c);
                }
                return clientes;
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

        // Agregar
        public bool add(Cliente obj)
        {
            try
            {
                cmd = new SqlCommand("SP_RegistrarCliente", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@nomcli", obj.nombre);
                cmd.Parameters.AddWithValue("@apepcli", obj.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemcli", obj.apellidoMaterno);
                cmd.Parameters.AddWithValue("@doccli", obj.documento);
                cmd.Parameters.AddWithValue("@dircli", obj.direccion);
                cmd.Parameters.AddWithValue("@telcli", obj.telefono);
                cmd.Parameters.AddWithValue("@celcli", obj.celular);
                cmd.Parameters.AddWithValue("@corcli", obj.correo);
                cmd.Parameters.AddWithValue("@estcli", obj.estado);
                cmd.Parameters.AddWithValue("@coddis", obj.coddis);
                cmd.Parameters.AddWithValue("@codtipd", obj.codtipd);

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

        // Actualizar
        public bool update(Cliente obj)
        {
            try
            {
                cmd = new SqlCommand("SP_ActualizarCliente", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@codcli", obj.codigo);
                cmd.Parameters.AddWithValue("@nomcli", obj.nombre);
                cmd.Parameters.AddWithValue("@apepcli", obj.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemcli", obj.apellidoMaterno);
                cmd.Parameters.AddWithValue("@doccli", obj.documento);
                cmd.Parameters.AddWithValue("@dircli", obj.direccion);
                cmd.Parameters.AddWithValue("@telcli", obj.telefono);
                cmd.Parameters.AddWithValue("@celcli", obj.celular);
                cmd.Parameters.AddWithValue("@corcli", obj.correo);
                cmd.Parameters.AddWithValue("@estcli", obj.estado);
                cmd.Parameters.AddWithValue("@coddis", obj.coddis);
                cmd.Parameters.AddWithValue("@codtipd", obj.codtipd);

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

        // Eliminar (deshabilitar)
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand("SP_EliminarCliente", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@codcli", id);
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

        // Habilitar
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand("SP_HabilitarCliente", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@codcli", id);
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
