using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SınavProjesi.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Text { get; set; }
        public bool Correct { get; set; }

        public virtual Question Question { get; set; }
    }
}