using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathui : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void fuckoff()
    {
        SceneManager.LoadScene("main menu");
    }
}
