using System;
using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class CipherCD
   {
      [Key]
      public int ID { get; set; }
      public String Value { get; set; }
      public CipherCD() { }
      public CipherCD(String str)
      {
         Value = str;
      }
      public override string ToString()
      {
         return Value??"";
      }
   }
}