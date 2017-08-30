﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FantasyFootball.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FantasyFootball.Controllers
{
    public class Playercontroller : Controller
    {
        private FantasyFootballContext db = new FantasyFootballContext();

        private readonly FantasyFootballContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public Playercontroller(UserManager<ApplicationUser> userManager, FantasyFootballContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        [Authorize]
        public IActionResult Index(int id)
        {
            var userTeam = _db.Teams.FirstOrDefault(team => team.TeamId == id);
            ViewBag.TeamId = userTeam.TeamId;
            return View(_db.Players.ToList());
        }

        [Authorize]
        public IActionResult AddPlayer(int id, int tId)
        {
            var thisPlayer = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            var userTeam = _db.Teams.Where(t => t.TeamId == tId);
            ViewBag.TeamId = new SelectList(userTeam, "TeamId", "TeamName");
            return View(thisPlayer);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddPlayer(Player player, string TeamId)
        {
            var id = int.Parse(TeamId);
            player.Team = _db.Teams.FirstOrDefault(t => t.TeamId == id);
            player.FreeAgent = false;
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction ("Index", "League");
        }
        [Authorize]
        public IActionResult DropPlayer(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(p => p.PlayerId == id);
            return View(thisPlayer);
        }
        [Authorize]
        [HttpPost]
        public IActionResult DropPlayer(Player player)
        {
            player.FreeAgent = true;
            player.Team = null;
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "League");
        }

    }
}
