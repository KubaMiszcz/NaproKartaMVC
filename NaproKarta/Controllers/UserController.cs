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
using NaproKarta.Models.UserModel;
using NaproKarta.Services;
using NaproKarta.ViewModels;
using NaproKarta.ViewModels.AuxiliaryVMs;


namespace NaproKarta.Controllers
{
   public class UserController : MyController
   {
      private NaproKartaDAL db = new NaproKartaDAL();

      //private string errorMessage{get { return ViewBag.ErrorMessage; }set { ViewBag.ErrorMessage = value; }}

      private int? currentUserId
      {
         get => MyServices.CurrentlyLoggedUser;
         set => MyServices.CurrentlyLoggedUser = value;
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

         try
         {
            Chart chart = new Chart();
            if (user.Charts is null) return MyError("this user has no charts");
            else
            {
               if (chartId is null) chart = user.Charts.LastOrDefault(); //no chart selected => show last chart
               else
               {
                  chart = user.Charts.SingleOrDefault(c => c.ID == chartId);
                  if (chart is null) return MyError(new Collection<string>() { "there is no chart with this ID", "or this chart not belongs to this user" });
               }
            }

            currentUserId = id;
            ChartVM vm = new ChartVM(user, chart);
            prevChartID(user.ID, chart.ID);
            Session["prevChartID"] = chart.ID;//TODO: ogarnij session=> prevchartID
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
            ChartVM vm = new ChartVM();
            vm.User = db.Users.Find(currentUserId);
            vm.PrevChartID = prevChartID((int)currentUserId);
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
            int prevChartId = (int)Session["prevChartID"];
            return RedirectToAction("Chart", new { id = vm.User.ID, chartId = prevChartID((int)currentUserId) });
         }
         else
         {
            if (ModelState.IsValid)
            {
               try
               {
                  vm.User = db.Users.Find(currentUserId);
                  vm.User.Charts.Add(vm.Chart);
                  db.SaveChanges();
                  return RedirectToAction("Chart", new { id = vm.User.ID, chartId = vm.Chart.ID });
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
      public ActionResult EditChart(int? chartId)
      {
         if (chartId == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         try
         {
            ChartVM vm = new ChartVM();
            vm.Chart = db.Charts.Find(chartId);
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
            return RedirectToAction("Chart", new { id = currentUserId, chartId = vm.Chart.ID });
         }
         if (ModelState.IsValid)
         {
            try
            {
               Chart chart = db.Charts.Find(vm.Chart.ID);
               if (chart == null)
               {
                  return HttpNotFound();
               }
               vm.UpdateChart(chart);
               db.Entry(vm.Chart).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Chart", new { id = currentUserId, chartId = vm.Chart.ID });
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
            return RedirectToAction("Chart", new { id = currentUserId, chartId = vm.Chart.ID });
         }
         try
         {
            Chart chart = db.Charts.Find(vm.Chart.ID);
            if (chart == null)
            {
               return HttpNotFound();
            }
            db.Charts.Remove(chart);
            db.SaveChanges();
            int chartId = db.Users.Find(currentUserId).Charts.LastOrDefault().ID;
            return RedirectToAction("Chart", new { id = currentUserId, chartId });
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }

      }

      private int prevChartID(int userId)
      {
         try
         {
            return MyServices.PrevChartsOfUsers[userId];
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      private int prevChartID(int userId, int chartId)
      {
         try
         {
            return MyServices.PrevChartsOfUsers[userId] = chartId;
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

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
   }
}
