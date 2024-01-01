using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models.ViewModels
{
    public class GirisVM
    {       
        [Required]
        [Display(Name = "E-posta Adresi")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]       
        public string Sifre { get; set; }
    }
}
