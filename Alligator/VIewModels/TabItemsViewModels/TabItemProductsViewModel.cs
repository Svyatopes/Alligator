using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.Commands.TabItemProducts;
using Alligator.UI.ViewModels.EntitiesViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.ViewModels.TabItemsViewModels
{
    public class TabItemProductsViewModel : BaseViewModel
    {

        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly ProductTagService _productTagService;


        public ICommand OpenAddProductCard { get; set; }
        public ICommand Return { get; set; }
        public ICommand OpenProductCard { get; set; }
        public ICommand AddProduct { get; set; }
        public ICommand DeleteProduct { get; set; }
        public ICommand LoadProducts { get; set; }
        
        public ICommand AddProductTagToProductToAdd { get; set; }
        public ICommand AddProductTagToProductToEdit { get; set; }
        public ICommand DeleteProductTagFromProductToAdd { get; set; }
        public ICommand DeleteProductTagFromProductToEdit { get; set; }
        public ICommand SaveChanges { get; set; }

        public TabItemProductsViewModel()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _productTagService = new ProductTagService();


            Products = new ObservableCollection<ProductModel>();
            Categories = new ObservableCollection<CategoryModel>();
            ProductTags = new ObservableCollection<ProductTagModel>();

            LoadProducts = new LoadProducts(this, _productService, _categoryService, _productTagService);
            OpenProductCard = new OpenProductCard(this, _productService);
            OpenAddProductCard = new OpenAddProductCard(this);
            Return = new Return(this);
            AddProduct = new AddProduct(this, _productService);
            DeleteProduct = new DeleteProduct(this, _productService);
            AddProductTagToProductToAdd = new AddProductTagToProductToAdd(this);
            AddProductTagToProductToEdit = new AddProductTagToProductToEdit(this);
            DeleteProductTagFromProductToAdd = new DeleteProductTagFromProductToAdd(this);
            DeleteProductTagFromProductToEdit = new DeleteProductTagFromProductToEdit(this);
            SaveChanges = new SaveChanges(this, _productService);

            VisibilityAllProducts = Visibility.Visible;
            VisibilityAddProduct = Visibility.Collapsed;
            VisibilityEditProduct = Visibility.Collapsed;

        }


        private ProductTagModel _selectedProductTagToEdit;
        public ProductTagModel SelectedProductTagToEdit
        {
            get { return _selectedProductTagToEdit; }
            set
            {
                _selectedProductTagToEdit = value;
                OnPropertyChanged(nameof(SelectedProductTagToEdit));
            }
        }

        private ProductTagModel _selectedProductTagToAddInProductToEdit;
        public ProductTagModel SelectedProductTagToAddInProductToEdit
        {
            get { return _selectedProductTagToAddInProductToEdit; }
            set
            {
                _selectedProductTagToAddInProductToEdit = value;
                OnPropertyChanged(nameof(SelectedProductTagToAddInProductToEdit));
            }
        }

        private ProductViewModel _productToEdit;
        public ProductViewModel ProductToEdit
        {
            get { return _productToEdit; }
            set
            {
                _productToEdit = value;
                OnPropertyChanged(nameof(ProductToEdit));
            }
        }


        private ProductTagModel _selectedProductTagInProductToAdd;
        public ProductTagModel SelectedProductTagInProductToAdd
        {
            get { return _selectedProductTagInProductToAdd; }
            set
            {
                _selectedProductTagInProductToAdd = value;
                OnPropertyChanged(nameof(SelectedProductTagInProductToAdd));
            }
        }

        private ProductTagModel _selectedProductTagToAdd;
        public ProductTagModel SelectedProductTagToAdd
        {
            get { return _selectedProductTagToAdd; }
            set
            {
                _selectedProductTagToAdd = value;
                OnPropertyChanged(nameof(SelectedProductTagToAdd));
            }
        }

        private ProductViewModel _productToAdd;
        public ProductViewModel ProductToAdd
        {
            get { return _productToAdd; }
            set
            {
                _productToAdd = value;
                OnPropertyChanged(nameof(ProductToAdd));
            }
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

        public ObservableCollection<ProductTagModel> ProductTags { get; set; }

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

        private Visibility _visibilityAllProducts;
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

        private Visibility _visibilityAddProduct;
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

        private Visibility _visibilityEditProduct;
        public Visibility VisibilityEditProduct
        {
            get
            {
                return _visibilityEditProduct;
            }
            set
            {
                _visibilityEditProduct = value;
                OnPropertyChanged(nameof(VisibilityEditProduct));
            }
        }
    }
}
