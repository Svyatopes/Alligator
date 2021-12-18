using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.ViewModels.TabItemsViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Alligator.UI.TabItems
{
    /// <summary>
    /// Interaction logic for TabItemCategories.xaml
    /// </summary>
    public partial class TabItemCategories : TabItem
    {

        private TabItemCategoriesViewModel ViewModel;
        public TabItemCategories()
        {
            InitializeComponent();
            ViewModel = new TabItemCategoriesViewModel();
            DataContext = ViewModel;

            InitialFillViewModel();
        }

        private void InitialFillViewModel()
        {
            ViewModel.Categories.Add(new CategoryViewModel() { Name = "Овощи" });
            ViewModel.Categories.Add(new CategoryViewModel() { Name = "Фрукты" });
            ViewModel.Categories.Add(new CategoryViewModel() { Name = "Замороженные продукты" });

            ViewModel.ProductTags.Add(new ProductTagViewModel() { Name = "Готов к употреблению" });
            ViewModel.ProductTags.Add(new ProductTagViewModel() { Name = "Требует обработки" });
            ViewModel.ProductTags.Add(new ProductTagViewModel() { Name = "Вкусное" });
            ViewModel.ProductTags.Add(new ProductTagViewModel() { Name = "Сладкое" });
        }

        private void ButtonCategoryDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var category = (CategoryViewModel)button.DataContext;
            var userAnswer = MessageBox.Show("Вы правда хотите удалить эту категорию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                ViewModel.Categories.Remove(category);
        }

        private void ButtonProductTagDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var productTag = (ProductTagViewModel)button.DataContext;
            var userAnswer = MessageBox.Show("Вы правда хотите удалить этот тэг?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
                ViewModel.ProductTags.Remove(productTag);
        }

        private void ButtonAddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            var categoryNameToAdd = ViewModel.TextBoxNewCategoryText.Trim();
            
            if(string.IsNullOrEmpty(categoryNameToAdd))
            {
                MessageBox.Show("Введите название категории");
                return;
            }

            if (ViewModel.Categories.Any(c => c.Name == categoryNameToAdd))
            {
                MessageBox.Show("Такая категория уже существует");
                return;
            }

            //TODO: use business logic with adding
            ViewModel.Categories.Add(new CategoryViewModel() { Name = categoryNameToAdd});
            ViewModel.TextBoxNewCategoryText = string.Empty;

        }

        private void ButtonAddNewProductTag_Click(object sender, RoutedEventArgs e)
        {
            var productTagNameToAdd = ViewModel.TextBoxNewProductTagText.Trim();

            if (string.IsNullOrEmpty(productTagNameToAdd))
            {
                MessageBox.Show("Введите название тэга");
                return;
            }

            if (ViewModel.ProductTags.Any(pt => pt.Name == productTagNameToAdd))
            {
                MessageBox.Show("Такой тэг уже существует");
                return;
            }

            //TODO: use business logic with adding
            ViewModel.ProductTags.Add(new ProductTagViewModel() { Name = productTagNameToAdd });
            ViewModel.TextBoxNewProductTagText = string.Empty;

        }
    }
}
