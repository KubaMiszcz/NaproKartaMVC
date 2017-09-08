using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.Services
{
   public static class MyServices
   {
      public static List<Marker> MarkersList;
      public static List<Letter> LettersList;
      public static List<Cipher> CiphersList;
      public static List<CipherCD> CiphersCDlList;
      public static List<NumTimes> NumTimesList;
      public static List<string> CommentsDescriptions;


      //public static int? CurrentlyLoggedUser { get; set; }
      //public static Dictionary<int,int> PrevChartsOfUsers { get; set; }=new Dictionary<int, int>();
      public static Marker MarkerNone = new Marker { MarkerUrl = "http://kubamiszcz.hekko24.pl/Naprokarta/markerNone.jpg", Name = "none" };

      public static void PopulateEmbeddedDataFromDatabase(NaproKartaDAL db)
      {
         MarkersList = db.Markers.ToList();
         LettersList = db.Letters.ToList();
         CiphersList = db.Ciphers.ToList();
         CiphersCDlList = db.CiphersCD.ToList();
         NumTimesList = db.NumTimes.ToList();
         CommentsDescriptions = new List<string>();
         CommentsDescriptions.Add("Wizyta");
         CommentsDescriptions.Add("Badania");
         CommentsDescriptions.Add("Lupucupu");
      }
   }


}