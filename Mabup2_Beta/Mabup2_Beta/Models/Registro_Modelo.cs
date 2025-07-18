using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mabup2_Beta.Models
{
    public class Registro_Modelo 
    {

        public string Nombre { get; set; }
        public string Ap_Pat { get; set; }
        public string Ap_Mat { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Confirmar_Contraseña { get; set; }
        public string Estimado_Tiempo { get; set; }
    }
}
