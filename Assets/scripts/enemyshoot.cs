using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource au;
    void Start()
    {
    }

    public void Shoot()
    {
        if(gameObject.name == "firepointenemy")Instantiate(Resources.Load("enemybullet"), transform.position, Quaternion.identity);
        else Instantiate(Resources.Load("enemybulletboss"), transform.position, Quaternion.identity);
    }
}
