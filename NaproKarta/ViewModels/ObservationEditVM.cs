using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;
using NaproKarta.ViewModels;
using NaproKarta.ViewModels.AuxiliaryVMs;
using WebGrease.Css.Ast;
using NaproKarta.Services;

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
      //public int ID { get; set; }
      //public int Row { get; set; }
      //public int Col { get; set; }
      //public int MarkerID { get; set; }
      //public DateTime Date { get; set; }
      //public Letter Letter { get; set; }
      //public Cipher Cipher { get; set; }
      //public CipherCD CipherCD { get; set; }
      //public NumTimes NumTimes { get; set; }
      public int? MarkerID { get; set; }
      public List<string> CommentsDescriptons { get; set; } = new List<string>();
      public List<Note> NotesVM { get; set; } = new List<Note>();
      public List<String> NoteMarks { get; set; } = new List<string>();
      public List<string> NoteMarksBackgroundColors { get; set; } = new List<string>();
      //public String DisableIf6x8x10xIsSelected { get; set; } = "";
      public Observation Observation { get; set; } = new Observation();
      public Chart Chart { get; set; }
      public int Row { get; set; }
      public int Col { get; set; }

      private NaproKartaDAL db=new NaproKartaDAL();
      private static readonly string _blankSpace = "&nbsp;";
      private int numNotes = 3;

      public ObservationEditVM()
      {
         CommentsDescriptons = MyServices.CommentsDescriptions;
         PopulateFormLabels();
      }

      public ObservationEditVM(int row, int col) : this()
      {
         //db = dbContext;
         Row = row;
         Col = col;
      }

      public void PopulateFormLabels()
      {
         //populate form field data descriptions
         Observation.Date = DateTime.Now;
         MarkersList = MyServices.MarkersList;
         LettersTwoColumns = SplitList(MyServices.LettersList.Select(x => x.ToString()).ToList(), 3);
         NumTimesList = MyServices.NumTimesList.Select(x => x.ToString()).ToList();
         CiphersTwoColumns = SplitList(MyServices.CiphersList.Select(l => l.ToString()).ToList(), 4);
         CiphersCDTwoColumns = SplitList(MyServices.CiphersCDlList.Select(l => l.ToString()).ToList(), 4);
         for (int i = 0; i < numNotes; i++)
         {
            NotesVM.Add(new Note(" "));
            NoteMarks.Add(" ");
            NoteMarksBackgroundColors.Add("");
         }
      }

      public void FillFormDataFromExistedObservation(Observation o)
      {
         //current observation values
         Observation = o;
         for (int i = 0; i < Observation.Notes.Count; i++)
         {
            Note note = Observation.Notes[i];
            NotesVM[i] = note;
            NoteMarks[i] = note.Content.Length < 1 ? " " : note.Content.Trim().Substring(0, 1).ToUpper();
            NoteMarksBackgroundColors[i] = note.IsImportant ? "background-color: red; " : "";
         }
      }

      public void UpdateObservation()
      {
         Observation observationToUpdate = db.Observations.Include(o => o.Notes).SingleOrDefault(i => i.ID == Observation.ID);
         if (observationToUpdate is null) //observation doesnt exist
         {
            Cycle cycle = Chart?.Cycles?.SingleOrDefault(c => c.RowNumber == Row);
            if (cycle is null)//cycle doesnt eixst
            {
               cycle = new Cycle();
               cycle.RowNumber = Row;
               Chart.AddCycle(cycle);
               db.Cycles.Add(cycle);
               db.SaveChanges();//xx
            }
            observationToUpdate=new Observation();
            cycle.AddObservation(observationToUpdate);
            db.Observations.Add(observationToUpdate);
            db.SaveChanges();//xx
         }
         //xx db.SaveChanges();

         //update fields
         observationToUpdate.ColNumber = Col;
         if (MarkerID !=null)
         {
            observationToUpdate.MarkerID = MyServices.MarkersList.SingleOrDefault(l => l.ID == MarkerID)?.ID;
         }
         observationToUpdate.Date = Observation.Date;
         observationToUpdate.LetterID = MyServices.LettersList.SingleOrDefault(l => l.Value == Observation.Letter?.Value)?.ID;
         observationToUpdate.LetterIsB = Observation.LetterIsB;
         observationToUpdate.CipherID = MyServices.CiphersList.SingleOrDefault(l => l.Value == Observation.Cipher?.Value)?.ID;
         observationToUpdate.CipherCDID = MyServices.CiphersCDlList.SingleOrDefault(l => l.Value == Observation.CipherCD?.Value)?.ID;
         observationToUpdate.NumTimesID = MyServices.NumTimesList.SingleOrDefault(l => l.Value == Observation.NumTimes?.Value)?.ID;
         observationToUpdate.CommentVisit = Observation.CommentVisit;
         observationToUpdate.CommentMedicalTest = Observation.CommentMedicalTest;
         observationToUpdate.CommentLupucupu = Observation.CommentLupucupu;
         
         NotesVM=NotesVM.OrderBy(x=>x.Content).ToList();
         Observation.Notes=Observation.Notes?.OrderBy(x => x.Content).ToList();
         foreach (Note note in NotesVM
         ) //todo: przeorb bo usuwanie notek kilku usuwa tylko jedna, potestuj kombinacje i zrob jako dwie tablice itp notek...
         {
            int i = NotesVM.IndexOf(note);
            Note noteToUpdate = observationToUpdate.Notes?.ElementAtOrDefault(i);
            if ((note.Content?.Trim()).IsNullOrEmpty()) //user wrotes nothing
            {
               if (noteToUpdate.IsNotNull()) //note exist=>to delete
               {
                  db.Notes.Remove(noteToUpdate);
                  db.SaveChanges(); //xx
               }
            }
            else //user wrotes sth
            {
               if (noteToUpdate.IsNotNull()) //note exist=> update
               {
                  noteToUpdate.Content = note.Content.Trim(); //update note
                  noteToUpdate.IsImportant = note.IsImportant;
                  db.Entry(noteToUpdate).State = EntityState.Modified;
                  db.SaveChanges(); //xx
                  db.Entry(observationToUpdate).State = EntityState.Modified;
                  db.SaveChanges(); //xx
               }
               else //note doesnt exist=> create and add
               {
                  observationToUpdate.AddNote(note); //if user wrote sth
                  db.Notes.Add(note);
                  db.SaveChanges(); //xx
               }
            }
         }

         //db.SaveChanges();
         db.Entry(observationToUpdate).State = EntityState.Modified;
         db.SaveChanges();
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