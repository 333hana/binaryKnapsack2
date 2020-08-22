using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace binaryKnapsack2
{
    class GeneticKnapsack
    {
        static int[] weight;
        static int[] value;
        static int capacity;
        static int nitems;
        static int maxg;
        static double mutationProb = 0.5;
        int population;
        static double fittest = 0;
        public static ArrayList solutions = new ArrayList();//contains chromosomes


        public GeneticKnapsack(int[] w, int[] v, int c, int items, int generations, int p)
        {
            weight = w; // weight of items
            value = v; // value of items
            capacity = c; // max weight
            nitems = items;//number of items
            maxg = generations; //stopping condition max generations allowed
            population = p;//number of chromosomes in search space
        }


        public static void generateChromosome()
        {
            Random rnd = new Random();
            int[] chromosome = new int[nitems];
            for (int i = 0; i < nitems; i++)
            {
                chromosome[i] = rnd.Next(0, 2);
            }
            solutions.Add(chromosome);
        }
        public static double calcFitness(int[] chromo)
        {
            int chromow = 0; int chromof = 0;
            for (int i = 0; i < chromo.Length; i++)
            {
                if (chromo[i] == 1)
                {
                    chromow += weight[i];
                    chromof += value[i];//fitness value considered as total value of chromosome
                }
            }
            if (chromow > capacity)
                return 0;
            else
                return chromof;
        }
        public (int[], int[]) crossover(int[] chromo1, int[] chromo2)
        {
            int cvpoint = nitems / 2;
            for (int i = 0; i < cvpoint; i++)
            {
                int temp = chromo1[i];
                chromo1[i] = chromo2[i];
                chromo2[i] = temp;
            }
            return (chromo1, chromo2);
        }
        public int[] mutation(int[] chromosome)
        {
            for (int i = 0; i < nitems; i++)

            {
                Random rnd = new Random();
                int r = rnd.Next(0, 1);
                if (r <= mutationProb)
                {
                    if (chromosome[i] == 1)
                        chromosome[i] = 0;
                    else
                        chromosome[i] = 1;
                }
            }
            return chromosome;
        }

        public static int[] getFittest()
        {
            // fittest = 0;
            int[] best = new int[nitems];
            for (int i = 0; i < solutions.Count; i++)
            {
                if (fittest < GeneticKnapsack.calcFitness((int[])solutions[i]))
                {
                    fittest = GeneticKnapsack.calcFitness((int[])solutions[i]);
                    best = (int[])solutions[i];
                }

            }
            // i might need to save fittest
            return best;
        }
        public void generateG() // using crossover mutation and elitism
        {

            int[] chromo1 = getFittest();
            solutions.Remove(chromo1);
            int[] chromo2 = getFittest();
            solutions.Remove(chromo2);
            solutions = new ArrayList();
            for (int i = 0; i < nitems; i++)
            {
                solutions.Add(mutation(crossover(chromo1, chromo2).Item1));
                //solutions.Add(mutation(crossover(chromo1, chromo2).Item2));
            }
            maxg--;
        }

        public void solveGenetic()
        {
            //instantiate generation
            for (int i = 0; i < population; i++)
            {
                generateChromosome();
            }
            while (maxg != 0)//termination condition
            {
                getFittest();
                generateG();
            }
            Console.WriteLine("Genetic algorithm solution:");
            Console.WriteLine("Maximum value is : " + fittest);
        }
    }
}
}
