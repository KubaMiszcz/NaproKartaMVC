using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.ObservationModel

{
   public class Picture
   {
      [Key]
      public int ID { get; set; }
      [Required]
      public string Name { get; set; }
      [DataType(DataType.ImageUrl)]
      public string PictureUrl { get; set; }

      public int ObservationID { get; set; }
      public virtual Observation Observation { get; set; }

      public Picture(string name, string url)
      {
         Name = name;
         PictureUrl = url;
      }
      public Picture() { }
      public override string ToString()
      {
         return Name;
      }
   }
}


