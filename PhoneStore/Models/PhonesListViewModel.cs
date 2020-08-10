using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Domain.Entities;

namespace PhoneStore.Models
{
    public class PhonesListViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentManufacturer { get; set; }
    }
}