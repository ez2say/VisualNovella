using System;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class MiniGameSystem : MonoBehaviour
{
    public static MiniGameSystem Instance { get; private set; }

    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _cardsParent;

    private ICardFactory _cardFactory;
    private IPairChecker _pairChecker;
    private IGameLogic _gameLogic;
    private ICardSpawner _cardSpawner;
    private IWin _winHandler;
    private List<ICard> _cards = new List<ICard>();
    private bool _isGameActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _cardsParent.gameObject.SetActive(false);
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        if (_isGameActive) return;

        _isGameActive = true;

        _cardsParent.gameObject.SetActive(true);
        Engine.GetService<IScriptPlayer>().Stop();

        Initialize();
    }

    private void ClearCards()
    {
        foreach (var card in _cards)
        {
            if (card != null)
                card.Destroy();
        }
        _cards.Clear();
    }

    private void HandleCardSelected(ICard card) => _gameLogic?.SelectCard(card);

    private void Initialize()
    {
        ClearCards();

        if (_gameConfig.FrontSides.Count < _gameConfig.PairsCount)
        {
            Debug.LogError("Не хватает спрайтов для всех пар");
            return;
        }

        _cardFactory = new CardFactory(_gameConfig.CardPrefab, _cardsParent);
        _cardSpawner = new CardSpawner(_cardFactory, _gameConfig, HandleCardSelected);

        _cardSpawner.SpawnCards();
        _cards = _cardSpawner.GetCards();

        _pairChecker = new PairChecker();
        _winHandler = new WinHandler(_gameConfig.PairsCount, WinGame);
        _gameLogic = new MiniGameLogic(_pairChecker, _winHandler.OnPairMatched, () => { });
    }

    private void WinGame()
    {
        
        _cardsParent.gameObject.SetActive(false);

        Engine.GetService<IScriptPlayer>().Play();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            ClearCards();
            Instance = null;
        }
    }
}