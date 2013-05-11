using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoInfrastructure;
using DataServices;
using Collector.Models;
using Domain.Entities.DTOS;

namespace Collector.Controllers
{
    public class ArtWorkController : Controller
    {

        private DataService dataService;
        //
        // GET: /ArtWork/

        public ArtWorkController(DataService dataService)
        {
            this.dataService = dataService;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddArtWork()
        {
            ArtWorkModel am = new ArtWorkModel();

            am.YearList = dataService.YearPublishedService.YearList();
            am.ArtTypeList = dataService.ArtTypeService.ArtTypeList();
            am.ArtistList = dataService.ArtistService.ArtistList();


            return View(am);
        }

    [HttpPost]
        public ActionResult AddArtWork(ArtWorkModel model)
        {

            ArtWork art = new ArtWork();

            art.ArtistId = model.ArtistId;
            art.ArtTypeId = model.ArtTypeId;
            art.YearId = model.YearId;

            dataService.ArtWorkService.AddNew(art);

            return View("ThankYou");
        }

    public ActionResult EditArtWork()
    {
        ArtWorkModel am = new ArtWorkModel();

        var artwork = dataService.ArtWorkService.FindBy(2);

        am.ArtWorkId = artwork.ArtId;

        am.YearList = dataService.YearPublishedService.YearList();
        am.YearId = artwork.YearId;

        am.ArtTypeList = dataService.ArtTypeService.ArtTypeList();
        am.ArtTypeId = artwork.ArtTypeId;

        am.ArtistList = dataService.ArtistService.ArtistList();
        am.ArtistId = artwork.ArtistId;

        return View(am);
    }

    [HttpPost]
    public ActionResult EditArtWork(ArtWorkModel model)
    {
        ArtWork am = new ArtWork();

        am.ArtId = model.ArtWorkId;

        //am.YearList = dataService.YearPublishedService.YearList();
        am.YearId = model.YearId;

        //am.ArtTypeList = dataService.ArtTypeService.ArtTypeList();
        am.ArtTypeId = model.ArtTypeId;

        //am.ArtistList = dataService.ArtistService.ArtistList();
        am.ArtistId = model.ArtistId;


        dataService.ArtWorkService.Edit(am);

        return View("ThankYou");
    }






    }
}
