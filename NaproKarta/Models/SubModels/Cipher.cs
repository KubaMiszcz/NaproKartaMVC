using System;
using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class Cipher
   {
      [Key]
      public int ID { get; set; }
      public String Value { get; set; }
      public Cipher() { }
      public Cipher(String str)
      {
         Value = str;
      }

      public override string ToString()
      {
         return Value;
      }
   }
}