using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbow : MonoBehaviour
{
    void Update()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Mathf.Sin(Time.time) * 0.5f + 0.5f, Mathf.Cos(Time.time) * 0.5f + 0.5f, Mathf.Sin(Time.time * 2) * 0.5f + 0.5f);
    }
}
