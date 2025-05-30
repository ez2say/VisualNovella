public class PairChecker : IPairChecker
{
    public bool IsMatch(ICard card1, ICard card2)
    {
        if (card1 == null || card2 == null)
            return false;

        return card1.PairID == card2.PairID;
    }
}