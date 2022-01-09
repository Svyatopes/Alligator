using System.Collections.ObjectModel;
using Alligator.BusinessLayer.Models;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SupplyViewModel : BaseViewModel
    {
        
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        private ObservableCollection<SupplyDetailModel> _supplyDetails;

        public ObservableCollection<SupplyDetailModel> SupplyDetails
        {
            get { return _supplyDetails; }
            set
            {
                _supplyDetails = value;
                OnPropertyChanged(nameof(SupplyDetails));
            }
        }


        private SupplyModel _supply;

        public SupplyModel Supply
        {
            get { return _supply; }
            set
            {
                _supply = value;
                OnPropertyChanged(nameof(Supply));
            }
        }
        
    }
}
