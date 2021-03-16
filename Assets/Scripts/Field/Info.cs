using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private TMP_Text _viewPlayer1Name;
    [SerializeField] private TMP_Text _viewPlayer2Name;
    [SerializeField] private TMP_Text _viewPlayerTurn;

    [Header("Player 1")] [SerializeField] private Player _player1;
    [Header("Player 2")] [SerializeField] private Player _player2;

    [Header("Player Switcher")] [SerializeField] private PlayerSwitcher _playerSwitcher;

    private void OnEnable()
    {
        _playerSwitcher.Switched += OnPlayerSwitched;
    }

    private void OnDisable()
    {
        _playerSwitcher.Switched -= OnPlayerSwitched;
    }

    private void Start()
    {
        InitPlayers();
    }

    private void InitPlayers()
    {
        _viewPlayer1Name.text = _player1.Name;
        _viewPlayer2Name.text = _player2.Name;

        OnPlayerSwitched();
    }

    private void OnPlayerSwitched()
    {
        _viewPlayerTurn.text = "Player Turn:\n" + _playerSwitcher.OrderOfPlayers[0].Name;
    }
}
