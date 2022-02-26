namespace InteractiveProject
{
    public class LevelThree
    {
        public void RunLevelThree(User user)
        {
            Character iceQueen = new("Now you finally meet me, the ***ICE QUEEN*** How dare you enter my woods?! I will take you down with this question!", "What result is of this equation: 0.3 * 0.5 ? ", "a. 0.15 / b. 1.5 / c. 15", "a");

            CrossRoad(iceQueen, user);
        }

        public bool CrossRoad(Character iceQueen, User user)
        {
            bool correctPath = false;

            Console.Clear();
            Console.WriteLine("The woods have turned all cold and frosty, snow is everywhere.");
            Console.WriteLine("I can't see what way to go... ");
            Console.WriteLine("Turn RIGHT or LEFT... (Enter r or l)");
            string userInput = Console.ReadLine();

            if (userInput == "l" || userInput == "r")
            {
                Console.WriteLine("...");
                Random rnd = new Random();
                int rndL = rnd.Next(1, 3);
                if (rndL == 1)
                {
                    Console.WriteLine("WRONG WAY!");
                    Console.WriteLine("Ouch! I slipped on ice, clumsy me... WOAH!!! A POLAR BEAR, ruuuuuun!!!");

                    Console.WriteLine("Let's try again!");
                    CrossRoad(iceQueen, user);
                }
                else if (rndL == 2)
                {
                    correctPath = true;

                    Console.Clear();
                    Console.WriteLine("Wow, I make smart choices when it comes to navigating a snow storm! I just hope there are no polar bears around...");

                    Console.WriteLine("Press any key to continue the journey...");
                    Console.ReadKey();

                    QFromCharacter(iceQueen, user);
                }
            }
            else
            {
                Console.WriteLine("You should enter l or r!");
                CrossRoad(iceQueen, user);
            }

            return correctPath;
        }

        public bool QFromCharacter(Character iceQueen, User user)
        {
            bool correctAnswer = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(iceQueen.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(iceQueen.Question);
            Console.WriteLine("...");
            Console.WriteLine(iceQueen.Alternative);
            Console.WriteLine("...");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("To answer enter a, b, or c...");

            string userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == iceQueen.CorrectAnswer)
                {
                    Console.Clear();
                    correctAnswer = true;
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine("So you are just gonna hand me the KEY now, Ice Queen? Well, that was easy...!");
                    Thread.Sleep(5000);
                    user.CorrectAnswers++;
                    user.Key++;
                    user.Level++;

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("******************************************************************************************");
                    Console.WriteLine("YOU NOW HAVE ALL THE THREE KEYS!");
                    Console.WriteLine("The Ice Queen was so stunned that you could answer her question, the Queen FAINTS!");
                    Console.WriteLine("Let's unlock Kaj's cell and free him...");
                    Console.WriteLine(user.UserName + " and Kaj returns home and lives happily ever after...!");
                    Console.WriteLine("******************************************************************************************");
                    Console.WriteLine("                                       THE END");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    //avsluta spelet
                }
                else if (userAnswer != iceQueen.CorrectAnswer)
                {
                    correctAnswer = false;
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    if (user.WrongAnswers == 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game over...The Ice Queen will forever keep your friend in a cold miserable cell...");
                        Console.ForegroundColor = ConsoleColor.White;
                        //avsluta spelet
                    }
                    else
                    {
                        Console.WriteLine("Let's try again!");
                        CrossRoad(iceQueen, user);
                    }
                }
            }
            else
            {
                Console.WriteLine("To answer enter a, b, or c...");
                QFromCharacter(iceQueen, user);
            }

            return correctAnswer;
        }
    }
}