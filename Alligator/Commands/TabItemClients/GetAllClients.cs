using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using Alligator.UI.ViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    class GetAllClients : CommandBase
    {
        private MainWindowViewModel _viewModel;
        private TabItemClientsViewModel _tabIteVviewModel;
        public GetAllClients( TabItemClientsViewModel tabIteVviewModel)
        {
            
            _tabIteVviewModel = tabIteVviewModel;
        }

        public override void Execute(object parameter)
        {
           
           
            
        }
    }
}
