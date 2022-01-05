using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemProductsViewModel : BaseViewModel
    {
        private ObservableCollection<ProductViewModel> _product;
        private ProductViewModel _selected;
        private Visibility _addProduct;
        private Visibility _viewProduct;


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

        public TabItemProductsViewModel()
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

        public Visibility AddProductGrid
        {
            get
            {
                return _addProduct;
            }
            set
            {
                _addProduct = value;
                OnPropertyChanged(nameof(AddProductGrid));
            }
        }

        public Visibility ViewProductGrid
        {
            get
            {
                return _viewProduct;
            }
            set
            {
                _viewProduct = value;
                OnPropertyChanged(nameof(ViewProductGrid));
            }
        }
    }
}
