using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw9.Interfaces
{
    public interface IParser
    {
        public Expression ParseExpression(string stringToParse);

        public void MakeBinaryExpression(Stack<Expression> stack, Stack<Operation> operationStack);

        bool TryParseOperationOrQuit(string arg, out Operation operation);
    }
}