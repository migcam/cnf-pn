using System;
using System.Text;
using pkg;
using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class NegationBenchmarks
    {

        private void GenericStringBuilder(StringBuilder input)
        {
            Negations.Delete_Negation(input);
        }

        private void GenericString(string input)
        {
            Negations.Delete_Negation(input);
        }

        private void GenericSpan(ReadOnlySpan<char> input)
        {
            Negations.Delete_Negation(input);
        }

        private void GenericExpression1(CnfExpressionParser input)
        {
            input.MoveNegationsInward();
        }

        private void GenericExpression2(CnfExpressionParser input, MoveNegationsInwardVisitor visitor)
        {
            visitor.Visit(input._expression);
        }

        [Benchmark]
        public void NegationStringBuilder1() => GenericStringBuilder(new StringBuilder("DNDNqrDNDNpqDNpr"));
        [Benchmark]
        public void NegationStringBuilder2() => GenericStringBuilder(new StringBuilder("NCNpp"));
        [Benchmark]
        public void NegationStringBuilder3() => GenericStringBuilder(new StringBuilder("NNNNNNNp"));
        [Benchmark]
        public void NegationStringBuilder4() => GenericStringBuilder(new StringBuilder("DNDNpqDpNp"));

        [Benchmark]
        public void NegationString1() => GenericString("DNDNqrDNDNpqDNpr");
        [Benchmark]
        public void NegationString2() => GenericString("NCNpp");
        [Benchmark]
        public void NegationString3() => GenericString("NNNNNNNp");
        [Benchmark]
        public void NegationString4() => GenericString("DNDNpqDpNp");

        [Benchmark]
        public void NegationSpan1() => GenericSpan("DNDNqrDNDNpqDNpr");
        [Benchmark]
        public void NegationSpan2() => GenericSpan("NCNpp");
        [Benchmark]
        public void NegationSpna3() => GenericSpan("NNNNNNNp");
        [Benchmark]
        public void NegationSpan4() => GenericSpan("DNDNpqDpNp");


        [Benchmark]
        public void NegationExpression1() => GenericExpression1(new CnfExpressionParser("DNDNqrDNDNpqDNpr"));
        [Benchmark]
        public void NegationExpression2() => GenericExpression1(new CnfExpressionParser("NCNpp"));
        [Benchmark]
        public void NegationExpression3() => GenericExpression1(new CnfExpressionParser("NNNNNNNp"));
        [Benchmark]
        public void NegationExpression4() => GenericExpression1(new CnfExpressionParser("DNDNpqDpNp"));

        [Benchmark]
        public void NegationExpression5() => GenericExpression2(new CnfExpressionParser("DNDNqrDNDNpqDNpr"), new MoveNegationsInwardVisitor());
        [Benchmark]
        public void NegationExpression6() => GenericExpression2(new CnfExpressionParser("NCNpp"), new MoveNegationsInwardVisitor());
        [Benchmark]
        public void NegationExpression7() => GenericExpression2(new CnfExpressionParser("NNNNNNNp"), new MoveNegationsInwardVisitor());
        [Benchmark]
        public void NegationExpression8() => GenericExpression2(new CnfExpressionParser("DNDNpqDpNp"), new MoveNegationsInwardVisitor());

    }

}
