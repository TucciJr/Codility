// See https://aka.ms/new-console-template for more information

internal class Lesson02_CyclicRotation
{
    public Lesson02_CyclicRotation()
    {
        Console.WriteLine("Lesson02_CyclicRotation");
        Console.WriteLine("-----------------------");

        Run([3, 8, 9, 7, 6], 3);
        Run([], 1);

        Console.WriteLine("--- * ---");
    }

    private void Run(int[] A, int K)
    {
        var rotated = solution(A, K);

        Console.WriteLine($"Rotated: [{string.Join(",", rotated)}]");
    }

    public int[] solution(int[] A, int K)
    {
        var count = A.Length;

        if (count < 2 || count == K)
        {
            return A;
        }

        for (int k = 0; k < K; k++)
        {
            var last = A[count - 1];

            for (int i = count - 1; i > 0; i--)
            {
                A[i] = A[i - 1];
            }
            A[0] = last;
            
            //Console.WriteLine($"[{k}] {string.Join(",", A)}");
        }

        return A;
    }
}

/*
[3, 8, 9, 7, 6]

length = 5
last = 6

4 - 7
3 - 9
2 - 8
1 - 3
0 - 6

0 = 6
1 = 3
2 = 8
3 = 9
4 = 7
5 = 6
*/