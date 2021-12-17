using Alligator.UI.VIewModels.EntitiesViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    class TabItemClientsViewModel   : BaseViewModel
    {
        private ObservableCollection<ClientViewModel> clients;
        public ObservableCollection<ClientViewModel> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public TabItemClientsViewModel()
        {
            Clients = new ObservableCollection<ClientViewModel>();
        }
    }
}
