using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private string currentQuest = "Нет активного квеста";

    public void StartQuest(string questDescription)
    {
        currentQuest = questDescription;
        Debug.Log($"[Квест] Запущен: {questDescription}");
        // Здесь можно обновить UI квест-лога
    }

    public void UpdateQuest(string newDescription)
    {
        currentQuest = newDescription;
        Debug.Log($"[Квест] Обновлён: {newDescription}");
    }
}