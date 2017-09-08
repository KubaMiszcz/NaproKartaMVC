using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.Models
{
   public class Observation
   {
      [Key]
      public int ID { get; set; }

      public int CycleID { get; set; }
      public virtual Cycle Cycle { get; set; }

      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      public DateTime Date { get; set; }=new DateTime(1950,1,1);

      public int? MarkerID { get; set; }
      public virtual Marker Marker { get; set; }

      public int? LetterID { get; set; }
      public virtual Letter Letter { get; set; }

      public bool LetterIsB { get; set; }

      public int? CipherID { get; set; }
      public virtual Cipher Cipher { get; set; }

      public int? CipherCDID { get; set; }
      public virtual CipherCD CipherCD { get; set; }

      public int? NumTimesID { get; set; }
      public virtual NumTimes NumTimes { get; set; }

      public string Comments => (CommentVisit ? "W" + _blankSpace : _blankSpace + _blankSpace)
                                + (CommentMedicalTest ? "B" + _blankSpace : _blankSpace + _blankSpace)
                                + (CommentLupucupu ? "I" + _blankSpace : _blankSpace + _blankSpace);

      public bool CommentVisit { get; set; }
      public bool CommentMedicalTest { get; set; }
      public bool CommentLupucupu { get; set; }

      public virtual IList<Note> Notes { get; set; }

      public virtual IList<Picture> Pictures { get; set; }

      public int ColNumber { get; set; }

      public int PeakNum { get; set; } = -1;

      private static readonly string _blankSpace = "&nbsp;";

      public Observation(){}

      public void AddNote(Note note)
      {
         note.ObservationID= ID;
         note.Content = note.Content.Trim();
         if (Notes is null) Notes = new List<Note>();
         Notes.Add(note);
      }
   }
}
