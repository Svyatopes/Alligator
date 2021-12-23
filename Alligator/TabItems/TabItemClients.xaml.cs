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
            CreateClients();
           
            viewModel.ClientCard = Visibility.Collapsed;
            viewModel.AddClient = Visibility.Collapsed;
            
        }

        public void CreateClients()
        {
            ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
            comments.Add(new CommentViewModel() { Text = "не звонить" });

            viewModel.Clients.Add(new ClientViewModel() { Comments = comments, FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
            viewModel.Clients.Add(new ClientViewModel() { FirstName = "Дима", LastName = "ывапро", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ButtonAddComment_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void ButtonComeBack_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            //viewModel.ClientCardColumnWidth = 0;
            //viewModel.AllClientsColumnWidth = 1;
            viewModel.Selected = null;
        }

        private void ButtonDeleteClient_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //viewModel.ClientCardColumnWidth = 0;
            //viewModel.AllClientsColumnWidth = 1;
            viewModel.Clients.Remove(viewModel.Selected);

        }
        private void ButtonSaveChanges_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            //ClientCardWindow.Width = new GridLength(0, GridUnitType.Star);
            //viewModel.AllClientsColumnWidth = 1;
            //viewModel.ClientCardColumnWidth = 0;
        }
        private void ButtonDeleteClient_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.Clients.Remove(viewModel.Selected);
        }
        private void ButtonCheckClientCard_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClientViewModel client = viewModel.Selected;
            
        }

        private void ButtonAddNewClient_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (viewModel.Selected == null)
            //{
            //    AllClientsWindow.Width = new GridLength(0, GridUnitType.Star);
            //    AddClientWindow.Width = new GridLength(1, GridUnitType.Star);
            //}
            //else
            //{
            //    MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //viewModel.Selected = null; 

        }
        private void ButtonSaveChanges_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
           // viewModel.Clients.Add(new ClientViewModel() { FirstName = firstName.Text, LastName =lName.Text, Patronymic = tName.Text, PhoneNumber = phoneNumber.Text, Email = email.Text  });
            //viewModel.ClientCardColumnWidth = 1;
            //viewModel.AllClientsColumnWidth = 0;
        }
        private void ButtonComeBack_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //viewModel.ClientColumnWidth = 0;
            //viewModel.AllClientsColumnWidth = 1;
            viewModel.Selected = null;
            //AddClientWindow.Width = new GridLength(0, GridUnitType.Star);
            //AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            //viewModel.Selected = null;

        }
        
        private void ButtonOpenClientCard_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (viewModel.Selected != null)
            {
                //viewModel.ClientCardColumnWidth = 1;
                //viewModel.AllClientsColumnWidth = 1;
                //ClientCardWindow.Width = new GridLength(1, GridUnitType.Star);
                //AllClientsWindow.Width = new GridLength(0, GridUnitType.Star);
            }
            else
            {

            }
        }
        private void ButtonAddComment_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(viewModel.Selected.Comments is null)
            {
                ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
                viewModel.Selected.Comments = comments;
            }
            if(viewModel.SelectedCom == null)
            {
                if (commentOfCurrentClient.Text != "")
                {
                    CommentViewModel com = new CommentViewModel() { Text = commentOfCurrentClient.Text };
                    viewModel.Selected.Comments.Add(com);
                }
            }
            commentOfCurrentClient.Text = null;
            viewModel.SelectedCom = null;



        }
    }
}
