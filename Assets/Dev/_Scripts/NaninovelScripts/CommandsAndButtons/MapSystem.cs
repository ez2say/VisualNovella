using UnityEngine;
using UnityEngine.UI;
using Naninovel;
using TMPro;

public class MapSystem : MonoBehaviour
{
    public static MapSystem Instance;
    public string MAPBLOCK = "MapBlock";
    
    [SerializeField] private GameObject mapPanel;
    
    private bool _isActive;
    private bool _isBlocked;
    
    private ICustomVariableManager _variableManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        _variableManager = Engine.GetService<ICustomVariableManager>();

    }


    private void Update()
    {
        string currentValue = _variableManager.GetVariableValue(MAPBLOCK);
        _isBlocked = currentValue != null && currentValue.ToLower() == "true";
    }

    public void Click()
    {

        if (_isBlocked) return;
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

    public void HideMap()
    {
        _isActive = false;
        mapPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}