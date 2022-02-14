using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // he we have used Arrays for password values
    // Array is declared by "[]"
    string[] Level1Passwords = {"author", "study", "shelf", "books","library"};
    string[] Level2Passwords = {"bars", "holster", "prison", "police", "arrrest"};
    string[] Level3Passwords = {"astronaut", "rocket", "spaceship", "satellite", "telescope"};
    //Game State
    enum Screen { MainMenu, Password, Win }; //Screen is a variable type which is declard by enum
    Screen CurrentScreen; //"CurrentScreeen" is the name of variable declared above 
    int level; //Here int and string are member variable which can be used at multiple places in an object 
    string password; // And we can declare more member variable like these
    
    
    void Start()
    {
        print("hello");
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 to enter level 1");
        Terminal.WriteLine("Press 2 to enter level 2");
        Terminal.WriteLine("Press 3 to enter level 3");
        Terminal.WriteLine("Please enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }

        else if (input == "quit" || input == "exit" || input == "close")
        {
            Terminal.WriteLine("Thanks for playing.");
            Application.Quit();
        }

        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) // '.Length' is a command which shows the total number of values   
    {                             // in an aaray with which '.Length' has been declared
        if (input == "1")
        {
            level = 1;
            print(Level1Passwords.Length);
            StartGame2();
        }

        else if (input == "2")
        {
            level = 2;
            print(Level2Passwords.Length);
            StartGame2();
        }

        else if (input == "3")
        {
            level = 3;
            password = (Level3Passwords[0]);
            print(Level3Passwords.Length);
            StartGame2();
        }

        else
        {
            Terminal.WriteLine("Please enter a valid choice");
        }
    }

    void StartGame() // 'Random.Range' is a command which is used to give any 1 value as output 
    {               // among all the values of an array, which shows that it chooses the value randomly
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                var index = Random.Range(0, Level1Passwords.Length);
                password = Level1Passwords[index];
                break;
            case 2:
                password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];
                break;
            case 3:
                password = Level3Passwords[Random.Range(0, Level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Password.");
                break;
        }
        Terminal.WriteLine("You have entered level " + level);
        Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
    }
    void StartGame2()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();

        if (level == 1)
          password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];

        else if (level == 2)
          password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];

        else
            Terminal.WriteLine("Invalid level Password");

        Terminal.WriteLine("You have entered level " + level);
        Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
            Terminal.WriteLine("Please type menu to restart the game.");
        }
        else
        {
            StartGame2();
        }
    }

    void WinScreen()
    {
        Terminal.ClearScreen();
        CurrentScreen = Screen.Win;
        Terminal.WriteLine("Well Done! Its the right PIN! :)");
        Terminal.WriteLine("Here's a reward:");
        RewardForLevelClear();
    }
    // '@' is used to print the output in multiple lines in a single command line code
    void RewardForLevelClear()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
     _________
    /       //
   /       //
  /       //
 /_______//
(_______(/
           ");
                break;

            case 2:
                Terminal.WriteLine(@"
  .----.                   .----.
 //--\  \.---.---.---.---./  /--\\
((    ) @)  ( ) ( ) ( )  (@ (    ))
 \\__/  /'---'---'---'---'\  \__//
  '----'                   '----'
  ");
                break;

            case 3:
                Terminal.WriteLine(@"
        |
       / \
      / _ \
     |.o '.|
     |'._.'|
     |     |
   ,'|  |  |`.
  /  |  |  |  \
  |,-'--|--'-.| 
                ");
                break;
        }
    }

    void LevelClearReward()
    {
        if (level == 1)
        { Terminal.WriteLine(@"
     _________
    /       //
   /       // 
  /       //
 /_______//
(_______(/   
          "); 
        }

        else if (level == 2) 
        {
            Terminal.WriteLine(@"
  .----.                   .----.
 //--\  \.---.---.---.---./  /--\\
((    ) @)  ( ) ( ) ( )  (@ (    ))
 \\__/  /'---'---'---'---'\  \__//
  '----'                   '----'
                             ");
        }
    }
}