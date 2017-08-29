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
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            ViewBag.TeamId = _db.Teams.Where(x => x.User.Id == currentUser.Id);
            return View(_db.Players.ToList());
        }
    }
}
