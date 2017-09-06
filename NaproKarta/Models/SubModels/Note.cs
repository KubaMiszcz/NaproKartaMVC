using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaproKarta.Models.ObservationModel
{
   public class Note
   {
      [Key]
      public int ID { get; set; }
      public string Content { get; set; } = "&nbsp;";
      public bool IsImportant { get; set; }

      public int ObservationID { get; set; }
      public virtual Observation Observation { get; set; }

      public Note() { }
      public Note(string str, bool val=false):this()
      {
         Content = str;
         IsImportant = val;
      }
   }
}