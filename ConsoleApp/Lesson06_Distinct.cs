// See https://aka.ms/new-console-template for more information
internal class Lesson06_Distinct
{
    public Lesson06_Distinct()
    {
        Console.WriteLine("Lesson06_Distinct");
        Console.WriteLine("-----------------");

        Run([2, 1, 1, 2, 3, 1]);
        Run([1, 2, 3, 4]);
        Run([1, 1, 1, 1]);

        Console.WriteLine("--- * ---");
    }

    private void Run(int[] A)
    {
        var run = solution(A);
        Console.WriteLine($"String: [{run}] -  S: {A}");
    }

    public int solution(int[] A)
    {
        var hashSet = new HashSet<int>();

        foreach (var n in A)
        {
            hashSet.Add(n);
        }

        return hashSet.Count;
    }
}