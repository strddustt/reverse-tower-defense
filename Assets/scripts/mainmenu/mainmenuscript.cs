using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
