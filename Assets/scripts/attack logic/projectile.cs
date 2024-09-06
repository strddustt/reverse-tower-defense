using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject tower;
    private Enemy enemy;
    private TowerAttack towerattack;
    private Transform target;
    public int speed = 1;
    private Transform pos;
    private Transform towerpos;
    bool atack = false;

    // Start is called before the first frame update
    private void Awake()
    {
        pos = GetComponent<Transform>();
        towerpos = tower.GetComponent<Transform>();
        towerattack = tower.GetComponent<TowerAttack>();
        pos.position = towerpos.position;
        Debug.Log($"tower is set to {tower.ToString()}");
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
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("no enemy");
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
            Debug.Log($"dealt damage: {towerattack.damage}. enemy hp left: {enemy.hp}");
            enemy.IsDead();
            pos.position = towerpos.position;
            gameObject.SetActive(false);
        }
    }
}
