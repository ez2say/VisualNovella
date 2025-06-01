using Naninovel;
using UnityEngine;

[CommandAlias("updateQuestLog")]
public class UpdateQuestLogCommand : Command
{
    [SerializeField] private string description;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (QuestSystem.Instance == null)
        {
            Debug.LogError("QuestSystem не найден!");
            return UniTask.CompletedTask;
        }

        QuestSystem.Instance.UpdateMainQuestLog(description);
        return UniTask.CompletedTask;
    }
}