using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Alligator.UI.Commands.TabItemSupplies
{
    public class SaveNewSupply : CommandBase
    {
        private TabItemSuppliesViewModel viewModel;

        public SaveNewSupply(TabItemSuppliesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.Supply = new SuppliesViewModel()
            {
                Id = viewModel.TextBoxNewIdText,
                Date = viewModel.TextBoxNewDateText,
                Details = viewModel.SupplyDetails
            };
            var count = viewModel.Supplies.Count;
            var userAnswer = MessageBox.Show("Данные введены верно? Сохранить поставку?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                for (int i = 0; i < viewModel.Supplies.Count; i++)
                {
                    if (viewModel.Supplies[i].Id == viewModel.Supply.Id)
                    {
                        var userAnswer1 = MessageBox.Show("Такой номер поставки существует, перезаписать данные?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (userAnswer1 == MessageBoxResult.Yes)
                        {
                            viewModel.Supply = new SuppliesViewModel()
                            {
                                Id = viewModel.TextBoxNewIdText,
                                Date = viewModel.TextBoxNewDateText,
                                Details = viewModel.SupplyDetails
                            };
                            viewModel.VisibilitySecond = Visibility.Collapsed;
                            viewModel.VisibilityThird = Visibility.Visible;
                        }                 
                                                
                    }
                    else
                    {
                        count--;
                    }
                }
                if (count == 0)
                {
                    viewModel.Supplies.Add(viewModel.Supply);
                    viewModel.VisibilitySecond = Visibility.Collapsed;
                    viewModel.VisibilityThird = Visibility.Visible;
                }               

            }            
        }
    }
}


