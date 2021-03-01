using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class Biconditional_tests
    {
        [Fact]
        public void Delete_MaterialConditions_Test1()
        {
            StringBuilder input = new StringBuilder("Epq");
            Biconditional.Delete_MaterialConditions(input);
            Assert.Equal("CIpqIqp", input.ToString());
        }

        [Fact]
        public void Delete_MaterialConditions_Test2()
        {
            StringBuilder input = new StringBuilder("ECpqDab");
            Biconditional.Delete_MaterialConditions(input);
            Assert.Equal("CICpqDabIDabCpq", input.ToString());
        }
    }
}
