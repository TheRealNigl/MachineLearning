using System.IO;
using Encog.Util;
using Encog.Util.CSV;
using Encog.Util.File;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encog.App.Analyst
{
    public class TestAnalystClassification
    {
        public TempDir TEMP_DIR = new TempDir();
        
        public void TestClassification()
        {
            FileInfo rawFile = TEMP_DIR.CreateFile("simple.csv");
            FileInfo egaFile = TEMP_DIR.CreateFile("simple.ega");
            FileInfo outputFile = TEMP_DIR.CreateFile("simple_output.csv");

            FileUtil.CopyResource("Encog.Resources.simple.csv", rawFile);
            FileUtil.CopyResource("Encog.Resources.simple-c.ega", egaFile);

            EncogAnalyst analyst = new EncogAnalyst();
            analyst.AddAnalystListener(new ConsoleAnalystListener());
            analyst.Load(egaFile);

            analyst.ExecuteTask("task-full");

            ReadCSV csv = new ReadCSV(outputFile.ToString(), true, CSVFormat.English);
            while (csv.Next())
            {
                Assert.AreEqual(csv.Get(3), csv.Get(4));
            }

            Assert.AreEqual(4, analyst.Script.Fields.Length);
            Assert.AreEqual(3, analyst.Script.Fields[3].ClassMembers.Count);

            csv.Close();
        }
    }
}
