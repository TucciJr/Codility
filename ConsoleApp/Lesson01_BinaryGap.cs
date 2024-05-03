namespace ConsoleApp
{
    internal class Lesson01_BinaryGap
    {
        public Lesson01_BinaryGap(int N)
        {
            int longest = solution(N);

            Console.WriteLine(longest);
        }

        private int solution(int N)
        {
            var max = 0;
            var sequence = 0;
            var binaryN = Convert.ToString(N, 2);

            var index = 0;

            foreach (var item in binaryN)
            {
                var isOne = item == '1';

                if (isOne)
                {
                    if (sequence > max)
                    {
                        max = sequence;
                    }

                    sequence = 0;
                }
                else
                {
                    sequence++;
                }

                Console.WriteLine($"{index++} - {item} - {sequence} - {max}");
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