using Interactive_Saga;
using InteractiveProject;

public class MainMenu
{
    public void RunMenu(LevelOne level1, User user, MessageHelper messageHepler, MainMenu mainMenu, LevelTwo level2, LevelThree level3)
    {
        bool runMenu = true;
        while (runMenu)
        {
            messageHepler.MainMenuMessage();

            string userMenuInput = Console.ReadLine();

            int menuInputInt = 0;
            int.TryParse(userMenuInput, out menuInputInt);

            switch (menuInputInt)
            {
                case 1:
                    Console.Clear();
                    bool levelResult = level1.RunLevelOne(user);
                    if (!levelResult)
                    {
                        user.Key = 0;
                        user.CorrectAnswers = 0;
                        user.WrongAnswers = 0;
                        user.Level = 1;
                        break;
                    }
                    levelResult = level2.RunLevelTwo(user);
                    if (!levelResult)
                    {
                        user.Key = 0;
                        user.CorrectAnswers = 0;
                        user.WrongAnswers = 0;
                        user.Level = 1;
                        break;
                    }
                    levelResult = level3.RunLevelThree(user);
                    if (!levelResult)
                    {
                        user.Key = 0;
                        user.CorrectAnswers = 0;
                        user.WrongAnswers = 0;
                        user.Level = 1;
                        break;
                    }
                    break;

                case 2:
                    Console.Clear();
                    user.ShowStats();
                    break;

                case 3:
                    Console.Clear();
                    messageHepler.RulesOfGame();
                    break;

                case 4:
                    runMenu = false;
                    break;

                default:
                    messageHepler.MenuErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
    }
}