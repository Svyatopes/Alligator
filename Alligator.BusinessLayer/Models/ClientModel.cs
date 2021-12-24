using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace Alligator.BusinessLayer
{
    public class ClientModel:ClientShortModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<CommentModel> Comments { get; set; }

    }
}
