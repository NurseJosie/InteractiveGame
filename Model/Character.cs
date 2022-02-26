namespace InteractiveProject
{
    public class Character
    {
        public string Name { get; set; }
        public string HelloPhrase { get; set; }
        public string Question { get; set; }
        public string Alternative { get; set; }
        public string CorrectAnswer { get; set; }

        public Character(string name, string helloPhrase, string question, string alternative, string correctAnswer)
        {
            Name = name;
            HelloPhrase = helloPhrase;
            Question = question;
            Alternative = alternative;
            CorrectAnswer = correctAnswer;
        }

        public Character()
        {
        }
    }
}