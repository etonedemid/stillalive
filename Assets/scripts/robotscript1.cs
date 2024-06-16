using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class robotscriptsurvival : MonoBehaviour
{
    public int killCounter;
    public int killneed;

    GameObject cursor;
    GameObject legs;
    fire fire;
    Vector2 direction;
    private bool isUsingController = false;

    void Start()
    {
        fire = GameObject.Find("firepoint").GetComponent<fire>();
        if (fire.weapon == "shotgun")
        {
            killneed = 30;
        }
        else
        {
            killneed = 6;
        }
        killCounter = 0;
        legs = GameObject.Find("legs");
        cursor = GameObject.Find("cursor");

        // Initialize input system detection
    }

    void Update()
    {
        transform.position = legs.transform.position;
    if (Gamepad.current != null){    
    if (Gamepad.current.rightStick.ReadValue() != Vector2.zero) RotateUsingController();
    else RotateTowardsMouse();}
    else RotateTowardsMouse();
    }

    public void Killed()
    {
        if (fire.weapon == "shotgun")
        {
            killneed = 30;
        }
        else
        {
            killneed = 15;
        }
        killCounter += 1;
        if (killCounter >= killneed)
        {
            GameObject _ = (GameObject)Instantiate(Resources.Load("crate" + Random.Range(1, 3).ToString()), transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
            killCounter = 0;
        }
    }

    void RotateTowardsMouse()
{
    // Ensure the cursor is visible if needed (optional)
    Cursor.visible = true;

    // Convert mouse screen position to world position
    Vector3 mouseScreenPosition = Mouse.current.position.ReadValue();
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

    // Compute the direction vector from the character to the mouse world position
    Vector2 direction = (Vector2)(mouseWorldPosition - transform.position);

    // Calculate the angle required to rotate the character to face the cursor
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

    // Apply the calculated rotation to the character
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
}




    void RotateUsingController()
{
    if (Gamepad.current == null) return;
    if (Gamepad.current.rightStick.ReadValue() == Vector2.zero) return;
    if (Gamepad.current.rightStick.value != Vector2.zero) Cursor.visible = false;
    Vector2 input = Gamepad.current.rightStick.ReadValue();
    if (input == Vector2.zero) return;
    float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 90;
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
}

}