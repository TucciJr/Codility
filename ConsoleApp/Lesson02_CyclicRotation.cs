// See https://aka.ms/new-console-template for more information

internal class Lesson02_CyclicRotation
{
    public Lesson02_CyclicRotation()
    {
        Console.WriteLine("Lesson02_CyclicRotation");
        Console.WriteLine("-----------------------");

        Run([3, 8, 9, 7, 6], 3);

        Console.WriteLine("--- * ---");
    }

    private void Run(int[] A, int K)
    {
        var rotated = solution(A, K);

        Console.WriteLine($"Rotated: [{string.Join(",", rotated)}]");
    }

    public int[] solution(int[] A, int K)
    {
        int[] rotate = new int[A.Length];

        for (int k = 0; k < K; k++)
        {
            rotate[0] = A[A.Length - 1];

            for (int i = 0; i < A.Length - 1; i++)
            {
                rotate[i + 1] = A[i];
            }
            
            //Console.WriteLine($"[{k}] {string.Join(",", A)}");

            A = rotate.Clone() as int[];
        }

        return rotate;
    }
}

/*
[3, 8, 9, 7, 6]

last = 6

0 = 6
1 = 3
2 = 8
3 = 9
4 = 7
5 = 6
*/