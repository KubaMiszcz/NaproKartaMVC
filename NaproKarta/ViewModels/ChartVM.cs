using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web.Mvc;
using NaproKarta.DataAccessLayer;
using NaproKarta.Models;
using NaproKarta.Models.UserModel;
using NaproKarta.ViewModels.AuxiliaryVMs;

namespace NaproKarta.ViewModels
{
   [NotMapped]
   public class ChartVM : IVIewModel
   {
      public string Title { get; set; } = "";
      public IList<string> ColumnHeaders { get; set; }=new List<string>();
      public User User { get; set; }
      public Chart Chart { get; set; }=new Chart();
      public List<CycleVM> CyclesVM { get; set; } = new List<CycleVM>();

      public List<SelectListItem> UserChartNames
      {
         get
         {
            List<SelectListItem> slst = new List<SelectListItem>();
            foreach (Chart chart in User.Charts)
            {
               slst.Add(new SelectListItem
               {
                  Value = chart.ID.ToString(),
                  Text = chart.Name
               });
            }
            return slst;
         }
      }

      //private static readonly string _blankSpace = "&nbsp;";
      private int NumCyclesInChart { get; set; } = 5;

      public ChartVM()
      {
         MakeClearChart();
         SetRowColLabelsForCellsInView();
         Make1stRowWithHeaders();
      }
      
      public ChartVM(User user, Chart chart) : this()
      {
         User = user;
         Chart = chart;
         FillChartWithValues();
      }

      public void UpdateChart(Chart chart)
      {
         chart.Name = Chart.Name;
         chart.Note = Chart.Note;
         Chart = chart;
      }

      private void MakeClearChart()
      {
         for (int i = 0; i < NumCyclesInChart; i++)
         {
            CyclesVM.Add(new CycleVM());
         }
      }

      private void Make1stRowWithHeaders()
      {
         ColumnHeaders.Add("Notka");
         for (int k = 0; k < CyclesVM[0].NumObservationsInCycle; k++)
         {
            ColumnHeaders.Add((k + 1).ToString());
         }
      }

      private void SetRowColLabelsForCellsInView()
      {
         int row = 0;
         foreach (CycleVM cycleVm in CyclesVM)
         {
            int col = 0;
            foreach (ObservationCellInChartVM cellVm in cycleVm.ObservationCellsVMList)
            {
               CyclesVM[row].ObservationCellsVMList[col].RowCol = row + "," + col;
               col++;
            }
            row++;
         }
      }

      private void FillChartWithValues()
      {
         foreach (Cycle cycle in Chart)
         {
            int k = cycle.RowNumber;
            foreach (Observation observation in cycle)
            {
               int i = observation.ColNumber;
               try
               {
                  CyclesVM[k].ObservationCellsVMList[i] = (new ObservationCellInChartVM(observation));
               }
               catch (Exception e)
               {
                  Console.WriteLine(e);
                  throw;
               }
            }
         }
      }
   }




}
