using System;
using System.Collections.Generic;

#nullable disable

namespace basketballAPI.Models
{
    public partial class Fixture
    {
        public int Fixtureid { get; set; }
        public DateTime Fixturedate { get; set; }
        public string Fixturevenue { get; set; }
        public string Fixturemembername { get; set; }
        public double? Fixturecost { get; set; }
    }
}
