using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mabup2_Beta.Models;


using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Mabup2_Beta.Models;


namespace Mabup2_Beta.Controllers
{
    public class Servicio_Stream : Controller
    {
        public IActionResult Panel_Materias()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reproductor(string Materia)
        {
            ViewBag.Materia = Materia;

            if (Materia == "Matematicas")
            {
                ViewBag.Tema1 = "Algebra";
                ViewBag.Tema2 = "Geometria euclediana y analitica";
                ViewBag.Tema3 = "Calculo Diferencial e Integral";
                ViewBag.Tema4 = "Probabilidad y estadistica";
            }
            else if (Materia == "Fisica")
            {
                ViewBag.Tema1 = "Termodinamica";
                ViewBag.Tema2 = "Mecanica";
                ViewBag.Tema3 = "Electromagnetismo";
                ViewBag.Tema4 = "Optica";
            }
            else if (Materia == "Quimica")
            {
                ViewBag.Tema1 = "Elementos y compuestos";
                ViewBag.Tema2 = "Reacciones quimicas";
                ViewBag.Tema3 = "Acidos y bases";
                ViewBag.Tema4 = "El atomo";
            }
            else if (Materia == "Biologia")
            {
                ViewBag.Tema1 = "Los seres vivos";
                ViewBag.Tema2 = "La celulas";
                ViewBag.Tema3 = "Tipos de respiracion";
                ViewBag.Tema4 = "Metabolismo";
            }
            else if (Materia == "Psicologia educativa")
            {
                ViewBag.Tema1 = "Desarrollo de la habilidad del pensamiento";
                ViewBag.Tema2 = "Proyecto de vida";
                ViewBag.Tema3 = "Comunicacion y liderazgo";
                ViewBag.Tema4 = "Vida Profesional";
            }
            else if (Materia == "Geografia")
            {
                ViewBag.Tema1 = "Localizacion de las naciones";
                ViewBag.Tema2 = "Urbanización";
                ViewBag.Tema3 = "Medio ambiente y tipos";
                ViewBag.Tema4 = "Principales zonas de comercio actual";
            }
            else if (Materia == "Ingles")
            {
                ViewBag.Tema1 = "Past perfect";
                ViewBag.Tema2 = "Conditionals";
                ViewBag.Tema3 = "Verb To be";
                ViewBag.Tema4 = "Pasive and active voice";
            }
            else if (Materia == "Cuidado del medio ambiente")
            {
                ViewBag.Tema1 = "Calentamiento global";
                ViewBag.Tema2 = "Contaminacion ambiental";
                ViewBag.Tema3 = "Ahorro de insumos";
                ViewBag.Tema4 = "Formas de reducir el impacto ambiental";
            }
            return View();
        }
        
        /*[HttpPost]
        public IActionResult Reproductor(Reproductor Seleccion)
        {
            ViewBag.Materia = Seleccion.Materia;
            ViewBag.Tema = Seleccion.Tema;
            return View();
        }*/

        [HttpPost]
        public async Task<IActionResult> Reproductor(Reproductor model)
        {
            var resultado = await BuscarVideosEnYouTube(model.Tema);
            return View(resultado);
        }


        public async Task<YouTubeSearchResult> BuscarVideosEnYouTube(string tema)
        {
            string apiKey = ""; // Reemplaza con tu API Key de YouTube
            string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&maxResults=5&q={tema}&key={apiKey}";

            var videos = new List<YouTubeVideo>();

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);

                foreach (var item in json["items"])
                {
                    videos.Add(new YouTubeVideo
                    {
                        VideoId = item["id"]["videoId"].ToString(),
                        Title = item["snippet"]["title"].ToString(),
                        ThumbnailUrl = item["snippet"]["thumbnails"]["default"]["url"].ToString()
                    });
                }
            }

            return new YouTubeSearchResult
            {
                Tema = tema,
                Videos = videos
            };
        }


    }
}
