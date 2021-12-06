using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    class FileRead
    {
        public Object ReadData<type>()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            string file = openFileDialog.FileName;
            if (file == "")
                return null;
            Stream stream = File.Open(file, FileMode.Open);

            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            type result = (type)binaryFormatter.Deserialize(stream);
            stream.Dispose();
            return result;
        }
    }
}
