using System;
namespace assignment10.Models.ViewModels
{
    //class with variables to store all necessary info for the page numbering 
    public class PageNumberingInfo
    {
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalItems { get; set; }
        //calculate num pages
        public int numPages => (int)(Math.Ceiling((decimal)totalItems / itemsPerPage));
    }
}
