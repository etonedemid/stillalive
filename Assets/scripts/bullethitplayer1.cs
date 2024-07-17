using System.Collections;
using Pathfinding;
using UnityEngine;

public class BulletHitPlayer : MonoBehaviour
{
    public int damage = 1;
    private bool isInvincible = false;
    private GameObject player; // Declare player as a class field

    void Start()
    {
        player = GameObject.Find("legs"); // Assign player in Start()
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isInvincible)
        {
            Health healthComponent = player.GetComponent<Health>(); // Get the Health component
            healthComponent.currentHealth -= damage; // Use the damage variable
            StartCoroutine(InvincibilityTimer());
        }
    }

    private IEnumerator InvincibilityTimer()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}