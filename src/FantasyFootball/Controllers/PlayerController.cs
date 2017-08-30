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
        private FantasyFootballContext db = new FantasyFootballContext();   
        public IActionResult Index(int id)
        {
            var userTeam = db.Teams.FirstOrDefault(team => team.TeamId == id);
            ViewBag.TeamId = userTeam.TeamId;
            return View(db.Players.ToList());
        }
        //[HttpPost]
        //public IActionResult AddPlayer(int id, int tId)
        //{
        //    var thisPlayer = db.Players.FirstOrDefault(p => p.PlayerId == id);
        //    var userTeam = db.Teams.FirstOrDefault(team => team.TeamId == tId);
        //    ViewBag.TeamId = userTeam.TeamId;
        //    return View(thisPlayer);
        //}

        [HttpPost]
        public IActionResult AddPlayer(int id, int tid)
        {
            var thisPlayer = db.Players.FirstOrDefault(p => p.PlayerId == id);
            thisPlayer.Team = db.Teams.FirstOrDefault(team => team.TeamId == tid);
            thisPlayer.FreeAgent = false;
            db.Entry(thisPlayer).State = EntityState.Modified;
            db.SaveChanges();
            return Json(db.Players.ToList());
        }
    }
}
