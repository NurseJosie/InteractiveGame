namespace InteractiveProject
{
    public class Level_1

    {
        public void RunLevelOne(User user, Level_2 level2, Level_3 level3)
        {
            Character rabbit = new("Rabby", "Hello buddy, my name is Rabby! Let me ask you a question...", "What has hands and a face, but can’t hold anything or smile?", "a. Clock /  b.Mirror / c.Sun", "a");

            CrossRoad(rabbit, user, level2, level3);
        }

            public bool CrossRoad(Character rabbit, User user, Level_2 level2, Level_3 level3)
            {
                bool correctPath = false;

                Console.WriteLine("You are at a CROSSROAD! Choose to turn RIGHT or LEFT... Enter r or l, please!");
                string userInput = Console.ReadLine();

                if (userInput == "l" || userInput == "r")
                {
                    Console.WriteLine("...");
                    Random rnd = new Random();
                    int rndL = rnd.Next(1, 3);
                    if (rndL == 1)
                    {
                        Console.WriteLine("Wrong way!");
                        correctPath = false;
                    }
                    else if (rndL == 2)
                    {
                        Console.WriteLine("Correct!");
                        correctPath = true;
                    }
                }
                else
                {
                    Console.WriteLine("Enter l or r!");
                    correctPath = false;
                }

                if (correctPath == true)
                {
                    Console.WriteLine("Press any key to continue the journey...");
                    Console.ReadKey();

                    QFromCharacter(rabbit, user, level2, level3);
                }
                else
                {
                    Console.WriteLine("Let's try again!");
                    CrossRoad(rabbit, user, level2, level3);
                }

                return correctPath;
            }

            public bool QFromCharacter(Character rabbit, User user, Level_2 level2, Level_3 level3)
            {
                bool correctAnswer = false;

                Console.Clear();
                Console.WriteLine(rabbit.HelloPhrase);
                Console.WriteLine("...");
                Console.WriteLine(rabbit.Question);

                Console.WriteLine(rabbit.Alternative);
                Console.WriteLine("...");

                Console.WriteLine("To answer enter a, b, or c...");

                string userAnswer = Console.ReadLine();

                if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
                {
                    if (userAnswer == rabbit.CorrectAnswer)
                    {
                        Console.WriteLine("CORRECT!");
                        user.CorrectAnswers++;
                        correctAnswer = true;
                    }
                    else if (userAnswer != rabbit.CorrectAnswer)
                    {
                        Console.WriteLine("WRONG!!!");
                        user.WrongAnswers++;

                        if (user.WrongAnswers == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game over...The Ice Queen will forever keep your friend in a cold miserable cell...");
                            Console.ForegroundColor = ConsoleColor.White;
                            //avsluta spelet
                        }

                        correctAnswer = false;
                    }
                }
                else
                {
                    Console.WriteLine("To answer enter a, b, or c...");
                }
                if (correctAnswer == true)
                {
                    Console.WriteLine("You now continue to the next level!");
                    user.Key++;
                    user.Level++;
                    Console.WriteLine("Here are your current stats:");
                    user.ShowStats();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    level2.RunLevelTwo(user, level3);
                }
                else
                {
                    Console.WriteLine("Let's try again!");
                    CrossRoad(rabbit, user, level2, level3);
                }

                return correctAnswer;
            }
        }
    }