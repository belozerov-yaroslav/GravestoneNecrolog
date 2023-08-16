using Verse;
using HarmonyLib;

namespace Gravestone_Necrolog
{
    [StaticConstructorOnStartup]
    public class ModInitializer
    {
        private static bool inited = false;

        static ModInitializer()
        {
            if (!inited)
            {
                LongEventHandler.ExecuteWhenFinished(LaunchPatch);
                inited = true;
            }
        }

        public static void LaunchPatch()
        {
            var harmony = new Harmony("com.example.patch");
            harmony.PatchAll();
        }
    }
}
