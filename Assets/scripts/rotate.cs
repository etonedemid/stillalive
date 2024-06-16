using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, Random.Range(0f, 180f), 90) * Time.deltaTime);
    }
}