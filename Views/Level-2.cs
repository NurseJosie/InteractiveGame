namespace InteractiveProject
{
    public class Level_2
    {
        public void RunLevelTwo(User user, Level_3 level3)
        {
            Character deer = new("Bambi", "Hello, my name is Bambi !", "Which flower does produce opium?", "a. Poppy / b. Tulip / c. Carnation", "a");

            CrossRoad();
        }

            public bool CrossRoad()
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

                    QFromCharacter();
                }
                else
                {
                    Console.WriteLine("Let's try again!");
                    CrossRoad();
                }

                return correctPath;
            }

            //karaktärsmetod, KLAR
            public bool QFromCharacter()
            {
                bool correctAnswer = false;

                Console.Clear();
                Console.WriteLine(deer.HelloPhrase);
                Console.WriteLine("...");
                Console.WriteLine(deer.Question);
                Console.WriteLine(deer.Alternative);
                Console.WriteLine("...");

                Console.WriteLine("To answer enter a, b, or c...");

                string userAnswer = Console.ReadLine();

                if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
                {
                    if (userAnswer == deer.CorrectAnswer)
                    {
                        Console.WriteLine("CORRECT!");
                        user.CorrectAnswers++;
                        correctAnswer = true;
                    }
                    else if (userAnswer != deer.CorrectAnswer)
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

                    level3.RunLevelThree(user);
                }
                else
                {
                    Console.WriteLine("Let's try again!");
                    CrossRoad();
                }

                return correctAnswer;
            }
        }
    }