using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using HarmonyLib;

namespace BigInventory.Patches;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[HarmonyPatch(typeof(PlayerStorage))]
public class PlayerStoragePatches
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(PlayerStorage.RecalculateStorageCapacity))]
    public static IEnumerable<CodeInstruction> SetCapacityTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        const int offset = 0;
        var codes = new List<CodeInstruction>(64);
        codes.AddRange(instructions);

        int index = codes.FindIndex(x => x.opcode == OpCodes.Stloc_1) + offset;

        codes.InsertRange(index, [
            new CodeInstruction(OpCodes.Ldc_I4, ModBehaviour.PLAYER_STORAGE_MULTIPLIER),
            new CodeInstruction(OpCodes.Mul)
        ]);

        return codes;
    }
}