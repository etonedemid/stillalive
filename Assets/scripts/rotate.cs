using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float x;
    float y;
    float z;
    void Start()
    {
        x = Random.Range(0.5f, 0.7f);
        y = Random.Range(0.5f, 0.7f);
        z = Random.Range(0.5f, 0.7f);
    }
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime * 360f);
    }
}