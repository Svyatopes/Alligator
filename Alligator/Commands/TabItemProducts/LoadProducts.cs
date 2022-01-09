using Alligator.BusinessLayer.Models.Models;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemProducts
{
    class LoadProducts : CommandBase
    {
        private TabItemProductsViewModel _viewModel;
        public LoadProducts(TabItemProductsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            
        }
    }
}
