using System.Collections.Generic;
using UnityEngine;

public class MiniGameSystem : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _cardsParent;

    private ICardFactory _cardFactory;
    private IPairChecker _pairChecker;
    private IGameLogic _gameLogic;
    private ICardSpawner _cardSpawner;
    private IWin _winHandler;

    private List<ICard> _cards = new List<ICard>();

    private void Start() => Initialize();
    private void HandleCardSelected(ICard card) => _gameLogic.SelectCard(card);

    private void Initialize()
    {
        if (_gameConfig.FrontSides.Count < _gameConfig.PairsCount)
        {
            Debug.LogError("Не хватает спрайтов для всех пар, 1 пара - 1 уникальный спрайт в списке в конфиге");
            return;
        }

        _cardFactory = new CardFactory(_gameConfig.CardPrefab, _cardsParent);
        _cardSpawner = new CardSpawner(_cardFactory, _gameConfig, HandleCardSelected);

        _cardSpawner.SpawnCards();
        _cards = _cardSpawner.GetCards();

        _pairChecker = new PairChecker();

        _winHandler = new WinHandler(_gameConfig.PairsCount, _cardsParent);
        _gameLogic = new MiniGameLogic(_pairChecker, _winHandler.OnPairMatched, () => { });
    }

}
   

    