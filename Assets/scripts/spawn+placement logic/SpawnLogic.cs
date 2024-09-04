using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public Transform spawner;
    public GameObject weakestenemyprefab;
    public GameObject selfdestructenemy;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickweakest()
    {
        Instantiate(weakestenemyprefab, spawner.position, spawner.rotation);
    }
    public void OnClickSelfDestruct()
    {
        Instantiate(selfdestructenemy, spawner.position, spawner.rotation);
    }
}
