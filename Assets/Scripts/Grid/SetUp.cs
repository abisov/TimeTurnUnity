using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    private Grid2 grid2;

    private void Start()
    {
        //var grid = new Grid(20, 20, 10f);
        this.grid2 = new Grid2(20, 20, 10f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.grid2.SetValue(this.GetMouseWorldPosition(), 20);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(
               this.grid2.GetValue(this.GetMouseWorldPosition()));
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        var vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    private Vector3 GetMouseWorldPositionWithZ(Vector3 mousePosition, Camera main)
    {
        var worldPosition = main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }
}
