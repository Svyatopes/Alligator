using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alligator.UI.ViewModels.EntitiesViewModels;

namespace Alligator.UI.ViewModels.TabItemsViewModels
{
    public class TabItemCategoriesViewModel : BaseViewModel
    {
        public TabItemCategoriesViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            ProductTags = new ObservableCollection<ProductTagViewModel>();
        }


        private ObservableCollection<CategoryViewModel> _categories;
        public ObservableCollection<CategoryViewModel> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private ObservableCollection<ProductTagViewModel> _productTags;
        public ObservableCollection<ProductTagViewModel> ProductTags
        {
            get { return _productTags; }
            set
            {
                _productTags = value;
                OnPropertyChanged(nameof(ProductTags));
            }
        }

        private string? _textBoxNewCategoryText;
        public string? TextBoxNewCategoryText
        {
            get { return _textBoxNewCategoryText; }
            set
            {
                _textBoxNewCategoryText = value;
                OnPropertyChanged(nameof(TextBoxNewCategoryText));
            }
        }

        private string? _textBoxNewProductTagText;
        public string? TextBoxNewProductTagText
        {
            get { return _textBoxNewProductTagText; }
            set
            {
                _textBoxNewProductTagText = value;
                OnPropertyChanged(nameof(TextBoxNewProductTagText));
            }
        }


    }
}
