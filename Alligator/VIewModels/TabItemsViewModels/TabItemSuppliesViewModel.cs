using Alligator.BusinessLayer.Models;
using Alligator.BusinessLayer.Service;
using Alligator.UI.Commands;
using Alligator.UI.Commands.TabItemSupplies;
using Alligator.UI.VIewModels.EntitiesViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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
            LoadSupplies = new LoadSupplies(this, _supplyService, _supplyDetailService);
            OpenCardSupply = new SupplyDetailOpen(this, _supplyDetailService);
            SuppliesOpen = new SuppliesOpen(this);
            AddProductInSupply = new ProductAddInSupply(this, _supplyDetailService);
            SaveNewSupply = new SaveNewSupply(this, _supplyService, _supplyDetailService);
            SaveModifiedSupply = new SaveModifiedSupply(this, _supplyService, _supplyDetailService);
            ChangeCardSupply = new ChangeCardSupply(this);
            ProductDeleteFromSupply = new ProductDeleteFromSupply(this);
            DeleteSupply = new SupplyDelete(this, _supplyService, _supplyDetailService);
        }

        public ICommand OpenCardSupply { get; set; }
        public ICommand DeleteSupply { get; set; }
        public ICommand AddNewSupply { get; set; }
        public ICommand SuppliesOpen { get; set; }
        public ICommand AddProductInSupply { get; set; }
        public ICommand SaveNewSupply { get; set; }
        public ICommand SaveModifiedSupply { get; set; }
        public ICommand ChangeCardSupply { get; set; }
        public ICommand LoadSupplies { get; set; }
        public ICommand ProductDeleteFromSupply { get; set; }


        private ObservableCollection<ProductModel> _products;

        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                
                OnPropertyChanged(nameof(Products));
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



        private string _nameSelectProduct;
        public string NameSelectProduct
        {
            get { return _nameSelectProduct; }
            set
            {
                _nameSelectProduct = value;
                ((CommandBase)AddProductInSupply).RaiseCanExecutedChanged();

                OnPropertyChanged(nameof(NameSelectProduct));
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




        private SupplyModel _selectedSupply;

        public SupplyModel SelectedSupply
        {
            get { return _selectedSupply; }
            set
            {
                _selectedSupply = value;
                ((CommandBase)OpenCardSupply).RaiseCanExecutedChanged();
                ((CommandBase)DeleteSupply).RaiseCanExecutedChanged();
                
                OnPropertyChanged(nameof(SelectedSupply));
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
        
        private List<SupplyDetailModel> _selectedDetailForDelete;

        public List<SupplyDetailModel> SelectedDetailForDelete
        {
            get { return _selectedDetailForDelete; }
            set
            {
                _selectedDetailForDelete = value;
                OnPropertyChanged(nameof(SelectedDetailForDelete));
            }
        }
        
        
        private SupplyDetailModel _selectedDetail;

        public SupplyDetailModel SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                _selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
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
                ((CommandBase)AddProductInSupply).RaiseCanExecutedChanged();
                OnPropertyChanged(nameof(TextBoxNewAmountText));
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
