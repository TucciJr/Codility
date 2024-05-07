// See https://aka.ms/new-console-template for more information
internal class Lesson05_CountDiv
{
    public Lesson05_CountDiv ()
    {
        Console.WriteLine("Lesson05_CountDiv");
        Console.WriteLine("--------------------------");

        Run(0, 0, 11);
        Run(6, 11, 2);
        Run(11, 345, 17);

        Console.WriteLine("--- * ---");
    }

    private void Run(int A, int B, int K)
    {
        var run = solution(A, B, K);
        Console.WriteLine($"Count: [{run}] -  A: {A} -  B: {B} - K {K}");
    }

    public int solution(int A, int B, int K)
    {
        var countOk = 0;

        for (int i = A; i <= B; i++)
        {
            if (i % K == 0)
            {
                countOk++;
            }
        }

        return countOk;
    }
}

//
/*
A - B - K
6 - 11 - 2
*/