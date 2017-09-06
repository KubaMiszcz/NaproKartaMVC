using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   [NotMapped]
   public class CommentsVM
   {
      public Dictionary<string,bool> Comment { get; set; } = new Dictionary<string, bool>();
      public CommentsVM()
      {
         Comment.Add("Wizyta",false);
         Comment.Add("Badania", false);
         Comment.Add("Lupucupu", false);
      }
   }
}
