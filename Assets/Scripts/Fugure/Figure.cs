using System;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    public Cell Cell
    {
        get => _cell;
        set => _cell = value;
    }

    public Player Player => _player;
}
