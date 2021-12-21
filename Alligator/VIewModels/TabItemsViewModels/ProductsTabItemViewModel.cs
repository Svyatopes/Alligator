using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class ProductsTabItemViewModel : BaseViewModel
    {
        private ObservableCollection<ProductViewModel> _product;
        private ProductViewModel _selected;

        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ProductsTabItemViewModel()
        {
            Products = new ObservableCollection<ProductViewModel>();
        }

        public ProductViewModel Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
    }
}
