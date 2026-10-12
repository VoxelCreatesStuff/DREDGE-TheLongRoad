using HarmonyLib;
using Winch.Core;
using System;

namespace TheLongRoad;

[HarmonyPatch(typeof(ItemManager), "OnItemDataAddressablesLoaded")]
public static class ItemManagerPatch
{
    private static void Postfix(ItemManager __instance)
    {
        //Grabbing item info for debug purposes
        /*WinchCore.Log.Info("=== ITEM SCAN STARTED ===");
        int count = 0;
        foreach (ItemData item in __instance.allItems)
        {
            WinchCore.Log.Info(
                $"ITEM: id={item.id}, type={item.GetType().Name}"
            );

            count++;
        }
        WinchCore.Log.Info($"=== ITEM SCAN COMPLETE: {count} ITEMS ===");*/

        //Changing values
        foreach (ItemData item in __instance.allItems)
        {
            if (item is RodItemData rod)
            {
                decimal oldPrice = rod.value;
                rod.value = (decimal)Math.Truncate((float)rod.value * ConfigValues.RodBuyPrice);

                WinchCore.Log.Debug(
                    $"UPDATED ROD type:{item.GetType().Name}/id:{rod.id}, price={oldPrice} * {ConfigValues.RodBuyPrice} = {rod.value}"
                );
            }

            if (item is EngineItemData engine)
            {
                decimal oldPrice = engine.value;
                engine.value = (decimal)Math.Truncate((float)engine.value * ConfigValues.EngineBuyPrice);

                WinchCore.Log.Debug(
                    $"UPDATED ENGINE: type:{item.GetType().Name}/id:{engine.id}, price={oldPrice} * {ConfigValues.EngineBuyPrice} = {engine.value}"
                );
            }

            if (item is DeployableItemData net)
            {
                decimal oldPrice = net.value;
                net.value = (decimal)Math.Truncate((float)net.value * ConfigValues.DeployableBuyPrice);

                WinchCore.Log.Debug(
                    $"UPDATED DEPLOYABLE (NET/POT): type:{item.GetType().Name}/id:{net.id}, price={oldPrice} * {ConfigValues.DeployableBuyPrice} = {net.value}"
                );
            }

            if (item is LightItemData light)
            {
                decimal oldPrice = light.value;
                light.value = (decimal)Math.Truncate((float)light.value * ConfigValues.LightBuyPrice);

                WinchCore.Log.Debug(
                    $"UPDATED LIGHT: type:{item.GetType().Name}/id:{light.id}, price={oldPrice} * {ConfigValues.LightBuyPrice} = {light.value}"
                );
            }

            if (item is HarvestableItemData recource)
            {
                if (item.id == "cloth" || item.id == "lumber" || item.id == "metal" || item.id == "scrap" || item.id == "research-item" || item.id == "crate")
                {
                    decimal oldPrice = recource.value;
                    recource.value = (decimal)Math.Truncate((float)recource.value * ConfigValues.HarvestableBuyPrice);

                    WinchCore.Log.Debug(
                        $"UPDATED HARVESTABLE: type:{item.GetType().Name}/id:{recource.id}, price={oldPrice} * {ConfigValues.HarvestableBuyPrice} = {recource.value}"
                    );
                }
            }
        }
    }
}