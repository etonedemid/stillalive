using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class legscript : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Animator an;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        an.speed = 0;
    }

    void Update()
    {
        ProcessInput();
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        an.speed = (direction == Vector2.zero) ? 0 : 1;
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    void ProcessInput()
    {
        if (Gamepad.current != null){
		if (Gamepad.current.leftStick.ReadValue() != Vector2.zero)
        {
            direction = Gamepad.current.leftStick.ReadValue();
        }
		else direction = Vector2.zero;
		}
        else
        {
            var keyboardInput = Keyboard.current;
            direction = new Vector2(
                (keyboardInput.dKey.isPressed ? 1 : 0) - (keyboardInput.aKey.isPressed ? 1 : 0),
                (keyboardInput.wKey.isPressed ? 1 : 0) - (keyboardInput.sKey.isPressed ? 1 : 0)
            );
            Cursor.visible = true;
        }
        direction = direction.normalized;
    }

    public void MoveUsingKeyboard(InputAction.CallbackContext input)
    {
        direction = input.ReadValue<Vector2>();
    }
}
