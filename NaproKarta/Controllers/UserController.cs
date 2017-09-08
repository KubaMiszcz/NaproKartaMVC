using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;
using NaproKarta.Models.UserModel;
using NaproKarta.Services;
using NaproKarta.ViewModels;
using NaproKarta.ViewModels.AuxiliaryVMs;
using Newtonsoft.Json;

//todo: zeby marker image tez zmienal koor po najechaniu krusorem
//todo:CRUD notek do cykli, gdzie?
//todo:przenies do kontrolera USER i zrob jeden kontroler
//todo:note is important update nie dziala dodaj
//todo:W CSS albo JS, zmiana stylu radiobutton zeby klinkite mialy rounded corner i zielony kolor 
//todo:ziana cipherscd szary lables jak nei aktywne i uchcek all
//todo:dopisac pekanumber obok obrazkow
//todo:zaznaczanie obrazka po wczytaniu edit
//todo:kolorownaie radioboxow jak zanzaczone
//todo:szare ciphersCD jak niea,tywnne
//todo:paginacja chartow
//todo:
//todo:




namespace NaproKarta.Controllers
{
   public class UserController : MyController
   {
      private NaproKartaDAL db = new NaproKartaDAL();
      private User currentUser
      {
         get => Session["currentUser"] as User;
         set => Session["currentUser"] = value;
      }
      private int currentChartId
      {
         get => (int)Session["currentChartID"];
         set => Session["currentChartID"] = value;
      }

      // GET: Users
      public ActionResult Chart(int? id, int? chartId)
      {
         if (id is null) return MyError("no user id"); //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

         User user = db.Users.Find(id);
         if (user is null)return MyError("No user with this ID!"); //return HttpNotFound();
         
         ////todo:############### develop login procedure ##################################
         /// implement and move later, load embedded data
         currentUser = user;
         MyServices.PopulateEmbeddedDataFromDatabase(db);
         ///##############################################

         try
         {
            Chart chart = new Chart();
            if (currentUser.Charts is null) return MyError("this user has no charts");
            else
            {
               if (chartId is null) chart = currentUser.Charts.LastOrDefault(); //no chart selected => show last chart
               else
               {
                  chart = currentUser.Charts.SingleOrDefault(c => c.ID == chartId);
                  if (chart is null) return MyError(new Collection<string>() { "there is no chart with this ID", "or this chart not belongs to this user" });
               }
            }

            // ReSharper disable once PossibleNullReferenceException
            currentChartId = chart.ID;//
            ChartVM vm = new ChartVM(currentUser, chart);
            return View(vm);
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // GET: Users/Create
      public ActionResult CreateChart()
      {
         try
         {
            ChartVM vm = new ChartVM {User = currentUser};
            return View(vm);
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // POST: Users/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult CreateChart(ChartVM vm, string button)
      {
         if (button == "Cancel")
         {
            return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
         }
         else
         {
            if (ModelState.IsValid)
            {
               try
               {
                  vm.User = currentUser;
                  vm.User.AddChart(vm.Chart);
                  db.Charts.Add(vm.Chart);
                  db.SaveChanges();
                  currentChartId = vm.Chart.ID;
                  return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
               }
               catch (Exception e)
               {
                  Console.WriteLine(e);
                  throw;
               }
            }
         }

         return View(vm);
      }

      // GET: Users/ObservationEdit/5
      public ActionResult EditChart()
      {
         try
         {

            ChartVM vm = new ChartVM();
            vm.User = currentUser;
            vm.Chart = currentUser.Charts.Single(c => c.ID == currentChartId);
            return View(vm);
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // POST: Users/ObservationEdit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult EditChart(ChartVM vm, string button)
      {
         if (button == "Cancel")
         {
            return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
         }
         if (ModelState.IsValid)
         {
            try
            {
               Chart chart = currentUser.Charts.Single(c => c.ID == currentChartId);
               vm.UpdateChart(chart);
               db.Entry(vm.Chart).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
               throw;
            }
         }
         return View(vm);
      }

      // GET: Users/Delete/5
      public ActionResult DeleteChart(int? chartId)
      {
         if (chartId == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         try
         {
            ChartVM vm = new ChartVM();
            vm.Chart = db.Charts.Find(chartId);
            if (vm.Chart == null)
            {
               return HttpNotFound();
            }
            return View(vm);
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // POST: Users/Delete/5
      [HttpPost, ActionName("DeleteChart")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteChart(ChartVM vm, string button)
      {
         if (button == "Cancel")
         {
            return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
         }
         try
         {
            Chart chart = currentUser.Charts.Single(c => c.ID == vm.Chart.ID);
            if (chart == null) { return HttpNotFound(); }
            db.Entry(chart).State = EntityState.Deleted;
            db.SaveChanges();
            //var toDelete = new Chart() { ID = vm.Chart.ID };
            //db.Charts.Attach(toDelete);
            //db.Charts.Remove(toDelete);
            //db.SaveChanges();

            currentChartId = currentUser.Charts.LastOrDefault().ID;
            return RedirectToAction("Chart", new { id = currentUser.ID, chartId = currentChartId });
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      // GET: ObservationCellsVMList/ObservationEdit/5
      public ActionResult ObservationEdit(int? id)
      {
         if (id == null) return MyError("no user id"); //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         if (Request.QueryString.IsNull()) return MyError("no querystring");

         //todo:queystring
         var RowCol = Request.QueryString.GetValues("RowCol")?.ToList();
         if (RowCol is null)return MyError("no rowcol");

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
            ObservationEditVM vm = new ObservationEditVM(row, col);
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

      // POST: ObservationCellsVMList/ObservationEdit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost, ActionName("ObservationEdit")]
      [ValidateAntiForgeryToken]
      public ActionResult ObservationEdit(ObservationEditVM vm, string button)
      {
         if (button == "Save")//todo:popraw to zeby nie zalezlo od jezyka moze jaki enum albo cos, i if/else a nie same ify
         {
            if (ModelState.IsValid)
            {
               if (vm.Chart is null) vm.Chart = currentUser.Charts.SingleOrDefault(c => c.ID == currentChartId);
               vm.UpdateObservation();
            }
            else return MyError("Modelstate isnt valid");
         }
         else if (button == "Delete")//todo:popraw to zeby nie zalezlo od jezyka moze jaki enum albo cos, i if/else a nie same ify
         { //todo: dorob delete observation i reset form w JS, i przenies do kontrolera USER
            return RedirectToAction("DeleteObservation", "User", new { id = currentUser.ID, chartId = currentChartId });
         }
         else if (button == "Reset")
         {
            return RedirectToAction("ResetForm", "User", new { id = currentUser.ID, chartId = currentChartId });
         }
         return RedirectToAction("Chart", "User", new { id = currentUser.ID, chartId = currentChartId });
         //return View(vm);
      }


      public ActionResult DeleteObservation(int id, int chartid)
      {

         return MyError("delete observtion here");
      }

      public ActionResult ResetForm(int id, int chartid)
      {
         return MyError("reset form JS here");
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
