using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    [SerializeField] private Enemy enemylogic;
    private GameObject enemy;
    internal float threshold = 20;
    public static int wave = 0;
    healthbar health;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<healthbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemylogic = other.GetComponent<Enemy>();
            enemy = other.gameObject;
            Money.money += enemylogic.hp * enemylogic.damagemultiplier * 2f;
            threshold -= enemylogic.hp;
            health.UpdateHealthBar();
            Debug.Log($"threshold left: {threshold}");
            if (threshold <= 0)
            {
                wave++;
                threshold = 50 * wave;
                Debug.Log($"wave {wave}. threshold: {threshold}");
                health.SetHealth();
                Enemy[] enemies = FindObjectsOfType<Enemy>();
                foreach (Enemy enemy in enemies)
                {
                    Money.money += 5;
                    Destroy(enemy.gameObject);
                }
            }
            Destroy(enemy);
        }
    }
}
