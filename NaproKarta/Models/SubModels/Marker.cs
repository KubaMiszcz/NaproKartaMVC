using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace NaproKarta.Models.ObservationModel
{
   public class Marker
   {
      [Key]
      public int ID { get; set; }
      [Required]
      public string Name { get; set; } = "none";
      [DataType(DataType.ImageUrl)]
      public string MarkerUrl { get; set; } = "http://kubamiszcz.hekko24.pl/Naprokarta/markerNone.jpg";
      //public virtual Observation Parent { get; set; } //foreign key to Parent
      public Marker() { }
      public Marker(string name, string url)
      {
         Name = name;
         MarkerUrl = url;
      }
      public override string ToString()
      {
         return Name;
      }
   }
}