using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mabup2_Beta.Models;
using System.Data.SqlClient;
using System.Text;

namespace Mabup2_Beta.Controllers
{
    public class Gestor_Tareas : Controller
    {
        public IActionResult Gestor(int ID)
        {

            ViewBag.ID = ID;
            
            ViewBag.Tareas = "";

            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BD_Mabup2; Integrated Security=True");


            //CONSULTANDO NUMERO DE TAREAS
            SqlCommand Num_Tareas = new SqlCommand();
            Num_Tareas.Connection = conn;

            SqlDataReader Lector_Num_Tareas;
            conn.Open();
            Num_Tareas.CommandText = "SELECT MAX(#Tarea) FROM tb_Tareas";
            Lector_Num_Tareas = Num_Tareas.ExecuteReader();
            Lector_Num_Tareas.Read();
            int n_Tareas = (Convert.ToInt32((Lector_Num_Tareas[0])));
            conn.Close();

            //CONSULTANDO TAREAS

            SqlDataReader Consulta_Tareas;
            SqlCommand cmd = new SqlCommand();
            conn.Open();

            List<string> Titulo = new List<string>();
            List<string> Fecha_Entrega = new List<string>();
            List<string> Hora_Entrega = new List<string>();
            List<string> Dificultad = new List<string>();


            for (int n = 1; n <= n_Tareas; n++)
            {
                StringBuilder Sel = new StringBuilder();
                Sel.Append("SELECT Titulo,Fecha_Entrega,Hora_Entrega,Dificultad FROM tb_Usuarios JOIN tb_Tareas ON tb_Usuarios.ID = tb_Tareas.ID WHERE tb_Usuarios.ID=" + ID + " AND Estado=0 AND #Tarea=" + n);
                cmd.Connection = conn;
                cmd = new SqlCommand(Sel.ToString(), conn);
                Consulta_Tareas = cmd.ExecuteReader();

                if (Consulta_Tareas.Read())
                {
                    Titulo.Add(Convert.ToString(Consulta_Tareas[0]));
                    Fecha_Entrega.Add(Convert.ToString(Consulta_Tareas[1]));
                    Hora_Entrega.Add(Convert.ToString(Consulta_Tareas[2]));
                    Dificultad.Add(Convert.ToString(Consulta_Tareas[3]));
                }
                else
                {
                    
                }

                ViewBag.Titulo = Titulo;
                ViewBag.Fecha_Entrega = Fecha_Entrega;
                ViewBag.Hora_Entrega = Hora_Entrega;
                ViewBag.Dificultad = Dificultad;

                Consulta_Tareas.Close();
            }

            conn.Close();
            return View(); 
        }

        [HttpPost]
        public IActionResult Gestor(Gestor_Estado Estado)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BD_Mabup2; Integrated Security=True");

            //COMPLETANDO TAREA
            SqlCommand Marcar_Completado = new SqlCommand();
            Marcar_Completado.Connection = conn;
            Marcar_Completado.CommandText = "UPDATE tb_Tareas SET Estado = 1 WHERE Titulo = '" + Estado.Tarea + "' AND id =" + Estado.ID;
            conn.Open();
            Marcar_Completado.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Gestor", new { ID = Estado.ID});
        }

        [HttpGet]
        public IActionResult Agregar_Tarea(int ID)
        {
            ViewBag.ID = ID;
            return View();
        }
        [HttpPost]
        public IActionResult Agregar_Tarea(Agregar_Tarea_Modelo Datos_Tarea, LogIn Datos_Usuario)
        {
            if (Datos_Tarea.Titulo != null && Datos_Tarea.Fecha_Entrega != null && Datos_Tarea.Hora_Entrega != null && Datos_Tarea.Materia != null && Datos_Tarea.Dificultad != null && Datos_Tarea.Tema_Tarea != null)
            {
                //CONSULTANDO ID
                SqlDataReader Dr;
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BD_Mabup2; Integrated Security=True");
                SqlCommand comando_ID = new SqlCommand();


                conn.Open();

                comando_ID.Connection = conn;
                StringBuilder Sel = new StringBuilder();

                //VALIDANDO USUARIO Y CONTRASEÑA EN SQL
                Sel.Append("SELECT ID FROM tb_Usuarios WHERE Correo = '" + Datos_Usuario.Correo + "' AND Contraseña  = '" + Datos_Usuario.Contraseña + "'");
                comando_ID = new SqlCommand(Sel.ToString(), conn);
                Dr = comando_ID.ExecuteReader();
                if (Dr.Read())
                {

                }
                else
                {

                }
                conn.Close();

                //Guardando Tarea
                SqlConnection conn_2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BD_Mabup2; Integrated Security=True");
                string query = "INSERT INTO tb_Tareas VALUES (@ID, @Titulo, @Fecha_Inicio, @Hora_Inicio, @Fecha_Entrega, @Hora_Entrega, @Materia, @Dificultad, @Tema_Tarea, @Estado)";
                SqlCommand Comando_Tarea = new SqlCommand(query, conn_2);

                conn_2.Open();

                Comando_Tarea.Parameters.AddWithValue("@ID", Datos_Tarea.ID);
                Comando_Tarea.Parameters.AddWithValue("@Titulo", Datos_Tarea.Titulo);
                Comando_Tarea.Parameters.AddWithValue("@Fecha_Inicio", DateTime.Today.ToString("MM-dd-yyyy"));
                Comando_Tarea.Parameters.AddWithValue("@Hora_Inicio", DateTime.Now.ToString("HH:mm:ss"));
                Comando_Tarea.Parameters.AddWithValue("@Fecha_Entrega", Datos_Tarea.Fecha_Entrega);
                Comando_Tarea.Parameters.AddWithValue("@Hora_Entrega", Datos_Tarea.Hora_Entrega);
                Comando_Tarea.Parameters.AddWithValue("@Materia", Datos_Tarea.Materia);
                Comando_Tarea.Parameters.AddWithValue("@Dificultad", Datos_Tarea.Dificultad);
                Comando_Tarea.Parameters.AddWithValue("@Tema_Tarea", Datos_Tarea.Tema_Tarea);
                Comando_Tarea.Parameters.AddWithValue("@Estado", 0);


                int resultado = Comando_Tarea.ExecuteNonQuery();

                conn_2.Close();

                return RedirectToAction("Gestor", new { ID = Datos_Tarea.ID });

            }
            else
            {
                ViewBag.Aviso = "Llena todos los campos";
                return View();
            }


        }
    }
}
