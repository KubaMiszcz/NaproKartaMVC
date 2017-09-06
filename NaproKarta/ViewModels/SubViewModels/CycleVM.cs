using System.Collections.Generic;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;

namespace NaproKarta.ViewModels.AuxiliaryVMs
{
   public class CycleVM : IVIewModel
   {
      public string Title { get; set; } = "";
      public Cycle Cycle { get; set; }
      public List<ObservationCellVM> ObservationCellsVMList { get; set; } = new List<ObservationCellVM>();
      public int NumObservationsInCycle { get; set; } = 35;
      private int NumWeeksInCycle { get; set; }
      public CycleVM()
      {
         NumWeeksInCycle = NumObservationsInCycle / 7;
         for (int i = 0; i < NumObservationsInCycle; i++)
         {
            ObservationCellsVMList.Add(new ObservationCellVM());
         }
      }
      public CycleVM(Cycle cycle) : this()
      {
         Cycle = cycle;
      }

   }
}