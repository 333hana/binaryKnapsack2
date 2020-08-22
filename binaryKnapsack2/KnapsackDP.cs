using System;
using System.Collections.Generic;
using System.Text;

namespace binaryKnapsack2
{
    class KnapsackDP
    {
        //bottom up dp approach
        int[] weight;
        int[] value;
        int capacity;
        public KnapsackDP(int[] w, int[] v, int c)
        {
            this.weight = w;
            this.value = v;
            this.capacity = c;
        }
        public void solveDP()
        {
            int n = weight.Length;
            int[,] Dptable = new int[n + 1, capacity + 1];
            int[] vwratio = new int[n];

            for (int i = 0; i <= capacity; i++)
            {
                Dptable[0, i] = 0;
            }
            //shift weight and value arrays
            int[] weight2 = new int[n + 1];
            int[] value2 = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                weight2[i + 1] = weight[i];
                value2[i + 1] = value[i];

            }
            weight2[0] = 0;
            value2[0] = 0;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        Dptable[i, j] = 0;
                        continue;
                    }
                    else if (weight[i - 1] > j)
                    {
                        Dptable[i, j] = Dptable[i - 1, j];
                    }
                    else if ((value[i - 1] + Dptable[i - 1, j - weight[i - 1]]) > Dptable[i - 1, j])
                    {
                        Dptable[i, j] = value[i - 1] + Dptable[i - 1, (j - weight[i - 1])];
                    }
                    else
                    {
                        Dptable[i, j] = Dptable[i - 1, j];
                    }
                }
            }
            Console.WriteLine("Dynamic Programming algorithm solution:");
            Console.WriteLine("Maximum value is : " + Dptable[n, capacity]);
        }
    }
}
