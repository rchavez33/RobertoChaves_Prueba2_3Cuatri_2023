using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace RobertoChaves_Prueba2_3Cuatri_2023.Clases
{
    public class Equipos
{
        public static int EquipoID {  get; set; }
        public static int UsuarioID { get; set; }

        public static string TipoEquipo { get; set; }

        public static string Modelo { get; set; }

           

        public Equipos(int equiposID, int usuarioID, string tipoequipo, string modelo)
        {
            EquipoID = equiposID;
            UsuarioID = usuarioID;
            TipoEquipo = tipoequipo;
            Modelo = modelo;
        }
            
        public static int AgregarEquipo(string TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int BorrarEquipoID(int EquipoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarEquipoID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static List<Equipos> ConsultarEquipoID(int EquipoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> Equipo = new List<Equipos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipoID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipos Equipos = new Equipos(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));  // instancia
                            Equipo.Add(Equipos);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Equipo;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Equipo;
        }


        public static int ModificarEquipoID(int EquipoID, int UsuarioID, string TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuarioID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));  
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        

        internal static int ModificarEquipoID(int v, string text1, string text2, string text3)
        {
            throw new NotImplementedException();
        }
    }
}
