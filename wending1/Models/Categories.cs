using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wending1.Models
{
    public class Categories
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Категория товара")]
        [MaxLength(50, ErrorMessage = "Превышена длина")]
        public string Name { get; set; }
    }
}