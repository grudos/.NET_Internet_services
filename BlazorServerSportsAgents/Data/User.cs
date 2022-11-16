using System;
using System.Collections.Generic;

namespace SportsAgents.Models
{
    public partial class User
    {
        public User()
        {
            Athletes = new HashSet<Athlete>();
        }

        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }
    }



}
