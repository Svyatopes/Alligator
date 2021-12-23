using System.Collections.ObjectModel;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SupplyViewModel : BaseViewModel
    {
        private int _id;
        private ObservableCollection<SupplyDelailsViewModel> _supplyDetails;
        private SupplyViewModel _supply;
        
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public ObservableCollection<SupplyDelailsViewModel> SupplyDetails
        {
            get { return _supplyDetails; }
            set
            {
                _supplyDetails = value;
                OnPropertyChanged(nameof(SupplyDetails));
            }
        }
        public SupplyViewModel Supply
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
