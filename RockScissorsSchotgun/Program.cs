using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace RockScissorsSchotgun
{
    internal static class Program
    {
        static int gameType = 0; //rules switcher
        
        public static void Main()
        {
            //scores varibles
            var winCount = 0;
            var loseCount = 0;
            var gamesCount = 0;
            
            SelectRules(); //call selection of the game's type
            
            while (true)
            {
                var aiItem = Item.Null; //oppenent item
                var playerItem = Item.Null; //player item
                
                //3 items game
                if (gameType == 1)
                {
                    Console.WriteLine("Chose your item\n1 - {0}\n2 - {1}\n3 - {2}",Item.Rock, Item.Paper, Item.Scissors);
                    aiItem = SelectItem(new Random().Next(1,3).ToString()); //opponent selecting item
                }

                //5 items game
                else 
                {
                    Console.WriteLine("Chose your item\n1 - {0}\n2 - {1}\n3 - {2}\n4 - {3}\n5 - {4}",Item.Rock, Item.Paper, Item.Scissors, Item.Lizard, Item.Spock);
                    aiItem = SelectItem(new Random().Next(1,5).ToString());
                }
                
                //player item selection
                while (playerItem == Item.Null)
                {
                    playerItem = SelectItem(InputCommand());
                }
                
                Console.Clear();
                Console.WriteLine("Player item is {0}, Opponent item is {1}",playerItem,aiItem);
                Console.WriteLine(Decision.Decide(playerItem, aiItem));

                gamesCount++;
                
                //not realy a good idea to get win/lose info via double check list of rules again.
                if (Decision.Decide(playerItem, aiItem).GetWinnerInfo() == true)
                {
                    winCount++;
                }
                else if (Decision.Decide(playerItem, aiItem).GetWinnerInfo() == false)
                {
                    loseCount++;
                }
                
                Console.WriteLine("You won {0} times. Opponent won {1} times. Total games played {2}", winCount, loseCount, gamesCount);
                Console.WriteLine("Play one more game? Y/N\n'YES' is default selection");
                var input = InputCommand();
                switch (input)
                {
                    case "Y":
                        break;
                    case "N":
                        return; //exit game
                    default:
                        Console.WriteLine("Unknow command, assuming you selected YES");
                        break;
                }
                Console.Clear();
                Console.WriteLine("Change rules? Y/N");
                input = InputCommand();
                switch (input)
                {
                    case "Y":
                        SelectRules();
                        break;
                    case "N":
                        break;
                    default:
                        Console.WriteLine("Unknow command, assuming you are selected NO");
                        break;
                }
                Console.Clear();
            }
        }

        private static Item SelectItem(string input)
        {
            switch (input)
            {
                case "1":
                    return Item.Rock;
                case "2":
                    return Item.Paper;
                case "3":
                    return Item.Scissors;
                case "4":
                    if (gameType > 1)
                    {
                        return Item.Lizard;
                    }
                    Console.WriteLine("Unknow command, try again");
                    return Item.Null;
                case "5":
                    if (gameType > 1)
                    {
                        return Item.Spock;
                    }
                    Console.WriteLine("Unknow command, try again");
                    return Item.Null;
                default:
                    Console.WriteLine("Unknow command, try again");
                    return Item.Null;
            }
        }

        private static void SelectRules()
        {
            var hasRuleSelected = false;
            while (!hasRuleSelected)
            {
                Console.WriteLine("Please select rules\n1 - classic rules (Rock Paper Scissors)\n2 - advanced rules (Rock Paper Scissors Lizzard Spock)");
                var input = InputCommand();
                switch(input)
                {
                    case "1":
                        //Decision.Rules = GameRules.ClassicRules;
                        hasRuleSelected = true;
                        gameType = 1;    //here is actual game selection trigger. Old idea was to split Lists of game rules
                                         //maybe it's easier just to have only one full rules set and limit item selection
                                         //to classic (3 items, last 2 is unreacheble) or advanced (5 items) set
                        break;
                    case "2":
                        //Decision.Rules = GameRules.AdvancedRules;
                        hasRuleSelected = true;
                        gameType = 2;
                        break;
                    default:
                        Console.WriteLine("Wrong selection. Please try again");
                        hasRuleSelected = false;
                        break;
                }
                Decision.Rules = GameRules.AdvancedRules;
            }
        }

        //keyboard read
        private static string InputCommand()
        {
            var input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("Entered empty key, try again");
                input = Console.ReadLine();
            }
            return input.ToUpper();
        }
    }
}