using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    Enemy enemy;
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
            enemy = other.GetComponent<Enemy>();
            money.money += enemy.hp * enemy.damagemultiplier;
            Destroy(enemy);

        }
    }
}
