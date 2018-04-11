//
// Encog(tm) Core v3.1 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2012 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using System.IO;
using Encog.Util.File;
using Directory = System.IO.Directory;

namespace Encog.Util
{
    public class TempDir
    {
        private readonly FileInfo _tempdir;

        public TempDir()
        {
            _tempdir = FileUtil.CombinePath(new FileInfo(Path.GetTempPath()), "encog-ut");
            Directory.CreateDirectory(_tempdir.ToString());
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
