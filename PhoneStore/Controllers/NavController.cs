using PhoneStore.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Controllers
{
    public class NavController : Controller
    {
        private IPhoneRepository repository;

        public NavController(IPhoneRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string manufacturer = null)
        {
            ViewBag.SelectedManufacturer = manufacturer;
            IEnumerable<string> manufacturers = repository.Phones
                .Select(phone => phone.Manufacturer)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(manufacturers);
        }
    }
}