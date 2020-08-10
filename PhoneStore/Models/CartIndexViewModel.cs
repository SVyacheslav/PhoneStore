using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Domain.Entities;

namespace PhoneStore.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}