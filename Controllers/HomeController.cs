using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeWatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BikeWatcherContext context;

        public HomeController(ILogger<HomeController> logger, BikeWatcherContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> StationListAsync(double latitudeUser = 0f, double longitudeUser = 0f, string ville = "lyon", int idFav = 0)
        {
            List<Stations> StationList = new List<Stations>();
            if (ville == "lyon")
            {
                StationList = await Traitement.FindStation();
            }
            else if (ville == "bordeaux")
            {
                StationList = await Traitement.FindStationBordeaux();
            }

            if (latitudeUser == 0 && longitudeUser == 0)
            {
                StationList.Sort((x, y) => x.name.CompareTo(y.name));
            }
            else
            {
                StationList = StationList.OrderBy(s => s.CompareDistance(latitudeUser, longitudeUser)).ToList();
            }

            if (idFav != 0)
            {
                var a = new FavorisModel();
                a.stationId = idFav;
                context.Add(a);
                await context.SaveChangesAsync();
            }

            ViewBag.Ville = ville;
            return View(StationList);
        }

        public async Task<IActionResult> MapAsync()
        {
            var StationList = await Traitement.FindStation();

            return View(StationList);
        }

        public async Task<IActionResult> favorite()
        {
            List<FavorisModel> f = await context.Favoris.ToListAsync();
            List<Stations> StationList = await Traitement.FindStation();
            List<Stations> fs = new List<Stations>();
            foreach(FavorisModel ff in f)
            {
                foreach (Stations s in StationList)
                {
                    if (s.number == ff.stationId.ToString())
                    {
                        fs.Add(s);
                    }
                }
            }
            ViewBag.favs = fs;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
