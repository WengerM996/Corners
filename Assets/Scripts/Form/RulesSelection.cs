using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RulesSelection : MonoBehaviour
{
    [SerializeField] private TMP_Text _viewTitle;
    [SerializeField] private List<Toggle> _toggles;
    
    public event UnityAction Selected;

    private void Start()
    {
        JumpsRules.AvailableMovements.Clear();
        JumpsRules.AvailableJumpsDirections.Clear();
    }

    public void ChangeXYJumps(bool value)
    {
        JumpsRules.XYJumps = value;
    }
    
    public void ChangeDiagonalJumps(bool value)
    {
        JumpsRules.DiagonalJumps = value;
    }

    public void ChangeMovement(bool value)
    {
        JumpsRules.Movement = value;
    }

    public void OnConfirmButtonClick()
    {
        if (ExistSelected())
            Selected?.Invoke();
        else
            _viewTitle.text = "Select rules:\n(at least one selected required)";
    }

    private bool ExistSelected()
    {
        foreach (var toggle in _toggles)
        {
            if (toggle.isOn) return true;
        }

        return false;
    }
}
