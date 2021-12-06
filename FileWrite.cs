using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    class FileWrite
    {
        public void WriteData<T>(T objectToWrite, bool append = false)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string file = openFileDialog.FileName;
            Stream stream = File.Open(file, append ? FileMode.Append : FileMode.Create);

            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
            stream.Dispose();

        }
    }
}
