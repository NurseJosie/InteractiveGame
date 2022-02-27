// See https://aka.ms/new-console-template for more information

using Interactive_Saga;
using InteractiveProject;

User user = new();
LevelOne level1 = new();
MainMenu mainMenu = new();
MessageHelper messageHelper = new();
LevelTwo level2 = new();
LevelThree level3 = new();

messageHelper.WelcomeMessage(user);

mainMenu.RunMenu(level1, user, messageHelper, mainMenu, level2, level3);