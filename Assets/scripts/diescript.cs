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

    void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("collided");
    if (collision.gameObject.layer == 6)
    {
        enemy.GetComponent<DeathScript>().Die();
    }
}

}
