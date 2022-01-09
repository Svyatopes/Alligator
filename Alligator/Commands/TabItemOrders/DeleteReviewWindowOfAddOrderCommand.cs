using Alligator.BusinessLayer;
using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemOrders
{
    public class DeleteReviewWindowOfAddOrderCommand : CommandBase
    {
        private TabItemOrdersViewModel _viewModel;
       
        public DeleteReviewWindowOfAddOrderCommand(TabItemOrdersViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedNewOrderReview is not null;
        }
        public override void Execute(object parameter)
        {
            _viewModel.NewOrderReviews.Remove(_viewModel.SelectedNewOrderReview);
        }
    }   
}
