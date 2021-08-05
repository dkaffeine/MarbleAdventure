using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Static class that handles with 
    /// </summary>
    public static class FileManagement
    {
        /// <summary>
        /// Write generic data to disk
        /// </summary>
        /// <typeparam name="T">Type of data to be written</typeparam>
        /// <param name="data">Data to be written</param>
        /// <param name="fileName">File name</param>
        public static void SaveData<T>(T data, string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(fileName))
            {
                FileStream file = File.Open(fileName, FileMode.Open);
                binaryFormatter.Serialize(file, data);
                file.Close();
            }
            else
			{
                FileStream file = File.Open(fileName, FileMode.CreateNew);
                binaryFormatter.Serialize(file, data);
                file.Close();
            }
        }

        /// <summary>
        /// Load generic data from disk and returns a flag if that data is effectively loaded
        /// </summary>
        /// <typeparam name="T">Type of data to be loaded</typeparam>
        /// <param name="data">Reference to the data container</param>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        public static bool CheckLoadData<T>(ref T data, string fileName)
        {
            if (File.Exists(fileName))
            {
                // Load data from disk
                FileStream file = File.Open(fileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                data = (T)binaryFormatter.Deserialize(file);
                file.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}