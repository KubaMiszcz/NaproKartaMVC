using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaproKarta.Services
{
   public static class MyServices
   {
      public static int? CurrentlyLoggedUser { get; set; }
      public static Dictionary<int,int> PrevChartsOfUsers { get; set; }=new Dictionary<int, int>();

   }
}