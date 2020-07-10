using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Tilemap tilemap;
    public GridLayout grid;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilepos = tilemap.WorldToCell(mousePos);
            var pos = grid.CellToWorld(tilepos);

            this.transform.position = new Vector3(pos.x, pos.y + 0.25f);
            //this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, pos.y + 0.25f), Time.deltaTime);
            //new Vector3(pos.x, pos.y + 0.25f, 0); //Vector3.MoveTowards(transform.position, cor, 100 * Time.deltaTime);
        }
    }
}
