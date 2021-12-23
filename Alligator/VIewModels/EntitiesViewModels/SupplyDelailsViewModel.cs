using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class SupplyDelailsViewModel : BaseViewModel
    {

        private int _id;
        private int _amount;
        private ProductViewModel _product;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public ProductViewModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
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
