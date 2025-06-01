using UnityEngine;
using Naninovel;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance { get; private set; }

    private ICustomVariableManager variableManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Если нужно сохранять между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private ICustomVariableManager GetVariableManager()
    {
        if (variableManager == null)
            variableManager = Engine.GetService<ICustomVariableManager>();

        return variableManager;
    }

    public void StartMainQuest()
    {
        var manager = GetVariableManager();
        if (manager == null)
        {
            Debug.LogError("ICustomVariableManager не найден!");
            return;
        }

        manager.SetVariableValue("Quest_Main", "InProgress");
        UpdateMainQuestLog("В процессе");
        Debug.Log("Квест начат");
    }

    public void CompleteMainQuest()
    {
        var manager = GetVariableManager();
        if (manager == null)
        {
            Debug.LogError("ICustomVariableManager не найден!");
            return;
        }

        manager.SetVariableValue("Quest_Main", "Completed");
        UpdateMainQuestLog("Завершён");
        Debug.Log("Квест завершён");
    }

    public void UpdateMainQuestLog(string description)
    {
        var manager = GetVariableManager();
        if (manager == null) return;

        string log = manager.GetVariableValue("QuestLog") + $"\nГлавный квест: {description}";
        manager.SetVariableValue("QuestLog", log);
    }
}