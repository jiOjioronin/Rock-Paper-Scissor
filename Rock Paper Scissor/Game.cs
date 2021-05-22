using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace Rock_Paper_Scissor
{
    class Game
    {
        private int userScore;
        private int computerScore;
        private int computerChoiceInt;
        private string computerChoiceString;
        private string userChoice;
        private string difficulty;
        private int timesWon = 0;
        private int timesLost = 0;
        public Game()
        {
            //start and menu screen
            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Clear();
            userScore = 0;
            computerScore = 0;
            StartScreen();
        }
        public void Play()
        {
            //initiated after start screen, play a round
            while (userScore < 3 && computerScore < 3)
            {
                Clear();
                WriteLine("\nType \"rock\" for rock, \"paper\" for paper or \"scissors\" for scissors");
                userChoice = ReadLine().Trim().ToUpper();
                Clear();

                if (difficulty == "EASY")
                {
                    EasyRules();
                    HandsAndRules();
                }
                else if (difficulty == "HELL")
                {
                    HellRules();
                    HandsAndRules();
                }
                else
                {
                    RandomRoll();
                    HandsAndRules();
                }        

                WriteLine($"\nMan: {userScore} | Machine: {computerScore}");

                if (userScore == 3)
                {
                    WriteLine("\n-*-_-*-_-*- YOU WON THE GAME! -*-_-*-_-*-");
                    timesWon++;
                    PlayAgain();
                    break;
                }
                else if (computerScore == 3)
                {
                    WriteLine("\nYou lost the game.");
                    timesLost++;
                    PlayAgain();
                    break;
                }

                WriteLine("\nPress enter to play again.");
                ReadKey();
            }  //ReadKey(true).Key != ConsoleKey.E
            
        }
        public void StartScreen()
        {
            //let's you choose difficulty
            WriteLine("WELCOME TO ROCK PAPER SCISSOR FREEK VS MACHINE ULTIMATE SHOWDOWN - THE GAME");
            WriteLine("\nEnter:\n\t\"easy\"\t\tfor easy mode\n\t\"normal\"\tfor normal mode\n\t\"hell\"\t\tfor hell mode\n");
            difficulty = ReadLine().Trim().ToUpper();
            
        }
        //unused method... made for fun
        public void CinematicHellModeScreen()
        {
            int sleepTime = 1000;

            //WELCOME TO in ASCII
            WriteLine(@" __ __ __   ______   __       ______   ______   ___ __ __   ______       _________  ______      
/_//_//_/\ /_____/\ /_/\     /_____/\ /_____/\ /__//_//_/\ /_____/\     /________/\/_____/\     
\:\\:\\:\ \\::::_\/_\:\ \    \:::__\/ \:::_ \ \\::\| \| \ \\::::_\/_    \__.::.__\/\:::_ \ \    
 \:\\:\\:\ \\:\/___/\\:\ \    \:\ \  __\:\ \ \ \\:.      \ \\:\/___/\      \::\ \   \:\ \ \ \   
  \:\\:\\:\ \\::___\/_\:\ \____\:\ \/_/\\:\ \ \ \\:.\-/\  \ \\::___\/_      \::\ \   \:\ \ \ \  
   \:\\:\\:\ \\:\____/\\:\/___/\\:\_\ \ \\:\_\ \ \\. \  \  \ \\:\____/\      \::\ \   \:\_\ \ \ 
    \_______\/ \_____\/ \_____\/ \_____\/ \_____\/ \__\/ \__\/ \_____\/       \__\/    \_____\/ 
                                                                                                ");

            Thread.Sleep(sleepTime);
            ForegroundColor = ConsoleColor.Cyan;
            BackgroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine(StringToFullNameAndImage("ROCK"));
            Thread.Sleep(sleepTime);

            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine(StringToFullNameAndImage("PAPER"));
            Thread.Sleep(sleepTime);

            ForegroundColor = ConsoleColor.Cyan;
            BackgroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine("OR");
            Thread.Sleep(sleepTime);

            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine(StringToFullNameAndImage("SCISSORS"));
            Thread.Sleep(sleepTime);

            ForegroundColor = ConsoleColor.Cyan;
            BackgroundColor = ConsoleColor.DarkMagenta;
            Clear();
            //HELL MODE in ASCII
            WriteLine(@" ___   ___   ______   __       __           ___ __ __   ______   ______   ______      
/__/\ /__/\ /_____/\ /_/\     /_/\         /__//_//_/\ /_____/\ /_____/\ /_____/\     
\::\ \\  \ \\::::_\/_\:\ \    \:\ \        \::\| \| \ \\:::_ \ \\:::_ \ \\::::_\/_    
 \::\/_\ .\ \\:\/___/\\:\ \    \:\ \        \:.      \ \\:\ \ \ \\:\ \ \ \\:\/___/\   
  \:: ___::\ \\::___\/_\:\ \____\:\ \____    \:.\-/\  \ \\:\ \ \ \\:\ \ \ \\::___\/_  
   \: \ \\::\ \\:\____/\\:\/___/\\:\/___/\    \. \  \  \ \\:\_\ \ \\:\/.:| |\:\____/\ 
    \__\/ \::\/ \_____\/ \_____\/ \_____\/     \__\/ \__\/ \_____\/ \____/_/ \_____\/ 
                                                                                      ");
            Thread.Sleep(sleepTime + 1000);

            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Clear();
        }
        public void RandomRoll()
        {
            Random computer = new Random();
            computerChoiceInt = computer.Next(1, 4);
            computerChoiceString = TranslateToString(computerChoiceInt);
        }
        public static string StringToFullNameAndImage(string choice)
        {
            string rock = @"rock   
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)";
            string paper = @"paper
    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)";
            string scissors = @"scissors
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)";
            switch (choice)
            {

                case "ROCK":
                    return rock;
                case "PAPER":
                    return paper;
                case "SCISSORS":
                    return scissors;
                default:
                    return "Something went wrong...";
            }
        }
        public static string TranslateToString(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "ROCK";
                case 2:
                    return "PAPER";
                case 3:
                    return "SCISSORS";
                default:
                    return "Something went wrong...";
            }
        }
        public void Win()
        {
            WriteLine("\nYou win!");
            userScore++;
            
        }
        public void Lose()
        {
            WriteLine("\nYou lost!");
            computerScore++;
        }
        public void Tie()
        {
            WriteLine("\nIt's a tie!"); 
        }
        public void PlayAgain()
        {
            //prompt to play again
            WriteLine("\nPlay another game?");
            string answer = ReadLine().Trim().ToUpper();
            if (answer == "YES")
            {
                Game newGamePlus = new Game();
                newGamePlus.Play();
            }
            else
            {
                string grammarWonGames;
                string grammarLostGames;
                if (timesWon == 1){ grammarWonGames = "game"; }
                else { grammarWonGames = "games"; }
                if (timesLost == 1){ grammarLostGames = "game"; }
                else { grammarLostGames = "games"; }
                WriteLine($"Understandable, thank you for playing. You won {timesWon} {grammarWonGames} and lost {timesLost} {grammarLostGames}.");
                Thread.Sleep(3000);
            }
        }
        public void EasyRules()
        {
            if (userChoice == "ROCK")
            {
                computerChoiceString = "SCISSORS";
            }
            else if (userChoice == "PAPER")
            {
                computerChoiceString = "ROCK";
            }
            else if (userChoice == "SCISSORS")
            {
                computerChoiceString = "PAPER";
            }
        }
        public void HellRules()
        {
            if (userChoice == "ROCK")
            {
                computerChoiceString = "PAPER";
            }
            else if (userChoice == "PAPER")
            {
                computerChoiceString = "SCISSORS";
            }
            else if (userChoice == "SCISSORS")
            {
                computerChoiceString = "ROCK";
            }
        }
        public void HandsAndRules()
        {
            //ForegroundColor = ConsoleColor.Cyan;
            //BackgroundColor = ConsoleColor.DarkMagenta;
            //Clear();
            WriteLine($"\nYou chose {StringToFullNameAndImage(userChoice)}");
            WriteLine("\n\nand the computer chose ");
            //Thread.Sleep(3000);

            //BackgroundColor = ConsoleColor.Cyan;
            //ForegroundColor = ConsoleColor.DarkMagenta;
            //Clear();
            WriteLine($"\n{StringToFullNameAndImage(computerChoiceString)}");
            //Thread.Sleep(1000);
            //Clear();
            //WriteLine($"\n{StringToFullNameAndImage(userChoice)}\n{StringToFullNameAndImage(computerChoiceString)}");
            if (userChoice == "ROCK" && computerChoiceString == "SCISSORS" || userChoice == "SCISSORS" && computerChoiceString == "PAPER" || userChoice == "PAPER" && computerChoiceString == "ROCK")
            {
                Win();
            }
            else if (userChoice == computerChoiceString)
            {
                Tie();
            }
            else
            {
                Lose();
            }            
        }
        public void HandsAndCinematicRules()
        {
            ForegroundColor = ConsoleColor.Cyan;
            BackgroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine($"\nYou chose {StringToFullNameAndImage(userChoice)}");
            WriteLine("\n\nand the computer chose ");
            Thread.Sleep(3000);

            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Clear();
            WriteLine($"\n{StringToFullNameAndImage(computerChoiceString)}");
            Thread.Sleep(1000);
            Clear();
            WriteLine($"\n{StringToFullNameAndImage(userChoice)}\n{StringToFullNameAndImage(computerChoiceString)}");
            if (userChoice == "ROCK" && computerChoiceString == "SCISSORS" || userChoice == "SCISSORS" && computerChoiceString == "PAPER" || userChoice == "PAPER" && computerChoiceString == "ROCK")
            {
                Win();
            }
            else if (userChoice == computerChoiceString)
            {
                Tie();
            }
            else
            {
                Lose();
            }
        }
    }
}
