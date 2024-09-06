using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public void OnPlayButton()
    {
        enemy.hp = 10;
        enemy.damagemultiplier = 1;
        enemy.speed = 2;
        Money.money = 10;
        SceneManager.LoadScene("Main_Scene");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
