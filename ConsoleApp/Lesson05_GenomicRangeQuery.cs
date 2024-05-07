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
    /*
    0 - counters0: [0,1,1,1,1,1,2]
    1 - counters1: [1,1,1,2,3,3,3]
    2 - counters2: [0,0,1,1,1,1,1]
    3 - counters3: [0,0,0,0,0,1,1]
    */

    public int[] solution3(string S, int[] P, int[] Q)
    {
        int[] result = new int[P.Length];

        Dictionary<char, int> impactMap = new Dictionary<char, int>();
        impactMap.Add('A', 1);
        impactMap.Add('C', 2);
        impactMap.Add('G', 3);
        impactMap.Add('T', 4);

        int[][] prefixSums = new int[4][];
        for (int i = 0; i < 4; i++)
        {
            prefixSums[i] = new int[S.Length + 1];

            Console.WriteLine($"{i} - prefixSums: [{string.Join(",", prefixSums[i])}]");
        }

        for (int i = 0; i < S.Length; i++)
        {
            int impactIndex = impactMap[S[i]] - 1;
            for (int j = 0; j < 4; j++)
            {
                prefixSums[j][i + 1] = prefixSums[j][i] + (j == impactIndex ? 1 : 0);
                Console.WriteLine($"{i} - {j} - impactIndex-1: {impactIndex} - S[{i}]: {S[i]} - prefixSums[j][i]: {prefixSums[j][i]} - prefixSums[{j}][{i + 1}]: [{string.Join(",", prefixSums[j][i + 1])}]");
            }
        }

        for (int i = 0; i < P.Length; i++)
        {
            int start = P[i];
            int end = Q[i] + 1;

            for (int j = 0; j < 4; j++)
            {
                if (prefixSums[j][end] - prefixSums[j][start] > 0)
                {
                    result[i] = j + 1;
                    break;
                }
            }
        }

        return result;
    }

    public int[] solution2(string S, int[] P, int[] Q)
    {
        var nucleo = new int[S.Length + 1, 4];
        for (var count = 0; count < S.Length; count++)
        {
            if (count > 0)
            {
                for (var index = 0; index < 4; index++)
                {
                    nucleo[count + 1, index] += nucleo[count, index];
                }
            }
            switch (S[count])
            {
                case 'A':
                    nucleo[count + 1, 0]++;
                    break;
                case 'C':
                    nucleo[count + 1, 1]++;
                    break;
                case 'G':
                    nucleo[count + 1, 2]++;
                    break;
                case 'T':
                    nucleo[count + 1, 3]++;
                    break;
            }

            Console.WriteLine($"{count} - S[count]: {S[count]} - nucleo[{count + 1}, 0]: {nucleo[count + 1, 0]} - nucleo[{count + 1}, 1]: {nucleo[count + 1, 1]} - nucleo[{count + 1}, 2]: {nucleo[count + 1, 2]} - nucleo[{count + 1}, 3]: {nucleo[count + 1, 3]}");
        }

        var result = new int[P.Length];
        for (var count = 0; count < P.Length; count++)
        {
            if (P[count] == Q[count])
            {
                switch (S[P[count]])
                {
                    case 'A':
                        result[count] = 1;
                        break;
                    case 'C':
                        result[count] = 2;
                        break;
                    case 'G':
                        result[count] = 3;
                        break;
                    case 'T':
                        result[count] = 4;
                        break;
                }
            }
            else
            {
                for (var index = 0; index < 4; index++)
                {
                    if ((nucleo[Q[count] + 1, index] - nucleo[P[count], index]) > 0)
                    {
                        result[count] = index + 1;
                        break;
                    }
                }
            }
        }

        return result;
    }
}