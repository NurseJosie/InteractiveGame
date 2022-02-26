namespace InteractiveProject
{
    public class LevelTwo
    {
        public void RunLevelTwo(User user, LevelThree level3)
        {
            Character deer = new("Swoooosh! I'm Bambi, the fastest deer in all of Wonder Woods! Answer my question if you can...!", "Which flower does produce opium?", "a. Rose / b. Poppy / c. Tulip", "b");

            CrossRoad(deer, user, level3);
        }

        public bool CrossRoad(Character deer, User user, LevelThree level3)
        {
            bool correctPath = false;

            Console.Clear();
            Console.WriteLine("Another CROSSROAD, these woods are like a labyrinth...");
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
                    Console.WriteLine("Woooaaaaah! I almost fell down a cliff! I guess I have to choose more carefully the next time...");

                    Console.WriteLine("Let's try again!");
                    CrossRoad(deer, user, level3);
                }
                else if (rndL == 2)
                {
                    correctPath = true;
                    Console.WriteLine("Good choice!");

                    Console.Clear();
                    Console.WriteLine("Tra laa laaa... A field full of flowers... How wonderful!");

                    Console.WriteLine("Press any key to continue the journey...");
                    Console.ReadKey();

                    QFromCharacter(deer, user, level3);
                }
            }
            else
            {
                Console.WriteLine("You should enter l or r!");
                CrossRoad(deer, user, level3);
            }

            return correctPath;
        }

        //karaktärsmetod, KLAR
        public bool QFromCharacter(Character deer, User user, LevelThree level3)
        {
            bool correctAnswer = false;

            Console.Clear();
            Console.WriteLine(deer.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(deer.Question);
            Console.WriteLine("...");
            Console.WriteLine(deer.Alternative);
            Console.WriteLine("...");

            Console.WriteLine("To answer enter a, b, or c...");

            string userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == deer.CorrectAnswer)
                {
                    Console.Clear();
                    correctAnswer = true;
                    Console.WriteLine("CORRECT!");
                    user.CorrectAnswers++;

                    Console.WriteLine("Is that a KEY?! THANKS!");
                    Console.WriteLine("Bye Bambi, the fastest deer I've ever seen! Shwoooooosh...!");
                    Console.WriteLine("...");

                    user.Key++;
                    user.Level++;
                    Console.WriteLine("Here are your current stats:");
                    user.ShowStats();
                    Console.ReadKey();

                    Console.Clear();
                    Console.WriteLine("You now continue to the next level!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    level3.RunLevelThree(user);
                }
                else if (userAnswer != deer.CorrectAnswer)
                {
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    Console.WriteLine("Carefull, you now have " + user.WrongAnswers + "/3 incorrect answers...");
                    Console.WriteLine("Well, maybe we'll run into eachother again Bambi...");
                    correctAnswer = false;

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
                        CrossRoad(deer, user, level3);
                    }
                }
            }
            else
            {
                Console.WriteLine("To answer enter a, b, or c...");
                QFromCharacter(deer, user, level3);
            }

            return correctAnswer;
        }
    }
}