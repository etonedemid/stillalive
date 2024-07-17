using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    GameObject Target;
    float spawnrate;
    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 3f;
        StartCoroutine("DoCheck");
    }

    void spawn()
    {
        Target = GameObject.Find("spawnpoint" + Random.Range(1, 7).ToString());

        int enemy = Random.Range(0, 100);

        if (enemy > 50)
        {
            _ = Instantiate(Resources.Load("enemy1"), Target.transform.position, Quaternion.identity);
        }
        else if (enemy < 50)
        {
            _ = Instantiate(Resources.Load("enemy3"), Target.transform.position, Quaternion.identity);
        }
        else if (enemy < 95)
        {
            _ = Instantiate(Resources.Load("enemy2"), Target.transform.position, Quaternion.identity);
        }
    }
    void Update()
{
    float timeSinceLevelLoad = Time.timeSinceLevelLoad;
    int time = (int)timeSinceLevelLoad;

    switch (time)
    {
        case >= 200:
            spawnrate = 0.15f;
            break;
        case >= 100:
            spawnrate = 0.35f;
            break;
        case >= 60:
            spawnrate = 0.7f;
            break;
        case >= 30:
            spawnrate = 1f;
            break;
        case >= 10:
            spawnrate = 2f;
            break;
        default:
            spawnrate = 3f;
            break;
    }
}
    IEnumerator DoCheck() {
        while (true) {
            yield return new WaitForSeconds(spawnrate);
            spawn();
        }
    }

}
