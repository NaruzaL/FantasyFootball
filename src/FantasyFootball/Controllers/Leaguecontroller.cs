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
    public class Leaguecontroller : Controller
    {

        private readonly FantasyFootballContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public Leaguecontroller(UserManager<ApplicationUser> userManager, FantasyFootballContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        //list of user leagues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Leagues.Where(x => x.User.Id == currentUser.Id).ToList());
        }
        //create a league
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create (League league)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            league.User = currentUser;
            _db.Leagues.Add(league);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //home page for specific league
        [Authorize]
        public IActionResult Details(int id)
        {
            var thisLeague = _db.Leagues.Include(league => league.Teams).Include(league => league.Messages).FirstOrDefault(Leagues => Leagues.LeagueId == id);
            return View(thisLeague);
        }

        //list of leagues that aren't full
        [Authorize]
        public IActionResult Join()
        {
            return View(_db.Leagues.ToList());
        }


    }
}
