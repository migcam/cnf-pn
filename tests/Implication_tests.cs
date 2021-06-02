using System.Text;
using Xunit;
using pkg;

namespace tests
{
    public class Implication_tests
    {
        [Fact]
        public void Delete_All_Implications_Test()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            StringBuilder output = Implication.Delete_All_Implications(input);          
            Assert.Equal("DNDNqrDNDNpqDNpr", output.ToString());
        }

        [Fact]
        public void Delete_All_Implications_Test1()
        {
            string input = "IIqrIIpqIpr";
            string output = Implication.Delete_All_Implications(input);
            Assert.Equal("DNDNqrDNDNpqDNpr", output);
        }


    }
}
