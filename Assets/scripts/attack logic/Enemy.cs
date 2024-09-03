using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public static int deaths = 0;
    public int hp = 10;
    public float speed = 2f;
    private bool isDead = false; // Flag to track if the enemy is dead

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").transform;
        if (target == null)
        {
            Debug.LogError("Target not found in the scene.");
        }
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        if (IsDead())
            return;

        if (hp <= 0)
        {
            hp = 0;
            isDead = true;
        }
    }

    public bool IsDead() // Method to check if the enemy is dead
    {
        if (isDead)
        {
            deaths++;
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
