﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Evaluator
    {
        private const double EPS = 1e-5;
        private const char GUARDIAN_OPERATION = '#';
        private static readonly Dictionary<char, int> operatorPriorityInExpression = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2}, {'%', 2},
            {'^', 4},
            {'(', 5},
        };
        private static readonly Dictionary<char, int> operatorPriorityInStack = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2}, {'%', 2},
            {'^', 3},
            {'(', 0},
        };

        private static readonly char[] operators = { '+', '-', '*', '/', '%', '^', '(' };

        private bool divisionByZeroFlag;
        private bool unmatchedParenthesesFlag;

        public Evaluator()
        {
            divisionByZeroFlag = false;
            unmatchedParenthesesFlag = false;
        }
        
        public double eval(string infix_expr)
        {
            this.divisionByZeroFlag = false;
            this.unmatchedParenthesesFlag = false;

            string postfix_expr = postfix_representation(infix_expr);
            double result = computeResult(postfix_expr);

            if (divisionByZeroFlag || unmatchedParenthesesFlag)
                result = double.NaN;

            return result;
        }

        public string getInvalidExpressionMessage()
        {
            if (divisionByZeroFlag && !unmatchedParenthesesFlag)
                return "Division by zero.";
            if (!divisionByZeroFlag && unmatchedParenthesesFlag)
                return "Unmatched parentheses.";
            return "Invalid expression";
        }

        private bool isOperator(char c)
        {
            return operators.Contains(c);
        }

        private string postfix_representation(string expr)
        {
            StringBuilder sb = new StringBuilder();

            Stack<char> operatorStack = new Stack<char>();
            operatorStack.Push(GUARDIAN_OPERATION);

            foreach (char c in expr)
            {
                if (Char.IsDigit(c) || c == '.')
                {
                    sb.Append(c);
                }
                else if (isOperator(c))
                {
                    sb.Append(' ');
                    if (operatorPriorityInExpression[c] <= operatorPriorityInStack[operatorStack.Peek()])
                    {
                        sb.Append(operatorStack.Pop());
                        sb.Append(' ');
                    }

                    operatorStack.Push(c);
                }
                else if (c == ')')
                {
                    sb.Append(' ');
                    while (operatorStack.Peek() != '(')
                    {
                        sb.Append(operatorStack.Pop());
                        sb.Append(' ');
                    }

                    operatorStack.Pop();
                }
            }

            while (operatorStack.Peek() != GUARDIAN_OPERATION)
            {
                sb.Append(' ');
                sb.Append(operatorStack.Pop());
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }
        
        private double computeResult(string postfix_repr)
        {
            double result = 0.0;

            string[] tokens = postfix_repr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<double> operandStack = new Stack<double>();

            foreach (string token in tokens)
            {
                if (isOperator(token[0]))
                {
                    double operandRight = operandStack.Pop();
                    double operandLeft = operandStack.Pop();

                    double intermediary_res = 0;
                    switch (token[0])
                    {
                        case '+':
                            intermediary_res = operandLeft + operandRight;
                            break;
                        case '-':
                            intermediary_res = operandLeft - operandRight;
                            break;
                        case '*':
                            intermediary_res = operandLeft * operandRight;
                            break;
                        case '/':
                            intermediary_res = operandLeft / operandRight;
                            if (Math.Abs(operandRight) < EPS)
                                divisionByZeroFlag = true;
                            break;
                        case '%':
                            intermediary_res = operandLeft % operandRight;
                            if (intermediary_res < 0)
                                intermediary_res += operandRight;
                            
                            if (Math.Abs(operandRight) < EPS)
                                divisionByZeroFlag = true;
                            break;
                        case '^':
                            intermediary_res = Math.Pow(operandLeft, operandRight);
                            break;
                    }
                    operandStack.Push(intermediary_res);

                }
                else
                {
                    operandStack.Push(double.Parse(token, System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            result = operandStack.Pop();


            return result;
        }    
    }
}
