using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class giveup : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Money.money <= 4)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
    public void onclick()
    {
        SceneManager.LoadScene(3);
    }
}
