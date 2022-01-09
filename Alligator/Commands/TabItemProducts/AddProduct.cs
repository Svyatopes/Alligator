﻿using Alligator.BusinessLayer.Models.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemProducts
{
    class AddProduct : CommandBase
    {
        private TabItemProductsViewModel _viewModel;
        public AddProduct(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
           
            var product = new ProductModel() { Name = _viewModel.AddNewProductText };
            _viewModel.Products.Add(product);
            
            _viewModel.VisibilityAddProduct = System.Windows.Visibility.Collapsed;
            _viewModel.VisibilityAllProducts = System.Windows.Visibility.Visible;
        }
    }
}
