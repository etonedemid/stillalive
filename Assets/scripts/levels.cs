using UnityEngine;
using System.Linq;
public class Levels : MonoBehaviour
{
    public int nextLevel;
    GameObject legs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextLevel = 2;
        legs = GameObject.Find("legs");
    }

    int CountActiveEnemies()
    {
        int count = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                count++;
            }
        }
        return count;
    }
    public void ActivateNextLevel()
    {
        destroywalls();
        Instantiate(Resources.Load("level" + nextLevel), new Vector2(0, 0), Quaternion.identity);
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        foreach (GameObject bomb in bombs)
        {
            bomb.transform.position = new Vector3(0, 0, 0);
        }
        legs.transform.position = new Vector2(0, 0);
        nextLevel++;
        AstarPath.active.Scan();
    }

    public void destroywalls()
    {
        var toDestroy = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None).Where(go => go.layer == 8);
            foreach(var g in toDestroy)
            {
                Destroy(g);
            }
    }
}
