using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Dragging))]
public class MoveHandler : MonoBehaviour
{
    private Figure _figure;
    private Dragging _dragging;
    private PlaceSearcher _placeSearcher;
    private Coroutine _coroutine;
    private bool _checking;

    private void Awake()
    {
        _figure = GetComponent<Figure>();
        _dragging = GetComponent<Dragging>();
        _placeSearcher = GetComponent<PlaceSearcher>();

        transform.position = _figure.Cell.transform.position;
    }

    private void OnEnable()
    {
        _dragging.Begin += OnDraggingBegin;
        _dragging.Ended += OnDraggingEnded;
    }

    private void OnDisable()
    {
        _dragging.Begin -= OnDraggingBegin;
        _dragging.Ended -= OnDraggingEnded;
    }

    private void OnDraggingBegin()
    {
        if (_coroutine == null)
        {
            _checking = true;
            _coroutine = StartCoroutine(CastCells());
        }
    }

    private void OnDraggingEnded()
    {
        _checking = false;
    }

    private IEnumerator CastCells()
    {
        while (_checking)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cell cell))
                {
                    CheckCell(cell);
                }
            }
            
            yield return new WaitForEndOfFrame();
        }

        _coroutine = null;
    }

    private void CheckCell(Cell cell)
    {
        if (_placeSearcher.AvailableSpots.Count <= 0) return;

        foreach (var availableCell in _placeSearcher.AvailableSpots)
        {
            if (cell == availableCell)
            {
                if (cell.Available)
                {
                    SetCell(cell);
                }
            }
        }
    }

    private void SetCell(Cell cell)
    {
        if (_figure.Cell != null)
        {
            _figure.Cell.Available = true;
        }
                        
        cell.Available = false;
        _figure.Cell = cell;
        _dragging.SetPosition(cell.transform.position);
    }
}
