using System;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog;

namespace EncogCSharp.Models
{
    internal class EncogMLIntroduction
    {
        public static double[][] XORInput =
        {
            new [] {0.0, 0.0},
            new [] {1.0, 0.0},
            new [] {0.0, 1.0},
            new [] {1.0, 1.0}
        };

        public static double[][] XORIdeal =
        {
            new [] {0.0},
            new [] {1.0},
            new [] {1.0},
            new [] {0.0}
        };

        public void Run()
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(null, true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 3));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));
            network.Structure.FinalizeStructure();
            network.Reset();
            IMLDataSet trainingSet = new BasicMLDataSet(XORInput, XORIdeal);
            IMLTrain train = new ResilientPropagation(network, trainingSet);

            int epoch = 1;
            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch # " + epoch + @" Error: " + train.Error);
                epoch++;
            } while (train.Error > 0.01);

            train.FinishTraining();

            Console.WriteLine(@"Neural Network Results: ");
            foreach(IMLDataPair pair in trainingSet)
            {
                IMLData output = network.Compute(pair.Input);
                Console.WriteLine(pair.Input[0] + @" , " + pair.Input[1] + @" , actual = " + output[0] + @" , ideal = " + pair.Ideal[0]);
            }

            EncogFramework.Instance.Shutdown();
        }
    }
}
