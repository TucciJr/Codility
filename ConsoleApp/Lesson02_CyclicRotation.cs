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
        int length = A.Length;
        int[] rotatedArray = new int[length];

        if (length == 0 || K == 0)
        {
            return A;
        }

        int effectiveRotations = K % length;

        for (int i = 0; i < length; i++)
        {
            var position = (i + effectiveRotations) % length;

            rotatedArray[position] = A[i];

            //Console.WriteLine($"{i} - {position} - {A[i]}");
        }

        return rotatedArray;
    }
}

/*
[3, 8, 9, 7, 6]

0 - 3 - 3
1 - 4 - 8
2 - 0 - 9
3 - 1 - 7
4 - 2 - 6
*/