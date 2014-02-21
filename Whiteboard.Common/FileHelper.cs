using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard.Common {
    public class FileHelper {
        public static bool CreateFile(string path, Stream stream, bool closeInputStream) {
            bool result = false;
            try {
                BinaryReader b = new BinaryReader(stream);
                byte[] binData = b.ReadBytes((int)stream.Length);
                System.IO.File.WriteAllBytes(path, binData);
                if (closeInputStream) {
                    stream.Close();
                }
                b.Close();
                result = true;
            }
            catch (Exception) { }
            return result;
        }
    }
}
