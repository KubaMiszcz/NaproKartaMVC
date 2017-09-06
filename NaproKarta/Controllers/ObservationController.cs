using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.ViewModels;
using Newtonsoft.Json;

namespace NaproKarta.Controllers
{
   public class ObservationController : MyController
   {
      private NaproKartaDAL db = new NaproKartaDAL();
      // GET: ObservationCellsVMList/Edit/5
      public ActionResult Edit(int? id, string RowCol)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         //todo:queystring
         if (RowCol == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         int row = Convert.ToInt16(RowCol.Split(',')[0]);
         int col = Convert.ToInt16(RowCol.Split(',')[1]);
         Session["field0"] = "value1";
         //string field1 = (string)(Session["field0"]);

         Observation obs = db.Observations.Find(id);
         Session["field1"] = obs;
         Session["field2"] = Json(obs);
         Session["field3"] = JsonConvert.SerializeObject(obs, Formatting.Indented,new JsonSerializerSettings{
               ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
         });

         try
         {
            ObservationEditVM vm=new ObservationEditVM(db);
            if (obs != null) vm.FillFormData(obs);
            return View(vm);
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // POST: ObservationCellsVMList/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost,ActionName("Edit")]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(ObservationEditVM observationVM, string button)
      {
         if (button == "Save")
         {
            if (ModelState.IsValid)
            {
               observationVM.UpdateObservation(db);
              // db.Observations.Attach(observationVM.Observation);
              // db.Entry(observationVM.Observation).State = EntityState.Modified;
              // db.SaveChanges();
              //* return RedirectToAction("Chart","User", new {id = observationVM.UserID});
            }
         }
         if (button=="Cancel")
         {
           //* return RedirectToAction("Chart", "User", new { id = observationVM.UserID });
         }
         
         return View(observationVM);
      }





      //############################################################

      // GET: ObservationCellsVMList
      public ActionResult Index()
      {
         //ObservationVM vm = new ObservationVM(db);
         return View();
      }

      // GET: ObservationCellsVMList/Details/5
      public ActionResult Details(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Observation observation = db.Observations.Find(id);
         if (observation == null)
         {
            return HttpNotFound();
         }
         return View(observation);
      }

      // GET: ObservationCellsVMList/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: ObservationCellsVMList/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "ID,Date,PeakNum")] Observation observation)
      {
         if (ModelState.IsValid)
         {
            db.Observations.Add(observation);
            db.SaveChanges();
            return RedirectToAction("Index");
         }

         return View(observation);
      }


      // GET: ObservationCellsVMList/Edit/5
      public ActionResult Edit2(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Observation observation = db.Observations.Find(id);
         if (observation == null)
         {
            return HttpNotFound();
         }
         return View(observation);
      }


      // GET: ObservationCellsVMList/Delete/5
      public ActionResult Delete(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Observation observation = db.Observations.Find(id);
         if (observation == null)
         {
            return HttpNotFound();
         }
         return View(observation);
      }

      // POST: ObservationCellsVMList/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         Observation observation = db.Observations.Find(id);
         db.Observations.Remove(observation);
         db.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            db.Dispose();
         }
         base.Dispose(disposing);
      }
   }
}

