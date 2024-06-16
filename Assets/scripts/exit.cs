using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    Levels levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = GameObject.Find("room").GetComponent<Levels>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && CountActiveEnemies() == 0)
        {
            levels.ActivateNextLevel();
        }
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
}
