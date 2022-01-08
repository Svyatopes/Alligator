using Alligator.UI.Commands.TabItemProducts;
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
using System.Windows.Input;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemProductsViewModel : BaseViewModel
    {
        private ObservableCollection<ProductViewModel> _product;
        private ProductViewModel _selected;
        private Visibility _visibilityAddProduct;
        private Visibility _visibilityProduct;
        private Visibility _visibilityAllProducts;
        public ICommand OpenProductCard { get; set; }

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
            OpenProductCard = new OpenProductCard(this);
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
