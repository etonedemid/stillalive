using System.Linq; // For using LINQ methods
using UnityEngine;
using UnityEngine.InputSystem;
public class Bomb1 : MonoBehaviour
{
    [Header("References")]
    public GameObject bombPoint; // Target point to move towards
    public GameObject player; // Reference to the player GameObject

    [Header("Movement")]
    public float speed = 1f; // Movement speed towards bombPoint
    public float dashSpeed = 10f; // Speed of the dash

    private bool isActive; // Whether the bomb is currently active
    private bool hasDashed; // Whether the bomb has dashed

    private static Bomb1 currentlyActiveBomb; // Static reference to the currently active bomb

    private Bomb1[] bombReferences; // Array of all Bomb1 instances
    private Collider2D playerCollider; // Cached reference to the player's Collider2D
    private Collider2D bombCollider; // Cached reference to this bomb's Collider2D
    private Rigidbody2D bombRigidbody; // Cached reference to this bomb's Rigidbody2D

    void Start()
    {
        // Cache references to components and game objects
        bombReferences = Object.FindObjectsByType<Bomb1>(FindObjectsSortMode.None);
        player = GameObject.Find("legs");
        playerCollider = player.GetComponent<Collider2D>();
        bombCollider = GetComponent<Collider2D>();
        bombRigidbody = GetComponent<Rigidbody2D>();

        // Ignore collision between player and bomb
        Physics2D.IgnoreCollision(playerCollider, bombCollider);
    }

    void Update()
    {
        if (uiscript.isGamePaused) return; // Exit if the game is paused

        // Check if the secondary fire button (right mouse button) is pressed
        if (Mouse.current != null) if (Mouse.current.rightButton.isPressed) ActivateBomb();
        if (Gamepad.current != null) if (Gamepad.current.leftTrigger.isPressed) ActivateBomb();

        // Handle the bomb's state if it is currently active
        if (isActive)
        {
            if (Time.timeScale == 0) return; // Exit if the game is paused
            Dash();
            isActive = false; // Reset isActive after dashing
        }
        else if (!hasDashed)
        {
            MoveTowardsBombPoint();
        }
    }

    void ActivateBomb()
    {
        // Deactivate the currently active bomb if there is one
        if (currentlyActiveBomb != null && currentlyActiveBomb != this)
        {
            currentlyActiveBomb.Deactivate();
        }

        // Set this bomb as the currently active bomb
        currentlyActiveBomb = this;
        isActive = true;
    }

    void Deactivate()
    {
        // Reset the state of the bomb
        isActive = false;
        hasDashed = false;
    }

    bool CanActivate()
    {
        // Only activate if there isn't a currently active bomb or if the current bomb is active
        return currentlyActiveBomb == null || currentlyActiveBomb == this;
    }

    void MoveTowardsBombPoint()
    {
        // Move the bomb towards the designated point
        transform.position = Vector3.MoveTowards(transform.position, bombPoint.transform.position, speed * Time.deltaTime);
    }

    void Dash()
    {
        // Calculate the direction towards the mouse cursor
        Vector2 direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        direction.Normalize();

        // Add an impulse force in the calculated direction
        bombRigidbody.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        hasDashed = true; // Set hasDashed to true after dashing

        // Ensure no other bomb can dash while this one is active
        currentlyActiveBomb = this;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }
    void Explode()
    {
        // Instantiate explosion effect and deactivate the bomb
        Instantiate(Resources.Load("explosionCircle"), transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        // Clear the currently active bomb reference if this bomb is currently active
        if (currentlyActiveBomb == this)
        {
            currentlyActiveBomb = null;
        }
    }
}
