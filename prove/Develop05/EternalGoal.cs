
namespace EternalQuest

{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            // Eternal goals never mark complete
        }

        public override int RecordEvent()
        {
            // each time you record, you gain points, but it never sets complete
            return GetPoints();
        }

        public override string GetStatusString()
        {
            return "[∞]"; // indicates repeatable
        }

        public override string SaveData()
        {
            // Save as Eternal|name|desc|points
            string safeName = Escape(GetName());
            string safeDesc = Escape(GetDescription());
            string line = "Eternal" + "|" + safeName + "|" + safeDesc + "|" + GetPoints().ToString();
            return line;
        }

        public static EternalGoal LoadFromFields(string[] fields)
        {
            // Eternal|name|desc|points
            string name = fields[1].Replace("&#124;", "|").Replace("\\n", "\n");
            string desc = fields[2].Replace("&#124;", "|").Replace("\\n", "\n");
            int pts = 0;
            int.TryParse(fields[3], out pts);
            EternalGoal g = new EternalGoal(name, desc, pts);
            return g;
        }
    }
}
