using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class tileshower : MonoBehaviour
{
    public Tile tile;
    public Tile newtile;
    public Tilemap tilemap;
    Vector3Int tileposition;
    // Start is called before the first frame update
    void Start()
    {
        tileposition = tile.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void showtile()
    {
        tilemap.SetTile(tileposition, null); 
    }
}
