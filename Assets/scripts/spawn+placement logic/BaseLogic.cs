using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    Enemy enemylogic;
    GameObject enemy;
    Money money;
    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<Money>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemylogic = other.GetComponent<Enemy>();
            enemy = other.GetComponent<GameObject>();
            money.money += enemylogic.hp * enemylogic.damagemultiplier * 2f;
            Destroy(enemy);

        }
    }
}
