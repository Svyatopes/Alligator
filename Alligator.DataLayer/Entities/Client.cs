using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
