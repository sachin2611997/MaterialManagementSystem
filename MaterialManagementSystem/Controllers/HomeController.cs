using MaterialManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaterialManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        DbEntity db = new DbEntity();
        // GET: Home
        [HttpGet]
        public ActionResult IndentList()
        {
            List<Indent> list = db.Indents.ToList();
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
            db.SaveChanges();
            return RedirectToAction("IndentList");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
          Indent indent=  db.Indents.Single(x => x.Id == id);
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
    }
}