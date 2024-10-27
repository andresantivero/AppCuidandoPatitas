﻿using AppCuidandoPatitas.Models;
using AppCuidandoPatitas.Interface;
using System.Data.SqlClient;
using System.Data;

namespace AppCuidandoPatitas.Datos
{
    public class DatosHome : IGuardar<ModelHome>
    {
        public bool Guardar(ModelHome objHome)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());

                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INSERTAR_MENSAJE", conexion);

                    cmd.Parameters.AddWithValue("MENSAJE_NOMBRE", objHome.MensajeNombre);
                    cmd.Parameters.AddWithValue("MENSAJE_TELEFONO", objHome.MensajeTelefono);
                    cmd.Parameters.AddWithValue("MENSAJE_MAIL", objHome.MensajeMail);
                    cmd.Parameters.AddWithValue("MENSAJE_MENSAJE", objHome.MensajeMensaje);       
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;

            }
            catch (Exception x)
            {
                respuesta = false;
                Console.WriteLine(x);
            }

            return respuesta;

        }
    }
}
