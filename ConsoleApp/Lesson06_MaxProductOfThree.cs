// See https://aka.ms/new-console-template for more information
internal class Lesson06_MaxProductOfThree
{
    public Lesson06_MaxProductOfThree()
    {
        Console.WriteLine("Lesson06_MaxProductOfThree");
        Console.WriteLine("--------------------------");

        Run([-10, -2, -4]);
        Run([-3, 1, 2, -2, 5, 6]);

        Console.WriteLine("--- * ---");
    }

    private void Run(int[] A)
    {
        var run = solution(A);
        Console.WriteLine($"String: [{run}] -  S: {A}");
    }

    public int solution(int[] A)
    {
        var max = -1000;

        for (int i = 0; i < A.Length - 2; i++)
        {
            for (int j = i + 1; j < A.Length - 1; j++)
            {
                for (int k = j + 1; k < A.Length; k++)
                {
                    var product = A[i] * A[j] * A[k];
                    Console.WriteLine($"{i} - {j} - {k}, product: {product}");

                    max = Math.Max(max, product);
                }
            }
        }

        return max;
    }
}