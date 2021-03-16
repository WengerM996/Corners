using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WinForm : MonoBehaviour
{
    [SerializeField] private TMP_Text _viewTitle;
    
    public event UnityAction ExitClicked;

    public void OnButtonClick()
    {
        ExitClicked?.Invoke();
    }

    public void SetTitle(string text)
    {
        _viewTitle.text = text;
    }
}
