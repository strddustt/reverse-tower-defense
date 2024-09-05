using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Popup : MonoBehaviour
{
    public GameObject menu;
    private bool isactive;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Popup()
    {
        if(isactive == false)
        {
            menu.SetActive(true);
            isactive = true;
        }
        else if (isactive == true)
        {
            menu.SetActive(false);
            isactive = false;
        }
    }
}
