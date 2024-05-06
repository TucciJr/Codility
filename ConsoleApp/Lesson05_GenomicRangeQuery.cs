// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

internal class Lesson05_GenomicRangeQuery
{
    public Lesson05_GenomicRangeQuery()
    {
        Console.WriteLine("Lesson05_GenomicRangeQuery");
        Console.WriteLine("--------------------------");

        Run("A", [0], [0]);
        Run("CAGCCTA", [2, 5, 0], [4, 5, 6]);

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
            queries[i] = ImpactFactor(S.Substring(P[i], Q[i] - P[i] + 1));
        }

        return queries;
    }

    private int ImpactFactor(string sequence)
    {
        if (sequence.Contains('A'))
        {
            return 1;
        }
        else if (sequence.Contains('C'))
        {
            return 2;
        }
        else if (sequence.Contains('G'))
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }
}