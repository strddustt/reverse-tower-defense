using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class towerplacer : MonoBehaviour
{
    public Tile tile;
    public Tilemap tilemap;
    Vector3Int cellPosition;
    public int wavetoplace = 99;
    TowerAttack tower;
    private bool limiter = false;
    // Start is called before the first frame update
    void Start()
    {
        cellPosition = tilemap.WorldToCell(transform.position);
        tower = GetComponent<TowerAttack>();
        tower.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wavetoplace == 0/*wave*/ && limiter == false)
        {
            placeontile();
            limiter = true;
        }
    }
    public void placeontile()
    {
        tilemap.SetTile(cellPosition, tile);
        tower.enabled = true;
    }
}
