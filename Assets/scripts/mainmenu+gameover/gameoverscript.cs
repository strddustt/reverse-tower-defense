using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public void OnRetryButton()
    {
        enemy.speed = 2;
        enemy.damagemultiplier = 1;
        enemy.hp = 10;
        Money.money = 10;
        SceneManager.LoadScene("Main_Scene");
    }

    public void OnMainButton()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
