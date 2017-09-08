using System.Collections.Generic;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   public class CycleVM : IVIewModel
   {
      public string Title { get; set; } = "";
      public Cycle Cycle { get; set; }
      public List<ObservationCellInChartVM> ObservationCellsVMList { get; set; } = new List<ObservationCellInChartVM>();
      public int NumObservationsInCycle { get; set; } = 35;
      private int NumWeeksInCycle { get; set; }
      public CycleVM()
      {
         NumWeeksInCycle = NumObservationsInCycle / 7;
         MakeCleanCycle();
      }

      public CycleVM(Cycle cycle) : this()
      {
         Cycle = cycle;
      }

      private void MakeCleanCycle()
      {
         for (int i = 0; i < NumObservationsInCycle; i++)
         {
            ObservationCellsVMList.Add(new ObservationCellInChartVM());
         }
      }

   }
}