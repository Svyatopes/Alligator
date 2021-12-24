using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.ViewModels.EntitiesViewModels
{
    public class CommentViewModel :BaseViewModel
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }



    }
}
