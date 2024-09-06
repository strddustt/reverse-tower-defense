using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : MonoBehaviour
{
    internal Enemy self;
    private CircleCollider2D circleCollider;
    private TowerAttack tower;
    int cooldown = 2;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Enemy>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (self.IsDead() && self != null)
        {
            circleCollider.radius = 4;
            Destroy(self.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tower"))
        {
            tower = collision.GetComponent<TowerAttack>();
            StartCoroutine(towercooldown());
        }
    }
    IEnumerator towercooldown()
    {
        tower.enabled = false;
        circleCollider.enabled = false;
        yield return new WaitForSeconds(cooldown);
        tower.enabled = true;
        Destroy(gameObject);
        yield break;
    }
}
