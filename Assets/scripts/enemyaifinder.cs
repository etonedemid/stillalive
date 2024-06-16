using System.Collections;
using Pathfinding;
using UnityEngine;

public class enemyaifinder : MonoBehaviour
{
    public int damage = 1;
    private bool isseen = false;
    private GameObject player; // Declare player as a class field
    void Start()
    {
        player = GameObject.Find("legs"); // Assign player in Start()
        gameObject.GetComponent<AIDestinationSetter>().target = null;
    }
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 50f && !isseen)
        {
            isseen = true;
            set();
        }

    }
    
    void set()
    {  
        gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
    }
}