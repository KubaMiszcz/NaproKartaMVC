using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class LetterValue
   {
      [Key]
      public int ID { get; set; }
      public string Value { get; set; }


      public LetterValue() { }
      public LetterValue(string str)
      {
         Value = str;
      }
   }
}