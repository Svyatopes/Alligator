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
        //private ObservableCollection<CommentViewModel> comments;
        private ClientViewModel selected;
        private CommentViewModel selectedCom;
       

        public TabItemClientsViewModel()
        {
            Clients = new ObservableCollection<ClientViewModel>();
           
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

        public ClientViewModel Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public CommentViewModel SelectedCom
        {
            get { return selectedCom; }
            set
            {
                selectedCom = value;
                OnPropertyChanged("SelectedCom");
            }
        }

    }
}
