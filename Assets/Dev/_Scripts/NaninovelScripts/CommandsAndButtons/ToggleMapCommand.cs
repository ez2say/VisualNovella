using Naninovel;
using UnityEngine;

[CommandAlias("toggleMap")]
public class ToggleMapCommand : Command
{

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (MapSystem.Instance == null)
        {
            Debug.LogError("mapSystem �� ������ �� �����!");
            return UniTask.CompletedTask;
        }

        MapSystem.Instance.HideMap();
        return UniTask.CompletedTask;
    }
}