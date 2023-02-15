namespace Ducky.MarbleAdventure.Core.Data
{
	#region Usings
	using System.IO;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Formatters.Binary;
	#endregion Usings

	/// <summary>
	/// Static helper class that handles with data management
	/// </summary>
	public static class DataHelper
	{
		/// <summary>
		/// Write generic data to disk in a binary format
		/// </summary>
		/// <typeparam name="T">Type of data to be written</typeparam>
		/// <param name="data">Data to be written</param>
		/// <param name="fileName">File name</param>
		public static void SaveBinaryData<T>(T data, string fileName)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			SaveData(data, fileName, binaryFormatter);
		}

		/// <summary>
		/// Write generic data to disk
		/// </summary>
		/// <typeparam name="T">Type of data to be written</typeparam>
		/// <param name="data">Data to be written</param>
		/// <param name="fileName">File name</param>
		/// <param name="formatter">Serialization formatter</param>
		public static void SaveData<T>(T data, string fileName, IFormatter formatter)
		{
			if (File.Exists(fileName))
			{
				FileStream file = File.Open(fileName, FileMode.Open);
				formatter.Serialize(file, data);
				file.Close();
			}
			else
			{
				FileStream file = File.Open(fileName, FileMode.CreateNew);
				formatter.Serialize(file, data);
				file.Close();
			}
		}

		/// <summary>
		/// Load generic data from disk in a binary format and returns a flag if that data is effectively loaded
		/// </summary>
		/// <typeparam name="T">Type of data to be loaded</typeparam>
		/// <param name="data">Reference to the data container</param>
		/// <param name="fileName">File name</param>
		/// <returns>true if data is effectively loaded</returns>
		public static bool TryLoadBinaryData<T>(ref T data, string fileName)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			return TryLoadData(ref data, fileName, binaryFormatter);
		}

		/// <summary>
		/// Load generic data from disk in a binary format and returns a flag if that data is effectively loaded
		/// </summary>
		/// <typeparam name="T">Type of data to be loaded</typeparam>
		/// <param name="data">Reference to the data container</param>
		/// <param name="fileName">File name</param>
		/// <param name="formatter">Serialization formatter</param>
		/// <returns>true if data is effectively loaded</returns>
		public static bool TryLoadData<T>(ref T data, string fileName, IFormatter formatter)
		{
			if (File.Exists(fileName))
			{
				// Load data from disk
				FileStream file = File.Open(fileName, FileMode.Open);
				data = (T)formatter.Deserialize(file);
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
