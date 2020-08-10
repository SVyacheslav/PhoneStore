using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите область")]
        [Display(Name = "Область")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Укажите район")]
        [Display(Name = "Район")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Укажите город / населенный пункт")]
        [Display(Name = "Город / Населенный пункт")]
        public string City { get; set; }

        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        [Display(Name = "Первый адрес")]
        public string Line1 { get; set; }

        [Display(Name = "Второй адрес")]
        public string Line2 { get; set; }

        [Display(Name = "Третий адрес")]
        public string Line3 { get; set; }    
        
        public bool GiftWrap { get; set; }
    }
}
