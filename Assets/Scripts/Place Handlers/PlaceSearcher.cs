using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Figure), typeof(Dragging))]
public abstract class PlaceSearcher : MonoBehaviour
{
    [SerializeField] private List<Direction> _directions;
    protected Figure Figure { get; set; }
    private Dragging Dragging { get; set; }
    public List<Cell> AvailableSpots { get; private set; }

    protected List<Direction> Directions
    {
        get => _directions;
        set => _directions = value;
    }

    private void Awake()
    {
        Figure = GetComponent<Figure>();
        Dragging = GetComponent<Dragging>();
        AvailableSpots = new List<Cell>();
    }

    private void OnEnable()
    {
        Dragging.Begin += OnDraggingBegin;
        Dragging.Ended += OnDraggingEnded;
    }

    private void OnDisable()
    {
        Dragging.Begin -= OnDraggingBegin;
        Dragging.Ended -= OnDraggingEnded;
    }

    protected virtual void OnDraggingBegin()
    {
        CastRays();
    }

    protected virtual void OnDraggingEnded()
    {
        foreach (var direction in _directions)
        {
            direction.Hits.Clear();
        }
        
        AvailableSpots.Clear();
    }
    
    private void CastRays()
    {
        foreach (var direction in _directions)
        {
            var hits = Physics.RaycastAll(Figure.Cell.transform.position, direction.Ray, direction.Distance);
            
            direction.Hits.AddRange(hits);
        }
    }
}

