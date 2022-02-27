namespace InteractiveProject
{
    public class LevelTwo
    {
        public bool RunLevelTwo(User user, string userInput = "")
        {
            Character deer = new("Swoooosh! I'm Bambi, the fastest deer in all of Wonder Woods! Answer my question if you can...!", "Which flower does produce opium?", "a. Rose / b. Poppy / c. Tulip", "b");

            bool correctPath = false;
            while (!correctPath)
            {
                correctPath = CrossRoad(userInput);
            }

            bool correctAnswer = false;
            while (!correctAnswer)
            {
                correctAnswer = QFromCharacter(deer, user);
            }

            if (correctAnswer && user.WrongAnswers > 2) return false;

            return true;
        }

        public bool CrossRoad(string userInput = "")
        {
            bool correctPath = false;

            Console.WriteLine("Another CROSSROAD, these woods are like a labyrinth...");
            Console.WriteLine("Turn RIGHT or LEFT... (Enter r or l)");
            if (userInput == "") userInput = Console.ReadLine();

            if (userInput == "l" || userInput == "r")
            {
                Console.WriteLine("...");
                Random rnd = new Random();
                int rndL = rnd.Next(1, 3);
                if (rndL == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG WAY!");
                    Console.WriteLine("Woooaaaaah! I almost fell down a cliff! I guess I have to choose more carefully the next time...");
                    Console.WriteLine("Let's try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (rndL == 2)
                {
                    Console.WriteLine("Good choice!");
                    Console.WriteLine("Tra laa laaa... A field full of flowers... How wonderful!");
                    Thread.Sleep(3000);
                    correctPath = true;
                }
            }
            else
            {
                Console.WriteLine("You should enter l or r!");
            }

            return correctPath;
        }

        public bool QFromCharacter(Character deer, User user, string userAnswer = "")
        {
            bool correctAnswer = false;

            Console.WriteLine(deer.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(deer.Question);
            Console.WriteLine("...");
            Console.WriteLine(deer.Alternative);
            Console.WriteLine("...");
            Thread.Sleep(2000);
            Console.WriteLine("To answer enter a, b, or c...");

            if (userAnswer == "") userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == deer.CorrectAnswer)
                {
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine("...");
                    Console.WriteLine("Is that a KEY?! THANKS!");
                    Console.WriteLine("Bye Bambi, the fastest deer I've ever seen! Shwoooooosh...!");
                    Console.WriteLine("...");
                    user.CorrectAnswers++;
                    user.Key++;
                    user.Level++;
                    Console.WriteLine("Here are your current stats:");
                    user.ShowStats();
                    Console.WriteLine("You now continue to the next level!");
                    Thread.Sleep(3000);

                    correctAnswer = true;
                }
                else if (userAnswer != deer.CorrectAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    Console.WriteLine("Carefull, you now have " + user.WrongAnswers + "/3 incorrect answers...");
                    Console.WriteLine("...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(3000);
                    Console.WriteLine("Well, maybe we'll run into eachother again Bambi...");

                    if (user.WrongAnswers == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game over...The Ice Queen will forever keep your friend in a cold miserable cell...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(3000);
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("To answer enter a, b, or c...");
            }

            return correctAnswer;
        }
    }
}