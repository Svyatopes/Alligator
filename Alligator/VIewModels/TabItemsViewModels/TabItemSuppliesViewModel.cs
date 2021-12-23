using Alligator.UI.VIewModels.EntitiesViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

using Alligator.UI.Commands.TabItemSupplies;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemSuppliesViewModel : BaseViewModel
    {
        public TabItemSuppliesViewModel viewModel;

        public TabItemSuppliesViewModel()
        {
            Supplies = new ObservableCollection<SuppliesViewModel>();
            Supply = new SuppliesViewModel();
            SupplyDetails = new ObservableCollection<SupplyDelailsViewModel>();
            Product = new ObservableCollection<ProductViewModel>();
            StateMainDataGrid = true;
            

            DeleteSupply = new DeleteSupply_AllSupplies(this);
            AddNewSupply = new AddNewSupply_AllSupplies(this);
            OpenCardSupply = new OpenSupplyCard_AllSupplies(this);
            ReturnBackNewSupply = new ReturnBack_NewSupply(this);
            AddProductInSupply = new AddProductInSupply(this);
        }

        private ObservableCollection<SuppliesViewModel> _details;
        private ObservableCollection<SuppliesViewModel> _supplies;
        private SuppliesViewModel _supply;
        private ObservableCollection<SupplyDelailsViewModel> _supplyDetails;
        private ObservableCollection<ProductViewModel> _product;

        public ICommand OpenCardSupply { get; set; }
        public ICommand DeleteSupply { get; set; }
        public ICommand AddNewSupply { get; set; }
        public ICommand ReturnBackNewSupply { get; set; }
        public ICommand AddProductInSupply { get; set; }


        private DateTime _textBoxNewDateText;
        private int _textBoxNewAmountText;
        private int _textBoxNewIdText;
        private string _textBoxNewProductText;


        public ObservableCollection<SuppliesViewModel> Details
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

        public SuppliesViewModel Supply
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

        private Visibility _visibilityFirst;
        public Visibility VisibilityFirst
        {
            get
            {
                return _visibilityFirst;
            }
            set
            {
                _visibilityFirst = value;

                OnPropertyChanged(nameof(VisibilityFirst));
            }
        }
        private Visibility _visibilitySecond;
        public Visibility VisibilitySecond
        {
            get
            {
                return _visibilitySecond;
            }
            set
            {
                _visibilitySecond = value;

                OnPropertyChanged(nameof(VisibilitySecond));
            }
        }
        private Visibility _visibilityThird;
        public Visibility VisibilityThird
        {
            get
            {
                return _visibilityThird;
            }
            set
            {
                _visibilityThird = value;

                OnPropertyChanged(nameof(VisibilityThird));
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
