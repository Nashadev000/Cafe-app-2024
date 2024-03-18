using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AppSQL.Data
{
    public class BaseDatos
    {
        public static List<Tipos> GetTipos()
        {
            List<Tipos> listaTipo = new List<Tipos>();
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaTipo.Add(new Tipos()
                            {
                                id = Convert.ToInt32(dr["id_tipo"]),
                                nombre = dr["nom_tipo"].ToString(),
                                precio = (float)Convert.ToDouble(dr["precio"]),
                                descripcion = dr["descripcion"].ToString(),
                                imagen = dr["imagen"].ToString()
                            });
                        }
                    }
                    return listaTipo;
                }
                catch (Exception ex)
                {
                    return listaTipo;
                }
            }
        }

        public static bool AgregarTipo(Tipos tipo_cafe)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("insertar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_tipo", tipo_cafe.nombre);
                cmd.Parameters.AddWithValue("@precio", tipo_cafe.precio);
                cmd.Parameters.AddWithValue("@descripcion", tipo_cafe.descripcion);
                cmd.Parameters.AddWithValue("@imagen", tipo_cafe.imagen);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool ModificarTipo(Tipos tipo_cafe)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", tipo_cafe.id);
                cmd.Parameters.AddWithValue("@nom_tipo", tipo_cafe.nombre);
                cmd.Parameters.AddWithValue("@precio", tipo_cafe.precio);
                cmd.Parameters.AddWithValue("@descripcion", tipo_cafe.descripcion);
                cmd.Parameters.AddWithValue("@imagen", tipo_cafe.imagen);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool EliminarTipo(Tipos tipo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", tipo.id);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
