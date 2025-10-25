using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using UnityEngine;

namespace BigInventory.Patches;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[HarmonyPatch(typeof(CharacterMainControl))]
public class CharacterMainControlPatches
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(CharacterMainControl.InventoryCapacity), MethodType.Getter)]
    public static void InventoryCapacityGetterPostfix(CharacterMainControl __instance, ref float __result)
    {
        if (__instance.Team is not Teams.player) return;
        __result *= ModBehaviour.INVENTORY_CAPACITY_MULTIPLIER;
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(CharacterMainControl.MaxWeight), MethodType.Getter)]
    public static void MaxWeightGetterPostfix(ref float __result)
    {
        __result *= ModBehaviour.INVENTORY_WEIGHT_MULTIPLIER;
    }
}