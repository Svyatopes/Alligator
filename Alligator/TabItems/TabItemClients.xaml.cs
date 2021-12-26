using Alligator.BusinessLayer;
using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemClients.xaml
    /// </summary>
    public partial class TabItemClients : TabItem
    {
        TabItemClientsViewModel viewModel = new TabItemClientsViewModel();    
        public TabItemClients()
        {
            InitializeComponent();
            viewModel = new TabItemClientsViewModel();
            DataContext = viewModel;
           
            viewModel.AddClient = Visibility.Collapsed;
            viewModel.ClientCard = Visibility.Collapsed;

            
        }

        public void CreateClients()
        {
            ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
            comments.Add(new CommentViewModel() { Text = "не звонить" });

            viewModel.Clients.Add(new ClientViewModel() { Comments = comments, FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
            viewModel.Clients.Add(new ClientViewModel() { FirstName = "Дима", LastName = "ывапро", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
        }





    }
}
