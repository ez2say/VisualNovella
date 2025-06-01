using Naninovel;
using UnityEngine;

[CommandAlias("startQuest")]
public class StartQuestCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (QuestSystem.Instance == null)
        {
            Debug.LogError("QuestSystem �� ������!");
            return UniTask.CompletedTask;
        }

        QuestSystem.Instance.StartMainQuest();
        return UniTask.CompletedTask;
    }
}