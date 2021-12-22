
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
            Supply = new SupplyViewModel();
            SupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            Product = new ObservableCollection<ProductViewModel>();

            NewSupplies = new ObservableCollection<SuppliesViewModel>();
            NewSupply = new SupplyViewModel();
            NewSupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            NewProduct = new ObservableCollection<ProductViewModel>();
            
            //NewSupplies.RemoveAll();
            //WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            //WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            StateMainDataGrid = true;
        }

        private ObservableCollection<SupplyViewModel> _details;
        private ObservableCollection<SuppliesViewModel> _supplies;
        private SupplyViewModel _supply;
        private ObservableCollection<SupplyDelailsViewModel> _supplyDetails;
        private ObservableCollection<ProductViewModel> _product;


        private ObservableCollection<SuppliesViewModel> _newSupplies;
        private SupplyViewModel _newSupply;
        private ObservableCollection<SupplyDelailsViewModel> _newSupplyDetails;       
        private ObservableCollection<ProductViewModel> _newProduct;

        private DateTime _textBoxNewDateText;
        private int _textBoxNewAmountText;
        private int _textBoxNewIdText;
        private string _textBoxNewProductText;


        public ObservableCollection<SupplyViewModel> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
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

        public SupplyViewModel Supply
        {
            get { return _supply; }
            set
            {
                _supply = value;
                OnPropertyChanged(nameof(Supply));
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

        public ObservableCollection<ProductViewModel> Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
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

        public SupplyViewModel NewSupply
        {
            get { return _newSupply; }
            set
            {
                _newSupply = value;
                OnPropertyChanged(nameof(NewSupply));
            }
        }
        public ObservableCollection<SupplyDelailsViewModel> NewSupplyDetails
        {
            get { return _newSupplyDetails; }
            set
            {
                _newSupplyDetails = value;
                OnPropertyChanged(nameof(NewSupplyDetails));
            }
        }
        public ObservableCollection<ProductViewModel> NewProduct
        {
            get { return _newProduct; }
            set
            {
                _newProduct = value;
                OnPropertyChanged(nameof(NewProduct));
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
