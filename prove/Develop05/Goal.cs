using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base class for all goals
    public class Goal
    {
        private string _name;
        private string _description;
        private int _points; // points awarded per event (or on completion)
        private bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        // Accessors (methods only)
        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }

        public void SetComplete(bool val)
        {
            _isComplete = val;
        }

        // RecordEvent returns how many points were awarded by recording the goal now.
        // Base implementation marks complete and awards points once.
        public virtual int RecordEvent()
        {
            if (_isComplete)
            {
                return 0;
            }

            _isComplete = true;
            return _points;
        }

        // Status string for listing
        public virtual string GetStatusString()
        {
            if (_isComplete)
            {
                return "[X]";
            }
            else
            {
                return "[ ]";
            }
        }

        // For saving the goal data to a single line
        // Base format: Goal|name|description|points|isComplete
        public virtual string SaveData()
        {
            string safeName = Escape(_name);
            string safeDesc = Escape(_description);
            string line = "Goal" + "|" + safeName + "|" + safeDesc + "|" + _points.ToString() + "|" + (_isComplete ? "1" : "0");
            return line;
        }

        // Helper to escape pipe and newlines
        protected string Escape(string s)
        {
            if (s == null) return "";
            return s.Replace("|", "&#124;").Replace("\r", "").Replace("\n", "\\n");
        }

        protected string Unescape(string s)
        {
            if (s == null) return "";
            return s.Replace("&#124;", "|").Replace("\\n", "\n");
        }

        // Helper for parsing in derived classes
        public static string[] SplitFields(string line)
        {
            List<string> parts = new List<string>();
            char[] arr = line.ToCharArray();
            string cur = "";
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                if (c == '|')
                {
                    parts.Add(cur);
                    cur = "";
                }
                else
                {
                    cur += c;
                }
            }
            // push last
            parts.Add(cur);
            return parts.ToArray();
        }
    }
}