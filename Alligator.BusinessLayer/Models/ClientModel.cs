using Alligator.BusinessLayer.Models;
using System.Collections.Generic;

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
            return FirstName.Length < 50 &&
                LastName.Length < 50 &&
                PhoneNumber.Length < 50 &&
                Patronymic.Length < 50 &&
                Email.Length < 200;
        }

    }
}