using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class NumTimes
   {
      [Key]
      public int ID { get; set; }
      public string Value { get; set; }
      public NumTimes() { }
      public NumTimes(string str)
      {
         Value = str;
      }
      public override string ToString()
      {
         return Value;
      }
   }
}