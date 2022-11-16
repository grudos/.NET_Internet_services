using System;
using System.Collections.Generic;

namespace SportsAgents.Models
{
    public partial class Athlete
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string DisciplineName { get; set; } = null!;
        public string UserLogin { get; set; } = null!;

        //public virtual User UserLoginNavigation { get; set; } = null!;
    }
}
