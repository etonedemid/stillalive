using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    GameObject camerafollowpoint;

    void Start()
    {
        camerafollowpoint = GameObject.Find("camerafollowpoint");
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
    }

    void Update()
    {
    
    transform.position = legs.transform.position;
    if (!incar.active) 
     {
    RotateUsingController();
    }
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