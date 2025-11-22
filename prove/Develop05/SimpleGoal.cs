
namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            if (IsComplete())
            {
                return 0;
            }

            SetComplete(true);
            return GetPoints();
        }

        public override string GetStatusString()
        {
            return base.GetStatusString();
        }

        public override string SaveData()
        {
            string baseLine = base.SaveData(); // "Goal|..."
                                               // change type prefix to Simple
                                               // base.SaveData returns "Goal|..." so we replace "Goal" vs "Simple"
            string[] fields = SplitFields(baseLine);
            // fields: [0]=Goal, [1]=name, [2]=desc, [3]=points, [4]=isComplete
            string line = "Simple" + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4];
            return line;
        }

        // Static loader helper
        public static SimpleGoal LoadFromFields(string[] fields)
        {
            // fields expected: Simple|name|desc|points|isComplete
            string name = fields[1].Replace("&#124;", "|").Replace("\\n", "\n");
            string desc = fields[2].Replace("&#124;", "|").Replace("\\n", "\n");
            int pts = 0;
            int.TryParse(fields[3], out pts);
            SimpleGoal g = new SimpleGoal(name, desc, pts);
            if (fields.Length > 4 && fields[4] == "1")
            {
                g.SetComplete(true);
            }
            return g;
        }
    }
}
