
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Alligator.UI.VIewModels.EntitiesViewModels;
using System.Windows.Controls.Primitives;
using Alligator.UI.TabItems;

namespace Alligator.UI.VIewModels.TabItemsViewModels
{
    public class TabItemSuppliesViewModel : BaseViewModel
    {
        public TabItemSuppliesViewModel()
        {
            Supplies = new ObservableCollection<SuppliesViewModel>();
        }


        private ObservableCollection<SuppliesViewModel> _supplies;
        public ObservableCollection<SuppliesViewModel> Supplies
        {
            get { return _supplies; }
            set
            {
                _supplies = value;
                OnPropertyChanged(nameof(Supplies));
            }
        }


        private DateTime _textBoxNewDateText;
        public DateTime TextBoxNewDateText
        {
            get 
            {
                return _textBoxNewDateText; 
            }
            set
            {
                _textBoxNewDateText = value;
                OnPropertyChanged(nameof(TextBoxNewDateText));
            }
        }

        private int? _textBoxNewAmountText;
        public int? TextBoxNewAmountText
        {
            get { return _textBoxNewAmountText; }
            set
            {
                _textBoxNewAmountText = value;
                OnPropertyChanged(nameof(TextBoxNewAmountText));
            }
        }
        private string? _textBoxNewProductText;
        public string? TextBoxNewProductText
        {
            get { return _textBoxNewProductText; }
            set
            {
                _textBoxNewProductText = value;
                OnPropertyChanged(nameof(TextBoxNewProductText));
            }
        }
    }    
}
