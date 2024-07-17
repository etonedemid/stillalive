using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemybulletscript : MonoBehaviour
{
    public float speed = 1f;

    public GameObject player;
    public Rigidbody2D rb;
    public GameObject vignette;
    healthvignette vignetteScript;
    Health healthComponent;
    void Start()
    {

        player = GameObject.Find("legs");
        vignette = GameObject.Find("hitvignette");
        vignetteScript = vignette.GetComponent<healthvignette>();
        healthComponent = player.GetComponent<Health>();
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        rb = gameObject.GetComponent<Rigidbody2D>(); 

        rb.velocity = transform.right * speed;

        transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);

        Destroy(gameObject, 3f);


    }

    GameObject obj1;

    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
    {
        vignetteScript.OnHit();
        healthComponent.currentHealth -= 1;
        Destroy(gameObject); 
    }
    }
}
