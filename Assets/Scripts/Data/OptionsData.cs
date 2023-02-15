namespace Ducky.MarbleAdventure.Core.Data
{
	#region Usings
	using System;
	using UnityEngine;
	#endregion Usings

	/// <summary>
	/// Options data class
	/// </summary>
	[Serializable]
	public class OptionsData
	{
		#region Fields
		[SerializeField] private float _musicVolume = 1.0f;
		[SerializeField] private float _soundVolume = 1.0f;
		[SerializeField] private bool _muteMusic = false;
		[SerializeField] private bool _muteSound = false;
		#endregion Fields

		#region Properties
		public float MusicVolume
		{
			get { return _musicVolume; }
			set { _musicVolume = value; }
		}

		public float SoundVolume
		{
			get { return _soundVolume; }
			set { _soundVolume = value; }
		}

		public bool MuteMusic
		{
			get { return _muteMusic; }
			set { _muteMusic = value; }
		}

		public bool MuteSound
		{
			get { return _muteSound; }
			set { _muteSound = value; }
		}
		#endregion Properties
	}
}
