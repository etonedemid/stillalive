using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthdisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;
    int hp;
    // Update is called once per frame
    void Update()
    {
        hp = player.GetComponent<Health>().currentHealth;
        GetComponent<TMP_Text>().text = new string('|', hp);
    }
}
