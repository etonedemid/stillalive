using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diescript1 : MonoBehaviour
{
    GameObject enemy;
    public int health;

    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("collided");
        // Check if the collision is with a bullet
        if (collision.gameObject.layer == 6)
        {
        enemy.GetComponent<DeathScript>().Die();
        }
    }
}
