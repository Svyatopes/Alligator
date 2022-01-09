using Alligator.BusinessLayer.Models;
using Alligator.UI.Commands.TabItemProducts;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.ViewModels.TabItemsViewModels
{
    public class TabItemProductsViewModel : BaseViewModel
    {
      
        //private ProductViewModel _selected;
        private Visibility _visibilityAddProduct;
        private Visibility _visibilityProduct;
        private Visibility _visibilityAllProducts;
        public ICommand OpenAddProductCard { get; set; }
        public ICommand Return { get; set; }
        public ICommand OpenProductCard { get; set; }
        public ICommand AddProduct { get; set; }
        public ICommand DeleteProduct { get; set; }

        public TabItemProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
            OpenProductCard = new OpenProductCard(this);
            OpenAddProductCard = new OpenAddProductCard(this);
            Return = new Return(this);
            AddProduct = new AddProduct(this);
            DeleteProduct = new DeleteProduct(this);
        }
        private string _selectedProductToShow;
        public string SelectedProductToShow
        {
            get
            {
                return _selectedProductToShow;
            }
            set
            {
                _selectedProductToShow = value;
                OnPropertyChanged(nameof(SelectedProductToShow));
            }
        }
        private ObservableCollection<ProductModel> _products;
        public ObservableCollection<ProductModel> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        private ObservableCollection<CategoryModel> _categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private ProductModel _selectedProduct;
        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private CategoryModel _nameSelectCategory;
        public CategoryModel NameSelectProduct
        {
            get { return _nameSelectCategory; }
            set
            {
                _nameSelectCategory = value;
                

                OnPropertyChanged(nameof(NameSelectProduct));
            }
        }

        private string _addNewProductText;
        public string AddNewProductText
        {
            get { return _addNewProductText; }
            set
            {
                _addNewProductText = value;
                OnPropertyChanged(nameof(AddNewProductText));
            }
        }
        public Visibility VisibilityAllProducts
        {
            get
            {
                return _visibilityAllProducts;
            }
            set
            {
                _visibilityAllProducts = value;
                OnPropertyChanged(nameof(VisibilityAllProducts));
            }
        }

        public Visibility VisibilityAddProduct
        {
            get
            {
                return _visibilityAddProduct;
            }
            set
            {
                _visibilityAddProduct = value;
                OnPropertyChanged(nameof(VisibilityAddProduct));
            }
        }

        public Visibility VisibilityProduct
        {
            get
            {
                return _visibilityProduct;
            }
            set
            {
                _visibilityProduct = value;
                OnPropertyChanged(nameof(VisibilityProduct));
            }
        }
    }
}
