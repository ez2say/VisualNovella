using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private string currentQuest = "��� ��������� ������";

    public void StartQuest(string questDescription)
    {
        currentQuest = questDescription;
        Debug.Log($"[�����] �������: {questDescription}");
        // ����� ����� �������� UI �����-����
    }

    public void UpdateQuest(string newDescription)
    {
        currentQuest = newDescription;
        Debug.Log($"[�����] �������: {newDescription}");
    }
}