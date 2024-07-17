using System.Collections;
using Pathfinding;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public int damage = 1;
    private bool isInvincible = false;
    private GameObject player; // Declare player as a class field

    void Start()
    {
        player = GameObject.Find("legs"); // Assign player in Start()
        gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        gameObject.transform.localScale = new Vector3(6, 6, 0);
        gameObject.SetActive(true);
        
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