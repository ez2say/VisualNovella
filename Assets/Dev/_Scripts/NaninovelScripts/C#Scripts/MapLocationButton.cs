using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class MapLocationButton : MonoBehaviour
{
    [Tooltip("Имя скрипта без .nani")]
    public string LocationName;

    [Tooltip("Основная метка для запуска (оставьте пустым, чтобы начать с начала)")]
    public string DefaultLabel = null;

    [Tooltip("Название переменной для проверки условия")]
    public string ConditionVariableName = "";

    [Tooltip("Значение переменной, при котором будет использоваться альтернативная метка")]
    public string ConditionVariableValue = "True";

    [Tooltip("Альтернативная метка для запуска при выполнении условия")]
    public string AlternativeLabel = "afterQuestUpdate";

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private async void OnButtonClick()
    {
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        if (scriptPlayer == null) return;

        string labelToUse = DefaultLabel;

        // Если указано условие — проверяем его
        if (!string.IsNullOrEmpty(ConditionVariableName))
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            string value = variableManager.GetVariableValue(ConditionVariableName);

            if (value == ConditionVariableValue)
                labelToUse = AlternativeLabel;
        }

        await scriptPlayer.PreloadAndPlayAsync(LocationName, label: labelToUse);
    }
}