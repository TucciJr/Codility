// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

internal class Lesson05_GenomicRangeQuery
{
    public Lesson05_GenomicRangeQuery()
    {
        Console.WriteLine("Lesson05_GenomicRangeQuery");
        Console.WriteLine("--------------------------");

        Run("CAGCCTA", [2, 5, 0, 2], [4, 5, 6, 2]);
        Run("A", [0], [0]);

        Console.WriteLine("--- * ---");
    }

    private void Run(string S, int[] P, int[] Q)
    {
        var impactFactors = solution(S, P, Q);
        Console.WriteLine($"Min Impact Factors: [{string.Join(",", impactFactors)}] Sequence: {S} for P: [{string.Join(",", P)}], Q: [{string.Join(",", Q)}]");
    }

    public int[] solution(string S, int[] P, int[] Q)
    {
        int a = 0, c = 0, g = 0, t = 0;

        int[][] counters = new int[4][];
        for (int i = 0; i < 4; i++)
        {
            counters[i] = new int[S.Length + 1];
        }

        for (int i = 0; i < S.Length; i++)
        {
            var letter = S[i];
            if (letter == 'A')
            {
                a++;
            }
            else if (letter == 'C')
            {
                c++;
            }
            else if (letter == 'G')
            {
                g++;
            }
            else
                t++;

            counters[0][i + 1] = a;
            counters[1][i + 1] = c;
            counters[2][i + 1] = g;
            counters[3][i + 1] = t;
        }

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"{i} - counters{i}: [{string.Join(",", counters[i])}]");
        }

        var result = new int[P.Length];

        for (int i = 0; i < result.Length; i++)
        {
            var indexStart = P[i];
            var indexEnd = Q[i] + 1;

            int r = 4;

            for (int j = 0; j < 4; j++)
            {
                var valueP = counters[j][indexStart];
                var valueQ = counters[j][indexEnd];
                var isDiff = valueQ != valueP;

                if (isDiff)
                {
                    r = j + 1;
                    break;
                }
            }
            result[i] = r;
        }

        return result;
    }
}

/*
A: [0,1,1,1,1,1,2]
C: [1,1,1,2,3,3,3]
G: [0,0,1,1,1,1,1]
T: [0,0,0,0,0,1,1]
*/
