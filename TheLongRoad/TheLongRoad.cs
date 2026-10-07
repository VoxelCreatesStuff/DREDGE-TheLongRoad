using UnityEngine;
using Winch.Core;
using HarmonyLib;

namespace TheLongRoad
{
	public class TheLongRoad : MonoBehaviour
	{
		public void Awake()
		{
            Harmony harmony = new Harmony("TheLongRoad");
            harmony.PatchAll();

            WinchCore.Log.Debug($"{nameof(TheLongRoad)} has loaded!");
		}
	}
}
