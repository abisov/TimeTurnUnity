using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class CharacterMovement : MonoBehaviour
{
    private const float speed = 40f;

    private List<Vector3> pathVectorList = null;
    private List<PathNode> pathNodeList = null;
    private int currentPathIndex;

    private int currentX = 0;
    private int currentY = 0;

    private void Update()
    {
        HandleMovement2();

        if (Input.GetMouseButtonDown(0))
        {
            //var mouseWorldPosition = GetMouseWorldPosition();
            //this.pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), mouseWorldPosition);

           SetTargetPosition2(GetMouseWorldPosition());
        }
    }

    private void HandleMovement2()
    {
        if (this.pathNodeList != null)
        {
            var targetPosition = this.pathNodeList[currentPathIndex].GetWorldPosition();

            //Debug.Log(targetPosition);

            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                var dir = targetPosition - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                currentPathIndex++;
                if (this.currentPathIndex >= this.pathNodeList.Count)
                {
                    this.StopMoving();
                }
            }
        }
    }

    private void HandleMovement3()
    {
        if (this.pathVectorList != null)
        {
            var targetPosition = pathVectorList[currentPathIndex];

            Debug.Log(targetPosition);

            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                var dir = targetPosition - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                currentPathIndex++;
                if (this.currentPathIndex >= this.pathVectorList.Count)
                {
                    this.StopMoving();
                }
            }
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
        this.pathNodeList = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition2(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        Pathfinding.Instance.GetGrid().GetXYIsometric(targetPosition, out int x, out int y);
        this.pathNodeList = Pathfinding.Instance.FindPath(this.currentX, this.currentY, x, y);
        this.currentX = x;
        this.currentY = y;
       

        if (this.pathNodeList != null && this.pathNodeList.Count > 1)
        {
            this.pathNodeList.RemoveAt(0);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;

        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
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
