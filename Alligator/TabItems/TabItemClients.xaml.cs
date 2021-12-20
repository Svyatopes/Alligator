﻿using Alligator.BusinessLayer;
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
            dg.ItemsSource = viewModel.Clients;
            CreateClients();
        }

        public void CreateClients()
        {
            ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
            comments.Add(new CommentViewModel() { Text = "не звонить" });

            viewModel.Clients.Add(new ClientViewModel() { Comments = comments, FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
            viewModel.Clients.Add(new ClientViewModel() { FirstName = "Ваня", LastName = "Ivanov", Patronymic = "Ivanovich", PhoneNumber = "12345", Email = "qwe@ru" });
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonComeBack_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClientCardWindow.Width = new GridLength(0, GridUnitType.Star);
            AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            viewModel.Selected = null;
        }

        private void ButtonDeleteClient_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClientCardWindow.Width = new GridLength(0, GridUnitType.Star);
            AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            viewModel.Clients.Remove(viewModel.Selected);

        }
        private void ButtonSaveChanges_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            ClientCardWindow.Width = new GridLength(0, GridUnitType.Star);
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
            if (viewModel.Selected == null)
            {
                AllClientsWindow.Width = new GridLength(0, GridUnitType.Star);
                AddClientWindow.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                 MessageBox.Show("Вы не можете добавить существующего клиента", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            viewModel.Selected = null; 

        }
        private void ButtonSaveChanges_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.Clients.Add(new ClientViewModel() { FirstName = firstName.Text, LastName =lName.Text, Patronymic = tName.Text, PhoneNumber = phoneNumber.Text, Email = email.Text });
            AddClientWindow.Width = new GridLength(0, GridUnitType.Star);
            AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
        }
        private void ButtonComeBack_AddingClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddClientWindow.Width = new GridLength(0, GridUnitType.Star);
            AllClientsWindow.Width = new GridLength(1, GridUnitType.Star);
            viewModel.Selected = null;
        }
        
        private void ButtonOpenClientCard_AllClients_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (viewModel.Selected!=null)
            {

                ClientCardWindow.Width = new GridLength(1, GridUnitType.Star);
                AllClientsWindow.Width = new GridLength(0, GridUnitType.Star);
            }
            else
            {
                 MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ButtonAddComment_ClientCard_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
