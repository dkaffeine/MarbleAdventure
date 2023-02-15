namespace Ducky.MarbleAdventure.Core.Manager
{
	#region Usings
	using Ducky.MarbleAdventure.Core.Data;
	using UnityEngine;
	#endregion Usings

	public class OptionsManager : IGenericManager<OptionsManager>
	{
		#region Fields
		#region Constant fields
		private const char Separator = '/';
		private const string OptionsDataFile = "optionsData.save";
		#endregion Constant fields

		#region Serialized
		[SerializeField] private OptionsData _optionsData;
		[SerializeField] private bool _wasOptionsDataLoaded;
		#endregion Serialized
		#endregion Fields

		#region Properties
		public OptionsData OptionsData
		{
			get { return _optionsData; }
		}

		public bool WasOptionsDataLoaded
		{
			get { return _wasOptionsDataLoaded; }
		}
		#endregion Properties

		#region Methods
		#region Override virtual
		protected override void Init()
		{
			base.Init();
			_optionsData = new OptionsData();
		}

		protected override void Terminate()
		{
			base.Terminate();
		}
		#endregion Override virtual

		#region Option Data Management
		/// <summary>
		/// Get the file name to save / load options
		/// </summary>
		/// <returns>Gives the options file name</returns>
		public static string GetFileName()
		{
			string path = Application.persistentDataPath;

			if (path.EndsWith(Separator) == false)
			{
				path = path + Separator;
			}

			return path + "/options.save";
		}
		#endregion Options Data Management
		#endregion Methods
	}
}
