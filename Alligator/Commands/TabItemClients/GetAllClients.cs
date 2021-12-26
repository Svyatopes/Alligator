using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.EntitiesViewModels;
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
        private TabItemClientsViewModel _viewModel;
        public GetAllClients(TabItemClientsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public virtual bool CanExecute(object parameter)
        {
           if( _viewModel.IsSelectedTabItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Execute(object parameter)
        {
           
            ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
            comments.Add(new CommentViewModel() { Text = "не звонить" });
            _viewModel.Clients.Add(new ClientViewModel() { Comments = comments, FirstName = "Ebat'Poluchilos", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
        }
    }
}
