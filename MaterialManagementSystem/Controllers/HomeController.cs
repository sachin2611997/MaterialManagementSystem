using MaterialManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;

namespace MaterialManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        DbEntity db = new DbEntity();

        public class RandomViewModel
        {
            public  List<Indent> Indents { get; set; }
            public List<string> SplitIndent { get; set; }
        }
        // GET: Home
        [HttpGet]
        public ActionResult IndentList()
        {

            List<Indent> list = db.Indents.Where(x => x.IsActive == 1).ToList();

            ViewBag.done = db.Indents.Where(x => x.Status == "Done" && x.IsActive == 1).Count();
            ViewBag.pending = db.Indents.Where(x => x.Status == "Pending" && x.IsActive == 1).Count();
            ViewBag.cancle = db.Indents.Where(x => x.Status == "Cancle" && x.IsActive == 1).Count();
            ViewBag.total = db.Indents.Where(x => x.IsActive == 1).Count();

          //  var lists = list.Select(x => x.Item.Split(',')).ToList();
            //ViewData["listss"] = lists.ToList();
          


            return View(list);
            
        } 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Indent indent)
        {
            db.Indents.Add(indent);
         //   indent.SourceFund = "1340-PRST_";
            indent.IsActive = 1;
            db.SaveChanges();
            return RedirectToAction("IndentList");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Indent indent = db.Indents.Single(x => x.Id == id);
            return View(indent);
        }

        [HttpPost]
        public ActionResult Edit(Indent indent)
        {
            Indent ind = db.Indents.Where(x => x.Id == indent.Id).FirstOrDefault();
            ind.IndentDate = indent.IndentDate;
            ind.Item = indent.Item;
            ind.Description = indent.Description;
            ind.ItemCode = indent.ItemCode;
            ind.SourceFund = indent.SourceFund;
            ind.Quantity = indent.Quantity;
            ind.ReceivedDate = indent.ReceivedDate;
            ind.Status = indent.Status;
            UpdateModel(ind);
            db.SaveChanges();
            return RedirectToAction("IndentList");
        }

        public ActionResult Details(int id)
        {
            Indent indent = db.Indents.Where(x => x.Id == id).FirstOrDefault();
            return View(indent);
        }

        public ActionResult Delete(int id)
        {
          Indent ind=  db.Indents.Where(x => x.Id == id).FirstOrDefault();
            ind.IsActive = 0;
            UpdateModel(ind);
            db.SaveChanges();
            return RedirectToAction("IndentList");
        }

       



    }
}