using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Type
    {
        Player, AI
    }

    [SerializeField] private string _name;
    [SerializeField] private Type _type;
    [SerializeField] private bool _moving;
    [SerializeField] private PlayerSwitcher _playerSwitcher;
    [SerializeField] private List<Figure> _figures;

    public PlayerSwitcher PlayerSwitcher => _playerSwitcher;
    public List<Figure> Figures => _figures;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Type PlayerType
    {
        get => _type;
        set => _type = value;
    }

    public bool Moving
    {
        get => _moving;
        set => _moving = value;
    }
}
