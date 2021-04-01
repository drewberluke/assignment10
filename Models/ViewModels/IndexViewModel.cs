using System;
using System.Collections.Generic;

//index view model, used to enable us to store more information to use in the view and organize it better 
namespace assignment10.Models.ViewModels
{
    //create class with variables for a list of bowler objects, instance of pagenumberinginfo, team name and team id
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string team { get; set; }
        public int id { get; set; }
    }
}
