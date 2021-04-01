using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using assignment10.Models;
using Microsoft.EntityFrameworkCore;
using assignment10.Models.ViewModels;

namespace assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //create variable to hold the db context
        private readonly BowlingLeagueContext context;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //index page view, recieves optional paramiters of team id, team name, and results page number
        public IActionResult Index(long? id, string team, int pageNum = 1)
        {
            //set number of results per page here 
            int pageSize = 5;

            //set the selected team name to the view bag under the Team attribute (used to change the header dynamically)
            ViewBag.Team = team;

            ////return statement before adding pagination*****
            //return View(context.Bowlers.FromSqlInterpolated($"select * from Bowlers where TeamID = {id} or {id} is null order by BowlerFirstName"));

            //return function calls a new Index view model and populates it
            return View(new IndexViewModel
            {
                //sets the bowlers attribute to contain either all of the bowlers or whichever ones match the team id
                //that had been passed in. also recieves the page num and only shows those five records
                Bowlers = (context.Bowlers
                .Where(x => x.TeamId == id || id == null)
                .OrderBy(x => x.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                ),

                //set page number info to be used in the page number tag helper
                PageNumberingInfo = new PageNumberingInfo
                {
                    itemsPerPage = pageSize,
                    currentPage = pageNum,
                    //if no team has been selected count them all, otherwise filter by whichever team has
                    //been selected and then count
                    totalItems = (id == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == id).Count())
                },

                //view model attribute team is set equal to the team that is passed into the view
                team = team
            }) ; 
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
