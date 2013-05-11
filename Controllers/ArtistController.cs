using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataServices;
using Collector.Models;
using Domain.Entities.DTOS;

namespace Collector.Controllers
{
    public class ArtistController : Controller
    {

        private DataService dataService;

        public ArtistController (DataService dataService)
	{
        this.dataService = dataService;
	}
        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddArtist()
        {

            ArtistModel artist = new ArtistModel();
            artist.yearDropDown = dataService.YearPublishedService.YearList();
            return View(artist);
        }

        [HttpPost]
        public ActionResult AddArtist(ArtistModel model)
        {



            if (ModelState.IsValid)
            {
                try
                {
                    Artist artist = new Artist();
                    artist.ArtistId = model.yearDropDownId;
                    artist.ArtistFirstName = model.FirstName;
                    artist.ArtistLastName = model.LastName;

                    dataService.ArtistService.AddNew(artist);
                    ViewBag.ThankYou = model.FirstName + " " + model.LastName + " has been successfully added.";
                    return View("ThankYou");

                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.InnerException;
                    return View("Error");

                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Model State";
                return View("Error");
            }

            
        }

    }
}
