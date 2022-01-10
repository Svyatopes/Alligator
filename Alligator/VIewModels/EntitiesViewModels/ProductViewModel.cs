using Alligator.BusinessLayer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alligator.UI.ViewModels.EntitiesViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public CategoryModel Category { get; set; }
        public ObservableCollection<ProductTagModel> ProductTags { get; set; }

        public ProductViewModel()
        {
            Name = string.Empty;
            ProductTags = new ObservableCollection<ProductTagModel>(); 
        }

        public ProductViewModel(ProductModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Category = model.Category;
            ProductTags = new ObservableCollection<ProductTagModel>(model.ProductTags);
        }

        public ProductModel ConvertToProductModel()
        {
            var productModel = new ProductModel()
            {
                Id = this.Id,
                Name = this.Name,
                Category = this.Category,
                ProductTags = new List<ProductTagModel>()
            };

            foreach (var productTag in ProductTags)
            {
                productModel.ProductTags.Add(productTag);
            }
            return productModel;
        }

        public bool IsValid()
        {
            if (Name.Length > 100 || Name.Length == 0)
                return false;
            return true;
        }
    }
}
