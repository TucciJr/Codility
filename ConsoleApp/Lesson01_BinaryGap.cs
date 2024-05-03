namespace ConsoleApp
{
    internal class Lesson01_BinaryGap
    {
        public Lesson01_BinaryGap()
        {
            Console.WriteLine("Lesson01_BinaryGap");
            Console.WriteLine("------------------");

            Run(9);
            Run(529);
            Run(20);
            Run(15);
            Run(32);

            Console.WriteLine("--- * ---");
        }

        private void Run(int N)
        {
            int longest = solution(N);

            Console.WriteLine($"Longest gap: {longest} for {N} ({Convert.ToString(N, 2)})");
        }

        private int solution(int N)
        {
            var max = 0;
            var sequence = 0;
            var binaryN = Convert.ToString(N, 2);

            foreach (var item in binaryN)
            {
                if (item == '1')
                {
                    max = Math.Max(sequence, max);

                    sequence = 0;
                }
                else
                {
                    sequence++;
                }
            }

            return max;
        }
    }
}

/*
1000010001

0 - 1 - 0 - 0
1 - 0 - 1 - 0
2 - 0 - 2 - 0
3 - 0 - 3 - 0
4 - 0 - 4 - 0
5 - 1 - 0 - 4
6 - 0 - 1 - 4
7 - 0 - 2 - 4
8 - 0 - 3 - 3
9 - 1 - 0 - 4
*/