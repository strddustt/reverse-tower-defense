using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Transform target;
    SelfDestructEnemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInChildren<SelfDestructEnemy>();
        target = GameObject.FindGameObjectWithTag("target").transform;
        if (target == null)
        {
            Debug.LogError("Target not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.end == true)
        {
            Destroy(gameObject);

        }
    }
}
