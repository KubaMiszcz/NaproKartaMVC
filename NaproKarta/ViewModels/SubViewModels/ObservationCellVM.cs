using System;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   public class ObservationCellVM : IVIewModel
   {
      public string Title { get; set; } = "Twoje Karty";
      public Observation Observation { get; set; }

      public int ID { get; set; } 
      public String MarkerUrl { get; set; } = "http://kubamiszcz.hekko24.pl/Naprokarta/markerNone.jpg";
      public String MarkerAltText { get; set; } = "none";
      public String Date { get; set; } = _blankSpace;
      public String Letter { get; set; } = _blankSpace;
      public String CipherAndCipherCD { get; set; } = _blankSpace;
      public String NumTimes { get; set; } = _blankSpace;
      public String Comments { get; set; } = _blankSpace;
      public IList<String> NoteMarks { get; set; } = new List<string>() { _blankSpace, _blankSpace, _blankSpace };
      public IList<string> NoteMarksBackgroundColors { get; set; } = new List<string>() { _blankSpace, _blankSpace, _blankSpace };
      public string RowCol { get; set; } = "";
      private static readonly string _blankSpace = "&nbsp;";

      public ObservationCellVM()
      {
      }

      public ObservationCellVM(Observation o) : this()
      {
         try
         {
            Observation = o;
            ID = o.ID;
            RowCol = o.Cycle.RowNumber + "," + o.ColNumber;

            MarkerUrl = o.Marker.MarkerUrl;
            MarkerAltText = o.Marker.Name;

            Date = (o.Date.Year < 1990) ? _blankSpace : o.Date.ToString("MMM-dd");
            Letter = o.Letter.IfNotNull(l => l.ToString(), _blankSpace);
            Letter += o.Letter.IfNotNull(l => l.IsB ? " B" : "");

            CipherAndCipherCD = o.Cipher.IfNotNull(l => l.ToString(), _blankSpace);
            CipherAndCipherCD += o.CipherCD.IfNotNull(l => _blankSpace + l.ToString(), _blankSpace);

            NumTimes = o.NumTimes.IfNotNull(l => l.ToString(), _blankSpace);
            Comments = o.Comments.IfNotNull(l => l.ToString(), _blankSpace);

            int i = 0;
            foreach (var note in o.Notes)
            {
               NoteMarks[i] = note.Content.Substring(0, 1).ToUpper();
               NoteMarksBackgroundColors[i] = note.IsImportant ? "background-color: red;  " : "";
               i++;
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }
   }
}