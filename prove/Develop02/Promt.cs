using System;
using System.Collections.Generic;

namespace SimpleJournal
{
    public class PromptGenerator
    {
        private List<string> _prompts;
        private static readonly Random _rng = new Random();
        private int _lastIndex = -1;

        public PromptGenerator()
        {
            _prompts = new List<string>()
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is something I accomplished today that I am proud of?",
                "What is a challenge I faced today and how did I handle it?",
                "What is something new I learned today?",
                "What is a moment from today that made me smile?",
                "How did I take care of myself today?",
                "What is one small victory I had today?"
            };
        }

        public string GetRandomPrompt()
        {
            if (_prompts.Count == 0)
            {
                return "No prompts available.";
            }

            if (_prompts.Count == 1)
            {
                return _prompts[0];
            }

            int idx;
            do
            {
                idx = _rng.Next(_prompts.Count);
            } while (idx == _lastIndex);

            _lastIndex = idx;
            return _prompts[idx];
        }

        public void AddPrompt(string p)
        {
            _prompts.Add(p);
        }

        public List<string> GetAllPrompts()
        {
            return new List<string>(_prompts);
        }
    }
}
