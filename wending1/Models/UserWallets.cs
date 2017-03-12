using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wending1.Models
{
    public class UserWallets
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя пользователя")]
        [MaxLength(50, ErrorMessage = "Превышена длина")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Монеты по 1 рублю")]
        public int? Coins1 { get; set; }
        [Required]
        [Display(Name = "Монеты по 2 рубля")]
        public int? Coins2 { get; set; }
        [Required]
        [Display(Name = "Монеты по 5 рублей")]
        public int? Coins5 { get; set; }
        [Required]
        [Display(Name = "Монеты по 10 рублей")]
        public int? Coins10 { get; set; }
    }
}