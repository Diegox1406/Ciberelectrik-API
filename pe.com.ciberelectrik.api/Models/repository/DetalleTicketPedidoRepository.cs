using pe.com.ciberelectrik.api.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class DetalleTicketPedidoRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<DetalleTicketPedido> findAll()
        {
            List<DetalleTicketPedido> lista = new List<DetalleTicketPedido>();
            try
            {
                cmd = new SqlCommand("SP_MostrarDetalleTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetalleTicketPedido obj = new DetalleTicketPedido
                    {
                        numeroDetalle = Convert.ToInt32(dr["nrodet"]),
                        cantidad = Convert.ToInt32(dr["canent"]),
                        precio = Convert.ToDecimal(dr["preent"]),
                        nroped = Convert.ToInt32(dr["nroped"]),
                        codpro = Convert.ToInt32(dr["codpro"])
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

        public bool add(DetalleTicketPedido obj)
        {
            try
            {
                cmd = new SqlCommand("SP_RegistrarDetalleTicketPedido", objconexion.Conectar())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@canent", obj.cantidad);
                cmd.Parameters.AddWithValue("@preent", obj.precio);
                cmd.Parameters.AddWithValue("@nroped", obj.nroped);
                cmd.Parameters.AddWithValue("@codpro", obj.codpro);

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
    }
}
