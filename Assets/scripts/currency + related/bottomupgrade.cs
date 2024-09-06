using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bottomupgrade : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private int upgradevar = 0;
    public TextMeshProUGUI text;
    private string textchange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick()
    {
        if (upgradevar == 0 && Money.money >= 1000)
        {
            enemy.upgrader(5, 1, 50);
        }
    }
}
