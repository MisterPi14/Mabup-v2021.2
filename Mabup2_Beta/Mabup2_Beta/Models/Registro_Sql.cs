using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Mabup2_Beta.Models
{
    public class Registro_Sql : Controller
    {
        public static void AgregarUsuario(Registro_Modelo Datos)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BD_Mabup2; Integrated Security=True");

            conn.Open();

            string query = "Insert into tb_Usuarios(Nombre, Ap_Pat, Ap_Mat, Correo, Contraseña, Estimado_de_tiempo) Values(@Nombre, @Ap_Pat, @Ap_Mat, @Correo, @Contraseña, @Estimado_de_tiempo)";
            SqlCommand cmd = new SqlCommand(query, conn);
            

            cmd.Parameters.AddWithValue("@Nombre", Datos.Nombre);
            cmd.Parameters.AddWithValue("@Ap_Pat", Datos.Ap_Pat);
            cmd.Parameters.AddWithValue("@Ap_Mat", Datos.Ap_Mat);
            cmd.Parameters.AddWithValue("@Correo", Datos.Correo);
            cmd.Parameters.AddWithValue("@Contraseña", Datos.Contraseña);
            cmd.Parameters.AddWithValue("@Estimado_de_tiempo", Datos.Estimado_Tiempo);

            int resultado = cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
