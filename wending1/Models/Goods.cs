using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wending1.Models
{
    public class Goods
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название товара")]
        [MaxLength(50, ErrorMessage = "Превышена длина")]
        public string Name { get; set; }
        [Display(Name = "Категория товара")]
        public int? CategoryId { get; set; }
        public Categories Category { get; set; }
        [Required]
        [Display(Name = "Цена товара")]
        public int? Price { get; set; }
    }
}