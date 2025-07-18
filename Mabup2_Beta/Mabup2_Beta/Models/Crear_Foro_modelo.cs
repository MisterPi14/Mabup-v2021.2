using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mabup2_Beta.Models
{
    public class Crear_Foro_modelo 
    {
        public int ID_Creador { get; set; }
        public string Tema { get; set; }
        public string Materia { get; set; }
    }
}
