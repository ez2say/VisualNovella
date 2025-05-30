using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    public GameObject CardPrefab => cardPrefab;
    public int PairsCount => pairsCount;
    public List<Sprite> FrontSides => frontSides;

    [Header("Game Settings")]
    [SerializeField] private GameObject cardPrefab;
    

    [SerializeField] private int pairsCount = 4;
    [SerializeField] private List<Sprite> frontSides = new List<Sprite>();

}