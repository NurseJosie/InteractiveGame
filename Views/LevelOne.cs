namespace InteractiveProject
{
    public class LevelOne

    {
        public void RunLevelOne(User user, LevelTwo level2, LevelThree level3)
        {
            Character rabbit = new("Hop hop hop...Hi, I'm Buns the rabbit!... If you answer my question i may give you something you need...", "What has hands and a face, but can’t hold anything or smile?", "a. Clock /  b.Mirror / c.Sun", "a");

            CrossRoad(rabbit, user, level2, level3);
        }

        public bool CrossRoad(Character rabbit, User user, LevelTwo level2, LevelThree level3)
        {
            bool correctPath = false;

            Console.Clear();
            Console.WriteLine("Huh... Were am i...? Aha, at a CROSSROAD!");
            Console.WriteLine("There is a dark cave to the left, i wouldn't want to get lost in there...");
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
                    Console.WriteLine("Seems like I walked right opon a napping BEAR... I must RUN!");

                    Console.WriteLine("Let's try again...");
                    CrossRoad(rabbit, user, level2, level3);
                }
                else if (rndL == 2)
                {
                    correctPath = true;
                    Console.WriteLine("WISE CHOICE!");

                    Console.Clear();
                    Console.WriteLine("What a lovely day in the Wonder Woods... Butterflies everywhere!");

                    Console.WriteLine("Press any key to continue the journey...");
                    Console.ReadKey();

                    QFromCharacter(rabbit, user, level2, level3);
                }
            }
            else
            {
                Console.WriteLine("You should enter l or r!");
                CrossRoad(rabbit, user, level2, level3);
            }

            return correctPath;
        }

        public bool QFromCharacter(Character rabbit, User user, LevelTwo level2, LevelThree level3)
        {
            bool correctAnswer = false;

            Console.Clear();
            Console.WriteLine(rabbit.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(rabbit.Question);
            Console.WriteLine("...");
            Console.WriteLine(rabbit.Alternative);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("To answer enter a, b, or c...");

            string userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == rabbit.CorrectAnswer)
                {
                    Console.Clear();
                    correctAnswer = true;
                    Console.WriteLine("CORRECT!");
                    user.CorrectAnswers++;

                    Console.WriteLine("A KEY, thank you!!!");
                    Console.WriteLine("This part of the Wonder Woods was so nice, bye Buns the Rabbit!");
                    Console.WriteLine("...");

                    user.Key++;
                    user.Level++;
                    Console.WriteLine("Here are your current stats:");
                    user.ShowStats();

                    Console.WriteLine("You now continue to the next level!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    level2.RunLevelTwo(user, level3);
                }
                else if (userAnswer != rabbit.CorrectAnswer)
                {
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    Console.WriteLine("Carefull, you now have " + user.WrongAnswers + "/3 incorrect answers...");
                    Console.WriteLine("...");
                    Console.WriteLine("Hmm, well maybe I'll see you later Buns!");
                    Console.ReadKey();

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
                        CrossRoad(rabbit, user, level2, level3);
                    }
                }
            }
            else
            {
                Console.WriteLine("To answer enter a, b, or c...");

                QFromCharacter(rabbit, user, level2, level3);
            }

            return correctAnswer;
        }
    }
}