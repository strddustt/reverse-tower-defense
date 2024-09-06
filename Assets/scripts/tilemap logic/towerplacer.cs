using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class towerplacer : MonoBehaviour
{
    public Tile tile;
    public Tilemap tilemap;
    Vector3Int cellPosition;
    TowerAttack tower;
    CircleCollider2D towerrng;
    public int wavetoplace = 99;
    public int wavetoupgrade = 99;
    public int dmginc = 0;
    public int rnginc = 0;
    private bool limiter = false;
    // Start is called before the first frame update
    void Start()
    {
        cellPosition = tilemap.WorldToCell(transform.position);
        tower = GetComponent<TowerAttack>();
        towerrng = GetComponent<CircleCollider2D>();
        tower.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BaseLogic.wave == wavetoplace && limiter == false)
        {
            placeontile();
            limiter = true;
        }
        if (BaseLogic.wave == wavetoupgrade)
        {
            tower.damage += dmginc;
            tower.atkspd -= 0.1f;
            towerrng.radius += rnginc;
        }
    }
    public void placeontile()
    {
        tilemap.SetTile(cellPosition, tile);
        tower.enabled = true;
    }
}
