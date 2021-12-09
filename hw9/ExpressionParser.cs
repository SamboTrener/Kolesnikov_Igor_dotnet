using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using hw9.Interfaces;

namespace hw9
{
    public class ExpressionParser : IParser
    {
        private static readonly Dictionary<Operation, int> priorities = new()
        {
            {Operation.Lb, 0},
            {Operation.Add, 1},
            {Operation.Subtract, 1},
            {Operation.Multiply, 2},
            {Operation.Divide, 2}
        };

        public Expression ParseExpression(string stringToParse)
        {
            var stack = new Stack<Expression>();
            var operationStack = new Stack<Operation>();
            var numberBeforeParse = "";
            foreach (var symbol in stringToParse)
            {
                var strSymbol = symbol.ToString();

                if (!TryParseOperationOrQuit(strSymbol, out var operation) && strSymbol != ")" && strSymbol != "(")
                {
                    numberBeforeParse += strSymbol;
                    continue;
                }
                
                if (numberBeforeParse != "")
                {
                    var doubledNumber = double.Parse(numberBeforeParse);
                    stack.Push(Expression.Constant(doubledNumber,
                        typeof(double))); //Сомнительная строка, потом проверить
                    numberBeforeParse = "";
                }
                
                if (operation != Operation.None && operation != Operation.Lb)
                {
                    while (operationStack.Count > 0 && priorities[operationStack.Peek()] >= priorities[operation])
                    {
                        MakeBinaryExpression(stack, operationStack);
                    }

                    operationStack.Push(operation);
                }
                else if (symbol == '(')
                    operationStack.Push(Operation.Lb);
                else if (symbol == ')')
                {
                    Operation operationFromStack;
                    do
                    {
                        MakeBinaryExpression(stack, operationStack);
                        operationFromStack = operationStack.Pop();
                    } while (operationStack.Count > 0 && operationFromStack != Operation.Lb);
                }
                else
                    throw new ArgumentException();
            }

            if (numberBeforeParse != "")
            {
                var doubledNumber = double.Parse(numberBeforeParse);
                stack.Push(Expression.Constant(doubledNumber,
                typeof(double)));
            }

            while (operationStack.Count > 0)
            {
                MakeBinaryExpression(stack, operationStack);
            }

            return stack.Pop();
        }

        public void MakeBinaryExpression(Stack<Expression> stack, Stack<Operation> operationStack)
        {
            var rightVal = stack.Pop();
            switch (operationStack.Pop())
            {
                case Operation.Add:
                    stack.Push(Expression.MakeBinary(ExpressionType.Add, stack.Pop(),
                        rightVal));
                    break;
                case Operation.Subtract:
                    stack.Push(Expression.MakeBinary(ExpressionType.Subtract, stack.Pop(),
                        rightVal));
                    break;
                case Operation.Multiply:
                    stack.Push(Expression.MakeBinary(ExpressionType.Multiply, stack.Pop(),
                        rightVal));
                    break;
                case Operation.Divide:
                    stack.Push(Expression.MakeBinary(ExpressionType.Divide, stack.Pop(),
                        rightVal));
                    break;
            }
        }

        public bool TryParseOperationOrQuit(string arg, out Operation operation)
        {
            switch (arg)
            {
                case "+":
                    operation = Operation.Add;
                    break;
                case "-":
                    operation = Operation.Subtract;
                    break;
                case "*":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Divide;
                    break;
                case "(":
                    operation = Operation.Lb;
                    break;
                default:
                    operation = Operation.None;
                    return false;
            }

            return true;
        }
    }
}