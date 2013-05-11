using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Collector.Models
{
    public class ArtistModel
    {

        public ArtistModel()
        {
            yearDropDown = new List<SelectListItem>();
        }


        [Required(ErrorMessage="First Name Is Required")]
        [DisplayName("First Name")] public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [DisplayName("Last Name")] public string LastName { get; set; }

        public int yearDropDownId { get; set; }

        public IList<SelectListItem> yearDropDown { get; set; }

    }
}