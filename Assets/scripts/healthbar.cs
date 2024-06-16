using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public GameObject boss;
    DeathScript deathScript;
    void Start()
    {
        deathScript = boss.GetComponent<DeathScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(deathScript.hp / 200f, 0.1f, 1f);
    }
}
