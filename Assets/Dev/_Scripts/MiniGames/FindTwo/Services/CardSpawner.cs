using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardSpawner : ICardSpawner
{
    private readonly ICardFactory _cardFactory;
    private readonly GameConfig _gameConfig;
    private readonly Action<ICard> _onCardSelected;
    private readonly Transform _parent;

    private List<ICard> _cards = new List<ICard>();

    public CardSpawner(ICardFactory cardFactory, GameConfig gameConfig, Action<ICard> onCardSelected,Transform parent)
    {
        _cardFactory = cardFactory;
        _gameConfig = gameConfig;
        _onCardSelected = onCardSelected;
        _parent = parent;
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

        Shuffle(_cards);
        foreach (var card in _cards)
        {
            if (card is MonoBehaviour monoCard)
                monoCard.transform.SetParent(_parent, false);
        }
    }

    private void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }

    public List<ICard> GetCards() => _cards;
}