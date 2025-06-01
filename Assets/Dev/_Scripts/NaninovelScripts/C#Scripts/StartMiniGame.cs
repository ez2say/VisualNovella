using Naninovel;
using UnityEngine;

[CommandAlias("startMiniGame")]
public class StartMiniGameCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (MiniGameSystem.Instance == null)
        {
            Debug.LogError("MiniGameSystem �� ������ �� �����!");
            return UniTask.CompletedTask;
        }

        MiniGameSystem.Instance.StartGame();
        return UniTask.CompletedTask;
    }
}