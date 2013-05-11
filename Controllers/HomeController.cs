using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkLayer.Models;
using RepoInfrastructure;
using Domain.Entities.DTOS;
using DataServices;
using Collector.Models;


namespace Collector.Controllers
{
    public class HomeController : Controller
    {

        //private IRepository<Artist> artistRepository;

        private DataService dataService;


        public HomeController(DataService dataService)
        {

            this.dataService = dataService;
        }
        public ActionResult Index()
        {


            //ArtType assarttype = new ArtType();
            //assarttype.Category = "Rock";
            //dataService.ArtTypeService.AddArtType(assarttype);

            //ArtType assarttype1 = new ArtType();
            //assarttype1.Category = "Impressionist";
            //dataService.ArtTypeService.AddArtType(assarttype1);

            //Artist artist = new Artist();
            //artist.ArtistFirstName = "tommy";
            //artist.ArtistLastName = "pellegrino";
            //dataService.ArtistService.AddNew(artist);


            ////dataService.YearPublishedService.AddYears();


            //ArtWork artwork = new ArtWork();

            //Artist artists = new Artist();
            //int artistId = artists.ArtistId = 2;
            //artwork.ArtistId = artistId;

            //ArtType arttype = new ArtType();
            //int arttypeid = arttype.ArtTypeId = 2;
            //artwork.ArtTypeId = arttypeid;

            //YearPublished year = new YearPublished();
            //int yearId = year.YearId = 5;
            //artwork.YearId = yearId;

            //dataService.ArtWorkService.AddNew(artwork);
            //ArtistModel am = new ArtistModel();

            
           var temp = dataService.ArtWorkService.FindBy(2);
           string firstname = temp.Artist.ArtistFirstName;
           string lastname = temp.Artist.ArtistLastName;
            

           //var T = dataService.ArtistService.FindBy(7);

            HomeModel hm = new HomeModel();
           
            hm.ArtistFirstName = firstname;
            hm.ArtistLastName = lastname;


            //ViewBag.Message = T.ArtistFirstName + " " + T.ArtistLastName;


           

            var artrep = dataService.ArtistService.FindBy(x => x.ArtistFirstName == firstname);
           //var artrep = artistRepository.FilterBy(x => x.ArtistFirstName == T.ArtistFirstName);
           hm.ArtistCount = artrep.Count();
            return View(hm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
