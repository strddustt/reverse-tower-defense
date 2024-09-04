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

    void Start()
    {

    }

    void Update()
    {

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
            return true;
        }
        else
        {
            return false;
        }
    }
}
