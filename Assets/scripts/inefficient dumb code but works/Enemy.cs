using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int deaths = 0;
    public float hp = 10;
    public float speed = 2f;
    internal float damagemultiplier = 1f;
    private bool isDead = false; // Flag to track if the enemy is dead
    private SpriteRenderer sprite;
    private SelfDestructEnemy death;

    void Start()
    {
        death = GetComponent<SelfDestructEnemy>();
        sprite = GetComponent<SpriteRenderer>();
        hp = 10;
        damagemultiplier = 1;
        speed = 2;
    }

    void Update()
    {

    }

    public bool IsDead() // Method to check if the enemy is dead
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        return isDead;
    }
    public void upgrader(float damage, float speed, float health)
    {
        damagemultiplier += damage;
        this.speed += speed;
        hp += health;
    }
}
