internal class Lesson02_OddOccurrencesInArray
{
    public Lesson02_OddOccurrencesInArray()
    {
        Console.WriteLine("Lesson02_OddOccurrencesInArray");
        Console.WriteLine("------------------------------");

        Run([9, 3, 9, 3, 9, 7, 9]);
        Run([9, 3, 9, 3, 9, 7, 9, 7, 1]);

        Console.WriteLine("--- * ---");
    }

    private void Run(int[] A)
    {
        var oddOccurrencesInArray = solution(A);

        Console.WriteLine($"Odd: {oddOccurrencesInArray} in array [{string.Join(",", A)}]");
    }

    private int solution(int[] A)
    {
        var pairs = new HashSet<int>();

        foreach (var number in A)
        {
            if (!pairs.Contains(number))
            {
                pairs.Add(number);
            }
            else
            {
                pairs.Remove(number);
            }
        }

        return pairs.Single();
    }
}

/*
9, 3, 9, 3, 9, 7, 9


*/