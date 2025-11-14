using pe.com.ciberelectrik.api.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class TicketPedidoRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<TicketPedido> findAll()
        {
            List<TicketPedido> lista = new List<TicketPedido>();
            try
            {
                cmd = new SqlCommand("SP_MostrarTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TicketPedido obj = new TicketPedido
                    {
                        nroped = Convert.ToInt32(dr["nroped"]),
                        fechaPedido = Convert.ToDateTime(dr["fecped"]),
                        codemp = Convert.ToInt32(dr["codemp"]),
                        codcli = Convert.ToInt32(dr["codcli"]),
                        estado = Convert.ToBoolean(dr["estped"])
                    };
                    lista.Add(obj);
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

        public List<TicketPedido> findAllCustom()
        {
            List<TicketPedido> lista = new List<TicketPedido>();
            try
            {
                cmd = new SqlCommand("SP_MostrarTicketPedidoTodo", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TicketPedido obj = new TicketPedido
                    {
                        nroped = Convert.ToInt32(dr["nroped"]),
                        fechaPedido = Convert.ToDateTime(dr["fecped"]),
                        codemp = Convert.ToInt32(dr["codemp"]),
                        codcli = Convert.ToInt32(dr["codcli"]),
                        estado = Convert.ToBoolean(dr["estped"])
                    };
                    lista.Add(obj);
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

        public bool add(TicketPedido obj)
        {
            try
            {
                cmd = new SqlCommand("SP_RegistrarTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@fecha", obj.fechaPedido);
                cmd.Parameters.AddWithValue("@codemp", obj.codemp);
                cmd.Parameters.AddWithValue("@codcli", obj.codcli);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
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

        public bool update(TicketPedido obj)
        {
            try
            {
                cmd = new SqlCommand("SP_ActualizarTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codigo", obj.nroped);
                cmd.Parameters.AddWithValue("@fecha", obj.fechaPedido);
                cmd.Parameters.AddWithValue("@codemp", obj.codemp);
                cmd.Parameters.AddWithValue("@codcli", obj.codcli);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
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
                cmd = new SqlCommand("SP_EliminarTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codigo", id);
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
                cmd = new SqlCommand("SP_HabilitarTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@codigo", id);
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
