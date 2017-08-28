using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FantasyFootball.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;



namespace FantasyFootball.Controllers
{
    public class Teamcontroller : Controller
    {
        private FantasyFootballContext db = new FantasyFootballContext();

        private readonly FantasyFootballContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public Teamcontroller(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, FantasyFootballContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //all leagues user already belongs to
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Teams.Where(x => x.User.Id == currentUser.Id));
        }

       
        //make a new team
        [Authorize]
        public IActionResult Create(int id)
        {
            var thisLeague = _db.Leagues.FirstOrDefault(league => league.LeagueId == id);
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            team.User = currentUser;
            return RedirectToAction("League", "Details");

        }
    }
}
