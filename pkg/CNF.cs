using System;
using System.Text;

namespace pkg
{
    public class CNF
    {
        public static string ConvertFromString(string expression)
        {
            expression = Biconditional.Delete_MaterialConditions(expression);
            expression = Implication.Delete_All_Implications(expression);
            expression = Negations.Delete_Negation(expression);
            expression = Distribution.Distribution_ORs(expression);
            return expression;
        }

        public static ReadOnlySpan<char> ConvertFromSpan(ReadOnlySpan<char> expression)
        {
            expression = Biconditional.Delete_MaterialConditions(expression);
            expression = Implication.Delete_All_Implications(expression);
            expression = Negations.Delete_Negation(expression);
            expression = Distribution.Distribution_ORs(expression);
            return expression;
        }

        public static void ConvertFromStringBuilder(StringBuilder expression)
        {
            Biconditional.Delete_MaterialConditions(expression);
            Implication.Delete_All_Implications(expression);
            Negations.Delete_Negation(expression);
            Distribution.Distribution_ORs(expression);
            // return expression.ToString();
        }

    }
}