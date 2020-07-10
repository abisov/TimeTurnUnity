using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private Vector3 originPosition;

    public const int sortingOrderDefault = 5000;

    public Grid2(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for (int w = 0; w < this.gridArray.GetLength(0); w++)
        {
            for (int h = 0; h < this.gridArray.GetLength(1); h++)
            {
                //this.CreateWorldText(gridArray[w, h].ToString(), null, GetWorldPosition(w, h) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPositionIsometric(w, h), GetWorldPositionIsometric(w, h + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPositionIsometric(w, h), GetWorldPositionIsometric(w + 1, h), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPositionIsometric(0, height), GetWorldPositionIsometric(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPositionIsometric(width, 0), GetWorldPositionIsometric(width, height), Color.white, 100f);
    }

    public void SetValue(int x, int y, int value)
    {
        gridArray[x, y] = value;
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
