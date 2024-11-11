using System;
public class Solution
{
    public bool ParseBoolExpr(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == ')')
            {  // End of an expression
                List<char> operands = new List<char>();

                // Pop until we get to the start of the expression
                while (stack.Peek() != '(')
                {
                    operands.Add(stack.Pop());
                }
                stack.Pop();  // Remove the '('
                char operatorChar = stack.Pop();  // Get the operator before '('

                bool result;
                if (operatorChar == '&')
                {
                    result = operands.All(op => op == 't');
                }
                else if (operatorChar == '|')
                {
                    result = operands.Any(op => op == 't');
                }
                else
                { // operatorChar == '!'
                    result = operands[0] == 'f';
                }

                // Push result back as 't' for true or 'f' for false
                stack.Push(result ? 't' : 'f');
            }
            else if (c == 't' || c == 'f' || c == '!' || c == '&' || c == '|' || c == '(')
            {
                stack.Push(c);
            }
            // Ignore commas as they are separators
        }

        // The result will be the only item left in the stack
        return stack.Pop() == 't';
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        // Test cases
        string expression1 = "&(|(f))";
        string expression2 = "|(f,f,f,t)";
        string expression3 = "!(&(f,t))";

        // Printing the results
        Console.WriteLine("Expression: " + expression1 + " => " + solution.ParseBoolExpr(expression1)); // Expected: false
        Console.WriteLine("Expression: " + expression2 + " => " + solution.ParseBoolExpr(expression2)); // Expected: true
        Console.WriteLine("Expression: " + expression3 + " => " + solution.ParseBoolExpr(expression3)); // Expected: true

    }
}
