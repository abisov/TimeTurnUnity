using UnityEngine;

public class PathNode
{
    private Grid<PathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public bool isWalkable;
    public PathNode cameFromNode;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = true;
    }

    public void CalculateFCost()
    {
        this.fCost = this.gCost + this.hCost;
    }

    public Vector3 GetWorldPosition()
    {
       return this.grid.GetWorldPositionIsometric(this.x, this.y) + new Vector3(0, this.grid.GetCellSize() / 2, 0);
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        this.grid.TriggerGridObjectChanged(this.x, this.y);
    }

    public override string ToString()
    {
        return this.x + "," + this.y;
    }
}
