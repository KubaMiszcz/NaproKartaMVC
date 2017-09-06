using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;
using NaproKarta.ViewModels;
using NaproKarta.ViewModels.AuxiliaryVMs;
using WebGrease.Css.Ast;

namespace NaproKarta.ViewModels
{
   [NotMapped]
   public class ObservationEditVM : IVIewModel
   {
      //Form Field Data
      public string Title { get; set; } = "Edit Observation";
      public List<Marker> MarkersList { get; set; } = new List<Marker>();
      public List<List<string>> LettersTwoColumns { get; set; } = new List<List<string>>();
      public List<string> NumTimesList { get; set; } = new List<string>();
      public List<List<string>> CiphersTwoColumns { get; set; } = new List<List<string>>();
      public List<List<string>> CiphersCDTwoColumns { get; set; } = new List<List<string>>();

      //Observation instance Data
      public int ID { get; set; }
      public int Row { get; set; }
      public int Col { get; set; }
      public int MarkerID { get; set; }
      public DateTime Date { get; set; }
      public Letter Letter { get; set; }
      public Cipher Cipher { get; set; }
      public CipherCD CipherCD { get; set; }
      public NumTimes NumTimes { get; set; }
      public Dictionary<string, bool> CommentsVM { get; set; } = new Dictionary<string, bool>();
      public List<Note> NotesVM { get; set; } = new List<Note>();
      public List<String> NoteMarks { get; set; } = new List<string>();
      public List<string> NoteMarksBackgroundColors { get; set; } = new List<string>();

      //


      //public List<String> Marker { get; set; } = _blankSpace;
      //public String Date { get; set; } = _blankSpace;
      //public List<String> MarkerAltTextsList { get; set; } = _blankSpace;
      //public List<String> LettersTwoColumns { get; set; } = _blankSpace;
      //public List<String> NumTimesList { get; set; } = _blankSpace;
      //public List<String> CiphersTwoColumns { get; set; } = _blankSpace;
      //public List<String> CiphersCDlList { get; set; } = _blankSpace;
      //public String Comments { get; set; } = _blankSpace;

      private NaproKartaDAL db = new NaproKartaDAL();
      private static readonly string _blankSpace = "&nbsp;";
      private int numNotes = 3;

      public ObservationEditVM() { }

      public ObservationEditVM(NaproKartaDAL dbcontext)// : this()
      {
         db = dbcontext;
         MakeCleanForm();
      }

      public void MakeCleanForm()
      {
         //populate form field data descriptions
         Date=DateTime.Now;
         MarkersList = db.Markers.ToList();
         LettersTwoColumns = SplitList(db.LetterValues.Select(l => l.Value).ToList(), 3);
         NumTimesList = db.NumTimes.Select(l => l.Value).ToList();
         CiphersTwoColumns = SplitList(db.Ciphers.Select(l => l.Value).ToList(), 4);
         CiphersCDTwoColumns = SplitList(db.CiphersCD.Select(l => l.Value).ToList(), 4);
         CommentsVM.Add("Wizyta", false);
         CommentsVM.Add("Badania", false);
         CommentsVM.Add("Lupucupu", false);
         for (int i = 0; i < numNotes; i++)
         {
            NotesVM.Add(new Note(" "));
            NoteMarks.Add(" ");
            NoteMarksBackgroundColors.Add("");
         }
      }

      public void FillFormData(Observation o)
      {
         //current observation values
         MarkerID = o.Marker.ID;
         Date = o.Date;
         Letter = o.Letter;
         Cipher = o.Cipher;
         CipherCD = o.CipherCD;
         NumTimes = o.NumTimes;
         CommentsVM["Wizyta"] = o.Comments.Visit;
         CommentsVM["Badania"] = o.Comments.MedicalTest;
         CommentsVM["Lupucupu"] = o.Comments.Lupucupu;

         int i = 0;
         foreach (Note note in o.Notes)
         {
            NotesVM[i] = note;
            NoteMarks[i] = note.Content.Length<1?" ":note.Content.Substring(0, 1).ToUpper(); 
            NoteMarksBackgroundColors[i] = note.IsImportant ? "background-color: red; " : "";
         }
      }

      public void UpdateObservation(NaproKartaDAL db)
      {
         //Observation.MarkerID = MarkerID;
         //Observation.Date = DateTime.Parse(Date);
         ////db.Entry(Observation.Letter).State = EntityState.Modified;
         //db.Observations.Attach(Observation);
         //db.Ciphers.Attach(Observation.Cipher);
         //db.Entry(Observation.Cipher).State = EntityState.Modified;

         //bool anyCommentExists = false;
         //foreach (CommentsVM commentVm in CommentsVM)
         //{
         //   anyCommentExists = anyCommentExists || commentVm.Checked;
         //}
         //if (anyCommentExists)
         //{
         //   Comments comment = new Comments();
         //   comment.Visit = CommentsVM[0].Checked;
         //   comment.MedicalTest = CommentsVM[1].Checked;
         //   comment.Lupucupu = CommentsVM[2].Checked;
         //   Observation.Comments = comment;
         //}

         //List<Note> noteList=new List<Note>();
         //for (int i = 0; i < numNotes; i++)
         //{
         //   if (Observation.Notes[i].Content.Trim().IsEmpty()) {Observation.Notes.RemoveAt(i);}
         //   else
         //   {
         //      db.Entry(Observation.Notes[i]).State = EntityState.Modified;
         //   }
         //}
         //db.SaveChanges();

         //db.Entry(Observation).State = EntityState.Modified;
         //db.SaveChanges();
      }


      /// <summary>
      /// divide list, i: number of items put in first list A, the rest is moved to second list
      /// \n if i=-1 list is divided by half (first list rouded up eg 5 => 3+2)
      /// </summary>
      /// <param name="srcLst">source list</param>
      /// <param name="i">number items to remain in first list</param>
      private List<List<string>> SplitList(List<string> srcLst, int i = -1)
      {
         i = i < 0 ? (srcLst.Count / 2) + 1 : i;
         List<List<string>> result = new List<List<string>>();
         result.Add(srcLst.GetRange(0, i));
         result.Add(srcLst.GetRange(i, srcLst.Count - i));
         return result;
      }


   }
}