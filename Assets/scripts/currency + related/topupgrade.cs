using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class topupgrade : MonoBehaviour
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
        if (upgradevar == 0 && Money.money >= 25)
        {
            enemy.upgrader(0.5f, 0.1f, 0);
            text.text = "+0.5 damage, +0.05 speed and +2 hp";
            textchange = text.text;
            upgradevar++;
        }
        else if (upgradevar == 1 && Money.money >= 75)
        {
            enemy.upgrader(0.5f, 0.05f, 2);
            textchange = text.text;
            upgradevar++;
        }
        else if (upgradevar == 2 && Money.money >= 100)
        {
            enemy.upgrader(1f, 0.1f, 5);
            textchange = text.text;
            upgradevar++;
        }
        else if (upgradevar >= 2)
        {
            text.text = "max upgrades";
        }
        else
        {
            broke();
        }
    }
    IEnumerator broke()
    {
        text.text = "not enough money.";
        yield return new WaitForSeconds(2);
        text.text = textchange;
        yield break;
    }
}
