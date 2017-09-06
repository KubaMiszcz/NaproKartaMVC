using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NaproKarta.Models.UserModel;


namespace NaproKarta.Models
{
   public class Chart:IEnumerable<Cycle>
   {
      [Key]
      public int ID { get; set; }
      public string Name { get; set; } = "";

      public int UserID { get; set; }
      public virtual User User { get; set; }

      public string Note { get; set; } = "";

      public virtual IList<Cycle> Cycles { get; set; }

      public Chart() { }

      public Chart(string str)
      {
         Name = str;
      }

      public IEnumerator<Cycle> GetEnumerator()
      {
         return Cycles.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.GetEnumerator();
      }


   }
}