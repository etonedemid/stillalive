using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bombtofather : MonoBehaviour
{
    public float speed = -200f;
    public bool hide = false;

    public GameObject leg;

    void Update()
    {
        transform.position = leg.transform.position;
        transform.rotation *= Quaternion.AngleAxis(speed * Time.deltaTime, -Vector3.forward);
    }

}
