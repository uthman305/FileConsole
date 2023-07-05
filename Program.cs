using File_ConsoleC.Manager.Implementation;
using File_ConsoleC.Menu;

new UserManager().LoadDataFromFile();
// new CustomerManager().LoadDataFromFile();
// new AgentManager().LoadDataFromFile();
// new CMManager().LoadDataFromFile();
// new CompanyManager().LoadDataFromFile();
// new WalletManager().LoadDataFromFile();



MainMenu mainMenu = new MainMenu();
mainMenu.Main();