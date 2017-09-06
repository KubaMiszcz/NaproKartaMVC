using NaproKarta.Models.ObservationModel;
using NaproKarta.Models.UserModel;

namespace NaproKarta.Migrations
{
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;
   using NaproKarta.Models;
   using System.Collections.Generic;

   internal sealed class Configuration : DbMigrationsConfiguration<NaproKarta.DataAccessLayer.NaproKartaDAL>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
      }
      protected override void Seed(NaproKarta.DataAccessLayer.NaproKartaDAL context)
      {
         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplcate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         #region seed embedded readonly values 
         //embedded values
         List<string> lstr = new List<string>() { "red", "green", "yellow", "whitebaby", "greenbaby", "yellowbaby", "grey" };
         List<string> lstr2 = new List<string>() {
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerRed.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreen.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellow.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerWhiteBaby.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellowBaby.jpg",
            "http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGrey.jpg" };

         foreach (string item in lstr) {
            int i = lstr.IndexOf(item);
            context.Markers.AddOrUpdate(p => p.Name, new Marker(item, lstr2.ElementAt(i))); }
         
         lstr = new List<string>() { "B", "C", "C/K", "G", "L", "P", "Y", "\"P\"" };
         foreach (string item in lstr) { context.CiphersCD.AddOrUpdate(p => p.Value, new CipherCD(item)); }

         lstr = new List<string>() { "0", "2", "2W", "4", "6", "8", "10", "10DL", "10SL", "10WL" };
         foreach (string item in lstr) { context.Ciphers.AddOrUpdate(p => p.Value, new Cipher(item)); }

         lstr = new List<string>() { "M", "H", "L", "VL", "VVL" };
         foreach (string item in lstr) { context.LetterValues.AddOrUpdate(p => p.Value, new LetterValue(item)); }

         lstr = new List<string>() { "X1", "X2", "X3", "AD" };
         foreach (string item in lstr) { context.NumTimes.AddOrUpdate(p => p.Value, new NumTimes(item)); }

         lstr = new List<string>() { "admin", "user", "instructor" };
         foreach (string item in lstr) { context.Roles.AddOrUpdate(p => p.Name, new Role(item)); }
         #endregion

         #region seed example data
         //context.Users.AddOrUpdate(p => new {p.Login=("admin", "p", "adminname", "admin@email.com", new DateTime(), new DateTime(), new Role("admin"))};
         //context.Users.AddOrUpdate(p => new Users("ula", "p", "Ula Slodziuchna", "ula@email.com", new DateTime(), new DateTime(), new Role("user")));
         //context.Users.AddOrUpdate(p => new Users("instr1", "p", "Insztruktori Numero Uno", "instr1@email.com", new DateTime(), new DateTime(), new Role("instructor")));


         #endregion

      }
   }
}
