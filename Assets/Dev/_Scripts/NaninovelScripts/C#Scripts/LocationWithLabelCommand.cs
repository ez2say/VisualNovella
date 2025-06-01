using Naninovel;
using UnityEngine;

[CommandAlias("goToLocationWithLabel")]
public class GoToLocationWithLabelCommand : Command
{
    [Tooltip("Имя скрипта без .nani")]
    public string LocationName;

    [Tooltip("Метка внутри скрипта (опционально)")]
    public string LabelName;

    public override async UniTask ExecuteAsync(AsyncToken token = default)
    {
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        if (scriptPlayer == null)
        {
            Debug.LogError("IScriptPlayer не найден!");
            return;
        }

        await scriptPlayer.PreloadAndPlayAsync(LocationName, label: LabelName);
    }
}