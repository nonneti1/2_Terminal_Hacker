using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type 'menu' at anytime";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = {"prisoner","handcuffs","holster", "uniform","arrest" };
    string[] level3Passwords = { "starfield", "telescope", "enviroment", "exploration", "astronauts", };

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
                password = level1Passwords[Random.Range(0,level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0,level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
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
        Terminal.WriteLine("Enter your password, hint :"+password.Anagram());
        Terminal.WriteLine(menuHint);
        
    }

    void WinGame(int level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        Terminal.WriteLine("Congratulation! you passed level " + level);
        Terminal.WriteLine("Enter 'menu' to go back to main menu");
        Terminal.WriteLine("Play again for greater challenge.");
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
        else if (level == 3)
        {
            Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
");
            Terminal.WriteLine("Welcome to NASA internal system.");
        }
        else
            Debug.LogError("Invalid level");
        
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
