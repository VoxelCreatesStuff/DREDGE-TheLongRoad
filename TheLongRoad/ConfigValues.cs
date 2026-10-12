using System.ComponentModel;
using Newtonsoft.Json;
using UnityEngine;
using Winch.Config;

public class ConfigValues
{
    private static ModConfig Config => ModConfig.GetConfig();

    public static float RodBuyPrice =>
        Config.GetProperty<float>("tlrRodBuyPrice");
    public static float EngineBuyPrice =>
        Config.GetProperty<float>("tlrEngineBuyPrice");
    public static float DeployableBuyPrice =>
        Config.GetProperty<float>("tlrDeployableBuyPrice");
    public static float LightBuyPrice =>
        Config.GetProperty<float>("tlrLightBuyPrice");
    public static float HarvestableBuyPrice =>
        Config.GetProperty<float>("tlrHarvestableBuyPrice");
    public static float IceThawTime =>
        Config.GetProperty<float>("tlrIceThawTime");
    public static float BookReadTime =>
        Config.GetProperty<float>("tlrBookReadTime");
    public static float HasteHeatDecay =>
        Config.GetProperty<float>("tlrHasteHeatDecay");
}
