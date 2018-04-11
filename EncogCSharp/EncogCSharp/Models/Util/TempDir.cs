using System.IO;

namespace EncogCSharp
{
    public class TempDir
    {
        private readonly FileInfo _tempdir;

        public TempDir()
        {
            _tempdir = FileUtil.CombinePath(new FileInfo(Path.GetTempPath()), "encog-ut");
            System.IO.Directory.CreateDirectory(_tempdir.ToString());
        }

        public FileInfo CreateFile(string filename)
        {
            return FileUtil.CombinePath(_tempdir, filename);
        }

        public override string ToString()
        {
            return _tempdir.ToString();
        }

        public void ClearContents()
        {
            var di = new DirectoryInfo(_tempdir.ToString());
            var list = di.GetFiles();
            foreach (var fileInfo in list)
            {
                fileInfo.Delete();
            }
        }
    }
}
