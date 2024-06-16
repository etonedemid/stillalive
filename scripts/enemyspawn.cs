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
        StartCoroutine("DoCheck");
    }

    void spawn()
    {
        Target = GameObject.Find("spawnpoint" + Random.Range(1, 7).ToString());
        _ = Instantiate(Resources.Load("enemy" + Random.Range(1, 4).ToString()), Target.transform.position, Quaternion.identity);
    }

    IEnumerator DoCheck() {
        spawnrate = 3f;
        float timeSinceLevelLoad = Time.timeSinceLevelLoad;
        if (timeSinceLevelLoad >= 10) spawnrate = 1f;
        if (timeSinceLevelLoad >= 30) spawnrate = 0.5f;
        if (timeSinceLevelLoad >= 60) spawnrate = 0.25f;
        if (timeSinceLevelLoad >= 100) spawnrate = 0.1f;
        while (true) {
            yield return new WaitForSeconds(spawnrate);
            spawn();
        }
    }

}
