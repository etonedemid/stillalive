using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Animations;

public class enemyfire : MonoBehaviour
{
    AIPath ai;
    public GameObject enemyfirepoint;

    public float time;

    enemyshoot enemyshoot;
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
            yield return new WaitForSeconds(time); // Adjust the delay here
        }
    }

}
