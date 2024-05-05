// See https://aka.ms/new-console-template for more information
internal class Lesson04_MaxCounters
{
    public Lesson04_MaxCounters()
    {
        Console.WriteLine("Lesson04_MaxCounters");
        Console.WriteLine("--------------------");

        Run(5, [3, 4, 4, 6, 1, 4, 4]);

        Console.WriteLine("--- * ---");
    }

    private void Run(int N, int[] A)
    {
        var counters = solution(N, A);

        Console.WriteLine($"Counters: {string.Join(",", counters)} for ({string.Join(",", A)})]");
    }

    public int[] solution(int N, int[] A)
    {
        var counters = new int[N];
        var max = 0;

        for (int i = 0; i < A.Length; i++)
        {
            var x = A[i];

            if (x > N)
            {
                for (int n = 0; n < N; n++)
                {
                    counters[n] = max;
                }
            }
            else
            {
                counters[A[i] - 1]++;

                max = Math.Max(max, counters[A[i] - 1]);
            }
            
            //Console.WriteLine($"Counters: ({string.Join(",", counters)})");
        }

        return counters;
    }
}
/*
3, 4, 4, 6, 1, 4, 4
*/