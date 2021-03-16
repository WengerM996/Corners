using UnityEngine;

public class PlaceHandler : PlaceSearcher
{
    protected override void OnDraggingBegin()
    {
        base.OnDraggingBegin();
        
        CheckAvailableMoves();
    }

    protected override void OnDraggingEnded()
    {
        foreach (var cell in AvailableSpots)
        {
            cell.Color = Color.white;
        }
        
        base.OnDraggingEnded();
    }

    private void CheckAvailableMoves()
    {
        foreach (var direction in Directions)
        {
            foreach (var hit in direction.Hits)
            {
                if (hit.collider.TryGetComponent(out Cell cell))
                {
                    CheckCell(direction, cell);
                }
            }
        }
    }

    private void CheckCell(Direction direction, Cell cell)
    {
        if (AvailableToMove(direction.Way))
            if (SettingCell(cell, Color.green)) { return; }

        if (AvailableToJump(direction.Way) == false) return;
        
        if (Physics.Raycast(cell.transform.position, direction.Ray, out RaycastHit hit, direction.Distance))
        {
            if (hit.collider.TryGetComponent(out cell))
            {
                SettingCell(cell, Color.yellow);
            }
        }
    }

    private bool SettingCell(Cell cell, Color color)
    {
        if (cell.Available)
        {
            cell.Color = color;
            AvailableSpots.Add(cell);
            return true;
        }

        return false;
    }

    private bool AvailableToMove(Direction.Path path)
    {
        foreach (var direction in JumpsRules.AvailableMovements)
        {
            if (path == direction) return true;
        }

        return false;
    }

    private bool AvailableToJump(Direction.Path path)
    {
        foreach (var jumpsDirection in JumpsRules.AvailableJumpsDirections)
        {
            if (path == jumpsDirection) return true;
        }

        return false;
    }
}
