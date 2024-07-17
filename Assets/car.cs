using UnityEngine;
using UnityEngine.InputSystem;

public class car : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D cl;
    private AudioSource sfx;
    public float speed = 100f;
    public float turnspeed = 30f;

    private float currentturn;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>(); // Ensure Rigidbody2D component is attached to the GameObject
        cl = GetComponent<Collider2D>(); // Ensure Collider2D component is attached to the GameObject
    }

    void Update()
    {
        if (incar.active == true) 
        {
            if (Gamepad.current != null)
            {
                if (Gamepad.current.rightTrigger.isPressed) {
                currentturn = turnspeed;
                rb.AddForce(transform.up * speed);
                turn();}

                if (Gamepad.current.leftTrigger.isPressed) {
                currentturn = -turnspeed;
                rb.AddForce(transform.up * -speed);
                turn();}
            }
        }  

        // Change audio volume based on velocity
        float avelocity = rb.velocity.magnitude;
        sfx.volume = Mathf.Clamp(avelocity / 100, 0, 1);
    }

    void turn()
    {
        if (Gamepad.current != null)
            {
            if (Gamepad.current.leftStick.left.isPressed)
            {
                rb.AddTorque(currentturn);
            }
            if (Gamepad.current.leftStick.right.isPressed)
            { 
                rb.AddTorque(-currentturn);
            }
            }
    }
}
