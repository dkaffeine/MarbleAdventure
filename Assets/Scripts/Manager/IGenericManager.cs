namespace Ducky.MarbleAdventure.Core.Manager
{
	#region Usings
	using UnityEngine;
	#endregion Usings

	/// <summary>
	/// Very generic manager
	/// </summary>
	public class IVeryGenericManager : MonoBehaviour
	{

	}

	/// <summary>
	/// Generic manager
	/// </summary>
	/// <typeparam name="T">Manager type that derives from <see cref="IVeryGenericManager"/>. A derived class</typeparam>
	public class IGenericManager<T> : IVeryGenericManager where T : IVeryGenericManager
	{
		#region Fields
		private static T _instance = null;
		#endregion Fields

		#region Public
		public static T Instance
		{
			get { return _instance; }
		}

		public static bool HasInstance
		{
			get { return _instance != null; }
		}
		#endregion Public

		#region Methods
		#region Lifecycle
		private void Awake()
		{
			if (_instance != null)
			{
				Debug.LogError("Error : only one manager instance of type " + typeof(T).Name.ToString() + " is allowed");
			}

			_instance = this as T;
			DontDestroyOnLoad(this.gameObject);
			this.Init();
		}

		private void OnDestroy()
		{
			if (_instance != null)
			{
				this.Terminate();
				_instance = null;
			}
		}
		#endregion Lifecycle

		#region Virtual
		/// <summary>
		/// Virtual method called when the manager is awoken
		/// </summary>
		protected virtual void Init()
		{

		}

		/// <summary>
		/// Virtual method called when the manager is destroyed
		/// </summary>
		protected virtual void Terminate()
		{

		}
		#endregion Virtual
		#endregion Methods
	}

}


