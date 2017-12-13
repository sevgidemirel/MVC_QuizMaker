using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SınavProjesi.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        //      [Required(ErrorMessage = "Lütfen soruyu giriniz.")]
        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string QuestionExam { get; set; }
       
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }
}