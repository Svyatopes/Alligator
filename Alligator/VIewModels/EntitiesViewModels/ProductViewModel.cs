using Alligator.BusinessLayer.Models;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class ProductViewModel : BaseViewModel
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


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
        private CategoryModel _category;

        public CategoryModel Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
    }
}
