using Naninovel;
using UnityEngine;

[CommandAlias("exitGame")]
public class ExitGameCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        return UniTask.CompletedTask;
    }
}