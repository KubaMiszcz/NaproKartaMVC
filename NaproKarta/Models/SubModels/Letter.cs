using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class Letter
   {
      [Key]
      public int ID { get; set; }

      public int ValueID { get; set; }
      public virtual LetterValue Value { get; set; }

      public bool IsB { get; set; }

      private static readonly string _blankSpace = "&nbsp;";

      public Letter() { }
      public override string ToString()
      {
         return (Value is null) ? "" : Value.Value; //) + (IsB ? "B" : "");
      }
   }
}

