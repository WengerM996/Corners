using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private bool _available;

    private SpriteRenderer _sprite;

    public bool Available
    {
        get => _available;
        set => _available = value;
    }

    public Color Color
    {
        get => _sprite.color;
        set => _sprite.color = value;
    }

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
}
