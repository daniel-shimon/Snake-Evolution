using System;
using System.Collections.Generic;
using System.Text;

namespace Evolution
{
    public class Manager
    {
        private List<Creature> generation;
        private int currentGeneration, currentCreatureNum;
        public static int GenerationSize = 10;
        public static int BestfitsCount = 3;
        public static float MutationRate = 5;
        public Manager()
        {
            generation = new List<Creature>();
            for (int i = 0; i < GenerationSize; i++)
            {
                generation.Add(new Creature(i));
            }
        }
        public void NextGeneration()
        {
            generation.Sort();
            List<Creature> newGeneration = new List<Creature>();
            for (int i = 0; i < BestfitsCount; i++)
            {
                newGeneration.Add(generation[i]);
            }
            for (int i = 0; i < (GenerationSize-BestfitsCount)/2 ; i++)
            {
                newGeneration.Add(generation[i].GetChild(MutationRate));
            }
            for (int i = 0; newGeneration.Count < GenerationSize; i = (i + 1) % BestfitsCount)
            {
                newGeneration.Add(new Creature(newGeneration.Count));
            }
            generation = newGeneration;
            currentGeneration++;
            currentCreatureNum = 0;
        }
        public void NextCreature(int grade)
        {
            CurrentCreature.Grade = grade;
            if (currentCreatureNum == GenerationSize - 1)
                NextGeneration();
            else
                currentCreatureNum++;
        }
        public int CurrentGeneration
        {
            get { return currentGeneration; }
        }
        public int CurrentCreatureNumber
        {
            get { return currentCreatureNum; }
        }
        public Creature CurrentCreature
        {
            get { return generation[currentCreatureNum]; }
        }
    }
}
