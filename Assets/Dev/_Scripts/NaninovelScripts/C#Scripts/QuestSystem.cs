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
            DontDestroyOnLoad(gameObject); // ���� ����� ��������� ����� �������
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
            Debug.LogError("ICustomVariableManager �� ������!");
            return;
        }

        manager.SetVariableValue("Quest_Main", "InProgress");
        UpdateMainQuestLog("� ��������");
        Debug.Log("����� �����");
    }

    public void CompleteMainQuest()
    {
        var manager = GetVariableManager();
        if (manager == null)
        {
            Debug.LogError("ICustomVariableManager �� ������!");
            return;
        }

        manager.SetVariableValue("Quest_Main", "Completed");
        UpdateMainQuestLog("��������");
        Debug.Log("����� ��������");
    }

    public void UpdateMainQuestLog(string description)
    {
        var manager = GetVariableManager();
        if (manager == null) return;

        string log = manager.GetVariableValue("QuestLog") + $"\n������� �����: {description}";
        manager.SetVariableValue("QuestLog", log);
    }
}