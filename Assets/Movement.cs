using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Tilemap tilemap;
    public GridLayout grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilepos = tilemap.WorldToCell(mousePos);
            var pos = grid.CellToWorld(tilepos);

            StartCoroutine(move(pos));
             //new Vector3(pos.x, pos.y + 0.25f, 0); //Vector3.MoveTowards(transform.position, cor, 100 * Time.deltaTime);
        }
    }

    IEnumerator move(Vector3 pos)
    {
        while (this.transform.position != new Vector3(pos.x, pos.y + 0.25f, 0))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, pos.y + 0.25f, 0), 0.001f * Time.deltaTime);
        }
        return null;
    }
}
