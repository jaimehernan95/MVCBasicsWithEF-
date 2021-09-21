using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsWithEF.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
