using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
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
            dg.ItemsSource = viewModel.Clients;
            CreateClients();
        }

        DataTable table = new DataTable();
        public void CreateClients()
        {
            viewModel.Clients.Add(new ClientViewModel() { FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
            viewModel.Clients.Add(new ClientViewModel() { FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonComeBack_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonDeleteClient_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
     
        }
        private void ButtonSaveChanges_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
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

        }
        private void ButtonSaveChanges_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void ButtonComeBack_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        
        private void ButtonOpenClientCard_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}
