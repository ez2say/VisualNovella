using Naninovel;
using UnityEngine;

[CommandAlias("goToLocationWithLabel")]
public class GoToLocationWithLabelCommand : Command
{
    [Tooltip("��� ������� ��� .nani")]
    public string LocationName;

    [Tooltip("����� ������ ������� (�����������)")]
    public string LabelName;

    public override async UniTask ExecuteAsync(AsyncToken token = default)
    {
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        if (scriptPlayer == null)
        {
            Debug.LogError("IScriptPlayer �� ������!");
            return;
        }

        await scriptPlayer.PreloadAndPlayAsync(LocationName, label: LabelName);
    }
}