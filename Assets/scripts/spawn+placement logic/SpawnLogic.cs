using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public Transform spawner;
    public GameObject weakestenemyprefab;
    public GameObject selfdestructenemy;
    private float cooldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void OnClickweakest()
    {
        if (Money.money >= 5 && cooldown <= 0)
        {
            Instantiate(weakestenemyprefab, spawner.position, spawner.rotation);
            cooldown = 0.5f;
            Money.money -= 5;
        }
    }
    public void OnClickSelfDestruct()
    {
        Instantiate(selfdestructenemy, spawner.position, spawner.rotation);
    }
}
