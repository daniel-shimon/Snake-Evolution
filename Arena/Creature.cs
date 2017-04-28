using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Creature : IComparable
    {
        public static byte[] HiddenLayers = new byte[1] {2};
        private readonly NeuralNet brain;
        private int grade;
        private readonly List<int> lineage;
        private int childrenCount;
        public Creature(int liniageNum)
        {
            this.brain = new NeuralNet(3, 2, 3);
            this.lineage = new List<int> {liniageNum};
        }
        public Creature(List<int> liniage, int liniageNum, NeuralNet brain)
        {
            this.brain = brain;
            this.lineage = new List<int>();
            for (int i = 0; i < liniage.Count; i++)
            {
                this.lineage.Add(liniage[i]);
            }
            this.lineage.Add(liniageNum);
        }
        public void Turn(Player player)
        {
            double A = Convert.ToDouble(1 - player.WallDistance / float.MaxValue);
            double B = Convert.ToDouble(1 - player.FoodDistance / float.MaxValue);
            double C = Convert.ToDouble(1 - player.Life / 100);
            double [] output = brain.Propagate(A, B, C);
            double maxOutput = double.MinValue;
            int choice = 0;
            for (int i = 0; i < 3; i++)
            {
                if (output[i] > maxOutput)
                {
                    maxOutput = output[i];
                    choice = i;
                }
            }
            switch (choice)
            {
                case 0:
                    player.MoveLeft();
                    break;
                case 1:
                    player.MoveForward();
                    break;
                case 2:
                    player.MoveRight();
                    break;
            }
        }
        public Creature GetChild(float mutationRate)
        {
            Creature newCreature = new Creature(this.lineage, childrenCount, this.brain.GetMutatedCopy(mutationRate));
            this.childrenCount++;
            return newCreature;
        }
        public int CompareTo(object obj)
        {
            if (obj is Creature)
            {
                if (this.grade > ((Creature)obj).grade)
                {
                    return -1;
                }
                else if (this.grade < ((Creature)obj).grade)
                {
                    return 1;
                }
            }
            return 0;
        }
        public int Grade
        {
            get { return this.grade; }
            set { if (this.grade < value) this.grade = value; }
        }
    }
}
