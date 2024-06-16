using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diescript : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit by bullet");
            enemy.GetComponent<DeathScript>().Die();
        }
    }
}
