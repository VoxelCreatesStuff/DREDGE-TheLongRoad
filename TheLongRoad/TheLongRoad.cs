using UnityEngine;
using Winch.Core;
using HarmonyLib;

namespace TheLongRoad
{
	public class TheLongRoad : MonoBehaviour
	{
        //public static config Config;

        public void Awake()
		{
            Harmony harmony = new Harmony("TheLongRoad");
            harmony.PatchAll();

            //Config = Util.GetJSON<config>("config");

            WinchCore.Log.Debug($"{nameof(TheLongRoad)} has loaded!");
		}
	}
}
