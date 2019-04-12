using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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

    void RunRetry()
    {
        Terminal.WriteLine("Please try again");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "shelf";
            StartGame(input);
        }
        else if (input == "2")
        {
            level = 2;
            password = "handcuff";
            StartGame(input);
        }
        else if (input == "3")
        {
            level = 3;
            password = "space engine";
            StartGame(input);
        }
        else if (input == "007")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hi there Mr.Bond");
        }
        else Terminal.WriteLine("Please enter valid number");
    }

    void StartGame(string level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password :");
    }

    void WinGame(int level)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        Terminal.WriteLine("Congratulation! you passed level " + level);
        Terminal.WriteLine("Enter 'menu' to go back to main menu");
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
