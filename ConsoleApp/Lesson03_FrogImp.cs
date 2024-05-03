// See https://aka.ms/new-console-template for more information
internal class Lesson03_FrogImp
{
    public Lesson03_FrogImp()
    {
        Console.WriteLine("Lesson03_FrogImp");
        Console.WriteLine("-----------------------");

        Run(10, 85, 30);

        Console.WriteLine("--- * ---");
    }

    private void Run(int X, int Y, int D)
    {
        var jumps = solution(X, Y, D);

        Console.WriteLine($"Jumps: {jumps} for ({X}, {Y}, {D})]");
    }

    public int solution(int X, int Y, int D)
    {
        var jumps = 0;

        while (X < Y)
        {
            X += D;

            jumps++;
        }

        return jumps;
    }
}