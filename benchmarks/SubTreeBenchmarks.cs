using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkg;
using BenchmarkDotNet.Attributes;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class SubTreeBenchmarks
    {

        // [Benchmark]
        // public void CopySubTree_1_StringBuilder()  => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),1);

        // [Benchmark]
        // public void CopySubTree_1_String()  => GenericString("IIqrIIpqIpr",1);

        // [Benchmark]
        // public void CopySubTree_1_Span()  => GenericString("IIqrIIpqIpr",1);

        // [Benchmark]
        // public void CopySubTree_2_StringBuilder() => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),4);

        // [Benchmark]
        // public void CopySubTree_2_String() => GenericString("IIqrIIpqIpr",4);
        // [Benchmark]
        // public void CopySubTree_2_String() => GenericSpan("IIqrIIpqIpr".AsSpan(),4);
        
        // [Benchmark]
        // public void CopySubTree_3_StringBuilder() => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),2);

        // [Benchmark]
        // public void CopySubTree_3_String() => GenericString("IIqrIIpqIpr",2);

        // [Benchmark]
        // public void CopySubTree_4_StringBuilder()  => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),1);

        // [Benchmark]
        // public void CopySubTree_4_String()  => GenericString("IIqrIIpqIpr",1);


        // [Benchmark]
        // public void GetSubTreeLength_String() => SubTree.GetSubTreeLength("IIqrIIpqIpr",4);
        // [Benchmark]
        // public void GetSubTreeLength_String() => SubTree.GetSubTreeLength("IIqrIIpqIpr",4);
        // [Benchmark]
        // public void GetSubTreeLength_Span() => SubTree.GetSubTreeLength("IIqrIIpqIpr".AsSpan(),4);


        [Benchmark]
        public void CutSubTree_1_StringBuilder()  => GenericCutStringBuilder(new StringBuilder("IIqrIIpqIpr"),1);

        [Benchmark]
        public void CutSubTree_1_String()  => GenericCutString("IIqrIIpqIpr",1);

         [Benchmark]
        public void CutSubTree_1_Span()  => GenericCutSpan("IIqrIIpqIpr".AsSpan(),1);


         private void GenericCopyStringBuilder(StringBuilder input, int i)
        {
            StringBuilder output = SubTree.Copy(input, i);
        }

        private void GenericCoytring(string strinput , int i)
        {
            string res = SubTree.Copy(strinput, i);
        }

        private void GenericCopySpan(ReadOnlySpan<char> strinput , int i)
        {
            ReadOnlySpan<char>  res = SubTree.Copy(strinput, i);
        }

        private void GenericCutStringBuilder(StringBuilder input, int i)
        {
            StringBuilder output = SubTree.Copy(input, i);
        }

        private void GenericCutString(string strinput , int i)
        {
            string res = SubTree.Copy(strinput, i);
        }

        private void GenericCutSpan(ReadOnlySpan<char> strinput , int i)
        {
            ReadOnlySpan<char>  res = SubTree.Copy(strinput, i);
        }


    }
}
