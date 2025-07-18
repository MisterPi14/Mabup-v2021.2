using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mabup2_Beta.Models
{
    public class Agregar_Tarea_Modelo 
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Fecha_Entrega { get; set; }
        public string Hora_Entrega { get; set; }
        public string Materia { get; set; }
        public string Dificultad { get; set; }
        public string Tema_Tarea { get; set; }
    }
}
