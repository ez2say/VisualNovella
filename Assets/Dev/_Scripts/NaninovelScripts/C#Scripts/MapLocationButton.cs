using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class MapLocationButton : MonoBehaviour
{
    [Tooltip("��� ������� ��� .nani")]
    public string LocationName;

    [Tooltip("�������� ����� ��� ������� (�������� ������, ����� ������ � ������)")]
    public string DefaultLabel = null;

    [Tooltip("�������� ���������� ��� �������� �������")]
    public string ConditionVariableName = "";

    [Tooltip("�������� ����������, ��� ������� ����� �������������� �������������� �����")]
    public string ConditionVariableValue = "True";

    [Tooltip("�������������� ����� ��� ������� ��� ���������� �������")]
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

        // ���� ������� ������� � ��������� ���
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