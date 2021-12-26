using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.Commands.TabItemCategories;
using System.Collections.ObjectModel;
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
        public ICommand DeleteCategory { get; set; }
        public ICommand AddProductTag { get; set; }
        public ICommand DeleteProductTag { get; set; }
        public ICommand LoadCategoriesAndProductTags { get; set; }

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

    }
}
