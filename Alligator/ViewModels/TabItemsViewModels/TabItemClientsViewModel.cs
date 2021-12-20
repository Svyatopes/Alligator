using Alligator.UI.ViewModels.EntitiesViewModels;
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
   public  class TabItemClientsViewModel   : BaseViewModel
    {
        private ObservableCollection<ClientViewModel> clients;
        private ObservableCollection<CommentViewModel> comments;
        private ClientViewModel selected;
        
        public TabItemClientsViewModel()
        {
            Clients = new ObservableCollection<ClientViewModel>();
            Comments = new ObservableCollection<CommentViewModel>();
        }
        public ObservableCollection<ClientViewModel> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        public ObservableCollection<CommentViewModel> Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChanged("Comments");
            }
        }
        public ClientViewModel Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

    }
}
