using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw11.Interfaces
{
    public interface IParser
    {
        public Expression ParseExpression(string stringToParse);

        void MakeBinaryExpression(Stack<Expression> stack, Stack<Operation> operationStack);

        bool TryParseOperationOrQuit(string arg, out Operation operation);
    }
}