using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Entities
{
    public class Comment
    {
         public int Id { get; set; }
         public Client Client { get; set; }
        public string Text { get; set; }
    }
}
