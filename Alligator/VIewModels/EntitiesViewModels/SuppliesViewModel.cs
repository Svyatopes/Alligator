using System.Collections.Generic;
using Alligator.BusinessLayer.Models;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SuppliesViewModel //: BaseViewModel
    {
        public List<SupplyDetailModels> SupplyDetail { get; set; }

        //private string _synchronizedText;
        //public string SynchronizedText
        //{
        //    get => _synchronizedText;
        //    set
        //    {
        //        _synchronizedText = value;
        //        OnPropertyChanged(nameof(SynchronizedText));
        //    }
        //}
    }
}
