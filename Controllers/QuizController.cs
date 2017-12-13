using SınavProjesi.Context;
using SınavProjesi.Models;
using SınavProjesi.RSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SınavProjesi.Controllers
{
    public class QuizController : Controller
    {
        ExamContext db = new ExamContext();
        List<Item> lastNews;
        [HttpGet]
        public ActionResult Create()
        {
          
                lastNews = RSSHelper.read();
                Quiz q = new Quiz();
                List<Quiz> qList = new List<Quiz>();

                for (int i = 0; i < 16; i++)
                {
                    q = new Quiz();
                    qList.Add(q);
                }



                #region wired title atanması
                SelectList list = new SelectList(lastNews, "Title", "Title");
                ViewBag.Title = list;
                #endregion


                #region şıkların atanması
                List<SelectListItem> items = new List<SelectListItem>();
                SelectListItem item1 = new SelectListItem() { Text = "A", Value = "0" };
                SelectListItem item2 = new SelectListItem() { Text = "B", Value = "1" };
                SelectListItem item3 = new SelectListItem() { Text = "C", Value = "2" };
                SelectListItem item4 = new SelectListItem() { Text = "D", Value = "3" };

                items.Add(item1);
                items.Add(item2);
                items.Add(item3);
                items.Add(item4);

                ViewBag.Option = items;

                #endregion
                return View(qList);
        }

        [HttpPost]
        public ActionResult Create(List<Quiz> quiz, FormCollection form)
        {
            lastNews = RSSHelper.read();
            string Options = form["Option"].ToString();
            string Title = form["Title"].ToString();
            Item item = lastNews.Where(x => x.Title == Title).FirstOrDefault();

            Test t = new Test();
            Answer a;
            Question q;

            t.Name = Title;
            t.Description = item.Description;
            db.Tests.Add(t);
            db.SaveChanges();
            for (int i = 0; i <= 12; i += 4)
            {
                q = new Question();
                q.QuestionExam = quiz[i].QuestionExam;
                q.Test = t;
                db.Questions.Add(q);
                db.SaveChanges();

                switch (i)
                {
                    case 0:
                        for (int j = 0; j < 4; j++)
                        {
                            a = new Answer();
                            a.Text = quiz[j].AnswerText;
                            a.Question = q;
                            a.Correct = CalculateCorrect(Options, i, j);
                            db.Answers.Add(a);
                            db.SaveChanges();
                        }
                        break;

                    case 4:
                        for (int j = 4; j < 8; j++)
                        {
                            a = new Answer();
                            a.Text = quiz[j].AnswerText;
                            a.Question = q;
                            a.Correct = CalculateCorrect(Options, i, j);
                            db.Answers.Add(a);
                            db.SaveChanges();
                        }
                        break;

                    case 8:
                        for (int j = 8; j < 12; j++)
                        {
                            a = new Answer();
                            a.Text = quiz[j].AnswerText;
                            a.Question = q;
                            a.Correct = CalculateCorrect(Options, i, j);
                            db.Answers.Add(a);
                            db.SaveChanges();
                        }
                        break;

                    case 12:
                        for (int j = 12; j < 16; j++)
                        {
                            a = new Answer();
                            a.Text = quiz[j].AnswerText;
                            a.Question = q;
                            a.Correct = CalculateCorrect(Options, i, j);
                            db.Answers.Add(a);
                            db.SaveChanges();
                        }
                        break;

                    default:
                        break;
                }

            }
            return RedirectToAction("Create");

        }

        public JsonResult GetTitleDescription(string title)
        {

            List<Item> lastNews = RSSHelper.read();

            Item snc = lastNews.Where(x => x.Title == title).FirstOrDefault();

            var results = new List<Item>()
        {
            new Item{ Description = snc.Description}
        }.ToList();

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public bool CalculateCorrect(string options, int i, int j)
        {
            string[] option = options.Split(',');


            for (int y = 0; y < 4; y++)
            {
                if (y * 4 == i)//hangi soruda
                {
                    if (Convert.ToInt32(option[y]) % 4 == j % 4)//hangi şıkta
                    {
                        return true;
                    }

                }
            }

            return false;

        }

        [HttpGet]
        public ActionResult Solve()
        {
            Test t = db.Tests.OrderByDescending(u => u.TestID).FirstOrDefault();
            return View(t);
        }


    }
}
