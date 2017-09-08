using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.Models.UserModel;
using NaproKarta.Services;
using NaproKarta.ViewModels;
using Newtonsoft.Json;

namespace NaproKarta.Controllers
{
   public class ObservationController : MyController
   {
      private NaproKartaDAL db = new NaproKartaDAL();
      private User currentUser => Session["currentUser"] as User;
      private int CurrentChartId => (int)Session["currentChartID"];


      // GET: ObservationCellsVMList/Edit/5
      public ActionResult Edit(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         //todo:queystring
         var RowCol = Request.QueryString.GetValues("RowCol")?.ToList();
         if (RowCol is null)
         {
            return MyError("no rowcol");
         }

         int row = Convert.ToInt16(RowCol[0].Split(',')[0]);
         int col = Convert.ToInt16(RowCol[0].Split(',')[1]);

         //Session["field0"] = "value1";
         ////string field1 = (string)(Session["field0"]);
         //Session["field1"] = obs;
         //Session["field2"] = Json(obs);
         //Session["field3"] = JsonConvert.SerializeObject(obs, Formatting.Indented,new JsonSerializerSettings{
         //      ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
         //   PreserveReferencesHandling = PreserveReferencesHandling.Objects
         //});

         try
         {
            ObservationEditVM vm = new ObservationEditVM(db, row, col);
            Observation obs = db.Observations.Find(id);
            if (obs != null) vm.FillFormDataFromExistedObservation(obs);
            //Chart chart = Session["currentChart"] as Chart;
            //ObservationEditVM vm = new ObservationEditVM(db, chart, row, col);
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
      [HttpPost, ActionName("Edit")]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(ObservationEditVM vm, string button)
      {
         if (button == "Save")//todo:popraw to zeby nie zalezlo od jezyka moze jaki enum albo cos, i if/else a nie same ify
         {
            if (ModelState.IsValid)
            {
               if (vm.Chart is null) vm.Chart = currentUser.Charts.SingleOrDefault(c => c.ID == CurrentChartId);
               vm.UpdateObservation(new Observation());
            }
         }
         else if (button == "Delete")//todo:popraw to zeby nie zalezlo od jezyka moze jaki enum albo cos, i if/else a nie same ify
         { //todo: dorob delete observation i reset form w JS, i przenies do kontrolera USER
            return RedirectToAction("DeleteObservation", "User", new { id = currentUser.ID, chartId = CurrentChartId });
         }
         else if (button == "Reset")
         {
            return RedirectToAction("ResetForm", "User", new { id = currentUser.ID, chartId = CurrentChartId });
         }
         return RedirectToAction("Chart", "User", new { id = currentUser.ID, chartId = CurrentChartId });
         //return View(vm);
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

