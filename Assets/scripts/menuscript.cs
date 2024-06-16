using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public GameObject gamemenu;
    // Update is called once per frame
    
    void Start()
    {
        gamemenu.SetActive(false);
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            gamemenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resume()
    {
        gamemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void exit()
    {
        SceneManager.LoadScene("main menu");
    }
}
