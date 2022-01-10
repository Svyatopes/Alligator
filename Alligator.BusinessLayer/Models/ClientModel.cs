﻿using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alligator.BusinessLayer
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<OrderModel> Orders { get; set; }

      

        public bool IsValid()
        {
            if (FirstName.Length > 50)
                return false;
            if (LastName.Length > 50)
                return false;
            if (Patronymic.Length > 50)
                return false;
            if (PhoneNumber.Length > 50)
                return false;
            if (Email.Length > 200)
                return false;
            return true;
        }

    }
}
