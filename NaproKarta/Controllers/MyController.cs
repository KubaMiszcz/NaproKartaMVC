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
   public abstract class MyController : Controller
   {
      protected virtual ActionResult MyError(string message)
      {
         ErrorProvider err = new ErrorProvider(message);
         return View("Error", err);
      }

      protected virtual ActionResult MyError(ICollection<string> messages)
      {
         ErrorProvider err = new ErrorProvider(messages);
         return View("Error", err);
      }
   }
}
