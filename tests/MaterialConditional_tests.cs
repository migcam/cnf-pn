using System.Text;
using Xunit;
using dpll_dotnet_5;

namespace tests
{
    public class MaterialConditional_tests
    {
        [Fact]
        public void Delete_All_Implications_Test()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            StringBuilder output = MaterialConditional.Delete_All_Implications(input);          
            Assert.Equal("DNDNqrDNDNpqDNpr", output.ToString());
        }


    }
}
