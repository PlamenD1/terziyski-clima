using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerziyskiClima.Models.ProductViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на продукта е задължително")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Цената на продукта е задължителна")]
        [Range(0, double.MaxValue, ErrorMessage = "Цената не може да е под 0 лева")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Описанието на продукта е задължително")]
        public string Description { get; set; }
    }
}
