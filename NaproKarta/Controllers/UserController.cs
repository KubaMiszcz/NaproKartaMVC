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
//todo:
//todo:
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
         if (id is null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         User user = db.Users.Find(id);
         if (user is null)
         {
            return MyError("No user with this ID!");
            //return HttpNotFound();
         }
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

      // GET: Users/Edit/5
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

      // POST: Users/Edit/5
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

      //public ActionResult EditObservation(int? id)
      //{
      //   if (id == null)
      //   {
      //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //   }

      //   //todo:queystring
      //   var RowCol = Request.QueryString.GetValues("RowCol")?.ToString();
      //   if (RowCol is null)
      //   {
      //      return MyError("no rowcol");
      //   }

      //   int row = Convert.ToInt16(RowCol.Split(',')[0]);
      //   int col = Convert.ToInt16(RowCol.Split(',')[1]);


      //   //if (RowCol == null)
      //   //{
      //   //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //   //}
      //   //int row = Convert.ToInt16(RowCol.Split(',')[0]);
      //   //int col = Convert.ToInt16(RowCol.Split(',')[1]);
      //   Session["field0"] = "value1";
      //   //string field1 = (string)(Session["field0"]);

      //   Observation obs = db.Observations.Find(id);
      //   Session["field1"] = obs;
      //   Session["field2"] = Json(obs);
      //   Session["field3"] = JsonConvert.SerializeObject(obs, Formatting.Indented, new JsonSerializerSettings
      //   {
      //      ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
      //      PreserveReferencesHandling = PreserveReferencesHandling.Objects
      //   });

      //   try
      //   {
      //      ObservationEditVM vm = new ObservationEditVM(db);
      //      if (obs != null) vm.FillFormDataFromExistedObservation(obs);
      //      return View(vm);
      //   }
      //   catch (Exception e)
      //   {
      //      Console.WriteLine(e);
      //      throw;
      //   }
      //}

      //// POST: ObservationCellsVMList/Edit/5
      //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public ActionResult EditObservation(ObservationEditVM observationVM, string button)
      //{
      //   if (button == "Save")
      //   {
      //      if (ModelState.IsValid)
      //      {
      //         observationVM.UpdateObservation(db);
      //         // db.Observations.Attach(observationVM.Observation);
      //         // db.Entry(observationVM.Observation).State = EntityState.Modified;
      //         // db.SaveChanges();
      //         //* return RedirectToAction("Chart","User", new {id = observationVM.UserID});
      //      }
      //   }
      //   if (button == "Cancel")
      //   {
      //      //* return RedirectToAction("Chart", "User", new { id = observationVM.UserID });
      //   }

      //   return View(observationVM);
      //}

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            db.Dispose();
         }
         base.Dispose(disposing);
      }

      #region ####################################################################################
      //// GET: Users
      //public ActionResult Index()
      //{
      //   return View(db.Users.ToList());
      //}


      //// GET: Users/Details/5
      //public ActionResult Details(int? id)
      //{
      //   if (id == null)
      //   {
      //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //   }
      //   User user = db.Users.Find(id);
      //   if (user == null)
      //   {
      //      return HttpNotFound();
      //   }
      //   return View(user);
      //}

      //// GET: Users/Create
      //public ActionResult Create()
      //{
      //   return View();
      //}

      //// POST: Users/Create
      //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public ActionResult Create([Bind(Include = "ID,UserName,Email,RegisterDate,LastLoginDate")] User user)
      //{
      //   if (ModelState.IsValid)
      //   {
      //      db.Users.Add(user);
      //      db.SaveChanges();
      //      return RedirectToAction("Index");
      //   }

      //   return View(user);
      //}

      //// GET: Users/Edit/5
      //public ActionResult Edit(int? id)
      //{
      //   if (id == null)
      //   {
      //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //   }
      //   User user = db.Users.Find(id);
      //   if (user == null)
      //   {
      //      return HttpNotFound();
      //   }
      //   return View(user);
      //}

      //// POST: Users/Edit/5
      //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public ActionResult Edit([Bind(Include = "ID,UserName,Email,RegisterDate,LastLoginDate")] User user)
      //{
      //   if (ModelState.IsValid)
      //   {
      //      db.Entry(user).State = EntityState.Modified;
      //      db.SaveChanges();
      //      return RedirectToAction("Index");
      //   }
      //   return View(user);
      //}

      //// GET: Users/Delete/5
      //public ActionResult Delete(int? id)
      //{
      //   if (id == null)
      //   {
      //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //   }
      //   User user = db.Users.Find(id);
      //   if (user == null)
      //   {
      //      return HttpNotFound();
      //   }
      //   return View(user);
      //}

      //// POST: Users/Delete/5
      //[HttpPost, ActionName("Delete")]
      //[ValidateAntiForgeryToken]
      //public ActionResult DeleteConfirmed(int id)
      //{
      //   User user = db.Users.Find(id);
      //   db.Users.Remove(user);
      //   db.SaveChanges();
      //   return RedirectToAction("Index");
      //}
      #endregion

      public ActionResult DeleteObservation(int id, int chartid)
      {
         return MyError("delete observtion here");
      }

      public ActionResult ResetForm(int id, int chartid)
      {
         return MyError("reset form JS here");
      }
   }
}
