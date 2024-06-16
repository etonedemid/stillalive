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

    public void Playconstruction()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("construction");
    }
    public void Play1()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("dungeon");
    }
    public void tutorial()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("tutorial");
    }
    public void Playdrughouse()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("drughouse");
    }

    public void Playgraveyard()
    {
        Time.timeScale = 1;
        uiscript.isGamePaused = false;
        SceneManager.LoadScene("grave");
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
