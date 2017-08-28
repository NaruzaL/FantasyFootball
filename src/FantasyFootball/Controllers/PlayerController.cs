using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FantasyFootball.Models;

namespace FantasyFootball.Controllers
{
    public class PlayerController : Controller
    {
        private FantasyFootballContext db = new FantasyFootballContext();
        public IActionResult Index()
        {
            return View(db.Players.ToList());
        }
    }
}
