using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playbutton : MonoBehaviour
{

    public void Play()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("TEST");
    }

    public void Playsur()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("waves");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("main menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
