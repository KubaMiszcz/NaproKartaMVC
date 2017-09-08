using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;


namespace NaproKarta.Models
{
   public class Cycle : IEnumerable<Observation>
   {
      [Key]
      public int ID { get; set; }
      public string Note { get; set; } = "&nbsp;";
      public float MCS { get; set; }

      public int ChartID { get; set; }
      public virtual Chart Chart { get; set; }
      public int RowNumber { get; set; }

      public virtual IList<Observation> Observations { get; set; }

      public Cycle() { }

      public IEnumerator<Observation> GetEnumerator()
      {
         return Observations.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.GetEnumerator();
      }

      public void AddObservation(Observation observation)
      {
         observation.CycleID = ID;
         if (Observations is null)Observations = new List<Observation>();
         Observations.Add(observation);
      }
   }
}