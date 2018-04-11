using System;
using System.IO;
using Encog.Util;
using Encog.Util.File;
using Encog.Util.CSV;
using Encog.App.Analyst;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncogCSharp
{
    public class TestAnalystRegression
    {
        public TempDir TEMP_DIR = new TempDir();
        
        public void TestRegression()
        {
            FileInfo rawFile = TEMP_DIR.CreateFile("EncogCSharp/Resources/simple.csv");
            FileInfo egaFile = TEMP_DIR.CreateFile("EncogCSharp/Resources/simple.ega");
            FileInfo outputFile = TEMP_DIR.CreateFile("EncogCSharp/Resources/simple_output.csv");

            FileUtil.CopyResource("EncogCSharp/Resources/simple.csv", rawFile);
            FileUtil.CopyResource("EncogCSharp/Resources/simple-r.ega", egaFile);

            EncogAnalyst analyst = new EncogAnalyst();
            analyst.Load(egaFile);

            analyst.ExecuteTask("task-full");

            ReadCSV csv = new ReadCSV(outputFile.ToString(), true, CSVFormat.English);
            while (csv.Next())
            {
                double diff = Math.Abs(csv.GetDouble(2) - csv.GetDouble(4));
                Assert.IsTrue(diff < 1.5);
            }

            Assert.AreEqual(4, analyst.Script.Fields.Length);
            Assert.AreEqual(3, analyst.Script.Fields[3].ClassMembers.Count);

            csv.Close();
        }
    }
}
