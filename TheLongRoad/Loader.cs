using UnityEngine;

namespace TheLongRoad
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			var gameObject = new GameObject(nameof(TheLongRoad));
			gameObject.AddComponent<TheLongRoad>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}