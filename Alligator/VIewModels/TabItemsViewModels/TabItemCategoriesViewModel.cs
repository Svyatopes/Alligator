using System.Collections.ObjectModel;
using System.Windows.Input;
using Alligator.UI.Commands.TabItemCategories;
using Alligator.UI.ViewModels.EntitiesViewModels;

namespace Alligator.UI.ViewModels.TabItemsViewModels
{
    public class TabItemCategoriesViewModel : BaseViewModel
    {
        private string? _textBoxNewCategoryText;
        private string? _textBoxNewProductTagText;
        private CategoryViewModel _selectedCategory;
        private ProductTagViewModel _selectedProductTag;
        
        public ICommand AddCategory { get; set; }
        public ICommand DeleteCategory { get; set; }
        public ICommand AddProductTag { get; set; }
        public ICommand DeleteProductTag { get; set; }

        public TabItemCategoriesViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            ProductTags = new ObservableCollection<ProductTagViewModel>();

            AddCategory = new ButtonCategoryAdd(this);
            DeleteCategory = new ButtonCategoryDelete(this);
            AddProductTag = new ButtonProductTagAdd(this);
            DeleteProductTag = new ButtonProductTagDelete(this);
        }

        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public ObservableCollection<ProductTagViewModel> ProductTags { get; set; }

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


        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ProductTagViewModel SelectedProductTag
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
