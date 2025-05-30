using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : ICardSpawner
{
    private readonly ICardFactory _cardFactory;
    private readonly GameConfig _gameConfig;
    private readonly Action<ICard> _onCardSelected;

    private List<ICard> _cards = new List<ICard>();

    public CardSpawner(ICardFactory cardFactory, GameConfig gameConfig, Action<ICard> onCardSelected)
    {
        _cardFactory = cardFactory;
        _gameConfig = gameConfig;
        _onCardSelected = onCardSelected;
    }

    public void SpawnCards()
    {
        for (int pairID = 0; pairID < _gameConfig.PairsCount; pairID++)
        {
            Sprite sprite = _gameConfig.FrontSides[pairID];

            for (int copy = 0; copy < 2; copy++)
            {
                ICard card = _cardFactory.CreateCard();
                card.SetData(pairID, sprite);
                card.OnCardSelected += _onCardSelected;
                card.ShowBack();

                _cards.Add(card);
            }
        }
    }

    public List<ICard> GetCards() => _cards;
}