using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Player _player1;
    [SerializeField] private Player _player2;

    private bool _pvp;
    
    public bool PVP { get; set; }

    public Player Player1
    {
        get => _player1;
        set => _player1 = value;
    }

    public Player Player2
    {
        get => _player2;
        set => _player2 = value;
    }
}
