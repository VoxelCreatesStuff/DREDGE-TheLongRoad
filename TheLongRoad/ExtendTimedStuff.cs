using System.Reflection;
using HarmonyLib;
using Winch.Core;

namespace TheLongRoad;

[HarmonyPatch(typeof(ItemManager), "OnItemDataAddressablesLoaded")]
public static class ExtendIceThaw
{
    private static void Postfix(ItemManager __instance)
    {
        //Changing values
        foreach (ItemData item in __instance.allItems)
        {
            if (item is DurableItemData ice)
            {
                if (item.id == "ice-block-1" || item.id == "ice-block-2")
                {
                    float oldTime = ice.maxDurabilityDays;
                    ice.maxDurabilityDays *= 1.5f;
                    
                    WinchCore.Log.Debug(
                        $"ICE BLOCK: type:{item.GetType().Name}/id:{ice.id}, time={oldTime} -> {ice.maxDurabilityDays}"
                    );


                    /*foreach (FieldInfo field in item.GetType().GetFields(
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Instance))
                    {
                        WinchCore.Log.Debug(
                            $"ICE FIELD: {field.Name} / {field.FieldType.Name}"
                        );
                    }

                    foreach (PropertyInfo property in item.GetType().GetProperties(
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Instance))
                    {
                        WinchCore.Log.Debug(
                            $"ICE PROPERTY: {property.Name} / {property.PropertyType.Name}"
                        );
                    }*/
                }
            }


        }
    }
}


[HarmonyPatch(typeof(BoostAbility), "Awake")]
public static class ExtendHeatDecay
{
    private static void Postfix(BoostAbility __instance)
    {
        float oldHeatLoss = __instance.hasteHeatLoss;

        __instance.hasteHeatLoss *= 0.6667f;

        WinchCore.Log.Debug(
            $"HASTE HEAT LOSS: {oldHeatLoss} -> {__instance.hasteHeatLoss}"
        );
    }
}


[HarmonyPatch(typeof(ItemManager), "OnItemDataAddressablesLoaded")]
public static class ExtendReadTime
{
    private static void Postfix(ItemManager __instance)
    {
        foreach (ItemData item in __instance.allItems)
        {
            if (item is ResearchableItemData research)
            {
                float oldTime = research.daysToResearch;
                research.daysToResearch *= 2f;

                WinchCore.Log.Debug(
                    $"RESEARCG: type:{item.GetType().Name}/id:{research.id}, time={oldTime} -> {research.daysToResearch}"
                );
            }
        }
    }
}