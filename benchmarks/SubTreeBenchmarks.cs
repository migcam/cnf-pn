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

        private void GenericStringBuilder(string strinput , string stroutput , int i)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = SubTree.Copy(input, i);
        }
        private void GenericString(string strinput , string stroutput , int i)
        {
            // string input = "IIqrIIpqIpr";
            string res = SubTree.Copy(strinput, i);
        }

        [Benchmark]
        public void CopySubTree_1_StringBuilder()  => GenericStringBuilder("IIqrIIpqIpr" , "Iqr",1);

        [Benchmark]
        public void CopySubTree_2_StringBuilder() => GenericStringBuilder("IIqrIIpqIpr" , "IIpqIpr",4);
        
        [Benchmark]
        public void CopySubTree_3_StringBuilder() => GenericStringBuilder("IIqrIIpqIpr" , "q",2);

        [Benchmark]
        public void CopySubTree_4_StringBuilder()  => GenericStringBuilder("IIqrIIpqIpr" , "Iqr",1);

        
        [Benchmark]
        public void CopySubTree_1_String()  => GenericString("IIqrIIpqIpr" , "Iqr",1);

        [Benchmark]
        public void CopySubTree_2_String() => GenericString("IIqrIIpqIpr" , "IIpqIpr",4);
        
        [Benchmark]
        public void CopySubTree_3_String() => GenericString("IIqrIIpqIpr" , "q",2);

        [Benchmark]
        public void CopySubTree_4_String()  => GenericString("IIqrIIpqIpr" , "Iqr",1);

        // [Benchmark]
        // public void CopySubTree_2_String() => GenericString("IIqrIIpqIpr" , "IIpqIpr",4);

        // [Benchmark]
        // public void CopySubTree_3_String() => GenericString("IIqrIIpqIpr" , "q",2);

    }
}
