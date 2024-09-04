using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Enemy> enemiesInRange = new List<Enemy>();
    internal Enemy currentEnemy;
    private bool isAttacking;
    private Transform spawn;
    private Money money;
    private CircleCollider2D circleCollider;
    [SerializeField] internal float atkspd = 0.5f; // Attack speed in seconds
    [SerializeField] internal int damage = 2;
    private float attackCooldown = 0f; // Cooldown timer
    internal bool attacked = false;

    private void Start()
    {
        money = FindObjectOfType<Money>();
        circleCollider = GetComponent<CircleCollider2D>();
        if (money == null)
        {
            Debug.Log("no money");
        }
        circleCollider.enabled = true;
    }

    void Update()
    {
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
                enemiesInRange.Add(enemy); // adds enemy to list
                if (!isAttacking)
                {
                    StartAttacking();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) //enemy death triggers this, so attacks continue
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

    void StartAttacking() // specifically for attack cooldown and currentenemy selection. redirect attack requirements to here and not to attack()
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

        else //damage logic. using pre/posthp for accurate money calculations
        {
            float prehp = currentEnemy.hp;
            currentEnemy.hp -= damage;
            if (currentEnemy.hp < 0)
            {
                currentEnemy.hp = 0;
            }
            float posthp = currentEnemy.hp;
            money.money += prehp - posthp;
            Debug.Log($"enemy hp left = {currentEnemy.hp}");
            currentEnemy.TakeDamage(); //death check for enemy
            StartAttacking();
        }
    }
}
