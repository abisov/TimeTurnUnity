using System;
using UnityEngine;

public class Grid<TGridObject>
{
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    private TGridObject[,] gridArray;
    private Vector3 originPosition;

    public const int sortingOrderDefault = 5000;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, 
        Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];

        for (int w = 0; w < this.gridArray.GetLength(0); w++)
        {
            for (int h = 0; h < this.gridArray.GetLength(1); h++)
            {
                gridArray[w, h] = createGridObject(this, w, h);
            }
        }
        
        bool showDebug = true;
        if (showDebug)
        {
            var debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = this.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPositionIsometric(x, y) + new Vector3(0, cellSize / 2), 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPositionIsometric(x, y), GetWorldPositionIsometric(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPositionIsometric(x, y), GetWorldPositionIsometric(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPositionIsometric(0, height), GetWorldPositionIsometric(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPositionIsometric(width, 0), GetWorldPositionIsometric(width, height), Color.white, 100f);

            OnGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) => {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWorldPositionIsometric(float x, float y)
    {
        Vector2 XYIsometric = MakeIsometric(x, y);
        return GetWorldPosition(XYIsometric.x, XYIsometric.y);
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * this.cellSize + this.originPosition;
    }

    private Vector2 MakeIsometric(float x, float y)
    {
        return new Vector2(
          x - y,
          (x + y) / 2
        );
    }

    public void GetXYIsometric(Vector3 worldPosition, out int x, out int y)
    {
        Vector2 vec2 = Make2D((worldPosition - originPosition).x, (worldPosition - originPosition).y);
        x = Mathf.FloorToInt(vec2.x / this.cellSize);
        y = Mathf.FloorToInt(vec2.y / this.cellSize);
    }

    private Vector2 Make2D(float x, float y)
    {
        return new Vector2(
          (2 * y + x) / 2,
          (2 * y - x) / 2
        );
    }

    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXYIsometric(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(TGridObject);
        }
    }

    public TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}

