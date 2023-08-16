using Verse;


namespace Gravestone_Necrolog
{
    public class NecrologComp : ThingComp
    {
        private string necrolog = "";
        public string GetNecrologText()
        {
            return necrolog;
        }
        public void SetNecrologText(string new_text)
        {
            necrolog = new_text;
        }
        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref necrolog, "necrolog_" + parent.ToString(), "");
        }
    }
}