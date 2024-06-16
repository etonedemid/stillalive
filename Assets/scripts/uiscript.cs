using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiscript : MonoBehaviour
{
    public GameObject Menu;
    // Start is called before the first frame update
    public static bool isGamePaused = false;
    void Start()
    {
        Menu = GameObject.Find("Menu");
    }

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }   
    }

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }
}
