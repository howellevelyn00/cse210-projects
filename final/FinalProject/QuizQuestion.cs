namespace FinalProject
{
    public abstract class QuizQuestion
    {
        protected string prompt;

        public QuizQuestion(string prompt)
        {
            this.prompt = prompt;
        }

        public abstract bool Ask();
    }
}
