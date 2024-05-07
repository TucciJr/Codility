// See https://aka.ms/new-console-template for more information
internal class Lesson05_CountDiv
{
    public Lesson05_CountDiv ()
    {
        Console.WriteLine("Lesson05_CountDiv");
        Console.WriteLine("--------------------------");

        Run(6, 11, 2);
        Run(0, 0, 11);
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
        int offset = A % K == 0 ? 1 : 0;

        return offset + (B/K) - (A/K);
    }
}

//
/*
A - B  - K
6 - 11 - 2

 A%K  =  1
(B/K) =  5 +
(A/K) =  3 -

11,345,17
 A%K  =  0
(B/K) = 20 +
(A/K) =  0 -

*/