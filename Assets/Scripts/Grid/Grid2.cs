using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Grid2
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public const int sortingOrderDefault = 5000;

    public Grid2(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        debugTextArray = new TextMesh[width, height];

        for (int w = 0; w < this.gridArray.GetLength(0); w++)
        {
            for (int h = 0; h < this.gridArray.GetLength(1); h++)
            {
                debugTextArray[w, h] = this.CreateWorldText(gridArray[w, h].ToString(), null, GetWorldPositionIsometric(w, h) + new Vector3(0, cellSize / 2), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPositionIsometric(w, h), GetWorldPositionIsometric(w, h + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPositionIsometric(w, h), GetWorldPositionIsometric(w + 1, h), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPositionIsometric(0, height), GetWorldPositionIsometric(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPositionIsometric(width, 0), GetWorldPositionIsometric(width, height), Color.white, 100f);

        SetValue(0, 0, 10);
        SetValue(0, 1, 11);
        SetValue(1, 0, 12);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        this.GetXYIsometric(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    private void GetXYIsometric(Vector3 worldPosition, out int x, out int y)
    {
        Vector2 vec2 = Make2D(worldPosition.x, worldPosition.y);

        x = Mathf.FloorToInt(vec2.x / cellSize);
        y = Mathf.FloorToInt(vec2.y / cellSize);
    }

    private Vector2 Make2D(float x, float y)
    {
        return new Vector2(
          (2 * y + x) / 2,
          (2 * y - x) / 2
        );
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private Vector3 GetWorldPositionIsometric(float x, float y)
    {
        Vector2 XYIsometric = MakeIsometric(x, y);
        return GetWorldPosition(XYIsometric.x, XYIsometric.y);
    }

    private Vector2 MakeIsometric(float x, float y)
    {
        return new Vector2(
          x - y,
          (x + y) / 2
        );
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
