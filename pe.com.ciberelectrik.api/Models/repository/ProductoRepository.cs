using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using pe.com.ciberelectrik.api.Models.db;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class ProductoRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<Producto> findAll()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProducto";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto obj = new Producto();
                    obj.codigo = Convert.ToInt32(dr["codpro"]);
                    obj.nombre = dr["nompro"].ToString();
                    obj.descripcion = dr["despro"].ToString();
                    obj.precio = Convert.ToDecimal(dr["prepro"]);
                    obj.cantidad = Convert.ToInt32(dr["canpro"]);
                    obj.fechaingreso = Convert.ToDateTime(dr["fecing"]);
                    obj.estado = Convert.ToBoolean(dr["estpro"]);
                    obj.codcat = Convert.ToInt32(dr["codcat"]);
                    obj.codmar = Convert.ToInt32(dr["codmar"]);
                    productos.Add(obj);
                }
                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public List<Producto> findAllCustom()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarProductoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto obj = new Producto();
                    obj.codigo = Convert.ToInt32(dr["codpro"]);
                    obj.nombre = dr["nompro"].ToString();
                    obj.descripcion = dr["despro"].ToString();
                    obj.precio = Convert.ToDecimal(dr["prepro"]);
                    obj.cantidad = Convert.ToInt32(dr["canpro"]);
                    obj.fechaingreso = Convert.ToDateTime(dr["fecing"]);
                    obj.estado = Convert.ToBoolean(dr["estpro"]);
                    obj.codcat = Convert.ToInt32(dr["codcat"]);
                    obj.codmar = Convert.ToInt32(dr["codmar"]);
                    productos.Add(obj);
                }
                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool add(Producto p)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarProducto";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@precio", p.precio);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@fecha", p.fechaingreso); // parámetro correcto
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@codcat", p.codcat);
                cmd.Parameters.AddWithValue("@codmar", p.codmar);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool update(Producto p)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarProducto";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", p.codigo);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@precio", p.precio);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@fecha", p.fechaingreso); // parámetro correcto
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@codcat", p.codcat);
                cmd.Parameters.AddWithValue("@codmar", p.codmar);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
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
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarProducto";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
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
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarProducto";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}
