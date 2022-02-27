namespace InteractiveProject
{
    public class Character
    {
        public string HelloPhrase { get; set; }
        public string Question { get; set; }
        public string Alternative { get; set; }
        public string CorrectAnswer { get; set; }

        public Character(string helloPhrase, string question, string alternative, string correctAnswer)
        {
            HelloPhrase = helloPhrase;
            Question = question;
            Alternative = alternative;
            CorrectAnswer = correctAnswer;
        }
    }
}