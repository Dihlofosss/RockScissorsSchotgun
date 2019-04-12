using System.Collections.Generic;
using System.Linq;

namespace RockScissorsSchotgun
{
    public class Decision
    {
        private bool? _hasPlayerWon;
        private Rule _winningRule;

        //list of rules could be hardcoded here instead of assigment in Program.cs in SelectRules()
        public static List<Rule> Rules;

        //Constructor
        private Decision(bool? hasPlayerWon, Rule winningRule)
        {
            this._hasPlayerWon = hasPlayerWon;
            this._winningRule = winningRule;
        }
        
        //Win lose decide func
        public static Decision Decide(Item playerItem, Item aiItem)
        {
            var rule = FindWinningRule(playerItem, aiItem);
            if (rule != null)
            {
                return new Decision(true, rule);
            }

            rule = FindWinningRule(aiItem, playerItem);
            if (rule != null)
            {
                return new Decision(false, rule);
            }
            return new Decision(null, null);
        }
        
        //Rulefinder
        private static Rule FindWinningRule(Item player, Item ai)
        {
            return Rules.FirstOrDefault(rule => rule.Winner == player && rule.Loser == ai);
        }
        
        //WinLose getter
        public bool? GetWinnerInfo()
        {
            return _hasPlayerWon;
        }
        
        public override string ToString()
        {
            switch (_hasPlayerWon)
            {
                case null:
                    return "Tie!";
                case true:
                    return string.Format("{0}. You win!", _winningRule);
                default:
                    return string.Format("{0}. You lose!", _winningRule);
            }
        }
    }
}