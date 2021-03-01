using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using dpll_dotnet_5;

namespace tests
{
    public class Copy_Tests
    {
        [Fact]
        public void CopySubTree_Test1()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            StringBuilder output = SubTree.Copy(input, 1);
            Assert.Equal("Iqr", output.ToString());
        }

        [Fact]
        public void CopySubTree_Test2()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            StringBuilder output = SubTree.Copy(input, 4);
            Assert.Equal("IIpqIpr", output.ToString());
        }

        [Fact]        
        public void CopySubTree_Test3()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            StringBuilder output = SubTree.Copy(input, 2);
            Assert.Equal("q", output.ToString());
        }
    }
}
