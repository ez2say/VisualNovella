using Naninovel;
using UnityEngine;

[CommandAlias("completeQuest")]
public class CompleteQuestCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (QuestSystem.Instance == null)
        {
            Debug.LogError("QuestSystem не найден!");
            return UniTask.CompletedTask;
        }

        QuestSystem.Instance.CompleteMainQuest();
        return UniTask.CompletedTask;
    }
}