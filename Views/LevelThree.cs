namespace InteractiveProject
{
    public class LevelThree
    {
        public bool RunLevelThree(User user, string userInput = "")
        {
            Character iceQueen = new("Now you finally meet me, the ***ICE QUEEN*** How dare you enter my woods?! I will take you down with this question!", "What result is of this equation: 0.3 * 0.5 ? ", "a. 0.15 / b. 1.5 / c. 15", "a");

            bool correctPath = false;
            while (!correctPath)
            {
                correctPath = CrossRoad(userInput);
            }

            bool correctAnswer = false;
            while (!correctAnswer)
            {
                correctAnswer = QFromCharacter(iceQueen, user);
            }

            if (correctAnswer && user.WrongAnswers > 2) return false;

            return true;
        }

        public bool CrossRoad(string userInput = "")
        {
            bool correctPath = false;

            Console.WriteLine("The woods have turned all cold and frosty, snow is everywhere.");
            Console.WriteLine("I can't see what way to go... ");
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
                    Console.WriteLine("Ouch! I slipped on ice, clumsy me... WOAH!!! A POLAR BEAR, ruuuuuun!!!");
                    Console.WriteLine("Let's try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (rndL == 2)
                {
                    Console.WriteLine("Wow, I make smart choices when it comes to navigating a snow storm! I just hope there are no polar bears around...");
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

        public bool QFromCharacter(Character iceQueen, User user, string userAnswer = "")
        {
            bool correctAnswer = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(iceQueen.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(iceQueen.Question);
            Console.WriteLine("...");
            Console.WriteLine(iceQueen.Alternative);
            Console.WriteLine("...");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("To answer enter a, b, or c...");

            if (userAnswer == "") userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == iceQueen.CorrectAnswer)
                {
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine("So you are just gonna hand me the KEY now, Ice Queen? Well, that was easy...!");
                    Thread.Sleep(3000);
                    user.CorrectAnswers++;
                    user.Key++;
                    user.Level++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("******************************************************************************************");
                    Console.WriteLine("YOU NOW HAVE ALL THE THREE KEYS!");
                    Console.WriteLine("The Ice Queen was so stunned that you could answer her question, the Queen FAINTS!");
                    Console.WriteLine("Let's unlock Kaj's cell and free him...");
                    Console.WriteLine(user.UserName + " and Kaj returns home and lives happily ever after...!");
                    Console.WriteLine("******************************************************************************************");
                    Console.WriteLine("                                       THE END");
                    Thread.Sleep(7000);

                    correctAnswer = true;
                }
                else if (userAnswer != iceQueen.CorrectAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    Console.WriteLine("Carefull, you now have " + user.WrongAnswers + "/3 incorrect answers...");
                    Console.WriteLine("...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(3000);

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