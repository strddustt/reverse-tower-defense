using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Transform target;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").transform;
        enemy = GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * enemy.speed * Time.deltaTime;
    }
}
