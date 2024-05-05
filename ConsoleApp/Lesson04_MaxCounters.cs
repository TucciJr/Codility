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

        Console.WriteLine($"Counters: {string.Join(",", counters)} for ({string.Join(",", A)}), {N} times");
    }

    public int[] solution(int N, int[] A)
    {
        var max = 0;
        var lastMax = 0;
        var counters = new int[N];

        for (int i = 0; i < A.Length; i++)
        {
            var index = A[i] - 1;

            if (index == N)
            {
                lastMax = max;
            }
            else
            {
                counters[index] = Math.Max(lastMax, counters[index]);
                counters[index]++;

                max = Math.Max(max, counters[index]);
            }
        }

        for (int i = 0; i < N; i++)
        {
            counters[i] = Math.Max(lastMax, counters[i]);
        }

        return counters;
    }
}
/*
3, 4, 4, 6, 1, 4, 4
*/