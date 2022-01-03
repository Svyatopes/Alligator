using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.Commands.TabItemSupplies;
using Alligator.UI.VIewModels.EntitiesViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;


namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemSuppliesViewModel : BaseViewModel
    {
        private readonly SupplyService _supplyService;
        private readonly SupplyDetailService _supplyDetailService;

        public TabItemSuppliesViewModel()
        {
            _supplyService = new SupplyService();
            _supplyDetailService = new SupplyDetailService();
            AddNewSupply = new SupplyAdd(this);
            OpenCardSupply = new SupplyDetailOpen(this, _supplyDetailService);
            SuppliesOpen = new SuppliesOpen(this, _supplyService);
            AddProductInSupply = new ProductAddInSupply(this, _supplyDetailService);
            SaveNewSupply = new SaveNewSupply(this, _supplyService, _supplyDetailService);
            SaveChangSupply = new SaveChangSupply(this, _supplyService, _supplyDetailService);
            ChangeCardSupply = new ChangeCardSupply(this);
            ProductDeleteFromSupply = new ProductDeleteFromSupply(this, _supplyDetailService);
            DeleteSupply = new SupplyDelete(this, _supplyService, _supplyDetailService);
        }



        public ICommand OpenCardSupply { get; set; }
        public ICommand DeleteSupply { get; set; }
        public ICommand AddNewSupply { get; set; }
        public ICommand SuppliesOpen { get; set; }
        public ICommand AddProductInSupply { get; set; }
        public ICommand SaveNewSupply { get; set; }
        public ICommand SaveChangSupply { get; set; }
        public ICommand ChangeCardSupply { get; set; }
        public ICommand ProductDeleteFromSupply { get; set; }


        private List<ProductModel> _products;
        public List<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        private string _selectProduct;
        public string SelectProduct
        {
            get { return _selectProduct; }
            set
            {
                _selectProduct = value;
                OnPropertyChanged(nameof(SelectProduct));
            }
        }


        private ObservableCollection<SupplyModel> _supplies;

        public ObservableCollection<SupplyModel> Supplies
        {
            get { return _supplies; }
            set
            {
                _supplies = value;
                OnPropertyChanged(nameof(Supplies));
            }
        }

        private List<SupplyDetailModel> _details;
        public List<SupplyDetailModel> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }


        private SupplyModel _newSupply;

        public SupplyModel NewSupply
        {
            get { return _newSupply; }
            set
            {
                _newSupply = value;
                OnPropertyChanged(nameof(NewSupply));
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
       

        private List<SupplyDetailModel> _supplyDetails;

        public List<SupplyDetailModel> SupplyDetails
        {
            get { return _supplyDetails; }
            set
            {
                _supplyDetails = value;
                OnPropertyChanged(nameof(SupplyDetails));
            }
        }


        private SupplyModel _selected;

        public SupplyModel Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }


        private List<SupplyDetailModel> _pselected;

        public List<SupplyDetailModel> PSelected
        {
            get { return _pselected; }
            set
            {
                _pselected = value;
                OnPropertyChanged(nameof(PSelected));
            }
        }
        private SupplyDetailModel _prSelected;

        public SupplyDetailModel PrSelected
        {
            get { return _prSelected; }
            set
            {
                _prSelected = value;
                OnPropertyChanged(nameof(PrSelected));
            }
        }


        private DateTime _textBoxNewDateText;

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


        private int _textBoxNewIdText;

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


        private int _textBoxNewAmountText;
        public int TextBoxNewAmountText
        {
            get { return _textBoxNewAmountText; }
            set
            {
                _textBoxNewAmountText = value;
                OnPropertyChanged(nameof(TextBoxNewAmountText));
            }
        }
        
        private ButtonBase _deleteProduct;
        public ButtonBase DeleteProduct
        {
            get { return _deleteProduct; }
            set
            {
                _deleteProduct = value;
                OnPropertyChanged(nameof(DeleteProduct));
            }
        }

        private Visibility _visibilityWindowAllSupplies;
        public Visibility VisibilityWindowAllSupplies
        {
            get
            {
                return _visibilityWindowAllSupplies;
            }
            set
            {
                _visibilityWindowAllSupplies = value;

                OnPropertyChanged(nameof(VisibilityWindowAllSupplies));
            }
        }
        private Visibility _visibilityWindowAddNewSupply;
        public Visibility VisibilityWindowAddNewSupply
        {
            get
            {
                return _visibilityWindowAddNewSupply;
            }
            set
            {
                _visibilityWindowAddNewSupply = value;

                OnPropertyChanged(nameof(VisibilityWindowAddNewSupply));
            }
        }
        private Visibility _visibilityWindowOpenSupplyDetailCard;
        public Visibility VisibilityWindowOpenSupplyDetailCard
        {
            get
            {
                return _visibilityWindowOpenSupplyDetailCard;
            }
            set
            {
                _visibilityWindowOpenSupplyDetailCard = value;

                OnPropertyChanged(nameof(VisibilityWindowOpenSupplyDetailCard));
            }
        }
        private Visibility _visibilityWindowChangeSupply;
        public Visibility VisibilityWindowChangeSupply
        {
            get
            {
                return _visibilityWindowChangeSupply;
            }
            set
            {
                _visibilityWindowChangeSupply = value;

                OnPropertyChanged(nameof(VisibilityWindowChangeSupply));
            }
        }
    }
}
