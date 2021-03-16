using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private List<Cell> _targetCells;

    private Player _player;
    
    public static event UnityAction<string> Win;

    public List<Cell> TargetCells => _targetCells;

    private void OnEnable()
    {
        Dragging.Moved += OnMoved;
    }

    private void OnDisable()
    {
        Dragging.Moved -= OnMoved;
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnMoved()
    {
        var counter = 0;
        
        foreach (var figure in _player.Figures)
        {
            foreach (var targetCell in _targetCells)
            {
                if (figure.Cell == targetCell)
                {
                    counter++;
                }
            }
        }

        if (counter == _player.Figures.Count)
        {
            Win?.Invoke(_player.Name);
        }
    }
}
