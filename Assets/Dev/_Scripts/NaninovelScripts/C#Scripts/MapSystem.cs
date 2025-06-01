using UnityEngine;
using UnityEngine.UI;

public class MapSystem : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;
    private bool _isActive;

    public void Click()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            ShowMap();
        }
        else
        {
            HideMap();
        }
    }

    private void ShowMap()
    {
        mapPanel.SetActive(true);
    }

    private void HideMap()
    {
        mapPanel.SetActive(false);
    }
}