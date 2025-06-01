using System;
using UnityEngine;

public class WinHandler : IWin
{
    private readonly int _pairsToMatch;
    private int _matchedPairs;
    private readonly Action _onWinCallback;

    public WinHandler(int pairsToMatch, Action onWinCallback)
    {
        _pairsToMatch = pairsToMatch;
        _onWinCallback = onWinCallback;
    }

    public void OnPairMatched()
    {
        _matchedPairs++;
        if (_matchedPairs >= _pairsToMatch)
        {
            _onWinCallback?.Invoke();
        }
    }
}