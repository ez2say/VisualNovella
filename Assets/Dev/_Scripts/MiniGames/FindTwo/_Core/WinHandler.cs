using System;
using UnityEngine;

public class WinHandler: IWin
{
    private readonly int _totalPairs;
    private readonly Transform _cardsParent;

    public event Action OnWin;

    private int _matchedPairs;

    public WinHandler(int totalPairs, Transform cardsParent)
    {
        _totalPairs = totalPairs;
        _cardsParent = cardsParent;
    }

    public void OnPairMatched()
    {
        _matchedPairs++;

        if (_matchedPairs == _totalPairs)
        {
            OnWin?.Invoke();
            OnAllPairsMatched();
        }
    }

    private void OnAllPairsMatched()
    => _cardsParent.gameObject.SetActive(false);
}