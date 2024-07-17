using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakingplatform : MonoBehaviour
{
    void Update()
    {
        transform.position += Random.insideUnitSphere * 0.01f;
    }
}
