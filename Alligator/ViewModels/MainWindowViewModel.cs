using Alligator.UI.Commands.TabItemClients;
using Alligator.UI.VIewModels.TabItemsViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alligator.UI.ViewModels
{
   public class MainWindowViewModel : BaseViewModel
    {
        private TabItemClientsViewModel _tabItemClientViewModel;
        private bool myCommandClientsTabItemSelected;
        public ICommand GetAllClients { get; set; }

        public MainWindowViewModel()
        {
            _tabItemClientViewModel = new TabItemClientsViewModel();
            GetAllClients = new GetAllClients(_tabItemClientViewModel);
        }

       public bool MyCommandClientsTabItemSelected
        {
            get { return myCommandClientsTabItemSelected; }
            set
            {
                myCommandClientsTabItemSelected = value;
                OnPropertyChanged("MyCommandClientsTabItemSelected");

            }
        }
    }
}
