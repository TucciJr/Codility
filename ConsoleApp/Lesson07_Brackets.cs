// See https://aka.ms/new-console-template for more information
internal class Lesson07_Brackets
{
    public Lesson07_Brackets()
    {
        Console.WriteLine("Lesson07_Brackets");
        Console.WriteLine("-----------------");

        Run(")(");
        Run("[]{}(");
        Run("[[]{}()");
        Run("([]{}())");
        Run("");
        Run("]");
        Run("[");

        Console.WriteLine("--- * ---");
    }

    private void Run(string S)
    {
        var run = solution(S);
        Console.WriteLine($"String: [{run}] -  S: {S}");
    }

    public int solution(string S)
    {
        var stack = new Stack<char>();

        foreach (var s in S)
        {
            if ("([{".Contains(s))
            {
                stack.Push(s);
            }
            else if (stack.Count == 0)
            {
                return 0;
            }
            else
            {
                var peek = stack.Peek();

                if (s == ')' && peek == '(' ||
                    s == '}' && peek == '{' ||
                    s == ']' && peek == '[')
                {
                    stack.Pop();
                }
            }
        }

        return stack.Count == 0 ? 1 : 0;
    }
}