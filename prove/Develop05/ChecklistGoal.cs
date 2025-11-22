
namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int pointsPerRecord, int targetCount, int bonus)
            : base(name, description, pointsPerRecord)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonus;
        }

        public int GetTargetCount()
        {
            return _targetCount;
        }

        public int GetCurrentCount()
        {
            return _currentCount;
        }

        public int GetBonusPoints()
        {
            return _bonusPoints;
        }

        public override int RecordEvent()
        {
            if (IsComplete())
            {
                return 0;
            }

            _currentCount = _currentCount + 1;

            int awarded = GetPoints();

            if (_currentCount >= _targetCount)
            {
                SetComplete(true);
                awarded = awarded + _bonusPoints;
            }

            return awarded;
        }

        public override string GetStatusString()
        {
            string baseStatus = "[ ]";
            if (IsComplete())
            {
                baseStatus = "[X]";
            }
            // show Completed x/y
            string s = baseStatus + " Completed " + _currentCount.ToString() + "/" + _targetCount.ToString();
            return s;
        }

        public override string SaveData()
        {
            // Checklist|name|desc|points|target|current|bonus|isComplete
            string safeName = Escape(GetName());
            string safeDesc = Escape(GetDescription());
            string line = "Checklist" + "|" + safeName + "|" + safeDesc + "|" + GetPoints().ToString() + "|" + _targetCount.ToString() + "|" + _currentCount.ToString() + "|" + _bonusPoints.ToString() + "|" + (IsComplete() ? "1" : "0");
            return line;
        }

        public static ChecklistGoal LoadFromFields(string[] fields)
        {
            // fields: Checklist|name|desc|points|target|current|bonus|isComplete
            string name = fields[1].Replace("&#124;", "|").Replace("\\n", "\n");
            string desc = fields[2].Replace("&#124;", "|").Replace("\\n", "\n");
            int pts = 0;
            int target = 0;
            int current = 0;
            int bonus = 0;
            int.TryParse(fields[3], out pts);
            int.TryParse(fields[4], out target);
            int.TryParse(fields[5], out current);
            int.TryParse(fields[6], out bonus);
            ChecklistGoal g = new ChecklistGoal(name, desc, pts, target, bonus);
            // set current and completion state
            // using reflection of private fields isn't allowed — use methods
            // set the _currentCount by recording events as needed (but easier: we set via internal hack: use a helper)
            // Since we can't access private field, we will recreate and update via method calls simulated here:
            for (int i = 0; i < current; i++)
            {
                // trick: call RecordEvent but avoid double-bonus if already complete; it's okay because LoadFromFields will set complete at end if flag says so.
                g.RecordEvent();
            }
            if (fields.Length > 7 && fields[7] == "1")
            {
                g.SetComplete(true);
            }
            return g;
        }
    }
}
