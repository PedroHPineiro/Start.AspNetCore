using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.ViewModels
{
    public class OrderInputModel
    {
        [Required(ErrorMessage = "Vendor is required")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Items is required")]
        
        public Dictionary<string, int> Items { get; set; }
    }
}