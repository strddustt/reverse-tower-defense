using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : MonoBehaviour
{
    internal Enemy self;
    CircleCollider2D circleCollider;
    TowerAttack tower;
    int cooldown = 2;
    internal bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        self = transform.parent.Find("Enemy").GetComponent<Enemy>();
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
            towercooldown();
        }
    }
    IEnumerator towercooldown()
    {
        tower.enabled = false;
        circleCollider.enabled = false;
        yield return new WaitForSeconds(cooldown);
        tower.enabled = true;
        end = true;
        yield break;
    }
}
