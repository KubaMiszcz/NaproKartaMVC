using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaproKarta.Models.UserModel
{
   public class User
   {
      [Key]
      public int ID { get; set; }

      //[Required(ErrorMessage = "Error")]
      public string Login { get; set; }

      public string Password { get; set; }

      //[StringLength(255, MinimumLength = 3)] NOSPACES
      public string UserName { get; set; }

      [DataType(DataType.EmailAddress)]
      public string Email { get; set; }

      //[Required]
      [DataType(DataType.Date)]
      public DateTime RegisterDate { get; set; }

      //[Required]
      [DataType(DataType.Date)]
      public DateTime LastLoginDate { get; set; }

      //[Required]
      public int RoleID { get; set; }
      public Role Role { get; set; }

      public virtual IList<Chart> Charts { get; set; }

      public string Note { get; set; } = "";
      public User() { }

      public User(string v1, string v2, string v3, string v4, DateTime dateTime1, DateTime dateTime2, Role role)
      {
         Login = v1;
         Password = v2;
         UserName = v3;
         Email = v4;
         RegisterDate = dateTime1;
         LastLoginDate = dateTime2;
         Role = role;
      }

      public void AddChart(Chart chart)
      {
         chart.UserID = ID;
         if (Charts is null)Charts=new List<Chart>();
         Charts.Add(chart);
      }
   }
}