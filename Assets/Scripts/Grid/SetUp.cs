using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    private Pathfinding pathfinding;

    [SerializeField] private CharacterMovement characterPathfinding; 

    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXYIsometric(mouseWorldPosition, out int x, out int y);
            var path = pathfinding.FindPath(0, 0, x, y);
            Debug.Log(x + " " + y);
            Debug.Log(path[path.Count - 1].GetWorldPosition());


            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(path[i].GetWorldPosition(), path[i + 1].GetWorldPosition(), Color.green, 5f);
                }
            }
            //characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }

        /* if (Input.GetMouseButtonDown(1))
         {
             Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
             pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
             pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
         } */
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
