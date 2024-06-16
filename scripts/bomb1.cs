using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Bomb1 : MonoBehaviour
{
    public GameObject bombPoint;
    public float speed = 1f;

    private bool isActive;
    private bool hasDashed;

    private Bomb1[] bombReferences;
    private GameObject player;

    void Start()
    {
        bombReferences = GameObject.FindObjectsOfType<Bomb1>();
        player = GameObject.Find("legs");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

private int currentBombIndex = 0;

void Update()
{
    if (uiscript.isGamePaused) return;

    if (Input.GetMouseButtonDown(1))
    {
        bombReferences[currentBombIndex].isActive = true;
        currentBombIndex = (currentBombIndex + 1) % bombReferences.Length;
    }
        if (Input.GetMouseButtonDown(1) &&!hasDashed)
        {
            if (CanActivate())
            {
                isActive = true;
            }
        }

        if (isActive)
        {
            Dash();
            isActive = false;
        }
        else if (!hasDashed)
        {
            MoveTowardsBombPoint();
        }
    }
    bool CanActivate()
    {
    if (hasDashed)
    {
        return false;
    }

    for (int i = 0; i < bombReferences.Length; i++)
    {
        if (bombReferences[i].hasDashed)
        {
            return false;
        }
    }
    return true;
    }

    void MoveTowardsBombPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, bombPoint.transform.position, speed * Time.deltaTime);
    }

    public float dashSpeed = 10f;
    void Dash()
{
    // Calculate the direction towards the cursor
    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    direction.Normalize();

    // Add a force in the calculated direction with the set speed
    GetComponent<Rigidbody2D>().AddForce(direction * dashSpeed, ForceMode2D.Impulse);
    hasDashed = true;

}

void OnCollisionEnter2D(Collision2D collision)
{
    Explode();
}

void Explode()
{
    GameObject explosionCircle = (GameObject)Instantiate(Resources.Load("explosionCircle"), transform.position, Quaternion.identity);
    gameObject.SetActive(false);
}

}