using System;
using System.Collections.Generic;
using System.Text;

namespace binaryKnapsack2
{
    class KnapsackGreedy
    {
        static int[] weight;
        static int[] value;
        static int capacity;
        static int maxval;

        public KnapsackGreedy(int[] w, int[] v, int c)
        {
            weight = w;
            value = v;
            capacity = c;
        }


        public void solveGreedy()
        {
            int n = weight.Length;
            Boolean[] picked = new Boolean[n];
            int[] vwratio = new int[n];
            for (int i = 0; i < n; i++)
            {
                picked[i] = false;
            }
            for (int i = 0; i < n; i++)
            {
                vwratio[i] = value[i] / weight[i];
            }
            for (int i = 0; i <= vwratio.Length - 1; i++)
            {
                for (int k = i + 1; k < vwratio.Length; k++)
                {
                    if (vwratio[i] < vwratio[k])
                    {
                        int tempvw = vwratio[i];
                        vwratio[i] = vwratio[k];
                        vwratio[k] = tempvw;

                        int tempv = value[i];
                        value[i] = value[k];
                        value[k] = tempv;

                        int tempw = weight[i];
                        weight[i] = weight[k];
                        weight[k] = tempw;
                    }
                }
            }

            int j = 0;
            int cw = capacity;//current weight
            int cv = 0; //current value
            while (true)
            {
                cv += value[j];
                cw -= weight[j];
                picked[j] = true;
                j++;
                if (cw < 0)//if there is no space in Knapsack
                {
                    picked[j - 1] = false;
                    cv -= value[j - 1];
                    break;
                }
                if (j == n)//if all items fit in the Knapsack
                {
                    break;
                }
            }
            Console.WriteLine("Greedy algorithm solution:");
            Console.WriteLine("Maximum value is : " + cv);
        }
    
    }
}
