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
    public class Foro_de_discusion : Controller
    {
        [HttpGet]
        public IActionResult Buscar_Foro(int ID)
        {
            ViewBag.ID = ID;

            SqlConnection conn = new SqlConnection(@"Data Source=.; Initial Catalog=BD_Mabup2; Integrated Security=True");

            //CONSULTANDO NUMERO DE FOROS
            SqlCommand Num_Foros = new SqlCommand();
            Num_Foros.Connection = conn;

            SqlDataReader Lector_Num_Foros;
            conn.Open();
            Num_Foros.CommandText = "SELECT MAX(ID_Foro) FROM tb_Foro";
            Lector_Num_Foros = Num_Foros.ExecuteReader();
            Lector_Num_Foros.Read();
            int n_Foros = (Convert.ToInt32((Lector_Num_Foros[0])));
            conn.Close();

            //CONSULTANDO TAREAS

            SqlDataReader Consulta_Foros;
            SqlCommand cmd = new SqlCommand();
            conn.Open();

            List<string> Tema = new List<string>();
            List<string> Materia = new List<string>();
            List<string> Autor = new List<string>();

            for (int n = 1; n <= n_Foros; n++)
            {
                StringBuilder Sel = new StringBuilder();
                Sel.Append("SELECT Tema,Materia,Nombre,Ap_Pat,Ap_Mat FROM tb_Foro JOIN tb_Usuarios ON tb_Foro.ID_Creador=tb_Usuarios.ID Where ID_Foro=" + n);
                cmd.Connection = conn;
                cmd = new SqlCommand(Sel.ToString(), conn);
                Consulta_Foros = cmd.ExecuteReader();

                if (Consulta_Foros.Read())
                {
                    Tema.Add(Convert.ToString(Consulta_Foros[0]));
                    Materia.Add(Convert.ToString(Consulta_Foros[1]));
                    Autor.Add(Convert.ToString(Consulta_Foros[2])+" "+Convert.ToString(Consulta_Foros[3])+" "+Convert.ToString(Consulta_Foros[4]));
                }
                else
                {

                }
                Consulta_Foros.Close();
            }

            ViewBag.Validacion = true;
            ViewBag.Tema = Tema;
            ViewBag.Materia = Materia;
            ViewBag.Autor = Autor;

            return View();
        }

        [HttpPost]
        public IActionResult Buscar_Foro(Foro_modelo Entrar_Foro)
        {
            ViewBag.ID = Entrar_Foro.ID;

            SqlConnection conn = new SqlConnection(@"Data Source=.; Initial Catalog=BD_Mabup2; Integrated Security=True");

            //CONSULTANDO NUMERO DE FOROS
            SqlCommand Num_Foros = new SqlCommand();
            Num_Foros.Connection = conn;

            SqlDataReader Lector_Num_Foros;
            conn.Open();
            Num_Foros.CommandText = "SELECT MAX(ID_Foro) FROM tb_Foro";
            Lector_Num_Foros = Num_Foros.ExecuteReader();
            Lector_Num_Foros.Read();
            int n_Foros = (Convert.ToInt32((Lector_Num_Foros[0])));
            conn.Close();

            //CONSULTANDO TAREAS

            SqlDataReader Consulta_Foros;
            SqlCommand cmd = new SqlCommand();
            conn.Open();

            List<string> Tema = new List<string>();
            List<string> Materia = new List<string>();
            List<string> Autor = new List<string>();

            for (int n = 1; n <= n_Foros; n++)
            {
                StringBuilder Sel = new StringBuilder();
                Sel.Append("SELECT Tema,Materia,Nombre,Ap_Pat,Ap_Mat FROM tb_Foro JOIN tb_Usuarios ON tb_Foro.ID_Creador=tb_Usuarios.ID Where ID_Foro=" + n + "And Tema='" + Entrar_Foro.Foro + "'");
                cmd.Connection = conn;
                cmd = new SqlCommand(Sel.ToString(), conn);
                Consulta_Foros = cmd.ExecuteReader();

                if (Consulta_Foros.Read())
                {
                    Tema.Add(Convert.ToString(Consulta_Foros[0]));
                    Materia.Add(Convert.ToString(Consulta_Foros[1]));
                    Autor.Add(Convert.ToString(Consulta_Foros[2]) + " " + Convert.ToString(Consulta_Foros[3]) + " " + Convert.ToString(Consulta_Foros[4]));
                }
                else
                {

                }

                Consulta_Foros.Close();

            }

            ViewBag.Tema = Tema;
            ViewBag.Materia = Materia;
            ViewBag.Autor = Autor;

            //VALIDANDO QUE LA BUSQUEDA DEL FORO ARROJE DATOS 
            if (Tema.Count != 0)
            {
                ViewBag.Validacion = true;
            }
            else
            {
                ViewBag.Validacion = false;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Foro(string Nombre_foro, int ID)
        {
            ViewBag.Foro = Nombre_foro;
            ViewBag.ID = ID;

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.; Initial Catalog=BD_Mabup2; Integrated Security=True");


                //CONSULTANDO NUMERO DE TAREAS
                SqlCommand Num_Coment = new SqlCommand();
                Num_Coment.Connection = conn;

                SqlDataReader Lector_Num_Coment;
                conn.Open();
                Num_Coment.CommandText = "SELECT MAX(#Comentario) FROM tb_Comentarios Where Foro ='" + Nombre_foro + "'";
                Lector_Num_Coment = Num_Coment.ExecuteReader();
                Lector_Num_Coment.Read();
                int n_Comentarios = (Convert.ToInt32((Lector_Num_Coment[0])));
                conn.Close();

                //CONSULTANDO COMENTARIOS

                SqlDataReader Consulta_Comentarios;
                SqlCommand cmd = new SqlCommand();
                conn.Open();

                List<string> Comentario = new List<string>();

                for (int n = 1; n <= n_Comentarios; n++)
                {
                    StringBuilder Sel = new StringBuilder();
                    Sel.Append("SELECT Nombre, Ap_Pat, Ap_Mat, Comentario, Fecha FROM tb_Comentarios JOIN tb_Usuarios ON tb_Comentarios.ID_usuario = tb_Usuarios.ID Where tb_Comentarios.Foro ='" + Nombre_foro + "' AND tb_Comentarios.#Comentario=" + n);
                    cmd.Connection = conn;
                    cmd = new SqlCommand(Sel.ToString(), conn);
                    Consulta_Comentarios = cmd.ExecuteReader();

                    if (Consulta_Comentarios.Read())
                    {
                        Comentario.Add(Convert.ToString(Consulta_Comentarios[0]) + " " + Convert.ToString(Consulta_Comentarios[1]) + " " + Convert.ToString(Consulta_Comentarios[2]) + ": " + Convert.ToString(Consulta_Comentarios[3]) + " " + Convert.ToString(Consulta_Comentarios[4]));
                    }
                    else
                    {

                    }

                    Consulta_Comentarios.Close();
                    ViewBag.Comentarios = Comentario;
                }
            }
            catch
            {
                List<string> Ningun_comentario = new List<string>();
                Ningun_comentario.Add("Al parecer no existe ningun chat, Escribe uno seras el primero en hacerlo :D");
                ViewBag.Comentarios = Ningun_comentario;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Foro(Foro_Chat Postear_Chat)
        {
            if (Postear_Chat.ID > 0 && Postear_Chat.Comentario != null)
            {
                //Guardando Comentario
                SqlConnection conn = new SqlConnection(@"Data Source=.; Initial Catalog=BD_Mabup2; Integrated Security=True");
                string query = "INSERT INTO tb_Comentarios VALUES (@ID_usuario, @Comentario, @Fecha, @Foro)";
                SqlCommand Comando_Tarea = new SqlCommand(query, conn);

                conn.Open();

                Comando_Tarea.Parameters.AddWithValue("@ID_usuario", Postear_Chat.ID);
                Comando_Tarea.Parameters.AddWithValue("@Comentario", Postear_Chat.Comentario);
                Comando_Tarea.Parameters.AddWithValue("@Fecha", (DateTime.Today.ToString("dd-MM-yyyy")+" "+DateTime.Now.ToString("HH:mm:ss")));
                Comando_Tarea.Parameters.AddWithValue("@Foro", Postear_Chat.Foro);

                int resultado = Comando_Tarea.ExecuteNonQuery();

                conn.Close();
                return RedirectToAction("Foro", new { Nombre_foro = Postear_Chat.Foro, ID = Postear_Chat.ID });
            }
            else
            {
                return RedirectToAction("Foro", new { Nombre_foro = Postear_Chat.Foro, ID = Postear_Chat.ID });
            }
        }

            [HttpGet]
        public IActionResult Crear_Foro(int ID)
        {
            ViewBag.Creador = ID;
            return View();
        }
        [HttpPost]
        public IActionResult Crear_Foro(Crear_Foro_modelo Añadir_foro)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BD_Mabup2; Integrated Security=True");

            conn.Open();

            string query = "Insert into tb_Foro(Tema, Materia, Fecha_creacion, Hora_creacion, ID_Creador) Values(@Tema, @Materia, @Fecha_creacion, @Hora_creacion, @ID_Creador)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Tema", Añadir_foro.Tema);
            cmd.Parameters.AddWithValue("@Materia", Añadir_foro.Materia);
            cmd.Parameters.AddWithValue("@Fecha_creacion", DateTime.Today);
            cmd.Parameters.AddWithValue("@Hora_creacion", DateTime.Now);
            cmd.Parameters.AddWithValue("@ID_Creador", Añadir_foro.ID_Creador);

            int resultado = cmd.ExecuteNonQuery();

            conn.Close();
            return RedirectToAction("Buscar_Foro", new { ID = Añadir_foro.ID_Creador });
        }
    }
}
