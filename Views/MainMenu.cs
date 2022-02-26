using Interactive_Saga;
using InteractiveProject;

public class MainMenu
{
    public void RunMenu(LevelOne level1, User user, MessageHelper messageHepler, LevelTwo level2, MainMenu mainMenu, LevelThree level3)
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
                    level1.RunLevelOne(user, level2, level3);
                    break;

                case 2:
                    Console.Clear();
                    user.ShowStats();
                    break;

                case 3:
                    Console.Clear();
                    messageHepler.RulesOfGame();
                    mainMenu.RunMenu(level1, user, messageHepler, level2, mainMenu, level3);
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