using DG.Tweening;
using System;
using System.Collections.Generic;

public class MiniGameLogic : IGameLogic
{
    private readonly IPairChecker _pairChecker;
    private readonly Action _onPairMatched;
    private readonly Action _onAllMatched;

    private List<ICard> _selectedCards = new List<ICard>();

    public MiniGameLogic(IPairChecker pairChecker, Action onPairMatched, Action onAllMatched)
    {
        _pairChecker = pairChecker;
        _onPairMatched = onPairMatched;
        _onAllMatched = onAllMatched;
    }

    public void SelectCard(ICard card)
    {
        if (_selectedCards.Contains(card) || _selectedCards.Count >= 2)
            return;

        _selectedCards.Add(card);

        if (_selectedCards.Count == 2)
        {
            CheckMatch();
        }
    }

    private void CheckMatch()
    {
        ICard first = _selectedCards[0];
        ICard second = _selectedCards[1];

        if (_pairChecker.IsMatch(first, second))
        {
            first.Lock();
            second.Lock();

            _onPairMatched?.Invoke();
        }
        else
        {
            DOVirtual.DelayedCall(0.7f, () =>
            {
                first.ShowBack();
                second.ShowBack();
            });
        }

        _selectedCards.Clear();
    }
}