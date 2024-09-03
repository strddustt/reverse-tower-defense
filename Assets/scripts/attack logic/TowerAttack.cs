using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Enemy> enemiesInRange = new List<Enemy>();
    internal Enemy currentEnemy;
    private bool isAttacking;
    private Transform spawn;
    [SerializeField] internal float atkspd = 0.5f; // Attack speed in seconds
    [SerializeField] internal int damage = 2;
    private float attackCooldown = 0f; // Cooldown timer
    internal bool attacked = false;



    void Update()
    {
        //Vector3 MousePos = Input.mousePosition;
        // Vector3 Position = transform.position;
        //float difference = Vector3.Distance(Position, MousePos);
        // Debug.Log(Position);
        // Handle the cooldown timer
        if (isAttacking)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f)
            {
                Attack();
                attackCooldown = atkspd;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("enemy entered radius");
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("enemy left radius");
            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
                if (currentEnemy == enemy)
                {
                    currentEnemy = null;
                    isAttacking = false;
                    StartAttacking();
                }
            }
        }
    }

    void StartAttacking()
    {
        if (enemiesInRange.Count > 0)
        {
            currentEnemy = enemiesInRange[0];
            isAttacking = true;
            attackCooldown = atkspd; // Start the cooldown
            Debug.Log("attacking enemy");
        }
    }

    void Attack()
    {
        if (currentEnemy == null)
        {
            isAttacking = false;
            return;
        }

        if (currentEnemy.IsDead())
        {
            enemiesInRange.Remove(currentEnemy);
            currentEnemy = null;
            Destroy(currentEnemy);

            if (enemiesInRange.Count > 0)
            {
                currentEnemy = enemiesInRange[0];
            }
            else
            {
                isAttacking = false;
            }
        }
        else
        {
            currentEnemy.hp -= damage;
            Debug.Log($"enemy hp left = {currentEnemy.hp}");
            currentEnemy.TakeDamage();
            StartAttacking();
        }
    }
}
