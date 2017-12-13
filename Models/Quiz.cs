using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SınavProjesi.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string QuestionExam { get; set; }
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
        //public SelectList QuizList { get; set; }

    }
}