using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NamesEditor : MonoBehaviour
{
    [SerializeField] private TMP_Text _player1Name;
    [SerializeField] private TMP_Text _player2Name;
    
    [SerializeField] private TMP_Text _player1PlaceHolder;
    [SerializeField] private TMP_Text _player2PlaceHolder;

    public bool PVP { get; set; }

    public event UnityAction<string, string, bool> Entered;

    public void SetPlaceHolders(string placeHolder1, string placeHolder2)
    {
        _player1PlaceHolder.text = placeHolder1;
        _player2PlaceHolder.text = placeHolder2;
    }

    public void OnDoneButtonClick()
    {
        Entered?.Invoke(_player1Name.text, _player2Name.text, PVP);
    }
}
