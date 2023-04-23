using System;
using System.Linq.Expressions;

public class MoveNegationsInwardVisitor : ExpressionVisitor
{
    protected override Expression VisitUnary(UnaryExpression node)
    {
        if (node.NodeType == ExpressionType.Not)
        {
            var operand = Visit(node.Operand);
            if (operand is BinaryExpression binaryOperand)
            {
                if (binaryOperand.NodeType == ExpressionType.And)
                {
                    var left = Visit(Expression.Not(binaryOperand.Left));
                    var right = Visit(Expression.Not(binaryOperand.Right));
                    return Expression.Or(left, right);
                }
                else if (binaryOperand.NodeType == ExpressionType.Or)
                {
                    var left = Visit(Expression.Not(binaryOperand.Left));
                    var right = Visit(Expression.Not(binaryOperand.Right));
                    return Expression.And(left, right);
                }
            }
            else if (operand is UnaryExpression unaryOperand && unaryOperand.NodeType == ExpressionType.Not)
            {
                return Visit(unaryOperand.Operand);
            }
            else
            {
                return Expression.Not(operand);
            }
        }
        return base.VisitUnary(node);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        var left = Visit(node.Left);
        var right = Visit(node.Right);
        if (left != node.Left || right != node.Right)
        {
            switch (node.NodeType)
            {
                case ExpressionType.And:
                    return Expression.And(left, right);
                case ExpressionType.Or:
                    return Expression.Or(left, right);
                default:
                    throw new NotSupportedException($"Unsupported binary operator {node.NodeType}");
            }
        }
        return base.VisitBinary(node);
    }
}
