using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        StellerAcunMedyaDbEntities db = new StellerAcunMedyaDbEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia SocialMedia)
        {

            db.TblSocialMedia.Add(SocialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia SocialMedia)
        {
            var value = db.TblSocialMedia.Find(SocialMedia.SocialMediaId);
            value.SocialMediaName = SocialMedia.SocialMediaName;
            value.Icon=SocialMedia.Icon;
            value.Url=SocialMedia.Url;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}