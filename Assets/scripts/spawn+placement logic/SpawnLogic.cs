using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public Transform spawner;
    public GameObject enemyprefab;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Instantiate(enemyprefab, spawner.position, spawner.rotation);
    }
}
