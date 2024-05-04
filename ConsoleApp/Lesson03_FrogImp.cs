// See https://aka.ms/new-console-template for more information
internal class Lesson03_FrogImp
{
    public Lesson03_FrogImp()
    {
        Console.WriteLine("Lesson03_FrogImp");
        Console.WriteLine("-----------------------");

        Run(1, 7, 3);
        Run(10, 85, 30);
        Run(10, 1000000000, 1);
        Run(1, 999111321, 1);

        Console.WriteLine("--- * ---");
    }

    private void Run(int X, int Y, int D)
    {
        var jumps = solution(X, Y, D);

        Console.WriteLine($"Jumps: {jumps} for ({X}, {Y}, {D})]");
    }

    public int solution(int X, int Y, int D)
    {
        var jumps = (Y - X) / D;

        if ((Y - X) % D > 0)
        {
            jumps++;
        }

        return jumps;
    }
}
/*
X = 10
Y = 85
D = 30

Distance = Y - X        = 75
Jumps    = Distance / D = 2.5

*/