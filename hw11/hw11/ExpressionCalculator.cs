using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using hw11.Interfaces;

namespace hw11
{
    public class ExpressionCalculator : ICalculator
    {
        private IParser parser;
        private readonly Visitor visitor = new();

        public ExpressionCalculator(IParser parser)
        {
            this.parser = parser;
        }

        public double Calculate(string expression)
        {
            Expression expr;
            try
            {
                expr = parser.ParseExpression(expression);
            }
            catch (Exception e)
            {
                throw e;
            }

            var resultExpression = visitor.VisitDynamic(expr);
            return resultExpression;
        }
    }

    public class Visitor
    {
        public double VisitDynamic(Expression expression)
        {
            var t = Visit((dynamic) expression);
            return (double) ((ConstantExpression) t).Value!;
        }

        private Expression Visit(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() => VisitDynamic(node.Left));
            var rightNodeTask = Task.Run(() => VisitDynamic(node.Right));
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;

            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double))
            };
        }

        private Expression Visit(ConstantExpression node)
        {
            return node;
        }
    }
}