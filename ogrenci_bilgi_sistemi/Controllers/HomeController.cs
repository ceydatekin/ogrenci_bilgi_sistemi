using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ogrenci_bilgi_sistemi.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ogrenci_bilgi_sistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var ogrenciRepository = new ogrenciRepository();
            var ogrenciList = ogrenciRepository.GetAll();

            var ogretmenRepo = new ogretmenRepository();
            var ogretmenList = ogretmenRepo.GetAll();

            var dersrepo = new dersRepository();
            var derlist = dersrepo.GetAll();

            var viewModel = new OgretmenOgrenciViewModel();

            viewModel.ogrenciList = ogrenciList.ToList();
            viewModel.ogretmenList = ogretmenList.ToList();
            viewModel.derList = derlist.ToList();



            //ViewBag.liste = ogrenciList;
            return View(viewModel);
        }

        public IActionResult listele()
        {
            var ogrenciRepository = new ogrenciRepository();
            var ogrenciList = ogrenciRepository.GetAll();

            var ogretmenRepo = new ogretmenRepository();
            var ogretmenList = ogretmenRepo.GetAll();

            var dersrepo = new dersRepository();
            var derlist = dersrepo.GetAll();

            var viewModel = new OgretmenOgrenciViewModel();

            viewModel.ogrenciList = ogrenciList.ToList();
            viewModel.ogretmenList = ogretmenList.ToList();
            viewModel.derList = derlist.ToList();
            return View(viewModel);
        } 
        //[HttpPost]
        //[Route("api/ders/ekle")]
        //public string ekle(string ad)
        //{
        //    try
        //    {

        //        return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler" });
        //    }
        //    catch (Exception)
        //    {
        //        return JsonConvert.SerializeObject(new { success = false });
        //    }
        //}
    }

    public class OgretmenOgrenciViewModel
    {
        public List<Models.Ogrenci> ogrenciList = new List<Models.Ogrenci>();
        public List<Models.Ogretman> ogretmenList = new List<Models.Ogretman>();
        public List<Models.Der> derList = new List<Models.Der>();

    }
   
}
