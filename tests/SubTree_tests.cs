using System.Text;
using Xunit;
using pkg;

namespace tests
{
    public class Copy_Tests
    {

        // SubTree copy tests
        [Fact]
        public void CopySubTree_Test1()  => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_Test2() => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "IIpqIpr",4);
        
        [Fact]
        public void CopySubTree_Test3() => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "q",2);

        [Fact]
        public void CopySubTree_Test4()  => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_Test5() => SubTreeCopyGenericStringTest("IIqrIIpqIpr" , "IIpqIpr",4);

        [Fact]
        public void CopySubTree_Test6() => SubTreeCopyGenericStringTest("IIqrIIpqIpr" , "q",2);


        // SubTree cut tests
        [Fact]
        public void CutSubTree_Test1()  => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1, "IIIpqIpr");

        [Fact]
        public void CutSubTree_Test2() => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "IIpqIpr",4, "IIqr");
        
        [Fact]
        public void CutSubTree_Test3() => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");

        [Fact]
        public void CutSubTree_Test4()  => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "Iqr",1, "IIIpqIpr");

        [Fact]
        public void CutSubTree_Test5() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");

        [Fact]
        public void CutSubTree_Test6() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");


        private void SubTreeCopyGenericStringBuilderTest(string strinput , string stroutput , int i)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = SubTree.Copy(input, i);
            Assert.Equal(stroutput, output.ToString());
        }
        private void SubTreeCopyGenericStringTest(string strinput , string stroutput , int i)
        {
            string res = SubTree.Copy(strinput, i);
            Assert.Equal(stroutput, res);
        }

        private void SubTreeCutGenericStringBuilderTest(string strinput, string stroutput, int i, string cutedInput)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = SubTree.Cut(input, i);
            Assert.Equal(stroutput, output.ToString());
            Assert.Equal(cutedInput,input.ToString()); 
        }
        private void SubTreeCutGenericStringTest(string strinput, string stroutput , int i, string cutedInput)
        {
            string res = SubTree.Cut(ref strinput,i);
            Assert.Equal(stroutput, res);
            Assert.Equal(cutedInput,strinput.ToString()); 
        }

    }  
}
