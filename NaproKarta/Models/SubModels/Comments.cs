using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel
{
   public class Comments
   {
      [Key]
      public int ID { get; set; }
      public bool Visit { get; set; }
      public bool MedicalTest { get; set; }
      public bool Lupucupu { get; set; }
      private static readonly string _blankSpace = "&nbsp;";

      public Comments() { }
      public Comments(bool v1, bool v2, bool v3)
      {
         Visit = v1;
         MedicalTest = v2;
         Lupucupu = v3;
      }

      public override string ToString()
      {
         return (Visit ? "W" + _blankSpace : _blankSpace + _blankSpace)
            + (MedicalTest ? "B" + _blankSpace : _blankSpace + _blankSpace)
            + (Lupucupu ? "I" + _blankSpace : _blankSpace + _blankSpace);
      }
   }
}