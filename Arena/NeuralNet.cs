using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class NeuralNet
    {
        private double[][,] weights;
        private byte[] layerSizes;
        private static Random rnd = new Random();
        public NeuralNet(params byte[] layerSizes) 
        {
            if (layerSizes.Length < 2) throw new System.ArgumentException("Paramater must be greater than 1");
            this.layerSizes = layerSizes;
            weights = new double[layerSizes.Length - 1][,];
            for (int i = 0; i < layerSizes.Length - 1; i++)
            {
                weights[i] = new double[layerSizes[i], layerSizes[i+1]];
                for (int x = 0; x < layerSizes[i]; x++)
                {
                    for (int y = 0; y < layerSizes[i + 1]; y++)
                    {
                        weights[i][x, y] = rnd.NextDouble();
                    }
                }
            }
        }
        public double[] Propagate(params double[] input)
        {
            int length = input.Length;
            if (length != weights[0].GetLength(0)) throw new System.ArgumentException("Input length must be as set in constructor");
            double[,] data = new double[1, length];
            for (int i = 0; i < length; i++) data[0, i] = input[i];
            foreach (double[,] layerWeights in weights)
            {
                data = Function(DotProduct(data, layerWeights));
            }
            double[] output = new double[length];
            for (int i = 0; i < length; i++) output[i] = data[0, i];
            return output;
        }
        public NeuralNet GetMutatedCopy(float mutationRate)
        {
            NeuralNet newNet = new NeuralNet(this.layerSizes);
            for (int i = 0; i < weights.Length; i++)
            {
                for (int x = 0; x < weights[i].GetLength(0); x++)
                {
                    for (int y = 0; y < weights[i].GetLength(1); y++)
                    {
                        if (rnd.NextDouble() < mutationRate / 100) newNet.weights[i][x, y] = rnd.NextDouble();
                        else newNet.weights[i][x, y] = this.weights[i][x, y];
                    }
                }
            }
            return newNet;
        }
        private static double[,] DotProduct(double[,] a, double[,] b)
        {
            int width = a.GetLength(0);
            int height = b.GetLength(1);
            int mid = a.GetLength(1);
            if (mid != b.GetLength(0)) throw new ArgumentException("Not fitting sizes");
            double[,] result = new double[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int i = 0; i < mid; i++)
                    {
                        result[x, y] += a[x, i]*b[i, y];
                    }
                }
            }
            return result;
        }
        private static double[,] Function(double[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            double[,] output = new double[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    output[x, y] = Function(matrix[x, y]);
                }
            }
            return output;
        }
        private static double Function(double x)
        {
            return (1 / (1 + Math.Exp(-6*(x - 0.5))));
        }
    }
}
