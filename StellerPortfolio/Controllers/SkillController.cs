using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SkillController : Controller
    {
        StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();

        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkill skill)
        {
           
            db.TblSkill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill skill)
        {
            var value = db.TblSkill.Find(skill.SkillId);

            value.SkillName= skill.SkillName;
            value.Title= skill.Title;
            value.Value= skill.Value;
            value.Description= skill.Description;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}