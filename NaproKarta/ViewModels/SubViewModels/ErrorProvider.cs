using System.Collections.Generic;
using System.Collections.ObjectModel;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   public class ErrorProvider:IVIewModel
   {
      public string Title { get; set; } = "Error";
      public ICollection<string> Messages { get; set; }=new Collection<string>();

      public ErrorProvider(string message="")
      {
         Messages.Add(message);
      }

      public ErrorProvider(ICollection<string> messages)
      {
         foreach (string message in messages)
         {
            Messages.Add(message);
         }
      }

      public override string ToString()
      {
         string str="";
         foreach (string s in Messages)
         {
            str += (s+"\n");
         }
         return str;
      }
   }
}