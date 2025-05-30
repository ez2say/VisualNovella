using System;
using UnityEngine;

public class CardFactory : ICardFactory
{
    private readonly GameObject _cardPrefab;
    private readonly Transform _parent;

    public CardFactory(GameObject cardPrefab, Transform parent)
    {
        _cardPrefab = cardPrefab;
        _parent = parent;
    }

    public ICard CreateCard()
    {
        GameObject instance = GameObject.Instantiate(_cardPrefab, _parent);

        return instance.GetComponent<ICard>();
    }
}