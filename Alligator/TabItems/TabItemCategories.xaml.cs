using Alligator.UI.ViewModels.EntitiesViewModels;
using Alligator.UI.ViewModels.TabItemsViewModels;
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
       
    }
}
