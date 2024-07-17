using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Animations;

public class enemyfireboss : MonoBehaviour
{
    AIPath ai;
    public GameObject enemyfirepoint;

    enemyshoot enemyshoot;
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<AIPath>();
        enemyshoot = enemyfirepoint.GetComponent<enemyshoot>();
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        while (true)
        {
            if (ai.reachedEndOfPath)
            {
                Vector2 direction = (GameObject.Find("legs").transform.position - transform.position).normalized;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90));
                enemyshoot.Shoot();
            }
            yield return new WaitForSeconds(0.2f); // Adjust the delay here
        }
    }

}
