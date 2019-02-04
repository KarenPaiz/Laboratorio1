using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {

        // GET: Game
        int N = 6; // CANT DE JUEGOS 
        Game[] Juegos;

        public ActionResult Index()
        {
            return View();
        }
        public Game[] regresa ()
        {
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            Juegos = new Game[N];
            Juegos[0] = new Game() { Id = 1, Nombre = "juego 1", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 01 };
            Juegos[1] = new Game() { Id = 15, Nombre = "juego 6", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 3 };
            Juegos[2] = new Game() { Id = 6, Nombre = "juego 3", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 12 };
            Juegos[3] = new Game() { Id = 12, Nombre = "juego 5", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 20 };
            Juegos[4] = new Game() { Id = 9, Nombre = "juego 4", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 6 };
            Juegos[5] = new Game() { Id = 2, Nombre = "juego 2", Año = 2010, Categoria = "Arcade", Estudio = "Estudio", Puntuacion = 18 };
            TimeSpan stop = new TimeSpan(DateTime.Now.Ticks);
            string resultadoOrden = "La creacion de los juegos toma " + (stop.TotalMilliseconds - start.TotalMilliseconds) + " Milisegundos";
            Juegos[2].ResultadoTiempo = resultadoOrden;
            return Juegos;
        }
        public ActionResult MostrarJuego()
        {
            Juegos = regresa();

            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            //ALGORITMO DE ORDENAMIENTO
            Game aux;
            Game aux2;
            int posi;
            for (int i = 0; i < N - 1; i++)
            {
                aux = Juegos[i];
                aux2 = Juegos[i];
                posi = i;
                for (int j = i; j < N - 1; j++)
                {
                    if (aux.Id > Juegos[j + 1].Id)
                    {
                        aux = Juegos[j + 1];
                        posi = j + 1;
                    }
                }
                Juegos[i] = aux;
                Juegos[posi] = aux2;
            }
            //FIN ALGORITMO DE ORDENAMIENTO
            TimeSpan stop = new TimeSpan(DateTime.Now.Ticks);
            string resultadoOrden = "El algoritmo de ordenamiento toma " + (stop.TotalMilliseconds - start.TotalMilliseconds) + " Milisegundos";
            Juegos[0].ResultadoTiempo = resultadoOrden;
            Process currentProcess = Process.GetCurrentProcess();
            String processID = "El PID del algoritmo de ordenamiento es " + currentProcess.Id.ToString();
            Juegos[0].ResultadoPID = processID;

            return View(Juegos);

        }
        public string BuscarJuego (int id)
        {
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            Juegos = regresa();
            Game aux = new Game();
            for (int i=0;i<N;i++)
            {
                if (id==Juegos[i].Id)
                {
                    aux = Juegos[i];
                }
            }
            TimeSpan stop = new TimeSpan(DateTime.Now.Ticks);
            string resultadoOrden = "El algoritmo de busqueda toma " + (stop.TotalMilliseconds - start.TotalMilliseconds) + " Milisegundos";
            Juegos[1].ResultadoTiempo = resultadoOrden;
            Process currentProcess = Process.GetCurrentProcess();
            String processID = "El PID del algoritmo de busqueda es " + currentProcess.Id.ToString();
            Juegos[1].ResultadoPID = processID;
            return "ID: " + aux.Id + ". Juego: " + aux.Nombre + ". Puntuacion: " + aux.Puntuacion + ". Categoria: " + aux.Categoria + ". Estudio: " + aux.Estudio + ". Año: " + aux.Año+ ".   "+Juegos[1].ResultadoTiempo;
        }
    }
}