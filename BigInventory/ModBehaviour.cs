using HarmonyLib;
using ItemStatsSystem;

namespace BigInventory
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        public const float INVENTORY_CAPACITY_MULTIPLIER = 2f;
        public const float INVENTORY_WEIGHT_MULTIPLIER = 2f;
        public const int PLAYER_STORAGE_MULTIPLIER = 1;
        public const int MAX_STACK_MULTIPLIER = 2;


        private Harmony? _harmony;

        protected override void OnAfterSetup()
        {
            base.OnAfterSetup();
            _harmony = new Harmony("duckov_big_inventory_hatu");
            _harmony.PatchAll();
        }

        protected override void OnBeforeDeactivate()
        {
            base.OnBeforeDeactivate();
            _harmony?.UnpatchAll();
        }
    }
}
