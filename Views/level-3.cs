namespace InteractiveProject
{
    public class Level_3
    {
        public void RunLevelThree(User user)
        {
            Character iceQueen = new("Ice Queen", "How dare you enter my woods?! I will take you down with this question!", "What result is of this equation: 0.3 * 0.5 ? ", "a. 0.15 / b. 1.5 / c. 15", "a");

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

            public bool QFromCharacter()
            {
                bool correctAnswer = false;

                Console.Clear();
                Console.WriteLine(iceQueen.HelloPhrase);
                Console.WriteLine("...");
                Console.WriteLine(iceQueen.Question);
                Console.WriteLine(iceQueen.Alternative);
                Console.WriteLine("...");

                Console.WriteLine("To answer enter a, b, or c...");

                string userAnswer = Console.ReadLine();

                if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
                {
                    if (userAnswer == iceQueen.CorrectAnswer)
                    {
                        Console.WriteLine("CORRECT!");
                        user.CorrectAnswers++;
                        correctAnswer = true;
                    }
                    else if (userAnswer != iceQueen.CorrectAnswer)
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
                    user.Key++;
                    user.Level++;

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
                else
                {
                    Console.WriteLine("Let's try again!");
                    CrossRoad();
                }

                return correctAnswer;
            }
        }
    }
