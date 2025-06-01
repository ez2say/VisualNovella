using UnityEngine;
using Naninovel;

[CommandAlias("takeItem")]
public class InteractiveItem : Command
{
    [SerializeField] private string itemName = "ключ";

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        if (variableManager == null)
        {
            Debug.LogError("Не удалось получить переменные Naninovel.");
            return UniTask.CompletedTask;
        }

        variableManager.SetVariableValue($"Item_{itemName}", "Taken");

        QuestSystem.Instance?.UpdateMainQuestLog($"Получен предмет: {itemName}");

        Debug.Log($"{itemName} взят игроком.");

        return UniTask.CompletedTask;
    }
}