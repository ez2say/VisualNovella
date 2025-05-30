using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICard
{
    void ShowBack();
    void ShowFront();
    void Lock();
    int PairID { get; }
    void SetData(int pairID, Sprite frontSprite);

    event Action<ICard> OnCardSelected;
}