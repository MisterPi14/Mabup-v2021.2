using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Mabup2_Beta.Models
{
    public class Reproductor
    {
        public string Tema { get; set; }
        public string Materia { get; set; }
    }
    public class YouTubeSearchResult
    {
        public string Tema { get; set; }
        public List<YouTubeVideo> Videos { get; set; }
    }
    
}
