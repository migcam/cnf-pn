using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace pkg;

public class CnfExpressionParser
{
    private readonly string _formula;
    private readonly Dictionary<string,bool> dic;
    public Expression _expression;

    public override string ToString()
    {
        return _expression.ToString();
    }

    public CnfExpressionParser() {}

    public CnfExpressionParser(string formula)
    {
        _formula = formula;
        string[] variables = formula.Where(x => Char.IsLower(x)).Distinct().Select(x => x.ToString()).ToArray();
        Dictionary<string,bool> dic = new Dictionary<string, bool>();
        for (int i = 0; i < variables.Length; i++)
            dic.Add(variables[i],false);

        _expression = GenerateTree();
        // _expression.ReduceNots();
        // _expression.Interiorization();
    }

    private Expression GenerateTree()
    {
        Stack<Expression> stack = new Stack<Expression>();

        for (int i = _formula.Length - 1; i >= 0; i--)
        {
            string token = _formula[i].ToString();

            if (token == "E") // logical equivalence operator
            {
                Expression left = stack.Pop();
                Expression right = stack.Pop();
                stack.Push(Expression.And(Expression.Or(Expression.Not(left), right),
                                            Expression.Or(Expression.Not(right), left)));
            }
            else if (token == "I") // logical implication operator
            {
                Expression right = stack.Pop();
                Expression left = stack.Pop();
                stack.Push(Expression.Or(Expression.Not(right), left));
            }
            else if (token == "C") // logical AND operator
            {
                Expression left = stack.Pop();
                Expression right = stack.Pop();           
                stack.Push(Expression.And(left, right));
            }
            else if (token == "D") // logical OR operator
            {
                Expression left = stack.Pop();
                Expression right = stack.Pop();
                stack.Push(Expression.Or(left, right));
            }
            else if (token == "N") // logical NOT operator
            {
                Expression operand = stack.Pop();
                // if(operand.NodeType ==  ExpressionType.Not)
                //     continue;
                stack.Push(Expression.Not(operand));
            }
            
            else // variable name
            {
                ParameterExpression variable = Expression.Parameter(typeof(bool), token);
                stack.Push(variable);
            }
        }

        return stack.Pop();
    }

    public void ReduceNots(){
        _expression = _expression.ReduceNots();
    }

    public void Interiorization(){
        _expression = _expression.Interiorization();
    }

    public Expression ToCNF(){
        _expression.ReduceNots();
        _expression.Interiorization();
        return _expression;
    }



    // public bool EvalueTree(Dictionary<string,bool> dic, Expression exp){
    //     Expression evalTree = new ExpressionTreeModifier(dic).Visit(exp);
    //     Expression<Func<bool>> lambda = Expression.Lambda<Func<bool>>(evalTree);
    //     return lambda.Compile()();
    // }
}

public class ExpressionTreeModifier : ExpressionVisitor
{
    private readonly Dictionary<string, bool> _values;

    public ExpressionTreeModifier(Dictionary<string, bool> values)
    {
        _values = values;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        if (_values.TryGetValue(node.Name, out bool value))
        {
            return Expression.Constant(value, typeof(bool));
        }
        return base.VisitParameter(node);
    }
}