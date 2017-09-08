using System;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;
using NaproKarta.Services;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   public class ObservationCellInChartVM : IVIewModel
   {
      public string Title { get; set; } = "Twoje Karty";
      public Observation Observation { get; set; }

      public int ID { get; set; } 
      public String MarkerUrl { get; set; } = "http://kubamiszcz.hekko24.pl/Naprokarta/markerNone.jpg";
      public String MarkerAltText { get; set; } = "none";
      public String Date { get; set; } = _blankSpace;
      public String Letter { get; set; } = _blankSpace;
      public bool LetterIsB { get; set; } 
      public String CipherAndCipherCD { get; set; } = _blankSpace;
      public String NumTimes { get; set; } = _blankSpace;
      public String Comments { get; set; } = _blankSpace;
      public IList<String> NoteMarks { get; set; } = new List<string>() { _blankSpace, _blankSpace, _blankSpace };
      public IList<string> NoteMarksBackgroundColors { get; set; } = new List<string>() { _blankSpace, _blankSpace, _blankSpace };
      public string RowCol { get; set; } = "";
      private static readonly string _blankSpace = "&nbsp;";

      public ObservationCellInChartVM()
      {
      }

      public ObservationCellInChartVM(Observation o) : this()
      {
         try
         {
            Observation = o;
            ID = o.ID;
            RowCol = o.Cycle.RowNumber + "," + o.ColNumber;

            MarkerUrl = o.Marker?.MarkerUrl??MyServices.MarkerNone.MarkerUrl;
            MarkerAltText = o.Marker?.Name??MyServices.MarkerNone.Name;

            Date = (o.Date.Year < 1990) ? _blankSpace : o.Date.ToString("MMM-dd");
            Letter = o.Letter?.ToString()??_blankSpace;
            Letter += o.LetterIsB? " B" : "";

            CipherAndCipherCD = o.Cipher?.ToString()??_blankSpace;
            CipherAndCipherCD += o.CipherCD?.ToString()??_blankSpace;

            NumTimes = o.NumTimes?.ToString()??_blankSpace;
            Comments = o.Comments;

            int i = 0;
            foreach (var note in o.Notes)
            {
               NoteMarks[i] = note.Content.Trim().Substring(0, 1).ToUpper();
               NoteMarksBackgroundColors[i] = note.IsImportant ? "background-color: blue; color: white;  " : "";
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