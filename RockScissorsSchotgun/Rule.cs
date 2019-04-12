namespace RockScissorsSchotgun
{
    //a single rule class
    public class Rule
    {
        public readonly Item Winner;
        public readonly Item Loser;
        public readonly string WinnerPhrase;

        public Rule(Item winner, string winnerPhrase, Item loser)
        {
            this.Winner = winner;
            this.Loser = loser;
            this.WinnerPhrase = winnerPhrase;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Winner, WinnerPhrase, Loser);
        }
    }
}