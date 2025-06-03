using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class MapLocationButton : MonoBehaviour
{
    public string LocationName;
    public string _blocker = "Location3Lock";

    private bool _isBlocked;

    private IScriptPlayer _player;
    private ICustomVariableManager _variableManager;

    private Button _button;

    private void Start()
    {
        GetService();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);

    }

    private void GetService()
    {
        _player = Engine.GetService<IScriptPlayer>();
        _variableManager = Engine.GetService<ICustomVariableManager>();
    }

    private async void OnButtonClick()
    {

        if (_player == null) return;

        UpdateState();
        if (!_isBlocked)
        {
            await _player.PreloadAndPlayAsync(LocationName);
        }
    }

    private void UpdateState()
    {
        string currentValue = _variableManager.GetVariableValue(_blocker);
        _isBlocked = currentValue != null && currentValue.ToLower() == "true";
    }
}