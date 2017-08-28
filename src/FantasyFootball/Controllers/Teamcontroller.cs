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
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Index(int id)
        {
            var thisTeam = _db.Teams.Include(t => t.Players).FirstOrDefault(team => team.TeamId == id);
            return View(thisTeam);
        }

        //make a new team
        [Authorize]
        public IActionResult Create(int id)
        {
            var thisLeague = _db.Leagues.FirstOrDefault(league => league.LeagueId == id);
            ViewBag.LeagueId = new SelectList(_db.Leagues, "LeagueId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var selectedLeague = _db.Leagues.FirstOrDefault(league => league.LeagueId == team.LeagueId);
            selectedLeague.TeamCount += 1;
            team.User = currentUser;
            _db.Entry(selectedLeague).State = EntityState.Modified;
            _db.Teams.Add(team);
            _db.SaveChanges();
            return RedirectToAction("Index", "League");
        }

    }
}
