using HarmonyLib;
using RimWorld;
using System.Text;
using Verse;

namespace Gravestone_Necrolog
{
    [HarmonyPatch(typeof(Building_Grave), nameof(Building_Grave.Notify_CorpseBuried))]
    class NecrologPatch
    {
        static void Postfix(Building_Grave __instance)
        {
            NecrologComp comp = __instance.TryGetComp<NecrologComp>();
            if (comp != null)
            {
                if (comp.GetNecrologText() == "")
                {
                    Pawn_AgeTracker pawnAge = __instance.Corpse.InnerPawn.ageTracker;
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(__instance.Corpse.InnerPawn.Name.ToString());
                    stringBuilder.AppendLine(pawnAge.AgeBiologicalYears.ToString() + " " + "BiologicalYears".Translate());
                    string deathText = GenDate.DateFullStringAt(GenDate.TickGameToAbs(__instance.Corpse.timeOfDeath),
                        Find.WorldGrid.LongLatOf(__instance.Tile));
                    string birthText = GenDate.DateFullStringAt(pawnAge.BirthAbsTicks, Find.WorldGrid.LongLatOf(__instance.Tile));
                    stringBuilder.AppendLine(birthText + " – " + deathText);
                    comp.SetNecrologText(stringBuilder.ToString());
                }
            }
        }
    }
}
