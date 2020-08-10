using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Domain.Interface;
using PhoneStore.Domain.Entities;


namespace PhoneStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IPhoneRepository repository;

        public AdminController(IPhoneRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Phones);
        }

        public ViewResult Create()
        {
            return View("Edit", new Phone());
        }

        public ViewResult Edit(int phoneId = 1)
        {
            Phone phone = repository.Phones
                .FirstOrDefault(p => p.PhoneId == phoneId);
            return View(phone);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Phone phone, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    phone.ImageMimeType = image.ContentType;
                    phone.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(phone.ImageData, 0, image.ContentLength);
                }
                repository.SavePhone(phone);
                TempData["message"] = string.Format("Изменения в данных о товаре \"{0}\" были сохранены", phone.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(phone);
            }
        }

        [HttpPost]
        public ActionResult Delete(int phoneId)
        {
            Phone deletedPhone = repository.DeletePhone(phoneId);
            if (deletedPhone != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedPhone.Name);
            }
            return RedirectToAction("Index");
        }
    }
}