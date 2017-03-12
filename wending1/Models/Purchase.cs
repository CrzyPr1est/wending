using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wending1.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Display(Name = "Товар")]
        public int GoodsId { get; set; }
        public Goods Good { get; set; }
    }
}