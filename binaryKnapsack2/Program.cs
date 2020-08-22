using System;

namespace binaryKnapsack2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] val = new int[] { 60, 120, 100 };
            int[] wt = new int[] { 10, 30, 20 };
            int[] x = new int[] { 0, 0, 0 };
            int[] y = new int[] { 0, 0, 0 };
            int W = 50;
            int n = val.Length;
            Console.WriteLine("knapsack capacity is: " + W);
            Console.WriteLine("knapsack contains " + n + " items.");
            for (int i = 0; i < wt.Length; i++)
            {
                Console.WriteLine("Item '" + i + "' weight is " + wt[i]);
                Console.WriteLine("Item '" + i + "' value is " + val[i]);
                Console.WriteLine("...............................");
            }
            GeneticKnapsack genetic = new GeneticKnapsack(wt, val, W, wt.Length, 13, 100);
            genetic.solveGenetic();
            Console.WriteLine("----------------------------------------------------------");
            KnapsackGreedy greedy = new KnapsackGreedy(wt, val, W);
            greedy.solveGreedy();
            Console.WriteLine("----------------------------------------------------------");
        }
    }
}
