using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylegscript : MonoBehaviour
{
    public float speed = 10f;

    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public Collider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        if (moveVertical == 0 && moveHorizontal == 0)
        {
            animator.speed = 0f;
            return;
        }
        animator.speed = 1f;

        movement = movement.normalized * movement.magnitude;
        rigidbody2D.velocity = movement * speed;
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 270;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
