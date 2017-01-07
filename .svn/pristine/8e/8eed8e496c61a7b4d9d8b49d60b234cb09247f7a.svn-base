using System;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowling Tests:");
            Console.WriteLine("-----------------------------------------------------------");

            var rolls1 = new[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            var rolls2 = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            var rolls3 = new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 };
            var rolls4 = new[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8 };
            var rolls5 = new[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 7, 6 };

            Test(1, rolls1, 133);
            Test(2, rolls2, 300);
            Test(3, rolls3, 155);
            TestFaulty(4, rolls4);
            TestFaulty(5, rolls5);

            Console.WriteLine("End of tests.");
            Console.ReadKey(true);
        }

        public static void Test(int index, int[] rolls, int expected)
        {
            var game = new Game();
            string rollsHistory = string.Empty;

            foreach (int pins in rolls)
            {
                rollsHistory += $"{pins};";
                game.Roll(pins);
            }

            int score = game.Score();
            string status = score == expected ? "OK" : "KO";

            Console.WriteLine($"Test #{index}:");
            Console.WriteLine($"Rolls History : {rollsHistory}");
            Console.WriteLine($"Score history : {game.ScoreHistory()}");
            Console.WriteLine($"Score={score}, Expected={expected}, Check={status}");
            Console.WriteLine("-----------------------------------------------------------");
        }

        public static void TestFaulty(int index, int[] rolls)
        {
            var game = new Game();
            string rollsHistory = string.Empty;

            Console.WriteLine($"Test #{index}:");

            try
            {
                foreach (int pins in rolls)
                {
                    rollsHistory += $"{pins};";
                    game.Roll(pins);
                }
                int score = game.Score();
                Console.WriteLine($"Rolls History : {rollsHistory}");
                Console.WriteLine($"Not exception raised, Check=KO");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Rolls History : {rollsHistory}");
                Console.WriteLine($"Raised exception ({e.Message}) as expected, Check=OK");
            }
            finally
            {
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}
