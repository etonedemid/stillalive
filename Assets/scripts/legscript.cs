using UnityEngine;
using UnityEngine.InputSystem;

public class legscript : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Animator an;
    private Vector2 direction;
    private GameObject car;
    private bool incarActive = false;
    private GameObject getincar;

    void Start()
    {
        getincar = GameObject.Find("getincar");
        car = GameObject.Find("car");
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        an.speed = 0;
    }

    void Update()
    {
        if (incarActive)
        {
            GetComponent<Collider2D>().enabled = false;
            transform.position = car.transform.position;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
        }

        ProcessGamepadInput();

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        an.speed = (direction == Vector2.zero) ? 0 : 1;
    }

    void FixedUpdate()
    {
        if (!incarActive)
        {
            rb.velocity = direction * speed;
        }
    }

    void ProcessGamepadInput()
    {
        if (Gamepad.current != null)
        {
            // Gamepad input handling
            if (Gamepad.current.leftStick.ReadValue() != Vector2.zero)
            {
                direction = Gamepad.current.leftStick.ReadValue();
            }
            else
            {
                direction = Vector2.zero;
            }

            
                if (Gamepad.current.xButton.wasPressedThisFrame)
                    {
                    if (Vector2.Distance(transform.position, car.transform.position) < 5.0f)
                    {
                    if (!incar.active) incarActive = true;
                    if (incar.active) incarActive = false;
                    }
                    }

                if (Vector2.Distance(transform.position, car.transform.position) < 5.0f)
                {
                    getincar.SetActive(true);

                    if (Gamepad.current.xButton.wasPressedThisFrame)
                    {
                    
                    if (!incar.active) incarActive = true;
                    if (incar.active) incarActive = false;

                    }
                    
                }
                else getincar.SetActive(false);
                
        }
    }
}
