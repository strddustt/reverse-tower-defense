using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject tower;
    private Enemy enemy;
    TowerAttack towerattack;
    private Transform target;
    public int speed = 1000;
    Transform pos;
    Transform towerpos;
    bool atack = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        towerpos = tower.GetComponent<Transform>();
        towerattack = tower.GetComponent<TowerAttack>();
        pos = towerpos;
    }
    private void OnEnable()
    {
        enemy = towerattack.currentEnemy;
        target = enemy.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            atack = true;
            
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        if (towerattack.currentEnemy == null)
        {
            pos.position = towerpos.position;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float hpbeforeattack = enemy.hp;
            enemy.hp -= towerattack.damage;
            if (enemy.hp < 0)
            {
                enemy.hp = 0;
            }
            Money.money += hpbeforeattack - enemy.hp;
            pos = towerpos;
            enemy.IsDead();
            gameObject.SetActive(false);
        }
    }
}
