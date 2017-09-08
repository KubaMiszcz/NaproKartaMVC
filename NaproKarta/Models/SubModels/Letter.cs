using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class Letter
   {
      [Key]
      public int ID { get; set; }
      public string Value { get; set; }
      public Letter() { }

      public Letter(string str)
      {
         Value = str;
      }
      public override string ToString()
      {
         return Value??" ";
      }
   }
}

