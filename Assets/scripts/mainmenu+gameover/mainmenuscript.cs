using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public void OnPlayButton()
    {

        Money.money = 10;
        SceneManager.LoadScene("Main_Scene");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
