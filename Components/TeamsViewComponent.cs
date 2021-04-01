using System;
using assignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

//teams filter sidebar component
namespace assignment10.Components
{
    public class TeamsViewComponent : ViewComponent 
    {
        //create context variable
        public BowlingLeagueContext context { get; set; }

        //bring in the db context and assign it to context var  
        public TeamsViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        //query the db context and return distinct team names in order
        //set the viewbag.selected attribute equal to the id that was passed in to highlight the selected team
        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = Convert.ToInt32((RouteData?.Values["id"]));
            return View(context.Teams.Distinct().OrderBy(x => x)); 
        }
    }
}
