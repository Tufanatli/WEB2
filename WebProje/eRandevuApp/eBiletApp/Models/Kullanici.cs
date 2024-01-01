using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class Kullanici:IdentityUser
    {
        [Display(Name= "ADI SOYADI")]
        public string AdSoyad { get; set; }
    }
}
