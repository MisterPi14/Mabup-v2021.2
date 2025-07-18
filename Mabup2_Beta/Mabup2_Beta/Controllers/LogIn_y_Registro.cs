using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mabup2_Beta.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System.Data.SqlClient;
using System.Text;



namespace Mabup2_Beta.Controllers
{
    public class LogIn_y_Registro : Controller
    {


        private readonly ILogger<LogIn_y_Registro> _logger;
        private readonly IConfiguration _configuracion;

        public LogIn_y_Registro(ILogger<LogIn_y_Registro> logger, IConfiguration confic)
        {
            _logger = logger;
            _configuracion = confic;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LogIn(LogIn Datos_Form)
        {
            SqlDataReader Dr;
            SqlConnection conn = new SqlConnection(@"Data Source=.; Initial Catalog=BD_Mabup2; Integrated Security=True");
            SqlCommand cmd = new SqlCommand();


            conn.Open();

            cmd.Connection = conn;
            StringBuilder Sel = new StringBuilder();

            //VALIDANDO USUARIO Y CONTRASEÑA EN SQL
            Sel.Append("SELECT * FROM tb_Usuarios WHERE Correo ='" + Datos_Form.Correo + "' AND Contraseña = '" + Datos_Form.Contraseña + "'");
            cmd = new SqlCommand(Sel.ToString(), conn);
            Dr = cmd.ExecuteReader();
            if (Dr.Read())
            {
                int ID_Usuario = Convert.ToInt32(Dr[0]);
                string Nombre = (Convert.ToString(Dr[1])+" "+Convert.ToString(Dr[2])+" "+Convert.ToString(Dr[3]));
                Dr.Close();
                return RedirectToAction("Ventana_Principal", new { id = ID_Usuario, nombre = Nombre});
            }
            else
            {
                ViewBag.Aviso="Verifica tu correo y/o contraseña";
                Dr.Close();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Registro_Modelo _Usuario)
        {
            if (_Usuario.Nombre!=null && _Usuario.Ap_Pat!=null && _Usuario.Ap_Mat!=null && _Usuario.Correo != null && _Usuario.Contraseña != null && _Usuario.Confirmar_Contraseña!= null && _Usuario.Estimado_Tiempo != null)
            {
                if (_Usuario.Contraseña == _Usuario.Confirmar_Contraseña)
                {
                    Registro_Sql.AgregarUsuario(_Usuario);
                    return View("LogIn");
                }
                else
                {
                    ViewBag.Aviso = "Las contraseñas no coinciden";
                    return View();
                }
            }
            else
            {
                ViewBag.Aviso = "Llena todos los campos";
                return View();
            }

        }

        public IActionResult Ventana_Principal(int ID, string Nombre)
        {
            ViewBag.ID = ID;
            ViewBag.Nombre = Nombre;
            return View();
        }
    }
}
