using UnityEngine;

public class startdungeon : MonoBehaviour
{
    fire fire;
    GameObject astar;
    void Start()
    {
        uiscript.isGamePaused = true;
        astar = GameObject.Find("A*");
        fire = GameObject.Find("firepoint").GetComponent<fire>();
        Time.timeScale = 0;
        astar.SetActive(false);
    }


    public void shotgun()
    {
        fire.weapon = "shotgun";
        fire.Init1();
        Time.timeScale = 1;
        astar.SetActive(true);
        gameObject.SetActive(false);
        uiscript.isGamePaused = false;
    }
    public void pistol()
    {
        fire.weapon = "pistol";
        fire.Init1();
        Time.timeScale = 1;
        astar.SetActive(true);
        gameObject.SetActive(false);
        uiscript.isGamePaused = false;
    }
}
