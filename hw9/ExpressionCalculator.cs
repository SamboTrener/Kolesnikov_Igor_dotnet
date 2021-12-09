using System.Globalization;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using hw9.Interfaces;

namespace hw9
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
            var expr = parser.ParseExpression(expression);
            var resultExpression = visitor.Visit(expr);
            var result = (double)((ConstantExpression)resultExpression).Value;
            return result;
        }
    }

    public class Visitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var rightNodeTask = Task.Run(() => (double) ((ConstantExpression) Visit(node.Right)).Value);
            var leftNodeTask = Task.Run(() => (double) ((ConstantExpression) Visit(node.Left)).Value);
            Thread.Sleep(1000);
            Task.WaitAll(leftNodeTask, rightNodeTask);
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

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return node;
        }
    }
}