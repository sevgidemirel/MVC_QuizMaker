using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SınavProjesi.Context;
using System.Data.Entity;

namespace SınavProjesi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz!")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Parolayı Giriniz!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola:")]
        public string Password { get; set; }
    }

}