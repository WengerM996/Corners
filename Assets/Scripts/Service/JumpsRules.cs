using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpsRules : MonoBehaviour
{
    [SerializeField] private Rule _xyJumps;
    [SerializeField] private Rule _diagonalJumps;
    [SerializeField] private Rule _movements;

    private static List<Direction.Path> _availableMovements = new List<Direction.Path>();
    private static List<Direction.Path> _availableJumpsDirections = new List<Direction.Path>();

    public static event UnityAction<bool> XYJumpsChanged;
    public static event UnityAction<bool> DiagonalJumpsChanged;
    public static event UnityAction<bool> MovementsChanged;
    
    public static List<Direction.Path> AvailableJumpsDirections
    {
        get => _availableJumpsDirections;
        set => _availableJumpsDirections = value;
    }
    
    public static List<Direction.Path> AvailableMovements
    {
        get => _availableMovements;
        set => _availableMovements = value;
    }

    public static bool XYJumps { set => XYJumpsChanged?.Invoke(value); }
    public static bool DiagonalJumps { set => DiagonalJumpsChanged?.Invoke(value); }
    public static bool Movement { set => MovementsChanged?.Invoke(value); }

    private void OnEnable()
    {
        XYJumpsChanged += OnXyJumpsChanged;
        DiagonalJumpsChanged += OnDiagonalJumpsChanged;
        MovementsChanged += OnMovementsChanged;
    }

    private void OnDisable()
    {
        XYJumpsChanged -= OnXyJumpsChanged;
        DiagonalJumpsChanged -= OnDiagonalJumpsChanged;
        MovementsChanged -= OnMovementsChanged;
    }

    private void OnMovementsChanged(bool value)
    {
        if (value)
        {
            SetMovements();
        }
        else
        {
            RemoveMovements();
        }
    }

    private void OnXyJumpsChanged(bool value)
    {
        if (value)
        {
            SetXYJump();
        }
        else
        {
            RemoveXYJumps();
        }
    }
    
    private void OnDiagonalJumpsChanged(bool value)
    {
        if (value)
        {
            SetDiagonalJumps();
        }
        else
        {
            RemoveDiagonalJumps();
        }
    }

    private void SetXYJump()
    {
        _availableJumpsDirections.AddRange(_xyJumps.Paths);
    }

    private void RemoveXYJumps()
    {
        foreach (var jumpDirection in _xyJumps.Paths)
        {
            _availableJumpsDirections.Remove(jumpDirection);
        }
    }

    private void SetDiagonalJumps()
    {
        _availableJumpsDirections.AddRange(_diagonalJumps.Paths);
    }
    
    private void RemoveDiagonalJumps()
    {
        foreach (var jumpDirection in _diagonalJumps.Paths)
        {
            _availableJumpsDirections.Remove(jumpDirection);
        }
    }

    private void SetMovements()
    {
        _availableMovements.AddRange(_movements.Paths);
    }

    private void RemoveMovements()
    {
        foreach (var movement in _movements.Paths)
        {
            _availableMovements.Remove(movement);
        }
    }
}
