using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using pe.com.ciberelectrik.api.Models.db;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class MarcaRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<Marca> findAll()
        {
            List<Marca> marcas = new List<Marca>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarca";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Marca obj = new Marca();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
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

        public List<Marca> findAllCustom()
        {
            List<Marca> marcas = new List<Marca>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarcaTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Marca obj = new Marca();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
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

        public bool add(Marca m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarMarca";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@nombre", m.nombre);
                cmd.Parameters.AddWithValue("@estado", m.estado);
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public bool update(Marca m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarMarca";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", m.codigo);
                cmd.Parameters.AddWithValue("@nombre", m.nombre);
                cmd.Parameters.AddWithValue("@estado", m.estado);
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                cmd.CommandText = "SP_EliminarMarca";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                cmd.CommandText = "SP_HabilitarMarca";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", codigo);
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public int setCode()
        {
            int marcas = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoMarca";
                cmd.Connection = objconexion.Conectar();
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    marcas = (int)resultado;
                }
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

    }

}
