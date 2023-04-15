using System.Text;
using Xunit;
using pkg;
using System;

namespace tests
{
    public class Copy_Tests
    {

        //GetLength tests
        [Fact]
        public void GetLengthString() 
        {
            int res = SubTree.GetSubTreeLength("IIqrIIpqIpr",1);
            Assert.Equal(3,res);
        }

        [Fact]
        public void GetLengthStringBuilder()
        {
            int res = SubTree.GetSubTreeLength(new StringBuilder("IIqrIIpqIpr"),1);
            Assert.Equal(3,res);
        }

        [Fact]
        public void GetLengthStringSpan()
        {
            int res = SubTree.GetSubTreeLength("IIqrIIpqIpr".AsSpan(),1);
            Assert.Equal(3,res);
        }

        // SubTree copy StringBuilder tests
        [Fact]
        public void CopySubTree_StringBuilder_1()  => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_StringBuilder2() => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "IIpqIpr",4);
        
        [Fact]
        public void CopySubTree_StringBuilder3() => SubTreeCopyGenericStringBuilderTest("IIqrIIpqIpr" , "q",2);

        // SubTree copy String tests

        [Fact]
        public void CopySubTree_String1()  => SubTreeCopyGenericStringTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_String2() => SubTreeCopyGenericStringTest("IIqrIIpqIpr" , "IIpqIpr",4);

        [Fact]
        public void CopySubTree_String3() => SubTreeCopyGenericStringTest("IIqrIIpqIpr" , "q",2);

        // SubTree copy String tests

        [Fact]
        public void CopySubTree_Span1()  => SubTreeCopyGenericSpanTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_Span2() => SubTreeCopyGenericSpanTest("IIqrIIpqIpr" , "IIpqIpr",4);

        [Fact]
        public void CopySubTree_Span3() => SubTreeCopyGenericSpanTest("IIqrIIpqIpr" , "q",2);


        // SubTree cut StringBuilder tests
        [Fact]
        public void CutSubTree_StringBuilder_1()  => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1, "IIIpqIpr");

        [Fact]
        public void CutSubTree_StringBuilder_2() => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "IIpqIpr",4, "IIqr");
        
        [Fact]
        public void CutSubTree_StringBuilder_3() => SubTreeCutGenericStringBuilderTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");

        // SubTree cut string tests
        [Fact]
        public void CutSubTree_String_1()  => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "Iqr",1, "IIIpqIpr");

        [Fact]
        public void CutSubTree_String_2() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");

        [Fact]
        public void CutSubTree_String_3() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");
        
        // SubTree cut span tests
        [Fact]
        public void CutSubTree_Span_1()  => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "Iqr",1, "IIIpqIpr");

        [Fact]
        public void CutSubTree_Span_2() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");

        [Fact]
        public void CutSubTree_Span_3() => SubTreeCutGenericStringTest("IIqrIIpqIpr" , "q",2, "IIrIIpqIpr");


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

        private void SubTreeCopyGenericSpanTest(string strinput , string stroutput , int i)
        {
            ReadOnlySpan<char> span =  strinput.AsSpan();
            ReadOnlySpan<char>  expected = stroutput.AsSpan();
            ReadOnlySpan<char>  res = SubTree.Copy(span, i);
            Assert.Equal(stroutput, res.ToString());
        }

        // private void SubTreeCopyGenericSpanTest(string strinput , string stroutput , int i)
        // {
        //     StringBuilder output = SubTree.Copy(strinput.AsSpan(), i);
        //     Assert.Equal(stroutput, output.ToString());
        // }

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

        // private void SubTreeCutGenericSpanTest(string strinput, string stroutput , int i, string cutedInput)
        // {
        //     string res = SubTree.Cut(ref strinput.AsSpan(),i);
        //     Assert.Equal(stroutput, res);
        //     Assert.Equal(cutedInput,strinput.ToString()); 
        // }

    }  
}
