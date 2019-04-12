using System.Collections.Generic;

namespace RockScissorsSchotgun
{
    public static class GameRules
    {
        //old game type selection idea
        /*
        public static readonly List<Rule> ClassicRules = new List<Rule>
        {
            new Rule(Item.Rock, "crushes", Item.Scissors),
            new Rule(Item.Paper, "covers", Item.Rock),
            new Rule(Item.Scissors, "cut", Item.Paper)
        };
        */
        public static readonly List<Rule> AdvancedRules = new List<Rule>
        {
            new Rule(Item.Rock, "crushes", Item.Scissors),
            new Rule(Item.Spock, "vaporizes", Item.Rock),
            new Rule(Item.Paper, "disproves", Item.Spock),
            new Rule(Item.Lizard, "eats", Item.Paper),
            new Rule(Item.Scissors, "decapitate", Item.Lizard),
            new Rule(Item.Spock, "smashes", Item.Scissors),
            new Rule(Item.Lizard, "poisons", Item.Spock),
            new Rule(Item.Rock, "crushes", Item.Lizard),
            new Rule(Item.Paper, "covers", Item.Rock),
            new Rule(Item.Scissors, "cut", Item.Paper)
        };
    }
}