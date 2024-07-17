using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huechange : MonoBehaviour
{
    public Renderer r;
    public Color c;

    void Start()
    {
        r = GetComponent<Renderer>();
        c = r.material.GetColor("_Color");
    }

    void Update()
    {  
        float sinR = 0.1f * Mathf.Sin(Time.time);
        float sinG = 0.1f * Mathf.Sin(Time.time * 2f);
        float sinB = 0.1f * Mathf.Sin(Time.time * 3f);

        c.r += sinR;
        c.g += sinG;
        c.b += sinB;

        r.material.SetColor("_Color", c);
    }
}
