using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float rotationSpeed = 1f;

    private Rigidbody2D rb;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private LayerMask wallLayerMask;

    private bool canMove = true; // Add a flag to control movement

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        wallLayerMask = LayerMask.GetMask("Wall");
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            AvoidWalls(); // Avoid walls before updating the target direction
            UpdateTargetDirection();
            RotateTowardsTarget();
            SetVelocity();
        }
    }

    private void UpdateTargetDirection()
    {
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }

    private void AvoidWalls()
    {
        // Cast a ray in the current movement direction to detect nearby walls
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, 1f, wallLayerMask);
        if (hit)
        {
            // If a wall is detected, adjust the movement direction to avoid it
            targetDirection = Vector2.Reflect(targetDirection, hit.normal);
        }
    }

    public void StopMoving()
    {
        canMove = false;
    }

    public void ResumeMoving()
    {
        canMove = true;
    }
}