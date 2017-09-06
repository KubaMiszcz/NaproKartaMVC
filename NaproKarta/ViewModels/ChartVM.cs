using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
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
      public Chart Chart { get; set; }
      public List<CycleVM> CyclesVM { get; set; } = new List<CycleVM>();
      public int PrevChartID { get; set; }

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
         for (int i = 0; i < NumCyclesInChart; i++)
         {
            CyclesVM.Add(new CycleVM());
         }
         SetRowColLabels();
         ColumnHeaders.Add("Notka");
         for (int k = 0; k < CyclesVM[0].NumObservationsInCycle; k++)
         {
            ColumnHeaders.Add((k+1).ToString());
         }
      }

      private void SetRowColLabels()
      {
         int row = 0;
         foreach (CycleVM cycleVm in CyclesVM)
         {
            int col = 0;
            foreach (ObservationCellVM cellVm in cycleVm.ObservationCellsVMList)
            {
               CyclesVM[row].ObservationCellsVMList[col].RowCol = row+","+col;
               col++;
            }
            row++;
         }
      }

      public ChartVM(User user, Chart chart) : this()
      {
         User = user;
         Chart = chart;
         PrevChartID = Chart.ID;
         foreach (Cycle cycle in Chart)
         {
            int k = cycle.RowNumber;
            foreach (Observation observation in cycle)
            {
               int i = observation.ColNumber;
               CyclesVM[k].ObservationCellsVMList[i] = (new ObservationCellVM(observation));
            }
         }
      }

      public void UpdateChart(Chart chart)
      {
         chart.Name = Chart.Name;
         chart.Note = Chart.Note;
         Chart = chart;
      }

      public void AddCycle(CycleVM cycleVm)
      {
         CyclesVM.Add(cycleVm);
      }
   }
}
