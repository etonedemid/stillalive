using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float playerAwarenessDistance = 15f;

    private Transform player;
    private bool canDetectPlayer = true; // Add a flag to control player detection

    private void Awake()
    {
        player = GameObject.Find("legs").transform;
    }

    void Update()
    {
        if (canDetectPlayer) // Only detect player if allowed
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }

    public void StopDetectingPlayer()
    {
        canDetectPlayer = false;
    }

    public void ResumeDetectingPlayer()
    {
        canDetectPlayer = true;
    }
}