namespace Fence
{//	90	0	0	85	90	50	40	71
    internal class Program
    {
        static void Main(string[] args)
        {
            Garden garden1 = new Garden(new List<(int x, int y)> {
            (0, 0),
            (1, 2),
            (2, 1),
            (3, 3),
            (4, 2),
            (5, 0)
            });
            Garden garden2 = new Garden(new List<(int x, int y)> {
            (0, 0),
            (1, 1),
            (2, 2),
            (3, 3),
            (4, 4),
            (5, 5)
            });
            Console.WriteLine("Garden 1 fence length: " + garden1.CalculateFenceLength());
            Console.WriteLine("Garden 2 fence length: " + garden2.CalculateFenceLength());
            Console.WriteLine("Garden 1 < Garden 2: " + (garden1 < garden2));
            Console.WriteLine("Garden 1 > Garden 2: " + (garden1 > garden2));
            Console.WriteLine("Garden 1 <= Garden 2: " + (garden1 <= garden2));
            Console.WriteLine("Garden 1 >= Garden 2: " + (garden1 >= garden2));
        }
    }
}
