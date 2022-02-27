namespace InteractiveProject
{
    public class LevelOne
    {
        public bool RunLevelOne(User user, string userInput = "")
        {
            Character rabbit = new("Hop hop hop...Hi, I'm Buns the rabbit!... If you answer my question i may give you something you need...", "What has hands and a face, but can’t hold anything or smile?", "a. Clock /  b.Mirror / c.Sun", "a");

            bool correctPath = false;
            while (!correctPath)
            {
                correctPath = CrossRoad(userInput);
            }

            bool correctAnswer = false;
            while (!correctAnswer)
            {
                correctAnswer = QFromCharacter(rabbit, user);
            }

            if (correctAnswer && user.WrongAnswers > 2) return false;

            return true;
        }

        public bool CrossRoad(string userInput = "")
        {
            bool correctPath = false;

            Console.WriteLine("Huh... Were am i...? Aha, at a CROSSROAD!");
            Console.WriteLine("There is a dark cave to the left, i wouldn't want to get lost in there...");
            Console.WriteLine("Turn RIGHT or LEFT... (Enter r or l)");
            if (userInput == "") userInput = Console.ReadLine();

            if (userInput == "l" || userInput == "r")
            {
                Console.WriteLine("...");
                if (userInput == "l")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG WAY!");
                    Console.WriteLine("Seems like I walked right opon a napping BEAR... I must RUN!");
                    Console.WriteLine("Let's try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("WISE CHOICE!");
                    Console.WriteLine("What a lovely day in the Wonder Woods... Butterflies everywhere!");
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

        public bool QFromCharacter(Character rabbit, User user, string userAnswer = "")
        {
            bool correctAnswer = false;

            Console.WriteLine(rabbit.HelloPhrase);
            Console.WriteLine("...");
            Console.WriteLine(rabbit.Question);
            Console.WriteLine("...");
            Console.WriteLine(rabbit.Alternative);
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Console.WriteLine("To answer enter a, b, or c...");

            if (userAnswer == "") userAnswer = Console.ReadLine();

            if (userAnswer == "a" || userAnswer == "b" || userAnswer == "c")
            {
                if (userAnswer == rabbit.CorrectAnswer)
                {
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine("...");
                    Console.WriteLine("A KEY, thank you!!!");
                    Console.WriteLine("This part of the Wonder Woods was so nice, bye Buns the Rabbit!");
                    Console.WriteLine("...");
                    user.Key++;
                    user.Level++;
                    user.CorrectAnswers++;
                    Console.WriteLine("Here are your current stats:");
                    user.ShowStats();
                    Console.WriteLine("You now continue to the next level!");
                    Thread.Sleep(3000);

                    correctAnswer = true;
                }
                else if (userAnswer != rabbit.CorrectAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG!!!");
                    user.WrongAnswers++;
                    Console.WriteLine("Carefull, you now have " + user.WrongAnswers + "/3 incorrect answers...");
                    Console.WriteLine("...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(3000);
                    Console.WriteLine("Hmm, well maybe I'll see you later Buns!");

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