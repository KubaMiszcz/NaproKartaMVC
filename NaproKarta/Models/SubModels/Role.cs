using System.ComponentModel.DataAnnotations;

namespace NaproKarta.Models.UserModel
{
   public class Role
   {
      [Key]
      public int ID { get; set; }
      [Required]
      public string Name { get; set; }
      public Role() { }
      public Role(string str)
      {
         Name = str;
      }

   }
}