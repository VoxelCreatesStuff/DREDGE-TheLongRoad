using HarmonyLib;
using Winch.Core;

namespace TheLongRoad;

[HarmonyPatch(typeof(ItemManager), "OnItemDataAddressablesLoaded")]
public static class ItemManagerPatch
{
    private static void Postfix(ItemManager __instance)
    {
        //Grabbing item info for debug purposes
        WinchCore.Log.Info("=== ITEM SCAN STARTED ===");
        int count = 0;
        foreach (ItemData item in __instance.allItems)
        {
            WinchCore.Log.Info(
                $"ITEM: id={item.id}, type={item.GetType().Name}"
            );

            count++;
        }
        WinchCore.Log.Info($"=== ITEM SCAN COMPLETE: {count} ITEMS ===");

        //Changing values
        foreach (ItemData item in __instance.allItems)
        {
            if (item is RodItemData rod)
            {
                decimal oldPrice = rod.value;
                rod.value *= 2;

                WinchCore.Log.Debug(
                    $"UPDATED ROD type:{item.GetType().Name}/id:{rod.id}, price={oldPrice} -> {rod.value}"
                );
            }

            if (item is EngineItemData engine)
            {
                decimal oldPrice = engine.value;
                engine.value *= 2;

                WinchCore.Log.Debug(
                    $"UPDATED ENGINE: type:{item.GetType().Name}/id:{engine.id}, price={oldPrice} -> {engine.value}"
                );
            }

            if (item is DeployableItemData net)
            {
                decimal oldPrice = net.value;
                net.value *= 2;

                WinchCore.Log.Debug(
                    $"UPDATED DEPLOYABLE (NET/POT): type:{item.GetType().Name}/id:{net.id}, price={oldPrice} -> {net.value}"
                );
            }

            if (item is LightItemData light)
            {
                decimal oldPrice = light.value;
                light.value *= 2;

                WinchCore.Log.Debug(
                    $"UPDATED LIGHT: type:{item.GetType().Name}/id:{light.id}, price={oldPrice} -> {light.value}"
                );
            }

            if (item is HarvestableItemData recource)
            {
                if (item.id == "cloth" || item.id == "lumber" || item.id == "metal" || item.id == "scrap" || item.id == "research-item" || item.id == "crate")
                {
                    decimal oldPrice = recource.value;
                    recource.value *= 2;

                    WinchCore.Log.Debug(
                        $"UPDATED HARVESTABLE: type:{item.GetType().Name}/id:{recource.id}, price={oldPrice} -> {recource.value}"
                    );
                }
            }
        }
    }
}