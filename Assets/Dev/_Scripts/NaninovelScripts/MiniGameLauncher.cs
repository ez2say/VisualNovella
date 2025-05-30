using UnityEngine;

public class MiniGameLauncher : MonoBehaviour
{
    [SerializeField] private GameObject miniGamePrefab; // Префаб с MiniGameSystem
    private MiniGameSystem _miniGameInstance;

    public void RunMiniGame()
    {
        _miniGameInstance = miniGamePrefab.GetComponent<MiniGameSystem>();
        _miniGameInstance.StartGame();
    }
}