using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsWithEF.Models
{
    public class Game
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
