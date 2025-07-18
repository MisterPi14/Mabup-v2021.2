using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mabup2_Beta.Models
{
    public class Foro_Chat 
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public string Foro { get; set; }
    }
}
