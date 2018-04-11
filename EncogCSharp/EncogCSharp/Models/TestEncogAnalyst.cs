using Encog.App.Analyst;
using Encog.App.Analyst.Wizard;

namespace EncogCSharp
{
    public class TestEncogAnalyst
    {
        public void TestIrisClassificationFF()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Classification, WizardMethodType.FeedForward, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "Equilateral");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestEuroIrisClassificationFF()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris-euro.csv");
            test.FileFormat = AnalystFileFormat.DeccommaSemi;
            test.Wizard(AnalystGoal.Classification, WizardMethodType.FeedForward, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "Equilateral");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestIrisRegressionFF()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Regression, WizardMethodType.FeedForward, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "Equilateral");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestIrisClassificationSVM()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Classification, WizardMethodType.SVM, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "SingleField");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestIrisClassificationPNN()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Classification, WizardMethodType.PNN, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "SingleField");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestIrisClassificationBayes()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Classification, WizardMethodType.BayesianNetwork, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 0, 0, 0, 0, "sepal_l", 0, "PassThrough");
            test.ValidateAnalystField(1, 0, 0, 0, 0, "sepal_w", 0, "PassThrough");
            test.ValidateAnalystField(2, 0, 0, 0, 0, "petal_l", 0, "PassThrough");
            test.ValidateAnalystField(3, 0, 0, 0, 0, "petal_w", 0, "PassThrough");
            test.ValidateAnalystField(4, 0, 0, 0, 0, "species", 0, "SingleField");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
        
        public void TestIrisSOM()
        {
            var test = new AnalystTestingUtility("Encog.Resources.iris.csv");
            test.Wizard(AnalystGoal.Classification, WizardMethodType.SOM, true);

            test.ValidateDataField(0, 7.900000, 5.843333, 4.300000, 0.825301, "sepal_l", false, true, false, true);
            test.ValidateDataField(1, 4.400000, 3.057333, 2.000000, 0.434411, "sepal_w", false, true, false, true);
            test.ValidateDataField(2, 6.900000, 3.758000, 1.000000, 1.759404, "petal_l", false, true, false, true);
            test.ValidateDataField(3, 2.500000, 1.199333, 0.100000, 0.759693, "petal_w", false, true, false, true);
            test.ValidateDataField(4, 0, 0, 0, 0, "species", true, true, false, false);
            test.ValidateDataClass(4, "Iris-setosa", "Iris-versicolor", "Iris-virginica");
            test.ValidateAnalystField(0, 7.900000, 4.300000, 1.000000, -1.000000, "sepal_l", 0, "Normalize");
            test.ValidateAnalystField(1, 4.400000, 2.000000, 1.000000, -1.000000, "sepal_w", 0, "Normalize");
            test.ValidateAnalystField(2, 6.900000, 1.000000, 1.000000, -1.000000, "petal_l", 0, "Normalize");
            test.ValidateAnalystField(3, 2.500000, 0.100000, 1.000000, -1.000000, "petal_w", 0, "Normalize");
            test.ValidateAnalystField(4, 0.000000, 0.000000, 1.000000, -1.000000, "species", 0, "SingleField");

            test.Process(0.05);

            test.ValidateMethodError(0.05);
        }
    }
}
