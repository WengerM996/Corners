using UnityEngine;

public class IconSwitcher : MonoBehaviour
{
    [SerializeField] private Field _fieldTemplate;
    [SerializeField] private Mode _modeSelectionForm;
    [SerializeField] private NamesEditor _namesEditorForm;
    [SerializeField] private RulesSelection _rulesSelectionForm;
    [SerializeField] private WinForm _winFormTemplate;

    private Mode _mode;
    private NamesEditor _namesEditor;
    private Field _field;
    private RulesSelection _rulesSelection;
    private WinForm _winForm;


    private void OnEnable()
    {
        WinChecker.Win += OnGameOver;
    }

    private void OnDisable()
    {
        WinChecker.Win -= OnGameOver;
    }

    private void Start()
    {
        if (_mode != null) return;
        
        _mode = Instantiate(_modeSelectionForm, transform);
        
        _mode.PVPSelected += OnPVPSelected;
        _mode.AISelected += OnAISelected;
    }

    private void OnPVPSelected()
    {
        _mode.PVPSelected -= OnPVPSelected;
        Destroy(_mode.gameObject);

        if (_namesEditor != null) return;

        _namesEditor = Instantiate(_namesEditorForm, transform);
        _namesEditor.SetPlaceHolders("Player 1", "Player 2");
        _namesEditor.PVP = true;
        _namesEditor.Entered += OnNamesEntered;
    }

    private void OnAISelected()
    {
        _mode.AISelected -= OnAISelected;
        Destroy(_mode.gameObject);
        
        if (_namesEditor != null) return;

        _namesEditor = Instantiate(_namesEditorForm, transform);
        _namesEditor.SetPlaceHolders("Player", "AI");
        _namesEditor.PVP = false;
        // TODO: imp AI
    }

    private void OnNamesEntered(string name1, string name2, bool pvp)
    {
        _namesEditor.Entered -= OnNamesEntered;
        Destroy(_namesEditor.gameObject);
        
        if (_rulesSelection != null) return;

        _rulesSelection = Instantiate(_rulesSelectionForm, transform);
        _rulesSelection.Selected += OnRulesSelected;
        
        if (_field != null) return;

        _field = Instantiate(_fieldTemplate, transform);
        _field.Player1.Name = name1;
        _field.Player2.Name = name2;
        _field.PVP = pvp;
        _field.gameObject.SetActive(false);
    }

    private void OnRulesSelected()
    {
        _rulesSelection.Selected -= OnRulesSelected;
        Destroy(_rulesSelection.gameObject);
        
        _field.gameObject.SetActive(true);
    }

    private void OnGameOver(string playerName)
    {
        if (_winForm != null) return;

        _winForm = Instantiate(_winFormTemplate, transform);
        _winForm.SetTitle("Player " + playerName + " win !");
        _winForm.ExitClicked += OnExitWinForm;
    }

    private void OnExitWinForm()
    {
        _winForm.ExitClicked -= OnExitWinForm;
        Destroy(_winForm.gameObject);
        Destroy(_field.gameObject);
        
        Start();
    }
}
