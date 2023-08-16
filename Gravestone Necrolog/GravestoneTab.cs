using RimWorld;
using UnityEngine;
using Verse;

namespace Gravestone_Necrolog
{
    public class GravestoneTab : ITab
    {
        private Vector2 scrollbarPos = new Vector2(WinSize.x - 10f, 0f);
        private static readonly Vector2 WinSize = new Vector2(400f, 300f);

        public GravestoneTab()
        {
            size = WinSize;
            labelKey = "TabNecrolog";
        }

        protected override void FillTab()
        {
            Thing thing = (Thing)SelObject;
            NecrologComp comp = thing.TryGetComp<NecrologComp>();
            if (comp != null)
            {
                Rect labelRect = new Rect(0f, 0f, WinSize.x, WinSize.y).ContractedBy(10f);
                float buttonWidth = Text.CalcSize("EditNecrologButton".Translate()).x + 20f;
                Rect buttonRect = new Rect(WinSize.x - buttonWidth - 10f, WinSize.y - 40f, buttonWidth, 30f);
                Rect textRect = new Rect(0f, 30f, WinSize.x - 10f, WinSize.y - 70f).ContractedBy(10f);
                Text.Font = GameFont.Medium;
                Widgets.Label(labelRect, "Necrolog".Translate());
                Text.Font = GameFont.Small;
                Widgets.LabelScrollable(textRect, comp.GetNecrologText(), ref scrollbarPos, dontConsumeScrollEventsIfNoScrollbar: true);
                if (Widgets.ButtonText(buttonRect, "EditNecrologButton".Translate()))
                {
                    Find.WindowStack.Add(new NecrologWindow((Building_Grave)SelObject, comp.GetNecrologText()));
                }
            }
            else
            {
                Log.Error("Called GravestoneTab.FillTab, but selected object hasn`t NecrologComp");
            }
        }
    }
}
