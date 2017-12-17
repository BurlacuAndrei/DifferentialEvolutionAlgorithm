/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2016, Florin Leon                                    *
 *  E-mail:      florin.leon@tuiasi.ro                                    *
 *  Website:     http://florinleon.byethost24.com/lab_ia.htm              *
 *  Description: Evolutionary Algorithms                                  *
 *               (Artificial Intelligence lab 9)                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;

namespace EvolutionaryAlgorithm
{
    /// <summary>
    /// Clasa care reprezinta operatia de selectie
    /// </summary>
    public class Selection
    {
        private static Random _rand = new Random();

        public static Chromosome Tournament(Chromosome[] population)
        {
            //throw new Exception("Aceasta metoda trebuie implementata");
  
            Chromosome c1 = population[_rand.Next(0, population.Length - 1)];
            Chromosome c2 = population[_rand.Next(0, population.Length - 1)];

            if (c1.Fitness > c2.Fitness)
                return c1;
            else
                return c2;
        }

        public static Chromosome GetBest(Chromosome[] population)
        {
            //throw new Exception("Aceasta metoda trebuie implementata");
            double max_fitness = 0;
            int index = 0;
           
            for (int i=0;i<population.Length; ++i)
            {
                if (population[i].Fitness > max_fitness)
                {
                    max_fitness = population[i].Fitness;
                    index = i;
                }
            }

            return population[index];
        }
    }
}