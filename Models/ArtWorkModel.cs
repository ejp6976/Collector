using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collector.Models
{
    public class ArtWorkModel
    {


        public ArtWorkModel()
        {
            YearList = new List<SelectListItem>();
            ArtistList = new List<SelectListItem>();
            ArtTypeList = new List<SelectListItem>();

        }


        public IList<SelectListItem> YearList { get; set; }
        public IList<SelectListItem> ArtistList { get; set; }
        public IList<SelectListItem> ArtTypeList { get; set; }


        public int ArtWorkId  { get; set; }
        public int YearId { get; set; }
        public int ArtistId { get; set; }
        public int ArtTypeId { get; set; }
    }
}