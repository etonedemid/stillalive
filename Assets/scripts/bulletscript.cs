using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed = 1f;

    public Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 

        rb.velocity = transform.right * speed;

        transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);

        Destroy(gameObject, 1f);


    }

    GameObject obj1;

    void OnTriggerEnter2D(Collider2D obj)
    {
    if (obj.gameObject.tag == "wall")
    {
    obj1 = Instantiate(Resources.Load("debris"), transform.position, Quaternion.identity) as GameObject;

    Destroy(gameObject);
    }
    else
    {
    Destroy(gameObject);
    }
    }
}
