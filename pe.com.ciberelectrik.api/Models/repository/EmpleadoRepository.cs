using pe.com.ciberelectrik.api.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace pe.com.ciberelectrik.api.Models.repository
{
    public class EmpleadoRepository
    {
        private Conexion objconexion = new Conexion();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<Empleado> findAll()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                cmd = new SqlCommand("SP_MostrarEmpleado", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empleado e = new Empleado
                    {
                        codigo = Convert.ToInt32(dr["codemp"]),
                        nombre = dr["nomemp"].ToString(),
                        apellidoPaterno = dr["apepemp"].ToString(),
                        apellidoMaterno = dr["apememp"].ToString(),
                        documento = dr["docemp"].ToString(),
                        direccion = dr["diremp"].ToString(),
                        telefono = dr["telemp"].ToString(),
                        celular = dr["celemp"].ToString(),
                        correo = dr["coremp"].ToString(),
                        usuario = dr["usuemp"].ToString(),
                        clave = dr["claemp"].ToString(),
                        estado = Convert.ToBoolean(dr["estemp"]),
                        coddis = Convert.ToInt32(dr["coddis"]),
                        codrol = Convert.ToInt32(dr["codrol"]),
                        codtipd = Convert.ToInt32(dr["codtipd"])
                    };
                    lista.Add(e);
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

        public List<Empleado> findAllCustom()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                cmd = new SqlCommand("SP_MostrarEmpleadoTodo", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empleado e = new Empleado
                    {
                        codigo = Convert.ToInt32(dr["codemp"]),
                        nombre = dr["nomemp"].ToString(),
                        apellidoPaterno = dr["apepemp"].ToString(),
                        apellidoMaterno = dr["apememp"].ToString(),
                        documento = dr["docemp"].ToString(),
                        direccion = dr["diremp"].ToString(),
                        telefono = dr["telemp"].ToString(),
                        celular = dr["celemp"].ToString(),
                        correo = dr["coremp"].ToString(),
                        usuario = dr["usuemp"].ToString(),
                        clave = dr["claemp"].ToString(),
                        estado = Convert.ToBoolean(dr["estemp"]),
                        coddis = Convert.ToInt32(dr["coddis"]),
                        codrol = Convert.ToInt32(dr["codrol"]),
                        codtipd = Convert.ToInt32(dr["codtipd"])
                    };
                    lista.Add(e);
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

        public bool add(Empleado e)
        {
            try
            {
                cmd = new SqlCommand("SP_RegistrarEmpleado", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apepat", e.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemat", e.apellidoMaterno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.coddis);
                cmd.Parameters.AddWithValue("@codrol", e.codrol);
                cmd.Parameters.AddWithValue("@codtipd", e.codtipd);

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

        public bool update(Empleado e)
        {
            try
            {
                cmd = new SqlCommand("SP_ActualizarEmpleado", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apepat", e.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemat", e.apellidoMaterno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.coddis);
                cmd.Parameters.AddWithValue("@codrol", e.codrol);
                cmd.Parameters.AddWithValue("@codtipd", e.codtipd);

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
                cmd = new SqlCommand("SP_EliminarEmpleado", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };
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
                cmd = new SqlCommand("SP_HabilitarEmpleado", objconexion.Conectar()) { CommandType = CommandType.StoredProcedure };
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
