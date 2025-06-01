using UnityEngine;
using Naninovel;

[CommandAlias("takeItem")]
public class InteractiveItem : Command
{
    [SerializeField] private string itemName = "����";

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        if (variableManager == null)
        {
            Debug.LogError("�� ������� �������� ���������� Naninovel.");
            return UniTask.CompletedTask;
        }

        variableManager.SetVariableValue($"Item_{itemName}", "Taken");

        QuestSystem.Instance?.UpdateMainQuestLog($"������� �������: {itemName}");

        Debug.Log($"{itemName} ���� �������.");

        return UniTask.CompletedTask;
    }
}