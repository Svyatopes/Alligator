using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SupplyViewModel : INotifyPropertyChanged
    {
        private int _id;
        private ObservableCollection<SupplyDelailsViewModel> _supplyDetails;
        private ObservableCollection<SuppliesViewModel> _supplies;
        
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
        public ObservableCollection<SuppliesViewModel> Supplies
        {
            get { return _supplies; }
            set
            {
                _supplies = value;
                OnPropertyChanged(nameof(Supplies));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
