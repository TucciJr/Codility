// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

internal class Lesson05_GenomicRangeQuery
{
    public Lesson05_GenomicRangeQuery()
    {
        Console.WriteLine("Lesson04_MaxCounters");
        Console.WriteLine("--------------------");

        Run("CAGGCTA", [2, 5, 0], [4, 5, 6]);

        Console.WriteLine("--- * ---");
    }

    private void Run(string S, int[] P, int[] Q)
    {
        var impactFactors = solution(S, P, Q);

        Console.WriteLine($"Min Impact Factors: [{string.Join(",", impactFactors)}] Sequence: {S} for P: [{string.Join(",", P)}], Q: [{string.Join(",", Q)}]");
    }

    public int[] solution(string S, int[] P, int[] Q)
    {
        int M = P.Length;
        var queries = new int[M];

        for (int i = 0; i < M; i++)
        {
            var min = 4;
            for (int j = P[i]; j <= Q[i]; j++)
            {
                min = Math.Min(min, ImpactFactor(S[j]));
            }

            queries[i] = min;
        }

        return queries;
    }

    private int ImpactFactor(char letter)
    {
        var impactFactor = 0;
        switch (letter)
        {
            case 'A':
                impactFactor = 1;
                break;
            case 'C':
                impactFactor = 2;
                break;
            case 'G':
                impactFactor = 3;
                break;
            case 'T':
                impactFactor = 4;
                break;
            default:
                break;
        }

        return impactFactor;
    }
}