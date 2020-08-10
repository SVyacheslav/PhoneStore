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
   
    public class CartController : Controller
    {
        private IPhoneRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IPhoneRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        [Authorize]
        public RedirectToRouteResult AddToCart(Cart cart, int phoneId, string returnUrl)
        {
            Phone phone = repository.Phones
                .FirstOrDefault(p => p.PhoneId == phoneId);

            if (phone != null)
            {
                cart.AddItem(phone, 1);        
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [Authorize]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int phoneId, string returnUrl)
        {
            Phone phone = repository.Phones
                .FirstOrDefault(p => p.PhoneId == phoneId);

            if (phone != null)
            {
                cart.RemoveLine(phone);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [Authorize]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}