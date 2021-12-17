using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Alligator.UI.VIewModels.EntitiesViewModels;
using Alligator.BusinessLayer;

namespace Alligator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SupplyDetailService _supplyService;
        public MainWindow()
        {
             InitializeComponent();
            _supplyService = new SupplyDetailService();
            //this.DataContext = new SuppliesViewModel();
            var vm = new SuppliesViewModel();
            vm.SupplyDetail = _supplyService.GetAllSupplyDetails(); // позвали сервис
            DataContext = vm;
            int k = 45;
        }
        //юай потом идем в бизнес и потом дэйталэир потом возвращаем данные в бизнес
        //возможно изменяет удаляем добавляем и в юайё
    }
}
