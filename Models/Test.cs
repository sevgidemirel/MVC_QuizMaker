using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SınavProjesi.Models
{
    public class Test
    {
        public int TestID { get; set; }
        [Display(Name="Başlık:")]
        [StringLength(255), Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Display(Name = "Açıklama:")]
        [MaxLength]
        [StringLength(255), Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}