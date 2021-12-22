
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Alligator.UI.VIewModels.EntitiesViewModels;
using System.Windows.Controls.Primitives;
using Alligator.UI.TabItems;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemSuppliesViewModel : BaseViewModel
    {
        public TabItemSuppliesViewModel()
        {
            Supplies = new ObservableCollection<SuppliesViewModel>();
            NewSupplies = new ObservableCollection<SuppliesViewModel>();
            //NewSupplies.RemoveAll();
            Products = new ObservableCollection<ProductViewModel>();
            NewProducts = new ObservableCollection<ProductViewModel>();
            //WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            //WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            StateMainDataGrid = true;
        }


        private ObservableCollection<SuppliesViewModel> _supplies;
        private ObservableCollection<SuppliesViewModel> _newSupplies;
        private ObservableCollection<ProductViewModel> _products;
        private ObservableCollection<ProductViewModel> _newproducts;
        private DateTime _textBoxNewDateText;
        private int _textBoxNewAmountText;
        private int _textBoxNewIdText;
        private string _textBoxNewProductText;

        public ObservableCollection<SuppliesViewModel> Supplies
        {
            get { return _supplies; }
            set
            {
                _supplies = value;
                OnPropertyChanged(nameof(Supplies));
            }
        }
        public ObservableCollection<SuppliesViewModel> NewSupplies
        {
            get { return _newSupplies; }
            set
            {
                _newSupplies = value;
                OnPropertyChanged(nameof(NewSupplies));
            }
        }
        public ObservableCollection<ProductViewModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public ObservableCollection<ProductViewModel> NewProducts
        {
            get { return _newproducts; }
            set
            {
                _newproducts = value;
                OnPropertyChanged(nameof(NewProducts));
            }
        }
        private SuppliesViewModel _selected;
        public SuppliesViewModel Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
        private ProductViewModel _pselected;
        public ProductViewModel PSelected
        {
            get { return _pselected; }
            set
            {
                _pselected = value;
                OnPropertyChanged(nameof(PSelected));
            }
        }
        public DateTime TextBoxNewDateText
        {
            get 
            {
                return _textBoxNewDateText; 
            }
            set
            {
                _textBoxNewDateText = value;
                OnPropertyChanged(nameof(TextBoxNewDateText));
            }
        }
        public int TextBoxNewIdText
        {
            get 
            {
                return _textBoxNewIdText; 
            }
            set
            {
                _textBoxNewIdText = value;
                OnPropertyChanged(nameof(TextBoxNewIdText));
            }
        }
                
        public int TextBoxNewAmountText
        {
            get { return _textBoxNewAmountText; }
            set
            {
                _textBoxNewAmountText = value;
                OnPropertyChanged(nameof(TextBoxNewAmountText));
            }
        }
        private GridLength _supplyWindow;

        public GridLength SupplyWindow
        {
            get { return _supplyWindow; }
            set
            {
                _supplyWindow = value;
                OnPropertyChanged(nameof(SupplyWindow));
            }
        }
        private GridLength _allSupplyWindow;

        public GridLength AllSupplyWindow
        {
            get { return _allSupplyWindow; }
            set
            {
                _allSupplyWindow = value;
                OnPropertyChanged(nameof(AllSupplyWindow));
            }
        }
        private bool _stateMainDataGrid;
        public bool StateMainDataGrid
        {
            get { return _stateMainDataGrid; }
            set
            {
                _stateMainDataGrid = value;
                OnPropertyChanged(nameof(StateMainDataGrid));
            }
        }

        public string TextBoxNewProductText
        {
            get { return _textBoxNewProductText; }
            set
            {
                _textBoxNewProductText = value;
                OnPropertyChanged(nameof(TextBoxNewProductText));
            }
        }
    }    
}
