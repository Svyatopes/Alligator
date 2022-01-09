using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.Commands.TabItemCategories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Alligator.UI.ViewModels.TabItemsViewModels
{
    public class TabItemCategoriesViewModel : BaseViewModel
    {
        private string? _textBoxNewCategoryText;
        private string? _textBoxNewProductTagText;
        private CategoryModel _selectedCategory;
        private ProductTagModel _selectedProductTag;

        private readonly CategoryService _categoryService;
        private readonly ProductTagService _productTagService;


        public ICommand AddCategory { get; set; }
        public ICommand StartEditingCategory { get; set; }
        public ICommand DeleteCategory { get; set; }
        public ICommand AddProductTag { get; set; }
        public ICommand DeleteProductTag { get; set; }
        public ICommand LoadCategoriesAndProductTags { get; set; }
        public ICommand ReturnToMainGrid { get; set; }
        public ICommand SaveCategory { get; set; }
        public ICommand SaveProductTag { get; set; }
        public ICommand StartEditingProductTag { get; set; }

        public TabItemCategoriesViewModel()
        {
            _productTagService = new ProductTagService();
            _categoryService = new CategoryService();

            Categories = new ObservableCollection<CategoryModel>();
            ProductTags = new ObservableCollection<ProductTagModel>();

            LoadCategoriesAndProductTags = new LoadCategoriesAndProductTags(this, _productTagService, _categoryService);

            AddCategory = new CategoryAdd(this, _categoryService);
            DeleteCategory = new CategoryDelete(this, _categoryService);
            AddProductTag = new ProductTagAdd(this, _productTagService);
            DeleteProductTag = new ProductTagDelete(this, _productTagService);
            ReturnToMainGrid = new ReturnToMainGrid(this);
            SaveCategory = new SaveCategory(this, _categoryService);
            StartEditingCategory = new StartEditingCategory(this);
            StartEditingProductTag = new StartEditingProductTag(this);
            SaveProductTag = new SaveProductTag(this, _productTagService);

            MainGridVisibilty = Visibility.Visible;
            GridEditCategoryVisibility = Visibility.Collapsed;
            GridEditProdutTagVisibility = Visibility.Collapsed;
        }


        private string _textBoxCategoryEditText;
        public string TextBoxCategoryEditText
        {
            get { return _textBoxCategoryEditText; }
            set
            {
                _textBoxCategoryEditText = value;
                OnPropertyChanged(nameof(TextBoxCategoryEditText));
            }
        }


        private string _textBoxProductTagEditText;
        public string TextBoxProductTagEditText
        {
            get { return _textBoxProductTagEditText; }
            set
            {
                _textBoxProductTagEditText = value;
                OnPropertyChanged(nameof(TextBoxProductTagEditText));
            }
        }

        public ObservableCollection<CategoryModel> Categories { get; set; }

        public ObservableCollection<ProductTagModel> ProductTags { get; set; }

        public string? TextBoxNewCategoryText
        {
            get { return _textBoxNewCategoryText; }
            set
            {
                _textBoxNewCategoryText = value;
                OnPropertyChanged(nameof(TextBoxNewCategoryText));
            }
        }

        public string? TextBoxNewProductTagText
        {
            get { return _textBoxNewProductTagText; }
            set
            {
                _textBoxNewProductTagText = value;
                OnPropertyChanged(nameof(TextBoxNewProductTagText));
            }
        }


        public CategoryModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ProductTagModel SelectedProductTag
        {
            get { return _selectedProductTag; }
            set
            {
                _selectedProductTag = value;
                OnPropertyChanged(nameof(SelectedProductTag));
            }
        }


        private Visibility _mainGridVisibility;
        public Visibility MainGridVisibilty
        {
            get { return _mainGridVisibility; }
            set
            {
                _mainGridVisibility = value;
                OnPropertyChanged(nameof(MainGridVisibilty));
            }
        }


        private Visibility _gridEditCategoryVisibility;
        public Visibility GridEditCategoryVisibility
        {
            get { return _gridEditCategoryVisibility; }
            set
            {
                _gridEditCategoryVisibility = value;
                OnPropertyChanged(nameof(GridEditCategoryVisibility));
            }
        }


        private Visibility _gridEditProductTagVisibility;
        public Visibility GridEditProdutTagVisibility
        {
            get { return _gridEditProductTagVisibility; }
            set
            {
                _gridEditProductTagVisibility = value;
                OnPropertyChanged(nameof(GridEditProdutTagVisibility));
            }
        }

    }
}
