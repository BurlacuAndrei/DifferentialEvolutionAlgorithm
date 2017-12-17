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
    /// Clasa care implementeaza algoritmul evolutiv pentru optimizare
    /// </summary>
    public class EvolutionaryAlgorithm
    {
        private static Random _rand = new Random();
        /// <summary>
        /// Metoda de optimizare care gaseste solutia problemei
        /// </summary>
        /// 
        public Chromosome Solve(IOptimizationProblem p, int populationSize, int maxGenerations, double crossoverRate, double mutationRate)
        {
            //throw new Exception("Aceasta metoda trebuie completata");

            Chromosome[] population = new Chromosome[populationSize];
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = p.MakeChromosome();
                p.ComputeFitness(population[i]);
            }

            for (int gen = 0; gen < maxGenerations; gen++)
            {
                Chromosome[] newPopulation = new Chromosome[populationSize];
                //newPopulation[0] = Selection.GetBest(population); // elitism
                List<Chromosome> indivizi = new List<Chromosome>();
                for (int i = 0; i < populationSize; i++)
                {
                    indivizi.Add(population[i]);
                    for (int j = 0; j<3; ++j)
                    {
                        do
                        {
                            Chromosome c = Selection.Tournament(population);
                            if (indivizi.Contains(c) == false)
                            {
                                indivizi.Add(c);
                                break;
                            }
                        } while (true);
                    }

                    Chromosome individ_potential = Crossover.Arithmetic(population[i], indivizi, crossoverRate, mutationRate);

                    indivizi.Clear();

                    p.ComputeFitness(individ_potential);

                    if (individ_potential.Fitness >= population[i].Fitness)
                        newPopulation[i] = individ_potential;
                    else
                        newPopulation[i] = population[i];
                }

                for (int i = 0; i < populationSize; i++)
                    population[i] = newPopulation[i];
            }

            return Selection.GetBest(population);
        }
    }
}