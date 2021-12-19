using Alligator.BusinessLayer;
using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.VIewModels.EntitiesViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        //public ClientViewModel(ClientModel clientModel)
        //{
                
        //    FirstName = clientModel.FirstName;
        //    LastName = clientModel.LastName;
        //    Patronymic = clientModel.Patronymic;
        //    PhoneNumber = clientModel.PhoneNumber;
        //    Email = clientModel.Email;
        //}
        
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string patronymic { get; set; }
        private string phoneNumber { get; set; }
        private string email { get; set; }
        private List<CommentModel> Comments { get; set; }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }


        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
