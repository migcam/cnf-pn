using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using dpll_dotnet_5;

namespace tests
{
    public class Interiorization_Tests
    {
        [Fact]
        public void Interiorization_ORs_test1()
        {
            StringBuilder input = new StringBuilder("DCqrp");
            StringBuilder output = Interiorization.Interiorization_ORs(input);
            Assert.Equal("CDqpDrp", output.ToString());
        }

        [Fact]
        public void Interiorization_ORs_test2()
        {
            StringBuilder input = new StringBuilder("DCDqrDuyp");
            StringBuilder output = Interiorization.Interiorization_ORs(input);
            Assert.Equal("CDDqrpDDuyp", output.ToString());
        }
    }
}
