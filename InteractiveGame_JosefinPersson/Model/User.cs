namespace InteractiveProject
{
    public class User
    {
        public string UserName { get; set; } = "";
        public int CorrectAnswers { get; set; } = 0;
        public int WrongAnswers { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Key { get; set; } = 0;

        public void ShowStats()
        {
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("Name:     " + UserName);
            Console.WriteLine("You have " + CorrectAnswers + " correct answers");
            Console.WriteLine("You have " + WrongAnswers + " /3 wrong answers");
            Console.WriteLine("You have    " + Key + " keys");
            Console.WriteLine("Level:      " + Level + "/3");
            Console.WriteLine("******************************************************************************************");
            Thread.Sleep(3000);
        }
    }
}