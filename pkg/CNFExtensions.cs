using System.Linq.Expressions;

namespace pkg;

public static class CNFHelper
{
    public static bool IsInCNF(this Expression expression)
    {
        // If the expression is a binary logical operator (AND or OR)
        // and both of its operands are either literals or conjunctions of literals,
        // then it is in CNF.
        if (expression is BinaryExpression binaryExpression)
        {
            if (binaryExpression.NodeType == ExpressionType.AndAlso || binaryExpression.NodeType == ExpressionType.OrElse)
            {
                return IsInCNF(binaryExpression.Left) && IsInCNF(binaryExpression.Right);
            }
            else
            {
                return IsLiteral(binaryExpression.Left) && IsLiteral(binaryExpression.Right);
            }
        }
        // If the expression is a negation of a literal,
        // then it is in CNF.
        else if (expression is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Not)
        {
            return IsLiteral(unaryExpression.Operand);
        }
        // If the expression is a literal (a parameter or constant),
        // then it is in CNF.
        else
        {
            return true;
        }
    }

    private static bool IsLiteral(Expression expression)
    {
        return expression is ParameterExpression || expression is ConstantExpression;
    }
}