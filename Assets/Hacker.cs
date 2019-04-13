using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = {"prisoner","handcuffs","holster", "uniform","arrest" };
    int index1=0;
    int index2 = 0;
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
        index1 = Random.Range(0, level1Passwords.Length);
        index2 = Random.Range(0, level2Passwords.Length);
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.WriteLine("Welcome to WM2000 Hacking Terminal\n");
        Terminal.WriteLine("Select number you would like to hack");
        Terminal.WriteLine("1. Local library\n" +
            "2. Police Station\n" +
            "3. NASA\n");
        Terminal.WriteLine("Enter your selection : ");
    }

    //this should only decide who to handle input, not actually do it
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            Password(input, level);
        }
    }

    void RandomPassword(int level)
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[index1];
                break;
            case 2:
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void RunRetry()
    {
        Terminal.WriteLine("Please try again");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword(input);
        }
        else if (input == "007")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hi there Mr.Bond");
        }
        else Terminal.WriteLine("Please enter valid number");
    }

    void AskForPassword(string level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        RandomPassword(int.Parse(level));
        Terminal.WriteLine("Please enter your password, hint :"+password.Anagram());
        
    }

    void WinGame(int level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        Terminal.WriteLine("Congratulation! you passed level " + level);
        Terminal.WriteLine("Enter 'menu' to go back to main menu");
        if (level == 1)
        {
            Terminal.WriteLine("Have a book . . .");
            Terminal.WriteLine(@"
    _________
   /-------//
  /_______//
 /_______//
(_______(/
");
        }
        else if (level == 2)
        {
            Terminal.WriteLine("You got the prison key !!!");
            Terminal.WriteLine(@"
 __________
|          \__________________
|     O     _________--vVwWvv/
|__________/
");
        }
    }

    void Password(string input, int level)
    {
        if (input == password)
        {
            WinGame(level);
        }
        else
            RunRetry();
    }
}
