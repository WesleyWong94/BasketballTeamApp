using System;
using System.Collections.Generic;

#nullable disable

namespace basketballAPI.Models
{
    public partial class Fixture
    {
        public string Fixturename { get; set; }
        public DateTime Fixturedate { get; set; }
        public string Fixturevenue { get; set; }
    }
}
