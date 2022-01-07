using Alligator.BusinessLayer.Models;

namespace Alligator.UI.VIewModels.EntitiesViewModels
    
{
    public class SupplyDelailsViewModel : BaseViewModel
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


        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }


        private ProductModel _product;

        public ProductModel Product
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
