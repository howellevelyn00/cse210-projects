
namespace EternalQuest
{

    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalScore;
        private int _level; // computed by simple thresholds

        public GoalManager()
        {
            _goals = new List<Goal>();
            _totalScore = 0;
            _level = 1;
        }

        public void AddGoal(Goal g)
        {
            if (g == null) return;
            _goals.Add(g);
        }

        public int GetScore()
        {
            return _totalScore;
        }

        public int GetLevel()
        {
            return _level;
        }

        // Display all goals with index
        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Create one from the menu.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Goal g = _goals[i];
                string status = g.GetStatusString();
                string displayLine = (i + 1).ToString() + ". " + status + " " + g.GetName() + " - " + g.GetDescription();
                Console.WriteLine(displayLine);
            }
        }

        // Record an event for a specific goal index (1-based indexing for user)
        public void RecordGoalEvent(int userIndex)
        {
            int idx = userIndex - 1;
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            Goal g = _goals[idx];
            int pointsGained = g.RecordEvent();
            if (pointsGained <= 0)
            {
                Console.WriteLine("No points gained (goal may already be complete).");
                return;
            }

            Console.WriteLine("You earned " + pointsGained.ToString() + " points!");
            _totalScore = _totalScore + pointsGained;

            // Leveling: level up for each 1000 points
            int newLevel = (_totalScore / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine("***** LEVEL UP! You are now level " + _level.ToString() + " *****");
            }

            // Special: if checklist completed this event, display big stars
            ChecklistGoal cg = null;
            if (g is ChecklistGoal)
            {
                cg = (ChecklistGoal)g;
                if (cg.IsComplete())
                {
                    Console.WriteLine();
                    Console.WriteLine("****************************");
                    Console.WriteLine("*** EXCELLENT JOB — YOU DID IT! ***");
                    Console.WriteLine("****************************");
                    Console.WriteLine();
                }
            }
        }

        // Save goals and score to a file (asks filename)
        public void SaveToFile()
        {
            Console.Write("Enter filename to save to (example: mygoals.txt): ");
            string fname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fname))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            try
            {
                List<string> lines = new List<string>();

                // save header with score and level
                lines.Add("SCORE|" + _totalScore.ToString());

                for (int i = 0; i < _goals.Count; i++)
                {
                    string line = _goals[i].SaveData();
                    lines.Add(line);
                }

                File.WriteAllLines(fname, lines.ToArray());
                Console.WriteLine("Saved to " + fname);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save file: " + ex.Message);
            }
        }

        // Load goals and score from file (asks filename). Replaces current state.
        public void LoadFromFile()
        {
            Console.Write("Enter filename to load from: ");
            string fname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fname))
            {
                Console.WriteLine("Invalid filename.");
                return;
            }

            if (!File.Exists(fname))
            {
                Console.WriteLine("File not found: " + fname);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(fname);
                List<Goal> newGoals = new List<Goal>();
                int newScore = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] fields = Goal.SplitFields(line);
                    if (fields.Length == 0) continue;

                    string type = fields[0];

                    if (type == "SCORE")
                    {
                        if (fields.Length > 1)
                        {
                            int.TryParse(fields[1], out newScore);
                        }
                        continue;
                    }
                    else if (type == "Simple")
                    {
                        SimpleGoal sg = SimpleGoal.LoadFromFields(fields);
                        newGoals.Add(sg);
                    }
                    else if (type == "Eternal")
                    {
                        EternalGoal eg = EternalGoal.LoadFromFields(fields);
                        newGoals.Add(eg);
                    }
                    else if (type == "Checklist")
                    {
                        ChecklistGoal cg = ChecklistGoal.LoadFromFields(fields);
                        // LoadFromFields used RecordEvent to set current count; it also sets completion flag if present.
                        newGoals.Add(cg);
                    }
                    else
                    {
                        // Unknown type - skip
                    }
                }

                _goals = newGoals;
                _totalScore = newScore;
                _level = (_totalScore / 1000) + 1;
                Console.WriteLine("Loaded " + _goals.Count.ToString() + " goals. Score: " + _totalScore.ToString() + " Level: " + _level.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load file: " + ex.Message);
            }
        }
    }
}