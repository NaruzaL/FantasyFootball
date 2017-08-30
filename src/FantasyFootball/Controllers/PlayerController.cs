using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FantasyFootball.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FantasyFootball.Controllers
{
    public class Playercontroller : Controller
    {
        private readonly FantasyFootballContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public Playercontroller(UserManager<ApplicationUser> userManager, FantasyFootballContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index(int id)
        {
            var userTeam = _db.Teams.FirstOrDefault(team => team.TeamId == id);
            ViewBag.TeamId = userTeam.TeamId;
            return View(_db.Players.ToList());
        }
    }
}
