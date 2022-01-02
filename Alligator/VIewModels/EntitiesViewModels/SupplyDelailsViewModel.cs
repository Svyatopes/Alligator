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
    }
}
