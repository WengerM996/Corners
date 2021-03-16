using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private List<Player> _orderOfPlayers;

    public event UnityAction Switched;

    private bool _switcher;

    public List<Player> OrderOfPlayers
    {
        get => _orderOfPlayers;
        set => _orderOfPlayers = value;
    }


    private void OnEnable()
    {
        Dragging.Moved += OnMoved;
        WinChecker.Win += OnGameOver;
    }

    private void OnDisable()
    {
        Dragging.Moved -= OnMoved;
        WinChecker.Win -= OnGameOver;
    }

    private void Start()
    {
        _switcher = true;
        _orderOfPlayers[0].Moving = true;
    }

    private void OnMoved()
    {
        StopAll();
        
        if (_switcher == false) return;
        
        var currentPlayer = _orderOfPlayers[0];
        _orderOfPlayers.Remove(currentPlayer);
        _orderOfPlayers.Add(currentPlayer);

        _orderOfPlayers[0].Moving = true;
        
        Switched?.Invoke();
    }

    private void StopAll()
    {
        foreach (var player in _orderOfPlayers)
        {
            player.Moving = false;
        }
    }

    private void OnGameOver(string text)
    {
        _switcher = false;
    }
}
