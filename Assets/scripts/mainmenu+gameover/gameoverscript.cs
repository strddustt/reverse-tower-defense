using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscript : MonoBehaviour
{
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void OnMainButton()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
