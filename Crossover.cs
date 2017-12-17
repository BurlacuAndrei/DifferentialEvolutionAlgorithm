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
using System.Collections.Generic;

namespace EvolutionaryAlgorithm
{
    /// <summary>
    /// Clasa care reprezinta operatia de incrucisare
    /// </summary>
    public class Crossover
    {
        private static Random _rand = new Random();

        public static Chromosome Arithmetic(Chromosome p, List<Chromosome> indivizi,  double crossoverRate, double mutationRate)
        {
            double[] maxValues = new double[p.NoGenes];
            double[] minValues = new double[p.NoGenes];
            int division_point = _rand.Next(0, p.NoGenes - 1);
            for (int gene = 0; gene < p.NoGenes; ++gene)
            {
                if (gene == division_point || _rand.NextDouble() < crossoverRate)
                {
                    maxValues[gene] = indivizi[3].MaxValues[gene] + mutationRate * (indivizi[1].MaxValues[gene] - indivizi[2].MaxValues[gene]);
                    minValues[gene] = indivizi[3].MinValues[gene] + mutationRate * (indivizi[1].MinValues[gene] - indivizi[2].MinValues[gene]);
                }
                else
                {
                    maxValues[gene] = indivizi[0].MaxValues[gene];
                    minValues[gene] = indivizi[0].MinValues[gene];
                }
            }

            return new Chromosome(minValues.Length, minValues, maxValues);
        }
    }
}