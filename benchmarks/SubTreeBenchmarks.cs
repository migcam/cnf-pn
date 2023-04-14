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

        private void GenericStringBuilder(StringBuilder input, int i)
        {
            StringBuilder output = SubTree.Copy(input, i);
        }
        private void GenericString(string strinput , int i)
        {
            string res = SubTree.Copy(strinput, i);
        }

        [Benchmark]
        public void CopySubTree_1_StringBuilder()  => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),1);

        [Benchmark]
        public void CopySubTree_1_String()  => GenericString("IIqrIIpqIpr",1);

        [Benchmark]
        public void CopySubTree_2_StringBuilder() => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),4);

        [Benchmark]
        public void CopySubTree_2_String() => GenericString("IIqrIIpqIpr",4);
        
        [Benchmark]
        public void CopySubTree_3_StringBuilder() => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),2);

        [Benchmark]
        public void CopySubTree_3_String() => GenericString("IIqrIIpqIpr",2);

        [Benchmark]
        public void CopySubTree_4_StringBuilder()  => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"),1);

        [Benchmark]
        public void CopySubTree_4_String()  => GenericString("IIqrIIpqIpr",1);

    }
}
