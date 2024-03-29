using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public static class ExpressionExtensions
{
    public static Expression MoveNegationInward(Expression exp)
    {
        // exp = exp.ReduceNots();
        // return MoveNotInward(exp);
        return new MoveNegationsInwardVisitor().Visit(exp);
    }

    public static Expression MoveNotInward(Expression expression)
    {

        if (expression is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Not)
        {
            var operand = unaryExpression.Operand;

            switch (operand)
            {
                case BinaryExpression binaryExpression when binaryExpression.NodeType == ExpressionType.And ||
                 binaryExpression.NodeType == ExpressionType.AndAlso :
                    var left = MoveNotInward(Expression.Not(binaryExpression.Left));
                    var right = MoveNotInward(Expression.Not(binaryExpression.Right));
                    return Expression.Or(left, right);

                case BinaryExpression binaryExpression when binaryExpression.NodeType == ExpressionType.Or ||
                    binaryExpression.NodeType == ExpressionType.OrElse :
                    var left1 = MoveNotInward(Expression.Not(binaryExpression.Left));
                    var right1 = MoveNotInward(Expression.Not(binaryExpression.Right));
                    return Expression.And(left1, right1);

                case UnaryExpression nestedUnaryExpression when nestedUnaryExpression.NodeType == ExpressionType.Not:
                    return MoveNotInward(nestedUnaryExpression.Operand);

                default:
                    return expression;
            }
        }
        else if (expression is BinaryExpression binaryExpression)
        {
            var left = MoveNotInward(binaryExpression.Left);
            var right = MoveNotInward(binaryExpression.Right);
            if (left != binaryExpression.Left || right != binaryExpression.Right)
            {
                switch (binaryExpression.NodeType)
                {
                    case ExpressionType.And:
                        return Expression.And(left, right);
                    case ExpressionType.Or:
                        return Expression.Or(left, right);
                    default:
                        throw new NotSupportedException($"Unsupported binary operator {binaryExpression.NodeType}");
                }
            }
        }
        return expression;
    }

    
    public static Expression ReduceNots(this Expression expression)
    {
        if (expression.NodeType == ExpressionType.Not)
        {
            var unaryExpression = (UnaryExpression)expression;
            if (unaryExpression.Operand.NodeType == ExpressionType.Not)
            {
                return unaryExpression.Operand.ReduceNots();
            }
            else
            {
                return unaryExpression;
            }
        }
        else if (expression is BinaryExpression binaryExpression)
        {
            return Expression.MakeBinary(binaryExpression.NodeType, binaryExpression.Left.ReduceNots(), binaryExpression.Right.ReduceNots());
        }
        else if (expression is ConditionalExpression conditionalExpression)
        {
            return Expression.Condition(conditionalExpression.Test.ReduceNots(), conditionalExpression.IfTrue.ReduceNots(), conditionalExpression.IfFalse.ReduceNots());
        }
        else
        {
            return expression;
        }
    }

    public static Expression Interiorization(this Expression expression)
    {
        while (true)
        {
            // Find an OR expression
            var orExpression = FindOrExpression(expression);
            if (orExpression == null) break; // No more ORs to distribute

            // Find all AND expressions inside the OR expression
            var andExpressions = FindAndExpressions(orExpression);

            // Replace the OR expression with the distributed expression
            expression = DistributeOrOverAnds(orExpression, andExpressions);
        }

        return expression;

    }

    private static Expression FindOrExpression(Expression expression)
    {
        if (expression.NodeType == ExpressionType.OrElse) return expression;
        var binaryExpression = expression as BinaryExpression;
        if (binaryExpression == null) return null;
        var leftOrExpression = FindOrExpression(binaryExpression.Left);
        if (leftOrExpression != null) return leftOrExpression;
        var rightOrExpression = FindOrExpression(binaryExpression.Right);
        if (rightOrExpression != null) return rightOrExpression;
        return null;
    }

    private static List<Expression> FindAndExpressions(Expression expression)
    {
        var andExpressions = new List<Expression>();
        if (expression.NodeType == ExpressionType.AndAlso)
        {
            var binaryExpression = (BinaryExpression)expression;
            andExpressions.AddRange(FindAndExpressions(binaryExpression.Left));
            andExpressions.AddRange(FindAndExpressions(binaryExpression.Right));
            andExpressions.Add(expression);
        }
        else
        {
            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Not)
            {
                andExpressions.AddRange(FindAndExpressions(unaryExpression.Operand));
            }
        }
        return andExpressions;
    }

    private static Expression DistributeOrOverAnds(Expression orExpression, List<Expression> andExpressions)
    {
        // Distribute OR over all AND expressions
        Expression newOrExpression = orExpression;
        foreach (var andExpression in andExpressions)
        {
            var andLeft = ((BinaryExpression)andExpression).Left;
            var andRight = ((BinaryExpression)andExpression).Right;

            newOrExpression = Expression.OrElse(
                Expression.OrElse(newOrExpression, andLeft),
                andRight
            );
        }

        // Negate original OR expression and combine with new expression
        Expression notOrExpression = Expression.Not(orExpression);
        Expression notNewOrExpression = Expression.Not(newOrExpression);
        return Expression.AndAlso(
            Expression.OrElse(notOrExpression, notNewOrExpression),
            Expression.OrElse(orExpression, newOrExpression)
        );
    }


    
}

