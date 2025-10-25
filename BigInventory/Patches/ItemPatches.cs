using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using ItemStatsSystem;

namespace BigInventory.Patches;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[HarmonyPatch(typeof(Item))]
public class ItemPatches
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Item.MaxStackCount), MethodType.Getter)]
    public static void MaxStackCountGetterPostfix(ref int __result)
    {
        if (__result <= 1) return;
        __result *= ModBehaviour.MAX_STACK_MULTIPLIER;
    }
}