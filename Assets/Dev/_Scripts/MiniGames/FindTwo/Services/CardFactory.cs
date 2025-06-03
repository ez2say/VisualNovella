using System;
using UnityEngine;

public class CardFactory : ICardFactory
{
    private readonly GameObject _cardPrefab;
    private readonly Transform _parent;

    public CardFactory(GameObject cardPrefab)
    {
        _cardPrefab = cardPrefab;
    }

    public ICard CreateCard()
    {
        GameObject instance = GameObject.Instantiate(_cardPrefab);

        return instance.GetComponent<ICard>();
    }
}