using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Domain.Interface;
using PhoneStore.Domain.Entities;
using PhoneStore.Models;


namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 4;
        private IPhoneRepository repository;
        public HomeController(IPhoneRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string manufacturer, int page = 1)
        {
            PhonesListViewModel model = new PhonesListViewModel
            {
                Phones = repository.Phones
                    .Where(p => manufacturer == null || p.Manufacturer == manufacturer)
                    .OrderBy(phone => phone.PhoneId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = manufacturer == null ?
                repository.Phones.Count() :
                repository.Phones.Where(phone => phone.Manufacturer == manufacturer).Count()
                },
                CurrentManufacturer = manufacturer
            };
            return View(model);
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileContentResult GetImage(int phoneId)
        {
            Phone phone = repository.Phones
                .FirstOrDefault(g => g.PhoneId == phoneId);

            if (phone != null)
            {
                return File(phone.ImageData, phone.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
    }
}