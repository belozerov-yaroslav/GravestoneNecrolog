using RimWorld;
using UnityEngine;
using Verse;

namespace Gravestone_Necrolog
{
    public class NecrologWindow : Window
    {
        private Building_Grave workingGrave;
        private Vector2 scrollbarPos = new Vector2(0f, 0f);
        string cachedText = "";
        public NecrologWindow(Building_Grave grave, string text)
        {
            workingGrave = grave;
            cachedText = text;
        }
        public override void DoWindowContents(Rect inRect)
        {
            Text.Font = GameFont.Small;
            Rect textRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height - 35f);
            cachedText = Widgets.TextAreaScrollable(textRect, cachedText, ref scrollbarPos);
            workingGrave.TryGetComp<NecrologComp>().SetNecrologText(cachedText);
            float closeButtonWidth = Text.CalcSize("Close".Translate()).x + 70f;
            Rect closeButtonRect = new Rect((inRect.width - closeButtonWidth) / 2, textRect.height + 5f, closeButtonWidth, 30f);
            if (Widgets.ButtonText(closeButtonRect, "Close".Translate()))
            {
                Close();
            }
        }
        public string GetCurrentText()
        {
            return cachedText;
        }
    }
}
